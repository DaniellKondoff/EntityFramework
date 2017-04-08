using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AddMinion
{
    class AddMinion
    {
        static void Main()
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-5Q4NC7G;Database=MinionsDB;Integrated Security=true;");

            string minionInput = Console.ReadLine();
            string vallianInput = Console.ReadLine();

            string[] minionData = minionInput.Split(':')[1].Trim().Split(' ');
            string minioneName = minionData[0];
            int minionAge = int.Parse(minionData[1]);
            string minionTown = minionData[2];

            string vallianName = vallianInput.Split(':')[1].Trim();

           

            connection.Open();
            using (connection)
            {
                CheckAndAddTown(connection, minionTown);
                CheckAndAddVallians(connection, vallianName);
                AddMinions(connection, minioneName, minionAge, minionTown);
                AddMinionsAndVallians(connection, minioneName, vallianName);
            }

        }

        private static void AddMinionsAndVallians(SqlConnection connection, string minioneName, string vallianName)
        {
            string queryAddMinionAndVallian = @"Insert into VillainsMinions(VillainId,MinionId) Values(@VallainID,@MinionID)";
            SqlCommand addMinValCmd = new SqlCommand(queryAddMinionAndVallian, connection);
            addMinValCmd.Parameters.AddWithValue("@VallainID", GetVallianId(connection, vallianName));
            addMinValCmd.Parameters.AddWithValue("@MinionID", GetMinionId(connection, minioneName));
            addMinValCmd.ExecuteNonQuery();
            Console.WriteLine($"Successfully added {minioneName} to be minion of {vallianName}.");
        }

        private static void AddMinions(SqlConnection connection, string minioneName, int minionAge, string minionTown)
        {
            string queryAddinion = "Insert into Minions(Name,Age,TownId) Values(@minionName,@mAge,@mTownId);";
            SqlCommand addMinionCmd = new SqlCommand(queryAddinion, connection);
            addMinionCmd.Parameters.AddWithValue("@minionName", minioneName);
            addMinionCmd.Parameters.AddWithValue("@mAge", minionAge);
            addMinionCmd.Parameters.AddWithValue("@mTownId", GetTownId(connection, minionTown));
            addMinionCmd.ExecuteNonQuery();
        }

        private static void CheckAndAddVallians(SqlConnection connection, string vallianName)
        {
            string queryVillain = @"Select Id from Villains where Name=@villainName";
            SqlCommand villainCmd = new SqlCommand(queryVillain, connection);
            villainCmd.Parameters.AddWithValue("@villainName", vallianName);

            SqlDataReader reader = villainCmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                //Addind Villain to DB
                string queryAddVillain = @"Insert into Villains Values(@villainName,'evil')";
                SqlCommand addVillain = new SqlCommand(queryAddVillain, connection);
                addVillain.Parameters.AddWithValue("@villainName", vallianName);
                addVillain.ExecuteNonQuery();
                Console.WriteLine($"Villain {vallianName} was added to the database.");
            }
            reader.Close();
        }

        public static void CheckAndAddTown(SqlConnection connection, string minionTown)
        {
            string queryTown = @"Select Id from Towns Where TownName=@TownName";
            SqlCommand cmd = new SqlCommand(queryTown, connection);
            cmd.Parameters.AddWithValue("@TownName", minionTown);

            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                //Adding Town to DB
                string queryAddTown = "Insert into Towns(TownName) Values(@AddTownName)";
                SqlCommand addTownCmd = new SqlCommand(queryAddTown, connection);
                addTownCmd.Parameters.AddWithValue("@AddTownName", minionTown);
                addTownCmd.ExecuteNonQuery();
                Console.WriteLine($"Town {minionTown} was added to the database.");
            }
            reader.Close();
            
        }

        public static int GetTownId(SqlConnection connection, string minionTown)
        {
            string queryTown = @"Select Id from Towns Where TownName=@TownName";
            SqlCommand cmd = new SqlCommand(queryTown, connection);
            cmd.Parameters.AddWithValue("@TownName", minionTown);

            int townID = (int)cmd.ExecuteScalar();
            return townID;
        }

        public static int GetMinionId(SqlConnection connection, string minioneName)
        {
            string queryGetMinionId = @"Select Id from Minions Where Name=@MinionName";
            SqlCommand cmd = new SqlCommand(queryGetMinionId, connection);
            cmd.Parameters.AddWithValue("@MinionName", minioneName);

            int minionId = (int)cmd.ExecuteScalar();
            return minionId;
        }

        public static int GetVallianId(SqlConnection connection, string vallianName)
        {
            string queryGetVallianId = @"Select Id from Villains where Name=@villainName";
            SqlCommand cmd = new SqlCommand(queryGetVallianId, connection);
            cmd.Parameters.AddWithValue("@villainName", vallianName);

            int vallianId = (int)cmd.ExecuteScalar();
            return vallianId;
        }
    }
}
