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
    public partial class GameOver : PhoneApplicationPage
    {
        int score;

        public GameOver()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (this.NavigationContext.QueryString.ContainsKey("score"))
            {
                score = int.Parse(this.NavigationContext.QueryString["score"]);

                txtMessage.Text = "You're wrong! Your final score is " + score.ToString();
            }

            base.OnNavigatedTo(e);
        }

        private void btnUploadScore_Click(object sender, RoutedEventArgs e)
        {
            MakeWallPost(score);
        }

        private void MakeWallPost(int score)
        {
            MessageBox.Show("Feature not done yet, we need more time");
            //throw new NotImplementedException();
        }

        private void btnPlayAgain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}