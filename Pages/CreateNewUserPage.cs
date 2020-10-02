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

            User currentUser = new User();
            UserRepository.CreateNewUser(currentUser);
            UserRepository.SaveUser(currentUser);
        }
    }
}
