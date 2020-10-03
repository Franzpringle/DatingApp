using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DatingApp
{
    class CreateNewUserPage
    {

        public static void Run()
        {
            
            GUI.DisplayCreateNewUser();
            User currentUser = UserRepository.CreateNewUser();

            if (UserRepository.UserAlreadyExists(currentUser) == true)
            {
                Console.SetCursorPosition(2, 15);
                Console.WriteLine("Username or Email already exists. Please try again..");
                Console.ReadKey();
                Run();
            }
            else
            {
                UserRepository.SaveUser(currentUser);

                GUI.DisplayCreateNewProfile();
                Profile currentProfile = ProfileRepository.CreateNewProfile();
                ProfileRepository.SaveProfile(currentProfile, currentUser);
            }

        }
    }
}
