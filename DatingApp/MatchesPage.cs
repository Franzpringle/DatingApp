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
                GUI.DisplayMatchMenu(currentProfile, potentialMatch); 
                string menuChoice = Console.ReadLine().ToLower();

                if (menuChoice == "1") MessageInboxPage.Run(currentProfile);
                if (menuChoice == "2") DatingPage.Run(currentProfile, currentUser);

            }
        }
    }
}
