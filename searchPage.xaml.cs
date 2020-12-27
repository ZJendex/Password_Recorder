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
            string pathName = @"c:\Users\zhube\AppData\MyWindowsApp";
            string fileName = "password.txt";
            string pathString = System.IO.Path.Combine(pathName, fileName);

            var items = new List<Account>();

            // if DB doesn't created, create the file
            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(pathString));
            }

            string[] lines = System.IO.File.ReadAllLines(@"c:\Users\zhube\AppData\MyWindowsApp\password.txt");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                string[] words = line.Trim().Split(' ');
                items.Add(new Account(words[0], words[1], words[2]));
            }

            // send data to dataGrid
            AccountsGrid.ItemsSource = items;
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            string message = "Copy successfully!!";
            MessageBox.Show(message);
        }
    }
}
