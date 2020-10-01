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

        public static void CreateNewUser()
        {
            Console.SetCursorPosition(22, 10);
            User.Username = Console.ReadLine();
            Console.SetCursorPosition(22, 11);
            User.Email = Console.ReadLine();
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

            User.Password = pass;

            Console.SetCursorPosition(2, 15);
            Console.WriteLine($"Test af output: {User.Firstname} {User.Lastname} {User.Username} {User.Email} {User.Password}");

            userIsNew = true;
        }

        public static void SaveUser()
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                conn.Open();
                string command = "NewUser";

                SqlCommand cmd = new SqlCommand(command, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@username", User.Username));
                cmd.Parameters.Add(new SqlParameter("@Email", User.Email));
                cmd.Parameters.Add(new SqlParameter("@pw", User.Password));

                cmd.ExecuteNonQuery();

                Console.WriteLine($"user: {User.Username} has been saved..");
                Console.ReadKey();

                conn.Close();
            }

        }


        public static void GetUserByLogin()
        {

            Console.SetCursorPosition(17, 10);
            User.Username = Console.ReadLine();
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

            User.Password = pass;
            userIsNew = false;

            Console.SetCursorPosition(2, 13);
            Console.WriteLine($"Testing output: {User.Username} {User.Password}");

            Console.ReadKey();
        }
    }
}
