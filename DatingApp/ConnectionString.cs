using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DatingApp
{
    class ConnectionString
    {

        static public string GetConnectionString()
        {
            //return @"Data Source=LAPTOP-BFH2E4BH\H2PROJECT;Initial Catalog=DatingApp;Integrated Security=True";
            return @"Data Source=DESKTOP-2V887A2;Initial Catalog=DatingApp;Integrated Security=True";
        }
    }
}