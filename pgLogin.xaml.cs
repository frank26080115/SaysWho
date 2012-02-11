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
    public partial class pgLogin : PhoneApplicationPage
    {
        public pgLogin()
        {
            InitializeComponent();

            progbarPleaseWait.IsIndeterminate = true;
        }

        private void brwFacebookLogin_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            // this occurs when the browser finishes loading a page

            bool success = false;

            try
            {
                progbarPleaseWait.Visibility = System.Windows.Visibility.Collapsed;

                if (e.Uri.AbsoluteUri.Contains("http://www.facebook.com/connect/login_success.html"))
                {
                    string urlQuery = HttpUtility.HtmlDecode(e.Uri.OriginalString.Substring(e.Uri.OriginalString.IndexOf("?") + 1));
                    Dictionary<string, string> query = Helpers.ParseQueryString(urlQuery);
                    foreach (KeyValuePair<string, string> kvp in query)
                    {
                        if (kvp.Key.ToLowerInvariant() == "code")
                        {
                            progbarPleaseWait.Visibility = System.Windows.Visibility.Visible;
                            WebClient wc = new WebClient();
                            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
                            wc.DownloadStringAsync(new Uri(string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri=http://www.facebook.com/connect/login_success.html&client_secret={1}&code={2}",
                                FacebookInfo.CLIENT_ID,
                                FacebookInfo.CLIENT_SECRET,
                                kvp.Value
                                )));
                            success = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BrowseToLoginPage();
            }
        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            bool success = false;
            try
            {
                if (e.Cancelled == true)
                {
                    throw new Exception("e.Cancelled = true after requesting access token");
                }
                else if (e.Error != null)
                {
                    throw e.Error;
                }
                else
                {
                    Dictionary<string, string> query = Helpers.ParseQueryString(e.Result);
                    foreach (KeyValuePair<string, string> kvp in query)
                    {
                        if (kvp.Key == "access_token")
                        {
                            success = true;

                            // do shit here because we are in
                            FacebookInfo.Client = new Facebook.FacebookClient(kvp.Value);

                            FacebookInfo.Client.GetCompleted += new EventHandler<Facebook.FacebookApiEventArgs>(Client_GetMe_Done);

                            //FacebookInfo.Client.BatchAsync(new Facebook.FacebookBatchParameter[] {
                            //    new Facebook.FacebookBatchParameter(Facebook.HttpMethod.Get, "/me"),
                            //    new Facebook.FacebookBatchParameter(Facebook.HttpMethod.Get, "/me/picture"),
                            //});
                            FacebookInfo.Client.GetAsync("/me");
                            break;
                        }
                    }
                }

                if (success == false)
                {
                    throw new Exception("Failed to retrieve access token");
                }
            }
            catch (Exception ex)
            {
                BrowseToLoginPage();
            }
        }

        void Client_GetMe_Done(object sender, Facebook.FacebookApiEventArgs e)
        {
            FacebookInfo.Client.GetCompleted -= new EventHandler<Facebook.FacebookApiEventArgs>(Client_GetMe_Done);
            string s = e.GetResultData().ToString();
            FbUser me = new FbUser(s);
            me.LoadPicture();
        }

        private void brwFacebookLogin_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            BrowseToLoginPage();
        }

        private void BrowseToLoginPage()
        {
            FacebookInfo.Client = null;

            brwFacebookLogin.Visibility = Visibility.Visible;
            progbarPleaseWait.Visibility = System.Windows.Visibility.Collapsed;

            brwFacebookLogin.Navigate(new Uri(string.Format(
                "https://www.facebook.com/dialog/oauth?client_id={0}&redirect_uri=http://www.facebook.com/connect/login_success.html&client_secret={1}&display=touch",
                FacebookInfo.CLIENT_ID,
                FacebookInfo.CLIENT_SECRET
                )));
        }

        private void brwFacebookLogin_Navigating(object sender, NavigatingEventArgs e)
        {
            progbarPleaseWait.Visibility = System.Windows.Visibility.Visible;
        }
    }
}