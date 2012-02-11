using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

//using SaysWho.HelperClasses;

namespace SaysWho
{
    public partial class GamePlay : PhoneApplicationPage
    {
        //FBFriend fbf1;
        //FBFriend fbf2;
        
        string userData;
        static Random random;

        int whichIsCorrect = -1;

        int score = 0;

        public GamePlay()
        {
            InitializeComponent();
        }

        public void FullReset()
        {
            if (random == null) random = new Random();

            whichIsCorrect = -1;

            score = 0;

            txtScore.Text = "Score: 0";
            txtWallpost.Text = "Please wait while we load next wall post...";
            imgPersonPic1.Opacity = 0;
            imgPersonPic2.Opacity = 0;

            LoadNext();
        }

        private void btnPerson1_Click(object sender, RoutedEventArgs e)
        {
            if (whichIsCorrect < 0) return;

            if (whichIsCorrect == 0)
            {
                GuessIsCorrect();
            }
            else
            {
                GuessIsWrong();
            }

            txtWallpost.Text = "Please wait while we load next wall post...";
            imgPersonPic1.Opacity = 0;
            imgPersonPic2.Opacity = 0;

            whichIsCorrect = -1;

            LoadNext();
        }

        private void btnPerson2_Click(object sender, RoutedEventArgs e)
        {
            if (whichIsCorrect < 0) return;

            if (whichIsCorrect == 1)
            {
                GuessIsCorrect();
            }
            else
            {
                GuessIsWrong();
            }

            txtWallpost.Text = "Please wait while we load the next wall post...";
            imgPersonPic1.Opacity = 0;
            imgPersonPic2.Opacity = 0;

            whichIsCorrect = -1;

            LoadNext();
        }

        private void GuessIsWrong()
        {
            NavigationService.Navigate(new Uri("/GameOver.xaml?score=" + score.ToString(), UriKind.Relative));
        }

        private void GuessIsCorrect()
        {
            score++;
            txtScore.Text = "Score: " + score.ToString();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (this.NavigationContext.QueryString.ContainsKey("user"))
            {
                userData = this.NavigationContext.QueryString["user"];                
            }

            base.OnNavigatedTo(e);

            FullReset();
        }

        private void LoadNext()
        {
            /*try
            {
                //FBUser u = JsonStringSerializer.Deserialize<FBUser>(userData);

                WebClient wcf = new WebClient();
                wcf.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wcf_DownloadStringCompleted);

                //string at = App.AccessToken;
                //Uri uri = SaysWho.HelperClasses.FBUris.GetLoadFriendsUri(at);
                wcf.DownloadStringAsync(uri);
            }
            catch (Exception eX)
            {
                throw eX;
            }*/
        }

        void wcf_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            //try
            //{
            //    FBFriendsList fl = JsonStringSerializer.Deserialize<FBFriendsList>(e.Result);
            //    if (fl == null)
            //    {
            //        MessageBox.Show("Make some friends first!!");
            //    }
            //    else if (fl.Friends == null)
            //    {
            //        MessageBox.Show("Make some friends first");
            //    }
            //    else
            //    {

            //        int idx = random.Next() % fl.Friends.Count();
            //        fbf1 = fl.Friends[idx];
            //        idx = random.Next() % fl.Friends.Count();
            //        fbf2 = fl.Friends[idx];

            //        whichIsCorrect = random.Next() % 2;

            //        if (whichIsCorrect == 0)
            //        {
            //            imgPersonPic2.Source = new BitmapImage(new Uri(fbf1.PicLink));
            //        }
            //        else
            //        {
            //            imgPersonPic1.Source = new BitmapImage(new Uri(fbf1.PicLink));
            //        }

            //        WebClient m_wcLoadFeeds = new WebClient();
            //        m_wcLoadFeeds.DownloadStringCompleted += new DownloadStringCompletedEventHandler(m_wcLoadFeeds_DownloadStringCompleted);

            //        string at = App.AccessToken;
            //        Uri uri = SaysWho.HelperClasses.FBUris.GetWallUri(at, fbf2.ID);
            //        m_wcLoadFeeds.DownloadStringAsync(uri);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error getting friend list " + ex);
            //}
        }

        void m_wcLoadFeeds_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            //if (e.Error != null)
            //{
            //    MessageBox.Show("Error loading feeds: " + e.Error.Message);
            //    return;
            //}

            //try
            //{
            //    FBFeedList m_lFeeds = JsonStringSerializer.Deserialize<FBFeedList>(e.Result);
            //    int idx = random.Next() % m_lFeeds.Feeds.Count();
            //    FBFeed f = m_lFeeds.Feeds[idx];

            //    string wallpost = f.Message;

            //    if (wallpost == null || wallpost.Trim() == "")
            //    {
            //        LoadNext();
            //        return;
            //    }

            //    txtWallpost.Text = wallpost;

            //    if (whichIsCorrect == 0)
            //    {
            //        imgPersonPic1.Source = new BitmapImage(new Uri(f.From.PicLink));
            //    }
            //    else
            //    {
            //        imgPersonPic2.Source = new BitmapImage(new Uri(f.From.PicLink));
            //    }

            //    imgPersonPic1.Opacity = 1;
            //    imgPersonPic2.Opacity = 1;
            //}
            //catch (Exception eX)
            //{
            //    throw eX;
            //}
        } 
    } 
}