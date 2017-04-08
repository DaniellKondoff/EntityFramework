using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.GetVilainNames
{
    class GetNames
    {
        static void Main(string[] args)
        {
            string query = File.ReadAllText("../../VillainNames.sql");
            SqlConnection connection = new SqlConnection("Server=DESKTOP-5Q4NC7G;Integrated Security=true;");

            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();

            using (connection)
            {
               SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string villainName = (string)reader["Name"];
                    int countSlaves = (int)reader["MinionsCount"];

                    Console.WriteLine($"{villainName} {countSlaves}");
                }
            }
        }
    }
}
