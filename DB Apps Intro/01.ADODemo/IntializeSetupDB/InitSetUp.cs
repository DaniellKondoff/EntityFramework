using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntializeSetupDB
{
    class InitSetUp
    {
        static void Main(string[] args)
        {
            string query = File.ReadAllText("../../SetUpDB.sql");

            SqlConnection connection = new SqlConnection("Server=DESKTOP-5Q4NC7G;Integrated Security=true;");
            connection.Open();

            //String sqlcreateDB = "Create Database MinionsDB";
            //SqlCommand createDBCommand = new SqlCommand(sqlcreateDB,connection);
            SqlCommand createTableCommand = new SqlCommand(query, connection);
            using (connection)
            {
                Console.WriteLine(createTableCommand.ExecuteNonQuery());// How many columns have been affected
            }
        }
    }
}
