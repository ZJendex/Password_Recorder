﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;


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
            UnicodeEncoding ByteConverter = new UnicodeEncoding();

            // if first two property is empty, return
            if (account.Name.Trim() == "")
            {
                MessageBox.Show("Please filled up the Account and Username :)");
                return;
            }
            if (account.Username.Trim() == "")
            {
                MessageBox.Show("Please filled up the Account and Username :)");
                return;
            }

            //// encode the password
            //byte[] plaintext = ByteConverter.GetBytes(account.Password);
            //byte[] encryptedtext = App.RSAr.Encryption(plaintext, App.RSAr.RSA.ExportParameters(false), false);
            //string pw = ByteConverter.GetString(encryptedtext);
            //// decode the password
            //byte[] decryptedtex = App.RSAr.Decryption(encryptedtext, App.RSAr.RSA.ExportParameters(true), false);
            //string password = ByteConverter.GetString(decryptedtex);

            string message = account.Name + " " + account.Username + " " + account.Password;
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(App.dbPath, true))
            {
                file.WriteLine(message);
            }
            MessageBox.Show("Saved successfuly!");

            savePage savePage = new savePage();
            this.NavigationService.Navigate(savePage);
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

        private void NameText_TextChanged(object sender, TextChangedEventArgs e)
        {
            nameText.Text = nameText.Text.Replace(" ", "");
        }

        private void UsernameText_TextChanged(object sender, TextChangedEventArgs e)
        {
            usernameText.Text = usernameText.Text.Replace(" ", "");
        }

        private void PasswordText_TextChanged(object sender, TextChangedEventArgs e)
        {
            passwordText.Text = passwordText.Text.Replace(" ", "");
        }
    }
}
