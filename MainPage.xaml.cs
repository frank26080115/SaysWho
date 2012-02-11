using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace SaysWho
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.Portrait | SupportedPageOrientation.Landscape;

        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void bLogin_Click(object sender, RoutedEventArgs e)
        {
            // do login stuff for fb
            NavigationService.Navigate(new Uri("/pgLogin.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            /*bool bWeAreLoggedIn = !string.IsNullOrEmpty(App.AccessToken);
            bLogin.IsEnabled = !bWeAreLoggedIn; //reverse logic
            bPlay.IsEnabled = bWeAreLoggedIn; */
            tMsg.Text = false? "Time to play!" : "In order to begin, first log into facebook";
        }

        private void bPlay_Click(object sender, RoutedEventArgs e)
        {
            //string strUri = string.Format("/GamePlay.xaml?id={0}&name={1}&piclink={2}",
            //        .User.ID, App.CurUserHolder.User.Name, App.CurUserHolder.User.PictureLink);
            if (true) // if logged in
            {
                NavigationService.Navigate(new Uri("/Gameplay.xaml", UriKind.Relative));
            }
        }
    }
}