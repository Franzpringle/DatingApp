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

            User currentUser = UserRepository.GetUserCredentials();

            if (UserRepository.UserLoginSuccess(currentUser) == true)
            {
                Profile currentProfile = ProfileRepository.GetUserProfile(currentUser);
                UserMenuPage.Run(currentProfile, currentUser);
            }
            else if (UserRepository.UserLoginSuccess(currentUser) == false)
            {
                Run();
            }
            else
            {
                Console.SetCursorPosition(2, 15);
                Console.WriteLine("Something went wrong..");
                Console.SetCursorPosition(2, 16);
                Console.WriteLine("Press any key to return to the front page..");
                Console.ReadKey();
            }

        }
    }
}
