using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp
{
    class EditProfilePage
    {
        public static void Run(Profile currentProfile, User currentUser)
        {
            
            while (true)
            {
                GUI.DisplayEditProfile(currentProfile);
                string menuChoice = Console.ReadLine().ToLower();

                if (menuChoice == "1")
                {
                    ProfileRepository.ChangeProfileStatus(currentProfile, currentUser);
                    break;
                }
                if (menuChoice == "2") UserMenuPage.Run(currentProfile, currentUser);

            }
        }
    }
}
