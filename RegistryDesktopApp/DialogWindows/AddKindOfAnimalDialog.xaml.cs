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
    /// Interaction logic for AddKindOfAnimalDialog.xaml
    /// </summary>
    public partial class AddKindOfAnimalDialog : Window
    {
        public AddKindOfAnimalDialog()
        {
            InitializeComponent();
        }

        private void SaveKindButton_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new();
            AnimalRegistryClient client = new(MainWindow.BASEURL, httpClient);
            CreateKindOfAnimalRequest request = new()
            { 
                Kind = KindTextBox.Text
            };
            client.CreateKindOfAnimalAsync(request).Wait();
            DialogResult = true;
        }
    }
}
