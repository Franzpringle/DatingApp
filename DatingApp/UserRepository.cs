using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace DatingApp
{
    class UserRepository
    {
        public static bool userIsNew { get; set; }
        private static bool usernameIsOk;
        private static bool emailIsOk;

        public static User CreateNewUser()
        {

            string pass = string.Empty;
            User u = new User();

            do
            {
                Console.SetCursorPosition(22, 10);
                u.Username = Console.ReadLine();

                if (Regex.IsMatch(u.Username, "[^A-Za-z0-9]"))
                {
                    usernameIsOk = false;
                    Console.SetCursorPosition(45, 20);
                    Console.WriteLine("Username must only contain letters and numbers.");
                    Console.SetCursorPosition(45, 21);
                    Console.WriteLine("Please try again..");
                    Console.ReadKey();
                    Console.SetCursorPosition(22, 10);
                    Console.Write(new string(' ', u.Username.Length));
                }
                else
                {
                    usernameIsOk = true;
                    Console.SetCursorPosition(0, 20);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, 21);
                    Console.Write(new string(' ', u.Email.Length));
                }

            } while (usernameIsOk == false);


            do
            {
                Console.SetCursorPosition(22, 11);
                u.Email = Console.ReadLine();

                if (Regex.IsMatch(u.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                {
                    emailIsOk = false;
                    Console.SetCursorPosition(45, 20);
                    Console.WriteLine("Email is invalid.");
                    Console.SetCursorPosition(45, 21);
                    Console.WriteLine("Please try again..");
                    Console.ReadKey();
                    Console.SetCursorPosition(0, 11);
                    Console.Write(new string(' ', Console.WindowWidth));
                }
                else
                {
                    emailIsOk = true;
                    Console.SetCursorPosition(0, 20);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, 21);
                    Console.Write(new string(' ', Console.WindowWidth));
                }
            } while (emailIsOk == false);

            Console.SetCursorPosition(22, 12);
            // replaces any char with a * to avoid PW being visible in plain text in the console.
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

            u.Password = pass;
            userIsNew = true;

            return u;
        }
        public static bool UserAlreadyExists(User u)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString.GetConnectionString());
            conn.Open();
            string command = "CheckIfUserExists";

            SqlCommand cmd = new SqlCommand(command, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@username", u.Username));
            cmd.Parameters.Add(new SqlParameter("@email", u.Email));

            var result = cmd.ExecuteScalar();
            int UserExist = Convert.ToInt32(result);
            conn.Close();

            if (UserExist > 0) return true;
            else return false;
        }
        public static void SaveUser(User u)
        {

            using SqlConnection conn = new SqlConnection(ConnectionString.GetConnectionString());
            conn.Open();
            string command = "NewUser";

            SqlCommand cmd = new SqlCommand(command, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@username", u.Username));
            cmd.Parameters.Add(new SqlParameter("@Email", u.Email));
            cmd.Parameters.Add(new SqlParameter("@pw", u.Password));

            cmd.ExecuteNonQuery();

            Console.SetCursorPosition(2, 15);
            Console.WriteLine($"user: {u.Username} has been saved..");
            Console.ReadKey();

            conn.Close();

        }
        public static User GetUserCredentials()
        {
            string pass = string.Empty;

            User u = new User();
            Console.SetCursorPosition(17, 10);
            u.Username = Console.ReadLine();
            Console.SetCursorPosition(17, 11);
            // replaces any char with a * to avoid PW being visible in plain text in the console.
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

            u.Password = pass;

            return u;
        }
        public static bool UserLoginSuccess(User u)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString.GetConnectionString());
            conn.Open();
            string command = "LoginUser";

            SqlCommand cmd = new SqlCommand(command, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@username", u.Username));
            cmd.Parameters.Add(new SqlParameter("@password", u.Password));

            var result = cmd.ExecuteScalar();
            int userCanBeLoggedIn = Convert.ToInt32(result);
            conn.Close();

            if (userCanBeLoggedIn > 0) return true;
            else return false;
        }

    }
}
