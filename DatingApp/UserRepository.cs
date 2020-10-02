using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace DatingApp
{
    class UserRepository
    {
        public static bool userIsNew { get; set; }
        public static string pass { get; set; }

        public static User CreateNewUser()
        {
            User u = new User();
            Console.SetCursorPosition(22, 10);
            u.Username = Console.ReadLine();
            Console.SetCursorPosition(22, 11);
            u.Email = Console.ReadLine();
            Console.SetCursorPosition(22, 12);
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

        public static void SaveUser(User u)
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                conn.Open();
                string command = "NewUser";

                SqlCommand cmd = new SqlCommand(command, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@username", u.Username));
                cmd.Parameters.Add(new SqlParameter("@Email", u.Email));
                cmd.Parameters.Add(new SqlParameter("@pw", u.Password));

                cmd.ExecuteNonQuery();

                Console.WriteLine($"user: {u.Username} has been saved..");
                Console.ReadKey();

                conn.Close();
            }

        }
        public static User GetUserByLogin()
        {
            User u = new User();
            Console.SetCursorPosition(17, 10);
            u.Username = Console.ReadLine();
            Console.SetCursorPosition(17, 11);
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
            u.IsLoggedIn = true;

            return u;
        }
        public static User GetUserByLogin(User u)
        {
            // log user ind ved at tjekke om den findes i DB.
            u.IsLoggedIn = true;
            return u;
        }
        
    }
}
