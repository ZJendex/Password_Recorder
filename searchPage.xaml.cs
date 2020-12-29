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
            DataBase db = new DataBase(@"c:\Users\zhube\AppData\MyWindowsApp\password.txt"); 
            // send data to dataGrid
            AccountsGrid.ItemsSource = db.GetData();
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
            DataBase db = new DataBase(@"c:\Users\zhube\AppData\MyWindowsApp\password.txt");
            // send data to dataGrid
            AccountsGrid.ItemsSource = db.GetData();
        }

        /**
         *--------------------------------------------------------------------
         *             enable to locate the click button on data grid
         */
        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

        public static DataGridRow GetSelectedRow(DataGrid grid)
        {
            return (DataGridRow)grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem);
        }
        /**
         *--------------------------------------------------------------------
         */

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            // get the location
            int loc = GetSelectedRow(AccountsGrid).GetIndex();

            DataBase db = new DataBase(@"c:\Users\zhube\AppData\MyWindowsApp\password.txt");
            var rst = db.GetPassword(loc);

            // copy password to clipboard
            Clipboard.SetText(rst);

            string message = "Copy successfully!!";
            MessageBox.Show(message);
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            // get the location
            int loc = GetSelectedRow(AccountsGrid).GetIndex();

            DataBase db = new DataBase(@"c:\Users\zhube\AppData\MyWindowsApp\password.txt");
            var rst = db.GetPassword(loc);

            string message = "The password is " + rst;
            MessageBox.Show(message);
        }
    }
}
