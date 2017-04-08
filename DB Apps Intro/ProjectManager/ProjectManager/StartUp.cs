

namespace ProjectManager
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class StartUp
    {
        static void Main()
        {
            SqlConnection connection = new SqlConnection(
                @"Server=DESKTOP-5Q4NC7G;
                Database=SoftUni;
                Integrated Security=true");
            connection.Open();

            using (connection)
            {

                while (true)
                {
                    
                    Console.WriteLine("Enter Command: ");
                    string command = Console.ReadLine();
                    //Console.Clear();

                    switch (command)
                    {
                        case "list":
                            Console.Clear();
                            ListAllProjects(connection);
                            break;
                        case "details":
                            Console.Clear();
                            ShowDetails(connection);
                            break;
                        case "search":
                            Console.Clear();
                            SearcByName(connection);
                            break;
                        case "exit":
                            return;
                    }
                }
            }

        }

        public static void SearcByName(SqlConnection connection)
        {
            Console.Write("Enter Search Name: ");
            string pattern = Console.ReadLine();


                string query = @"
Select ProjectId
From Projects
Where Name LIKE @ProjectName";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProjectName", "%"+pattern+"%");
                //int result = (int?)cmd.ExecuteScalar() ?? -1;
                var reader = cmd.ExecuteReader();

                if(!reader.HasRows)
                {
                    Console.WriteLine("Proejct Now Found");
                    return;
                }
            using (reader)
            {
                List<string> ids = new List<string>();
                while (reader.Read())
                {
                    ids.Add(reader[0].ToString());
                }
                Console.WriteLine($"Found Project with ID: {String.Join(",",ids)}");
            }
            
        }
        public static void ListAllProjects(SqlConnection connection)
        {
                string query = @"Select ProjectId,Name from Projects";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine(" ID | Project Name");
                Console.WriteLine("----+-----------------------");
                using (reader)
                {
                    while (reader.Read())
                    {

                        Console.WriteLine($"{reader[0],4}| {reader[1]}");
                    }
                }
            
        }
        public static void ShowDetails(SqlConnection connection)
        {
            Console.Write("Enter Project ID: ");
            int projectId = int.Parse(Console.ReadLine());

                string query = @"Select * from Projects
                 Where ProjectId=@ProjectId";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProjectId", projectId);
                SqlDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    if (!reader.Read())
                    {
                        Console.WriteLine("Project Not Found");
                        return;
                    }

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine(reader.GetName(i)+":");
                        Console.WriteLine(reader[i]);
                        Console.WriteLine("-------------------------------");
                    }
                }

            string query2 = @"
Select e.EmployeeId,e.FirstName,e.LastName
FROM Employees as e
JOIN EmployeesProjects as ep
ON ep.ProjectId=@ProjectId
AND e.EmployeeId=ep.EmployeeId";
            SqlCommand cmd2 = new SqlCommand(query2, connection);
            cmd2.Parameters.AddWithValue("@ProjectId", projectId);
            var reader2 = cmd2.ExecuteReader();

            Console.WriteLine("Assigne Employees: ");
            if (!reader2.HasRows)
            {
                Console.WriteLine("No Employees");
            }
            else
            {
                using (reader2)
                {
                    while (reader2.Read())
                    {
                        Console.WriteLine($"{reader2[0],4}| {reader2[1]}{reader2[2]}");
                    }
                }
            }
            Console.WriteLine("-------------------------------");
        }
    }
}
