using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Password_Recorder
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

    public class Account
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Account (string Name, string Username, string Password)
        {
            this.Name = Name;
            this.Username = Username;
            this.Password = Password;
        }
    }

    public class DataBase 
    {
        public string FilePath { get; set; }
        public string[] lines { get; set; }

        public DataBase (string FilePath)
        {
            this.FilePath = FilePath;
            this.lines = System.IO.File.ReadAllLines(this.FilePath);
            // if DB doesn't created, create the file
            if (!System.IO.File.Exists(this.FilePath))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(this.FilePath));
            }
        }

        public void LoadDB()
        {
            this.lines = System.IO.File.ReadAllLines(this.FilePath);
        }

        public List<Account> GetData()
        {
            var items = new List<Account>();

            foreach (string line in this.lines)
            {
                string trimedLine = line.Trim();
                string[] words = System.Text.RegularExpressions.Regex.Split(trimedLine, @"\s{1,}");
                if (words.Length == 3)
                {
                    items.Add(new Account(words[0], words[1], words[2]));
                }
            }
            return items;
        }
        public ArrayList GetWithoutData(int index)
        {
            ArrayList rst = new ArrayList();

            int count = 0;
            // only take lines wtihout target line
            foreach (string line in this.lines)
            {
                if (count != index)
                {
                    rst.Add(line);
                }
                count++;
            }
            return rst;
        }
        public string GetPassword(int index)
        {
            string password = "";

            int count = 0;
            foreach (string line in this.lines)
            {
                if (count == index)
                {
                    string trimedLine = line.Trim();
                    string[] words = System.Text.RegularExpressions.Regex.Split(trimedLine, @"\s{1,}");
                    if (words.Length == 3)
                    {
                        password = words[2];
                        break;
                    }
                }
                count++;
            }
            return password;
        }
    }
}
