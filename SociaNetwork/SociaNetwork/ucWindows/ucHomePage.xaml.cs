using DAL.Enteties;
using DAL.Repository;
using DAL.Services;
using System;
using System.Collections.Generic;
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

namespace SociaNetwork.ucWindows
{
    /// <summary>
    /// Interaction logic for ucHomePage.xaml
    /// </summary>
    public partial class ucHomePage : UserControl
    {
        bool isAnyPosts = false;
        User user;
        bool tempLike = false;
        bool tempDislike = false;
        int indexOfPost = 0;
        Post currentPost;
        PostRepository postRepository;
        PostServices postServices;
        UserServices services;
        List<Post> posts;
        public ucHomePage()
        {
            InitializeComponent();
            services = new UserServices();
            postRepository = new PostRepository();
            postServices = new PostServices();
            //
            user = services.GetUser();
            //
            posts = new List<Post>();
            posts = postRepository.GetPosts(services.GetUserId());
            if (posts != null && posts.Count > 0)
            {
                foreach (Post p in posts)
                {
                    Grid upGrid = new Grid();

                    Label lblPostText = new Label();
                    lblPostText.Content = p.Text.ToString() + "\n";
                    lblPostText.Background = Brushes.White;
                    lblPostText.FontFamily = new FontFamily("Nirmala UI Semilight");
                    lblPostText.FontSize = 16;
                    lblPostText.FontWeight = FontWeights.Normal;
                    lblPostText.Padding = new Thickness(5, 10, 5, 10);

                    Button btnEdit = new Button();
                    //btnEdit.Content = MaterialDesignThemes.Wpf.PackIconKind.EditOff;
                    btnEdit.Content = "Edit";
                    btnEdit.Click += btn1_Click;
                    btnEdit.Width = 100;
                    btnEdit.Margin = new Thickness(400, 0, 0, 0);

                    Button btnDelete = new Button();
                    btnDelete.Content = "Delete";
                    btnDelete.Click += btn1_Click;
                    btnDelete.Width = 50;
                    btnDelete.Margin = new Thickness(400, 50, 0, 0);

                    upGrid.Children.Add(lblPostText);
                    upGrid.Children.Add(btnEdit);
                    upGrid.Children.Add(btnDelete);


                    Grid downGrid = new Grid();

                    Button btnComment = new Button();
                    btnComment.Content = "Сomment";
                    btnComment.Click += btn1_Click;
                    btnComment.Width = 100;
                 

                    Button btnLike = new Button();
                    btnLike.Content = "Like";
                    btnLike.Click += btn1_Click;
                    btnLike.Width = 100;
                    btnLike.Margin = new Thickness(0,0,200,0);

                    Button btnViewLikes = new Button();
                    btnViewLikes.Content = "Likes : " + postServices.GetLikes(p.Id).ToString();
                    btnViewLikes.Click += btn1_Click;
                    btnViewLikes.Width = 100;
                    btnViewLikes.Margin = new Thickness(0, 0, 400, 0);

                    Button btnDislike = new Button();
                    btnDislike.Content = "Dislike";
                    btnDislike.Click += btn1_Click;
                    btnDislike.Width = 100;
                    btnDislike.Margin = new Thickness(200, 0, 0, 0);

                    Button btnViewDislikes = new Button();
                    btnViewDislikes.Content = "Dislikes : " + postServices.GetDislikes(p.Id).ToString();
                    btnViewDislikes.Click += btn1_Click;
                    btnViewDislikes.Width = 100;
                    btnViewDislikes.Margin = new Thickness(400, 0, 0, 0);

                    downGrid.Children.Add(btnComment);
                    downGrid.Children.Add(btnLike);
                    downGrid.Children.Add(btnDislike);
                    downGrid.Children.Add(btnViewDislikes);
                    downGrid.Children.Add(btnViewLikes);

                    this.stackpanel.Children.Add(upGrid);
                    this.stackpanel.Children.Add(downGrid);

                    void btn1_Click(object sender, RoutedEventArgs e)
                    {

                    }

                }
            }
           
        }
       
    }
}
