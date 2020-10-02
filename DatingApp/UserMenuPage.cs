using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp
{
    class UserMenuPage
    {
        public static void Run(Profile currentProfile, User currentUser)
        {
            GUI.DisplayUserMenu();
            string menuChoice = Console.ReadLine().ToLower();

            if (menuChoice == "1") DatingPage.Run(currentProfile);
            if (menuChoice == "2") EditProfilePage.Run(currentProfile, currentUser);
        }
    }
}
