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
                Console.WriteLine("Username or Email already exists. Please try again..");
                Console.ReadKey();
                Run();
            }
            else
            {
                UserRepository.SaveUser(currentUser);
                UserRepository.GetUser(currentUser);

                GUI.DisplayCreateNewProfile();
                Profile currentProfile = ProfileRepository.CreateNewProfile();
                ProfileRepository.SaveProfile(currentProfile, currentUser);
            }

        }
    }
}
