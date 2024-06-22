using DataSocial;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Linq;

namespace SocialBase
{
    /// <summary>
    /// Логика взаимодействия для ImagePage.xaml
    /// </summary>
    public partial class ImagePage : Page
    {
        private Post post;

        public ObservableCollection<DataSocial.BlobPost> BlobPosts  { get; set; }
        public ImagePage(Post post)
        {
            InitializeComponent();

            BlobPosts = new ObservableCollection<DataSocial.BlobPost>(post.BlobPosts.ToList());

            DataContext = this;
            this.post = post;
        }

        private void buttonback_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LentaNews());
        }

        private void imageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); 
            if(openFileDialog.ShowDialog() == true) 
            {
               
                byte[] imagebytes = File.ReadAllBytes(openFileDialog.FileName);
                BlobPost newBlobPost = new BlobPost {
                    blob = imagebytes,
                    imageIdPost = post.IDPost
                };
                BlobPosts.Add(newBlobPost);
                MainWindow.Connection.BlobPosts.Add(newBlobPost);
                MainWindow.Connection.SaveChanges();
            }
            
           
        }

       

        private void buttondelete_Click(object sender, RoutedEventArgs e)
        {
            if (ImageListView.SelectedItems.Count > 0)
            {
                var selectedImage = ImageListView.SelectedItems[0] as BlobPost;
                if (selectedImage != null)
                {
                    BlobPosts.Remove(selectedImage);
                    MainWindow.Connection.BlobPosts.Remove(selectedImage);
                    MainWindow.Connection.SaveChanges();



                }

            }
        }
    }
}
