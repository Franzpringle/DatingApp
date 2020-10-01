using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp
{
    class MessageRepository
    {
        public static void CreateNewMessage()
        {
            Message.From = User.Username;
            Message.To = Profile.ProfileId;
            Message.Subject = Console.ReadLine();
            Message.Body = Console.ReadLine();
        }

        public static void SendMessage()
        {
            //send message ved at gem den i DB
        }

        public static void GetMessage()
        {
            //hent message fra DB
        }
    }
}
