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
    /// Interaction logic for UpdateAnimalDialog.xaml
    /// </summary>
    public partial class UpdateAnimalDialog : Window
    {
        private readonly Animal _animal;
        public UpdateAnimalDialog(Animal animal)
        {
            InitializeComponent();
            _animal = animal;
            AnimalRegistryClient client = new RegistryClient().GetClient();
            KindOfAnimal kind = client.GetKindOfAnimalByIdAsync(animal.KindOfAnimalId).Result;
            UpdateKindOfAnimalLabel.Content = kind.Kind;
            UpdateAnimalNameTextBox.Text = animal.Name;
            UpdateBirthdayPicker.SelectedDate = animal.Birthday.DateTime;
            UpdateDescriptionTextBox.Text = animal.Description;
        }

        private void SaveUpdateAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            AnimalRegistryClient client = new RegistryClient().GetClient();
            UpdateAnimalRequest request = new()
            {
                AnimalId = _animal.AnimalId,
                Name = UpdateAnimalNameTextBox.Text,
                Birthday = (DateTimeOffset)UpdateBirthdayPicker.SelectedDate,
                Description = UpdateDescriptionTextBox.Text
            };
            client.UpdateAnimalAsync(request).Wait();
            DialogResult = true;
        }
    }
}
