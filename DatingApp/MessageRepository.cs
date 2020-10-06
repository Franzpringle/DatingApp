using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DatingApp
{
    class MessageRepository
    {
        public static void CreateNewMessage()
        {
            //Message.From = User.Username;
            //Message.To = Profile.ProfileId;
            //Message.Body = Console.ReadLine();
        }

        public static void SendMessage(Profile currentprofile, Profile Matchedprofile)
        {
            Message message = new Message();

            using (SqlConnection conn = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                string command = "MessageSendt";

                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Userprofileid", currentprofile.ProfileId));
                cmd.Parameters.Add(new SqlParameter("@targetprofileid", Matchedprofile.ProfileId));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }

        }

        public static Message GetMessage(Profile currentprofile, Profile Matchedprofile)
        {
            Message NewMessage = new Message();

            using (SqlConnection conn = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                conn.Open(); 
                string command = "GetAllMessagesWithUser";

                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Userprofileid", currentprofile.ProfileId));
                cmd.Parameters.Add(new SqlParameter("@targetprofileid", Matchedprofile.ProfileId));

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        NewMessage.Body = (string)reader.GetValue("Tekst");
                        NewMessage.TS = (DateTime)reader.GetValue("TS");
                    }
                }
                else
                {
                    Console.SetCursorPosition(15, 14);
                    Console.WriteLine("No messages found");
                    Console.WriteLine("Try again later.");
                }

                conn.Close();

                return NewMessage;

            }
        }

        public static bool AnyNewMessages(User currentUser)
        {
            bool NewMessages = false;

            using (SqlConnection conn = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                string command = "AnyMessages";

                SqlCommand cmd = new SqlCommand(command, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Username", currentUser.Username));

                conn.Open();
                int MessageCounter = (int)cmd.ExecuteScalar();
                conn.Close();

                //something like
                // if(NewMessages > 0)
                {
                    //Notification on screen
                    NewMessages = true;
                }

                return NewMessages;
            }
        }
    }
}
