using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.RemoveVillain
{
    class RemoveVillain
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection("Server=DESKTOP-5Q4NC7G;Database=MinionsDB;Integrated Security=true;");
            connection.Open();
            using (connection)
            {
                CheckIdVallainExist(villainId, connection);
                DeleteMinionsForvalainID(villainId, connection);

            }

        }

        public static void DeleteVallian(int villainId, SqlConnection connection)
        {

            Console.WriteLine($"{GetMinionName(villainId, connection)} was deleted");
            string queryDeletevallian = "Delete From Villains Where Id=@vallianId";
            SqlCommand deleteValliansCmd = new SqlCommand(queryDeletevallian, connection);
            deleteValliansCmd.Parameters.AddWithValue("@vallianId", villainId);
            deleteValliansCmd.ExecuteNonQuery();

            
        }

        public static void DeleteMinionsForvalainID(int villainId, SqlConnection connection)
        {
            string queryDeleteMinionForVallain = " Delete from VillainsMinions Where VillainId=@vallianId";
            SqlCommand deleteMinionsPerValId = new SqlCommand(queryDeleteMinionForVallain, connection);
            deleteMinionsPerValId.Parameters.AddWithValue("@vallianId", villainId);
            int deleteMinions = deleteMinionsPerValId.ExecuteNonQuery();

            DeleteVallian(villainId, connection);
            Console.WriteLine($"{deleteMinions} minions released");
        }

        public static void CheckIdVallainExist(int villainId, SqlConnection connection)
        {
            string queryCheckVillain = @"Select Id from Villains where Id=@villainId";
            SqlCommand checkVillainCmd = new SqlCommand(queryCheckVillain, connection);
            checkVillainCmd.Parameters.AddWithValue("@villainId", villainId);

            SqlDataReader reader = checkVillainCmd.ExecuteReader();
            using (reader)
            {
                if (!reader.HasRows)
                {
                    Console.WriteLine("No such villain was found");
                }
            }
        }

        public static string GetMinionName(int villainId, SqlConnection connection)
        {
            string queryGetName = @"Select Name from Villains where Id=@villainId";
            SqlCommand GetVillainCmd = new SqlCommand(queryGetName, connection);
            GetVillainCmd.Parameters.AddWithValue("@villainId", villainId);

            string name = (string)GetVillainCmd.ExecuteScalar();
            return name;
        }
    }
}
