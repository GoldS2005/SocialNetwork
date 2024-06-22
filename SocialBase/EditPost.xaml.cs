using DataSocial;
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
    /// Логика взаимодействия для EditPost.xaml
    /// </summary>
    public partial class EditPost : Page
    {
        public Post SelectedPost { get; set; }
        public EditPost(Post postToEdit)
        {
            InitializeComponent();

            SelectedPost = postToEdit;
            lentatextBox.Text = SelectedPost.ContentPost;

            DataContext = this;
        }

        private void editpostButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPost != null)
            {
                SelectedPost.ContentPost = lentatextBox.Text.Trim();
                SelectedPost.DatePublic = DateTime.Now; 
                MainWindow.Connection.SaveChanges();
                NavigationService.Navigate(new LentaNews());
            }

        }

        private void buttonback_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LentaNews());
        }

        private void buttonclear_Click(object sender, RoutedEventArgs e)
        {
            lentatextBox.Clear();
        }

        private void lentatextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(lentatextBox.Text))
            {
                editpostButton.IsEnabled = false;
            }
            else
            {
                editpostButton.IsEnabled = true;
            }



        }
    }
}
