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
            UserRepository.SaveUser(currentUser);
            UserRepository.GetUserByLogin(currentUser);

            GUI.DisplayCreateNewProfile();
            Profile currentProfile = ProfileRepository.CreateNewProfile();
            ProfileRepository.SaveProfile(currentProfile, currentUser);

        }
    }
}
