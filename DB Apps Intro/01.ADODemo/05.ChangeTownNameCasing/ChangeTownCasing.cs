using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ChangeTownNameCasing
{
    class ChangeTownCasing
    {
        static void Main()
        {
            string countryName = Console.ReadLine();

            SqlConnection connection = new SqlConnection("Server=DESKTOP-5Q4NC7G;Integrated Security=true;");
            string query = File.ReadAllText("../../ChangeTownLetter.sql");

            connection.Open();
            using (connection)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlParameter countryParam = new SqlParameter("@countryName", countryName);
                cmd.Parameters.Add(countryParam);

                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.WriteLine("No town names were affected.");
                }

                using (reader)
                {
                    int index = 0;
                    List<string> townList = new List<string>();
                    while (reader.Read())
                    {
                        index++;
                        townList.Add(reader[0].ToString().ToUpper());
                    }
                    Console.WriteLine($"{index} town names were affected.");
                    Console.WriteLine($"[{String.Join(", ",townList )}]");
                }
            }

        }
    }
}
