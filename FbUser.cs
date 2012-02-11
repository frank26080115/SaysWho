using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace SaysWho
{
    public class FbUser
    {
        public string ID
        {
            get
            {
                return (string)jo["id"];
            }
        }

        public string FirstName
        {
            get
            {
                return (string)jo["first_name"];
            }
        }

        public string PicUrl
        {
            get
            {
                return string.Format(
                    "http://graph.facebook.com/{0}/picture",
                    this.ID
                );
            }
        }

        public BitmapImage ProfilePicture
        {
            get;
            private set;
        }

        private Facebook.JsonObject jo;

        public FbUser(string json)
        {
            this.jo = (Facebook.JsonObject)FacebookInfo.Client.DeserializeJson(json, typeof(Facebook.JsonObject));
        }

        public void LoadPicture()
        {
            LowProfileImageLoader
            ProfilePicture = new BitmapImage(new Uri(this.PicUrl));
        }
    }
}
