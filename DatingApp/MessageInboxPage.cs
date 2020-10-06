using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp
{
    class MessageInboxPage
    {
        public static void Run(Profile currentProfile)
        {
            GUI.DisplayMessagethreads(currentProfile);

        }
    }
}
