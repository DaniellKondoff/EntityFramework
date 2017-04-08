using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ADODemo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Console.Write("Enter Employee ID: ");
            int EmployeeId = int.Parse(Console.ReadLine());

            Console.Write("Enter TownName: ");
            string townName = Console.ReadLine();

            SqlConnection connection = new SqlConnection(
                @"Server=.;
                Database=SoftUni;
                Integrated Security=true");
            connection.Open();

            //Execute Scalar() - SqlCOomannd Class
            //using (connection)
            //{
            //    string query = "Select Count(*) From Employees";
            //    SqlCommand command = new SqlCommand(query,connection);
            //    int answer = (int) command.ExecuteScalar();
            //    Console.WriteLine("Number of Employees: {0}",answer);
            //}

            //Execute Reader() - SqlCOmmnad Class
            using (connection)
            {
                string query = $@"Select EmployeeId,FirstName,LastName,Salary 
                from Employees
                Where EmployeeId= {EmployeeId}";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    Console.WriteLine(reader.FieldCount);
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader.GetName(i),-15}");
                    }

                    Console.WriteLine();
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader[i],-15}");
                        }
                        Console.WriteLine();
                    }
                }
            }

            //Execute NON Reader - SqlCommand Class

            //using (connection)
            //{
            //    string query = $"Insert INTO Towns (Name) VALUES('@TownName')";
            //    SqlCommand command = new SqlCommand(query, connection);
            //    command.Parameters.AddWithValue("@TownName", townName);
            //    int rowsAffected = command.ExecuteNonQuery();
            //    Console.WriteLine($"Affected {rowsAffected} rows");
            //}
        }
    }
}
