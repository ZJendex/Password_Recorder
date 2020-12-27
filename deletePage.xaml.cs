using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Password_Recorder
{
    /// <summary>
    /// Interaction logic for deletePage.xaml
    /// </summary>
    public partial class deletePage : Page
    {
        public deletePage()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // go to the saving page
            savePage savePage = new savePage();
            this.NavigationService.Navigate(savePage);
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            // go to the saving page
            searchPage searchPage = new searchPage();
            this.NavigationService.Navigate(searchPage);
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
                using (System.IO.FileStream fs = System.IO.File.Create(pathString)) ;
            }

            string[] lines = System.IO.File.ReadAllLines(@"c:\Users\zhube\AppData\MyWindowsApp\password.txt");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                string trimedLine = line.Trim();
                string[] words = System.Text.RegularExpressions.Regex.Split(trimedLine, @"\s{1,}");
                if (words.Length == 3)
                {
                    items.Add(new Account(words[0], words[1], words[2]));
                }
            }

            // send data to dataGrid
            AccountsGrid.ItemsSource = items;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            string message = "Delete successfully!!";
            MessageBox.Show(message);
        }
    }
}
