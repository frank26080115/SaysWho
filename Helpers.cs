using System;
using System.Collections;
using System.Collections.Generic;
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
    public class Helpers
    {
        /// <summary>
        /// Parses a query string into a dictionary collection
        /// </summary>
        /// <param name="queryString">the query string to parse</param>
        /// <returns>a dictionary collection of querystring items</returns>
        public static Dictionary<string, string> ParseQueryString(string queryString)
        {
            Dictionary<string, string> nameValueCollection = new Dictionary<string, string>();
            string[] items = queryString.Split('&');

            foreach (string item in items)
            {
                if (item.Contains("="))
                {
                    string[] nameValue = item.Split('=');
                    if (nameValue[0].Contains("?"))
                        nameValue[0] = nameValue[0].Replace("?", "");
                    nameValueCollection.Add(nameValue[0], System.Net.HttpUtility.UrlDecode(nameValue[1]));
                }
            }

            return nameValueCollection;
        }

        private static Random random;
        public static Random Rng
        {
            get
            {
                if (random == null)
                    random = new Random();

                return random;
            }
        }
    }
}
