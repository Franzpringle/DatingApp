using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp
{
    class MessageInboxPage
    {
        public static void Run(Profile currentProfile, Profile potentialMatch)
        {

            Message message = MessageRepository.AnyNewMessages();
            GUI.DisplayMessagethreads();

            string menuChoice = Console.ReadLine().ToLower();
            if (menuChoice == "1")
            {

            }
            if (menuChoice == "2")
            {

            }
            if (menuChoice == "3")
            {

            }
            if (menuChoice == "4")
            {

            }
            if (menuChoice == "5")
            {

            }

        }
    }
}
