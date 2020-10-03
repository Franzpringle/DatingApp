using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp
{
    class DatingPage
    {
        public static void Run(Profile currentProfile, User currentUser)
        {
            while (true)
            {
                Profile potentialMatch = ProfileRepository.GetPotentialMatchProfile(currentUser);
                GUI.DisplayDatingProfile(potentialMatch);

                string menuChoice = Console.ReadLine().ToLower();
                if (menuChoice == "1")
                {
                    MatchRepository.RegisterLike(currentUser, potentialMatch);
                    bool isMatch = MatchRepository.CheckIfMatch(currentProfile, potentialMatch);
                    if (isMatch == true) GUI.DisplayMatchMenu(currentProfile, potentialMatch);
                }
                if (menuChoice == "2")
                {
                    Run(currentProfile, currentUser);
                }
                if (menuChoice == "3")
                {
                    UserMenuPage.Run(currentProfile, currentUser);
                }
            }
        }
    }
}
