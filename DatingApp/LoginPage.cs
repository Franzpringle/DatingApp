using System;
using System.Collections.Generic;
using System.Text;
using Figgle;

namespace DatingApp
{
    class LoginPage
    {
        public static void Run()
        {
            GUI.DisplayLoginPage();

            User currentUser = UserRepository.GetUserByLogin();

            if (currentUser.IsLoggedIn == true)
            {
                Profile currentProfile = ProfileRepository.GetUserProfile(currentUser);
                UserMenuPage.Run(currentProfile, currentUser);
            }
            else if (currentUser.IsLoggedIn == false)
            {
                Run();
            }
            else
            {
                Console.WriteLine("Something went wrong..");
                Console.WriteLine("Press any any key to return to the front page..");
                Console.ReadKey();
            }

        }
    }
}
