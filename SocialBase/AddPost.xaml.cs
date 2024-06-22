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
    /// Логика взаимодействия для AddPost.xaml
    /// </summary>
    public partial class AddPost : Page
    {
        

        public ObservableCollection<DataSocial.Post> Posts { get; set; }

        public AddPost()
        {
            InitializeComponent();
            

            Posts = new ObservableCollection<DataSocial.Post>(MainWindow.Connection.Posts.OrderByDescending(p => p.DatePublic).ToList());

            DataContext = this;
        }

        private void addpostButton_Click(object sender, RoutedEventArgs e)
        {

            string message = lentatextBox.Text.Trim();
            if (message.Length == 0)
                return;

            Post post = new Post()
            {
                ProfileId = MainWindow.User.IDProfile,
                ContentPost = message,
                DatePublic = DateTime.Now,

            };
    
            
            MainWindow.Connection.Posts.Add(post);
            MainWindow.Connection.SaveChanges(); 
            Posts.Add(post);

            NavigationService.Navigate(new LentaNews());

        }

       

        private void lentatextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(lentatextBox.Text))
            {
                addpostButton.IsEnabled = false;
            }
            else
            {
                addpostButton.IsEnabled = true;
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

       
        

       
    }
}
