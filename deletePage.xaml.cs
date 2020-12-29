using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections;
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
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            // go to the saving page
            searchPage searchPage = new searchPage();
            this.NavigationService.Navigate(searchPage);
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

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // get the location
            int loc = GetSelectedRow(AccountsGrid).GetIndex();
            // get the database
            DataBase db = new DataBase(@"c:\Users\zhube\AppData\MyWindowsApp\password.txt");
            var rst = db.GetWithoutData(loc);
            // re-print the file
            System.IO.File.WriteAllLines(db.FilePath, (String[])rst.ToArray(typeof(string)));
            // refresh the database
            db.LoadDB();
            AccountsGrid.ItemsSource = db.GetData();

            string message = loc + " " + "Delete successfully!!";
            MessageBox.Show(message);
        }
    }
}
