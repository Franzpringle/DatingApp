using Figgle;
using System;

namespace DatingApp
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsLoggedIn { get; set; }


        //public static object LoginUser(User user)
        //{
        //    Console.WriteLine("I have returned to you with the desired user..");

        //    User u = new User();
        //    u.Username = user.Username;
        //    u.Password = user.Password;

        //    repository kald hér for at hente user fra DB
        //    return u;
        //}
    }
}
