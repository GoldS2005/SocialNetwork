using DataSocial;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Логика взаимодействия для LentaNews.xaml
    /// </summary>
    

    public class SortItem
    {
        public string Text { get; set; }
        public SortDescription Description { get; set; }
    }
    public partial class LentaNews : Page
    {

        public ObservableCollection<DataSocial.Post> Posts { get; set; }

        public ObservableCollection<SortItem> SortItems { get; set; }
        

        public SortItem SelectedSortItem { get; set; }

        public LentaNews()
        {
            InitializeComponent();
           

            Posts = new ObservableCollection<DataSocial.Post>(MainWindow.Connection.Posts.OrderByDescending(p => p.DatePublic).ToList());

           SortItems = new ObservableCollection<SortItem>()
           {
                new SortItem() { Text = "Сначала самые последние", Description = new SortDescription("DatePublic", ListSortDirection.Descending) },
                new SortItem() { Text = "Сначала самые популярные", Description = new SortDescription("LikePost", ListSortDirection.Descending) },
           };


            DataContext =  this;
        }

        private void postButton_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new AddPost());

        }

        

        private void buttonback_Click(object sender, RoutedEventArgs e)
        {



            NavigationService.Navigate(new Authorization());


        }

        

        private void buttondelete_Click(object sender, RoutedEventArgs e)
        {
           
            if (PostListView.SelectedItems.Count > 0)
            {
               var selectedPost = PostListView.SelectedItems[0] as Post;

               if (selectedPost != null && selectedPost.ProfileId == MainWindow.User.IDProfile)
               {
                  Posts.Remove(selectedPost);
                  MainWindow.Connection.Posts.Remove(selectedPost);
                  MainWindow.Connection.SaveChanges();

               }

            }
               
   
        }

        private void buttonredac_Click(object sender, RoutedEventArgs e)
        {
            if (PostListView.SelectedItem != null)
            {
                var selectedPost = PostListView.SelectedItem as Post;
                if (selectedPost != null && selectedPost.ProfileId == MainWindow.User.IDProfile)
                {
                    NavigationService.Navigate(new EditPost(selectedPost));
                }
                
            }

        }

        private void commentButton_Click(object sender, RoutedEventArgs e)
        {
            if (PostListView.SelectedItem== null) 
                return;
            NavigationService.Navigate(new CommentPage(PostListView.SelectedItem as Post)); 
        }

        private void likeButton_Click(object sender, RoutedEventArgs e)
        {
            if (PostListView.SelectedItem != null)
            {
                var selectedPost = PostListView.SelectedItem as Post;
                var likeEntry = MainWindow.Connection.Likes.FirstOrDefault(l => l.PostId == selectedPost.IDPost && l.UserId == MainWindow.User.IDProfile);
                var dislikeEntry = MainWindow.Connection.Dislikes.FirstOrDefault(d => d.PostId == selectedPost.IDPost && d.UserId == MainWindow.User.IDProfile);

                if (dislikeEntry != null)
                {
                    MainWindow.Connection.Dislikes.Remove(dislikeEntry);
                    selectedPost.DisLikePost--;
                }
                if (likeEntry == null)
                {
                    
                    MainWindow.Connection.Likes.Add(new Like { PostId = selectedPost.IDPost, UserId = MainWindow.User.IDProfile });
                    selectedPost.LikePost++; 
                }
                MainWindow.Connection.SaveChanges();
                NavigationService.Navigate(new LentaNews());
            }
        }

        private void dislikeButton_Click(object sender, RoutedEventArgs e)
        {
            if (PostListView.SelectedItem != null)
            {
                var selectedPost = PostListView.SelectedItem as Post;
                var dislikeEntry = MainWindow.Connection.Dislikes.FirstOrDefault(d => d.PostId == selectedPost.IDPost && d.UserId == MainWindow.User.IDProfile);
                var likeEntry = MainWindow.Connection.Likes.FirstOrDefault(l => l.PostId == selectedPost.IDPost && l.UserId == MainWindow.User.IDProfile);

                if (likeEntry != null)
                {
                    MainWindow.Connection.Likes.Remove(likeEntry);
                    selectedPost.LikePost--;
                }
                if (dislikeEntry == null)
                {
                    
                    MainWindow.Connection.Dislikes.Add(new Dislike { PostId = selectedPost.IDPost, UserId = MainWindow.User.IDProfile });
                    selectedPost.DisLikePost++;
                }    
                MainWindow.Connection.SaveChanges();
                NavigationService.Navigate(new LentaNews());

                
            }

        }

        private void imagesButton_Click(object sender, RoutedEventArgs e)
        {


            if (PostListView.SelectedItems.Count > 0)
            {
                var selectedPost = PostListView.SelectedItems[0] as Post;
                if (selectedPost != null && selectedPost.ProfileId == MainWindow.User.IDProfile)
                {


                   NavigationService.Navigate(new ImagePage(PostListView.SelectedItem as Post));



                }

            }

        }

        private void Sort()
        {
            var view = CollectionViewSource.GetDefaultView(PostListView.ItemsSource);
            if (view != null)
            {
                view.SortDescriptions.Clear();
                if (SelectedSortItem != null)
                {
                    view.SortDescriptions.Add(SelectedSortItem.Description);
                    view.Refresh(); 
                }
            }
        }

        private void Search()
        {
            var searchString = tbSearch.Text.Trim().ToLower();


            var view = CollectionViewSource.GetDefaultView(PostListView.ItemsSource);
            if (view == null) return;

            view.Filter = (object o) =>
            {
                var messageoruser = o as Post;
                if (messageoruser == null) return false;



                if (searchString.Length > 0)
                {
                    if (!(messageoruser.ContentPost.ToLower().Contains(searchString) ||
                        messageoruser.Account.LastName.ToLower().Contains(searchString) ||
                        messageoruser.Account.FirstName.ToLower().Contains(searchString)))
                     
                    {
                        return false;
                    }


                }

                

                return true;
            };
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sort();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }
    }
}
