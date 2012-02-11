using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SaysWho
{
    public class FacebookInfo
    {
        public const string CLIENT_ID = "259515254122270";
        public const string CLIENT_SECRET = "4f018cd58f72f1cc30f2e732861fe9fc";

        public static Facebook.FacebookClient Client { get; set; }

        public static FbUser Me { get; set; }
    }
}
