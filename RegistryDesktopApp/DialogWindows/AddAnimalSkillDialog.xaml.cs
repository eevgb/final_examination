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
using System.Windows.Shapes;

namespace RegistryDesktopApp.DialogWindows
{
    /// <summary>
    /// Interaction logic for AddAnimalSkillDialog.xaml
    /// </summary>
    public partial class AddAnimalSkillDialog : Window
    {
        private Animal _animal;
        public AddAnimalSkillDialog(Animal animal)
        {
            _animal = animal;
            InitializeComponent();
            PrepareDialog();
        }

        private void PrepareDialog()
        {
            HttpClient httpClient = new();
            AnimalRegistryClient client = new(MainWindow.BASEURL, httpClient);
            ICollection<Skill> skills = client.GetAllSkillsByAnimalKindIdAsync(_animal.KindOfAnimalId).Result;
            AnimalSkillComboBox.ItemsSource = skills;
        }

        private void SaveAnimalSkillButton_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new();
            AnimalRegistryClient client = new(MainWindow.BASEURL, httpClient);
            Skill skill = (Skill)AnimalSkillComboBox.SelectedItem;
            CreateAnimalSkillRequest request = new()
            {
                AnimalId = _animal.AnimalId,
                SkilId = skill.SkillId
            };
            client.CreateAnimalSkillAsync(request).Wait();
            DialogResult = true;
        }
    }
}
