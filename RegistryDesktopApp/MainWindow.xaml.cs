using RegistryDesktopApp.DialogWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegistryDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PrepareTables();
        }

        /*
         * Начальная настройка списков
         */
        private void PrepareTables() 
        {
            AnimalRegistryClient client = new RegistryClient().GetClient();
            ICollection <Animal> animals = client.GetAllAnimalsAsync().Result;
            ICollection<KindOfAnimal> kinds = client.GetAllKindsOfAnimalAsync().Result;
            ICollection<Skill> skills = client.GetAllSkillsAsync().Result;

            AnimalListView.ItemsSource = animals;
            if (animals.Count > 0)
            {
                AnimalListView.SelectedIndex = 0;
                ShowAnimalFullData(animals.ElementAt(0).AnimalId);
            }
            KindListView.ItemsSource = kinds;
            if (kinds.Count > 0)
            {
                KindListView.SelectedIndex = 0;
                KindOfAnimal kind = (KindOfAnimal)KindListView.SelectedItem;
                skills = client.GetAllSkillsByAnimalKindIdAsync(kind.KindOfAnimalId).Result;
            }
            SkillListView.ItemsSource = skills;
            if (skills.Count > 0) 
            {
                SkillListView.SelectedIndex = 0;
            }
        }

        private void ShowAnimalFullData(int id) 
        {
            AnimalRegistryClient client = new RegistryClient().GetClient();
            Animal animal = client.GetAnimalByIdAsync(id).Result;
            AnimalNameLabel.Content = animal.Name;
            KindOfAnimal kind = client.GetKindOfAnimalByIdAsync(animal.KindOfAnimalId).Result;
            AnimalKindLabel.Content = kind.Kind;
            AnimalBirthLabel.Text = animal.Birthday.ToString();
            ICollection<AnimalSkill> animalSkills = client.GetAllAnimalSkillsByAnimalIdAsync(animal.AnimalId).Result;
            List<string> skills = new List<string>();
            foreach(var skill in animalSkills)
            {
                Skill s = client.GetSkillByIdAsync(skill.SkilId).Result;
                skills.Add(s.CharacterSkill);
            }
            AnimalSkillListBox.ItemsSource = skills;
            AnimalDescriptionLabel.Text = animal.Description;
        }

        /*
         * Методы работы со списком животных
         */

        private void AddAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            AddAnimalDialog dialog = new()
            {
                Owner = this
            };
            if (dialog.ShowDialog() == true)
            {
                RefreshAnimalList();
            }
        }

        private void UpdateAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = (Animal)AnimalListView.SelectedItem;
            UpdateAnimalDialog dialog = new(animal)
            {
                Owner = this
            };
            if (dialog.ShowDialog() == true)
            {
                RefreshAnimalList();
            }
        }

        private void DeleteAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Хотите удалить запись?",
                "Удалить запись",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                Animal animal = (Animal)AnimalListView.SelectedItem;
                if (animal != null)
                {
                    AnimalRegistryClient client = new RegistryClient().GetClient();
                    client.DeleteAnimalAsync(animal.AnimalId).Wait();
                    RefreshAnimalList();
                }
            }
        }

        private void RefreshAnimalList()
        {
            AnimalRegistryClient client = new RegistryClient().GetClient();
            ICollection<Animal> animals = client.GetAllAnimalsAsync().Result;
            AnimalListView.ItemsSource = animals;
            AnimalListView.SelectedIndex = 0;
        }

        private void AnimalListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Animal animal = (Animal)AnimalListView.SelectedItem;
            if (animal != null)
            {
                ShowAnimalFullData(animal.AnimalId);
            }
        }

        /*
         * Методы работы со списком видов животных
         */
        private void AddKindButton_Click(object sender, RoutedEventArgs e)
        {
            AddKindOfAnimalDialog dialog = new ()
            {
                Owner = this
            };
            if (dialog.ShowDialog() == true)
            {
                RefreshKindList();
            }
        }

        private void UpdateKindButton_Click(object sender, RoutedEventArgs e)
        {
            KindOfAnimal kindOfAnimal = (KindOfAnimal)KindListView.SelectedItem;
            UpdateKindOfAnimalDialog dialog = new(kindOfAnimal)
            {
                Owner = this
            };
            if (dialog.ShowDialog() == true)
            {
                RefreshKindList();
            }
        }

        private void DeleteKindButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Хотите удалить запись?",
                "Удалить запись",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                KindOfAnimal kind = (KindOfAnimal)KindListView.SelectedItem;
                if (kind != null)
                {
                    AnimalRegistryClient client = new RegistryClient().GetClient();
                    client.DeleteKindOfAnimalAsync(kind.KindOfAnimalId).Wait();
                    RefreshKindList();
                    RefreshSkillList(0);
                }
            }
        }

        private void RefreshKindList()
        {
            AnimalRegistryClient client = new RegistryClient().GetClient();
            ICollection<KindOfAnimal> kinds = client.GetAllKindsOfAnimalAsync().Result;
            KindListView.ItemsSource = kinds;
            KindListView.SelectedIndex = 0;
        }

        private void KindListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AnimalRegistryClient client = new RegistryClient().GetClient();
            KindOfAnimal kind = (KindOfAnimal)KindListView.SelectedItem;
            if (kind != null)
            {
                ICollection<Skill> skills = client.GetAllSkillsByAnimalKindIdAsync(kind.KindOfAnimalId).Result;
                SkillListView.ItemsSource = skills;
            }
        }

        /*
         * Методы работы со списком навыков
         */
        private void AddSkillButton_Click(object sender, RoutedEventArgs e)
        {
            if (KindListView.SelectedItem != null)
            {
                KindOfAnimal kind = (KindOfAnimal)KindListView.SelectedItem;
                AddSkillDialog dialog = new(kind.KindOfAnimalId)
                {
                    Owner = this
                };
                if (dialog.ShowDialog() == true)
                {
                    RefreshSkillList(kind.KindOfAnimalId);
                }
            }
        }

        private void UpdateSkillButton_Click(object sender, RoutedEventArgs e)
        {
            Skill skill = (Skill)SkillListView.SelectedItem;
            UpdateSkillDialog dialog = new(skill)
            {
                Owner = this
            };
            if (dialog.ShowDialog() == true)
            {
                RefreshSkillList(skill.KindOfAnimalId);
            }
        }

        private void DeleteSkillButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Хотите удалить запись?", 
                "Удалить запись", 
                MessageBoxButton.OKCancel, 
                MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                Skill skill = (Skill)SkillListView.SelectedItem;
                if (skill != null)
                {
                    AnimalRegistryClient client = new RegistryClient().GetClient();
                    client.DeleteSkillAsync(skill.SkillId).Wait();
                    RefreshSkillList(skill.KindOfAnimalId);
                }
            }
        }

        private void RefreshSkillList(int kindOfAnimalId)
        {
            AnimalRegistryClient client = new RegistryClient().GetClient();
            ICollection<Skill> skills = client.GetAllSkillsByAnimalKindIdAsync(kindOfAnimalId).Result;
            SkillListView.ItemsSource = skills;
            SkillListView.SelectedIndex = 0;
        }

        private void AddAnimalSkillButton_Click(object sender, RoutedEventArgs e)
        {
            if (KindListView.SelectedItem != null)
            {
                Animal animal = (Animal)AnimalListView.SelectedItem;
                AddAnimalSkillDialog dialog = new(animal)
                {
                    Owner = this
                };
                if (dialog.ShowDialog() == true)
                {
                    ShowAnimalFullData(animal.AnimalId);
                }
            }
        }
    }
}
