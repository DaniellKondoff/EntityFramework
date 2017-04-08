using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.IncreaseMinionsAge
{
    class IncreaseAge
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string argument = String.Join(",", input);

            string queryAge = File.ReadAllText("../../AgeUpdate.sql");

            SqlConnection connection = new SqlConnection("Server=DESKTOP-5Q4NC7G;Database=MinionsDB;Integrated Security=true;");
            SqlCommand updateAgeCmd = new SqlCommand(queryAge, connection);
            updateAgeCmd.Parameters.AddWithValue("@Ids", argument);
            connection.Open();
            using (connection)
            {
                SqlDataReader reader = updateAgeCmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{(string)reader["Name"]} {(int)reader["Age"]}");
                }
            }



        }
    }
}
