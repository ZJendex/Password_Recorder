using System;
using System.Collections.Generic;
using System.Linq;
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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace Password_Recorder
{
    /// <summary>
    /// Interaction logic for savePage.xaml
    /// </summary>
    public partial class savePage : Page
    {

        Account account = new Account (" ", " ", " ");
        public savePage()
        {
            InitializeComponent();
            this.DataContext = account;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string message = account.Name + " " + account.Username + " " + account.Password + " saved successfully!!";
            MessageBox.Show(message);
        }

        private void Seach_Click(object sender, RoutedEventArgs e)
        {
            // go to the searching page
            searchPage searchPage = new searchPage();
            this.NavigationService.Navigate(searchPage);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // go to the delete page
            deletePage deletePage = new deletePage();
            this.NavigationService.Navigate(deletePage);
        }
    }
}
