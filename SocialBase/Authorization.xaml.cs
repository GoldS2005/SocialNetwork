using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        
        public Authorization()
        {
            InitializeComponent();

            
        }

        private void createprofileButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Regiztration());


        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string login = logintextBox.Text.Trim();
            string password = passwordBox.Password.Trim();

            if (login.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("Введите данные");
                return;
            }

            MainWindow.User = MainWindow.Connection.Accounts.Where(acc => acc.NumberPhone == login && acc.PasswordName == password).FirstOrDefault();
            if (MainWindow.User == null)
            {
                MessageBox.Show("Неправильные данные");
                return;
            }
            NavigationService.Navigate(new LentaNews());



            


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(logintextBox.Text))
            {
                addButton.IsEnabled = false;
            }
            else
            {
                addButton.IsEnabled = true;
            }

            

        }

        private void buttonbackpanel_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);


        }
    }
}
