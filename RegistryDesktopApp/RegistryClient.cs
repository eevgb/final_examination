using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RegistryDesktopApp
{
    class RegistryClient
    {
        private readonly string BASEURL = "http://bcomms.ru:5000";
        private AnimalRegistryClient? client;

        public AnimalRegistryClient GetClient()
        {
            try 
            {
                HttpClient httpClient = new();
                client = new(BASEURL, httpClient);
            }
            catch (Exception e)
            { 
                MessageBox.Show(e.Message, "Client error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            return client;
        }
    }
}
