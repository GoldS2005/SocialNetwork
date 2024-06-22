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
    /// Логика взаимодействия для CommentPage.xaml
    /// </summary>
    public partial class CommentPage : Page
    {
        private Post post;
        
        public ObservableCollection<DataSocial.Comment> Comments { get; set; }
        public CommentPage(Post post)
        {
            InitializeComponent();

            Comments = new ObservableCollection<DataSocial.Comment>(post.Comments.ToList());
            

            DataContext = this;
            this.post = post;

            
        }

        

        private void commentButton_Click(object sender, RoutedEventArgs e)
        {
            string comment = commenttextBox.Text.Trim();
            if (comment.Length == 0)
                return;

            Comment com = new Comment()
            {
                IDCreatedComment = MainWindow.User.IDProfile,
                IDPosts = post.IDPost,
                ContentComment= comment,
                DatePublicate = DateTime.Now,
                
                
                
            };

            MainWindow.Connection.Comments.Add(com);
            MainWindow.Connection.SaveChanges();
            Comments.Add(com);
            commenttextBox.Clear();
        }

        private void buttonback_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LentaNews());
        }

        private void buttondelete_Click(object sender, RoutedEventArgs e)
        {
           

            if (CommentListView.SelectedItems.Count > 0)
            {
                var selectedComment = CommentListView.SelectedItems[0] as Comment;
                if (selectedComment != null && selectedComment.IDCreatedComment == MainWindow.User.IDProfile)
                {
                    Comments.Remove(selectedComment);
                    MainWindow.Connection.Comments.Remove(selectedComment);
                    MainWindow.Connection.SaveChanges();



                }

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(commenttextBox.Text))
            {
                commentButton.IsEnabled = false;
            }
            else
            {
                commentButton.IsEnabled = true;
            }


        }
    }
}
