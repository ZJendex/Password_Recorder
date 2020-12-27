using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.IO;

namespace Password_Recorder
{
    /// <summary>
    /// Interaction logic for searchPage.xaml
    /// </summary>
    public partial class searchPage : Page
    {
        public searchPage()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // go to the saving page
            savePage savePage = new savePage();
            this.NavigationService.Navigate(savePage);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // go to the delete page
            deletePage deletePage = new deletePage();
            this.NavigationService.Navigate(deletePage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var items = new List<Account>();
            items.Add(new Account("Google", "ketty.gmail.com", "123ausu!!"));
            items.Add(new Account("Tencent", "ketty.gmail.com", "668**!"));
            items.Add(new Account("J&C", "ketty.gmail.com", "ppanjk2"));

            AccountsGrid.ItemsSource = items;
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            string message = "Copy successfully!!";
            MessageBox.Show(message);
        }
    }
}
