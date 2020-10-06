using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DatingApp
{
    class Message
    {
        public string Body { get; set; }
        public DateTime TS { get; set; }
        public static string From { get; set; }
        public static int To { get; set; }


    }
}
