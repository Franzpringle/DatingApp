using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp
{
    class MatchesPage
    {
        public static void Run(Profile currentProfile, User currentUser, Profile potentialMatch)
        {

            while (true)
            {

                GUI.DisplayMatchMenu(); 
                string menuChoice = Console.ReadLine().ToLower();

                if (menuChoice == "1") MessageInboxPage.Run(currentProfile, potentialMatch);
                if (menuChoice == "2") DatingPage.Run(currentProfile, currentUser);

            }
        }
    }
}
