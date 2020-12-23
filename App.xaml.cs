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

        private string nameValue;

        public string Name
        {
            get { return nameValue; }
            set { nameValue = value; }
        }

        private string usernameValue;

        public string Username
        {
            get { return usernameValue; }
            set { usernameValue = value; }
        }

        private string passwordValue;

        public string Password
        {
            get { return passwordValue; }
            set { passwordValue = value; }
        }

    }

}
