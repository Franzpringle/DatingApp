using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DatingApp
{
    class MessageRepository
    {
        //public static void CreateNewMessage()
        //{
        //    Message.From = User.Username;
        //    Message.To = Profile.ProfileId;
        //    Message.Body = Console.ReadLine();
        //}

        //public static void SendMessage()
        //{
        //    //send message ved at gem den i DB
        //}

        //public static void GetMessage()
        //{
        //    //hent message fra DB
        //}

        public static bool AnyNewMessages(string username)
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                string command = "AnyMessages";

                SqlCommand cmd = new SqlCommand(command, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Username", username));

                conn.Open();
                int NewMessages = (int)cmd.ExecuteScalar();
                conn.Close();

                if (NewMessages > 0)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
