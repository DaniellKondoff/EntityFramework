using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.GetMinionsNameById
{
    class GetMinionnames
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

          
            string queryVillainName = File.ReadAllText("../../GetVillainName.sql");

            SqlConnection connection = new SqlConnection("Server=DESKTOP-5Q4NC7G;Integrated Security=true;");

            SqlCommand findVillainNameCmd = new SqlCommand(queryVillainName,connection);
            SqlParameter villainIdParam = new SqlParameter("@villainId", villainId);
            findVillainNameCmd.Parameters.Add(villainIdParam);
            connection.Open();

            SqlDataReader reader = findVillainNameCmd.ExecuteReader();

            if (reader.Read())
            {
                string villName = (string)reader["Name"];
                Console.WriteLine($"Villain: {villName}");

                string queryMinionName = File.ReadAllText("../../GetMinionsNames.sql");
                SqlCommand findMinionsCommand = new SqlCommand(queryMinionName,connection);
                SqlParameter MinionsNameByIdParam = new SqlParameter("@villainId", villainId);
                findMinionsCommand.Parameters.Add(MinionsNameByIdParam);
                reader.Close();

                SqlDataReader minionsReader = findMinionsCommand.ExecuteReader();
                int index = 1;
                while (minionsReader.Read())
                {
                    string minionName = (string)minionsReader["Name"];
                    int minionsAge = (int)minionsReader["Age"];

                    Console.WriteLine($"{index}. {minionName} {minionsAge}");
                    index++;
                }
            }
            else
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
            }

        }
    }
}
