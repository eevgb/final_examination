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
    /// Interaction logic for AddSkillDialog.xaml
    /// </summary>
    public partial class AddSkillDialog : Window
    {
        private int _kindOfAnimalId;
        public AddSkillDialog(int id)
        {
            _kindOfAnimalId = id;
            InitializeComponent();
        }

        private void SaveSkillButton_Click(object sender, RoutedEventArgs e)
        {
            AnimalRegistryClient client = new RegistryClient().GetClient();

            CreateSkillRequest request = new()
            {
                KindOfAnimalId = _kindOfAnimalId,
                CharacterSkill = SkillTextBox.Text
            };
            client.CreateSkillAsync(request).Wait();
            DialogResult = true;
        }
    }
}
