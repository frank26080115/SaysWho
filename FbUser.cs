using System;
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
        public string ID { get; set; }
        public string FirstName { get; set; }
        public BitmapImage ProfilePicture { get; set; }
    }
}
