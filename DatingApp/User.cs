using Figgle;
using System;

namespace DatingApp
{
    public class User
    {
        public static string Firstname { get; set; }
        public static string Lastname { get; set; }
        public static string Username { get; set; }
        public static string Email { get; set; }
        public static string Password { get; set; }


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
