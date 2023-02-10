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
    /// Interaction logic for AddAnimalDialog.xaml
    /// </summary>
    public partial class AddAnimalDialog : Window
    {
        public AddAnimalDialog()
        {
            InitializeComponent();
            PrepareDialog();
        }

        private void PrepareDialog()
        {
            HttpClient httpClient = new();
            AnimalRegistryClient client = new(MainWindow.BASEURL, httpClient);
            KindOfAnimalComboBox.ItemsSource = client.GetAllKindsOfAnimalAsync().Result;
        }

        private void KindOfAnimalComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SaveAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (KindOfAnimalComboBox.SelectedIndex != -1 && BirthdayPicker.SelectedDate != null)
            {
                HttpClient httpClient = new();
                AnimalRegistryClient client = new(MainWindow.BASEURL, httpClient);
                KindOfAnimal kind = (KindOfAnimal)KindOfAnimalComboBox.SelectedItem;
                CreateAnimalRequest request = new()
                {
                    KindOfAnimalId = kind.KindOfAnimalId,
                    Name = AnimalNameTextBox.Text,
                    Birthday = (DateTimeOffset)BirthdayPicker.SelectedDate,
                    Description = DescriptionTextBox.Text
                };
                client.CreateAnimalAsync(request).Wait();
                DialogResult = true;
            }
        }
    }
}
