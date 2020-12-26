using System;
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



}
