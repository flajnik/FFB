using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FFB.Data
{
    public class PlayerData
    {
        public static DataTable GetAllPlayers()
        {
            DataTable dt = new DataTable();
                            
            string strSQL = @"SELECT ID, Player
                FROM Players
                ORDER BY Player";
            string connStr = @"Server =(local);Database=FFB;User Id=webuser;Password=w3bus3r!";
            SqlConnection conn = new SqlConnection(connStr);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
            }
            return dt;
        }
        public static void UpdatePlayer(int player, int team, int effwk, int effyr, int expwk, int expyr)
        {
            DataTable dt = new DataTable();
            SqlParameter sq = new SqlParameter();
            string strSQL = @"Update TeamPlayer
            Set EffWk = @effWk, EffYr = @effYr, ExpWk=@expWk, ExpYr=@expYr
            WHERE Playerid = @player AND TeamID =@team";
            string connStr = @"Server =(local);Database=FFB;User Id=webuser;Password=w3bus3r!";
            SqlConnection conn = new SqlConnection(connStr);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                cmd.Parameters.Add(new SqlParameter("player", player));
                cmd.Parameters.Add(new SqlParameter("team", team));
                cmd.Parameters.Add(new SqlParameter("effWk", effwk));
                cmd.Parameters.Add(new SqlParameter("effYr", effyr));
                cmd.Parameters.Add(new SqlParameter("expWk", expwk));
                cmd.Parameters.Add(new SqlParameter("expYr", expyr));

                int x = cmd.ExecuteNonQuery();
                //returnVal = x == 1 ? true : false;
            }
            //return returnVal;
        }

        public static void InsertPlayer(int player, int team, int effwk, int effyr, int expwk, int expyr)
        {
            
            SqlParameter sq = new SqlParameter();
            string strSQL = @"INSERT INTO TeamPlayer
            values (@player, @team, @effwk, @effyr, @expwk, @expyr)";           
            string connStr = @"Server =(local);Database=FFB;User Id=webuser;Password=w3bus3r!";
            SqlConnection conn = new SqlConnection(connStr);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                cmd.Parameters.Add(new SqlParameter("player", player));
                cmd.Parameters.Add(new SqlParameter("team", team));
                cmd.Parameters.Add(new SqlParameter("effWk", effwk));
                cmd.Parameters.Add(new SqlParameter("effYr", effyr));
                cmd.Parameters.Add(new SqlParameter("expWk", expwk));
                cmd.Parameters.Add(new SqlParameter("expYr", expyr));

                int x = cmd.ExecuteNonQuery();
                //returnVal = x == 1 ? true : false;
            }
        }

        public static bool PersistNotes(string notes, int teamID)
        {
            bool returnVal = false;

            DataTable dt = new DataTable();
            SqlParameter sq = new SqlParameter();
            string strSQL = @"Update Teams
            Set Notes = @notes
            WHERE Teams.ID = @team";
            string connStr = @"Server =(local);Database=FFB;User Id=webuser;Password=w3bus3r!";
            SqlConnection conn = new SqlConnection(connStr);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                cmd.Parameters.Add(new SqlParameter("notes", notes));
                cmd.Parameters.Add(new SqlParameter("team", teamID));
                int x = cmd.ExecuteNonQuery();
                returnVal = x == 1 ? true : false;
            }
            return returnVal;
        }
    }
}
