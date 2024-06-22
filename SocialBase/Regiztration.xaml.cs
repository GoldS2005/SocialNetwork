using DataSocial;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
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

namespace SocialBase
{
    /// <summary>
    /// Логика взаимодействия для Regiztration.xaml
    /// </summary>
    public partial class Regiztration : Page
    {
       

        
        public Regiztration()
        {
            InitializeComponent();



            DataContext = new Account();
            
            
                
            
        }

        private void profileButton_Click(object sender, RoutedEventArgs e)
        {
           
            

            MainWindow.Connection.Accounts.Add(DataContext as Account);
            MainWindow.Connection.SaveChanges();
        
            NavigationService.Navigate(new Authorization());



        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Authorization());

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(lastnametextBox.Text))
            {
                profileButton.IsEnabled = false;
            }
            else
            {
                profileButton.IsEnabled = true;
            }

            if (string.IsNullOrEmpty(firstnametextBox.Text))
            {
                profileButton.IsEnabled = false;
            }
            else
            {
                profileButton.IsEnabled = true;
            }

            if (string.IsNullOrEmpty(numbertextBox.Text))
            {
                profileButton.IsEnabled = false;
            }
            else
            {
                profileButton.IsEnabled = true;
            }

            if (string.IsNullOrEmpty(passwordtextBox.Text))
            {
                profileButton.IsEnabled = false;
            }
            else
            {
                profileButton.IsEnabled = true;
            }


        }

       
    }
}
