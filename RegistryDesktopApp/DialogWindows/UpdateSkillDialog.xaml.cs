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
    /// Interaction logic for UpdateSkillDialog.xaml
    /// </summary>
    public partial class UpdateSkillDialog : Window
    {
        private Skill _skill;
        public UpdateSkillDialog(Skill skill)
        {
            InitializeComponent();
            _skill = skill;
            UpdateSkillTextBox.Text = _skill.CharacterSkill;
        }

        private void SaveUpdateSkillButton_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new();
            AnimalRegistryClient client = new(MainWindow.BASEURL, httpClient);

            UpdateSkillRequest request = new()
            {
                SkillId = _skill.SkillId,
                CharacterSkill = UpdateSkillTextBox.Text
            };
            client.UpdateSkillAsync(request).Wait();
            DialogResult = true;
        }
    }
}
