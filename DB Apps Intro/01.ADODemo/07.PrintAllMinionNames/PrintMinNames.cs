using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.PrintAllMinionNames
{
    class PrintMinNames
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-5Q4NC7G;Database=MinionsDB;Integrated Security=true;");
            connection.Open();
            using (connection)
            {
                string query = @"Select Name from Minions";
                SqlCommand getNamesCmd = new SqlCommand(query, connection);
                SqlDataReader reader = getNamesCmd.ExecuteReader();
                List<string> allMinionNames = new List<string>();

                using (reader)
                {
                    while (reader.Read())
                    {
                        allMinionNames.Add(reader[0].ToString());
                    }
                }

                while (allMinionNames.Count > 0)
                {
                    Console.WriteLine(allMinionNames.First());
                    allMinionNames.RemoveAt(0);
                    if (allMinionNames.Count>0)
                    {
                        Console.WriteLine(allMinionNames.Last());
                        allMinionNames.RemoveAt(allMinionNames.Count - 1);
                    }
                }
                

            }
        }
    }
}
