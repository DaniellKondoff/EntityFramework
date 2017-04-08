using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.IncreaseAgeByProc
{
    class IncreaseAgePROC
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-5Q4NC7G;Database=MinionsDB;Integrated Security=true;");
            Console.Write("Enter ID: ");
            int minionId = int.Parse(Console.ReadLine());

            string query = File.ReadAllText("../../ProcedureIncAge.sql");
            SqlCommand updateAgeCmd = new SqlCommand(query, connection);
            updateAgeCmd.Parameters.AddWithValue("@MinionID", minionId);
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
