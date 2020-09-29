using Figgle;
using System;

namespace DatingApp
{
    public class User
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public User(string firstname, string lastname, string username, string email, string password)
        {
            Firstname = firstname;
            Lastname = lastname;
            Username = username;
            Email = email;
            Password = password;
        }
        public User()
        {

        }

        public static User NewUser()
        {
            string firstname, lastname, mail, username, pass = string.Empty;

            Console.Clear();
            Console.WriteLine(FiggleFonts.Standard.Render("Dating App"));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please enter the following information");
            Console.Write("Firstname: ");
            firstname = Console.ReadLine();
            Console.Write("Lastname: ");
            lastname = Console.ReadLine();
            Console.Write("E-mail: ");
            mail = Console.ReadLine();
            Console.Write("Username: ");
            username = Console.ReadLine();
            Console.Write("Password: ");
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            User u = new User(firstname, lastname, username, mail, pass);

            return u;
        }

        public static void SaveUser(User user)
        {
            Console.WriteLine("I have saved the user to db..");
        }

        public static object LoginUser(User user)
        {
            Console.WriteLine("I have returned to you with the desired user..");

            User u = new User();
            u.Username = user.Username;
            u.Password = user.Password;

            //repository kald hér for at hente user fra DB
            return u;
        }
    }
}
