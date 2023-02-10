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
    /// Interaction logic for UpdateKindOfAnimalDialog.xaml
    /// </summary>
    public partial class UpdateKindOfAnimalDialog : Window
    {
        private readonly KindOfAnimal _kind;
        public UpdateKindOfAnimalDialog(KindOfAnimal kind)
        {
            InitializeComponent();
            _kind = kind;
            UpdateKindTextBox.Text = _kind.Kind;
        }

        private void SaveUpdateKindButton_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new();
            AnimalRegistryClient client = new(MainWindow.BASEURL, httpClient);

            UpdateKindOfAnimalRequest request = new()
            {
                KindOfAnimalId = _kind.KindOfAnimalId,
                Kind = UpdateKindTextBox.Text
            };
            client.UpdateKindOfAnimalAsync(request).Wait();
            DialogResult = true;
        }
    }
}
