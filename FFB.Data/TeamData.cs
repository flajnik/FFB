using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.Data.SqlClient;

namespace FFB.Data
{
    public class TeamData
    {

        public static DataTable GetTeamHeader(string team)
        {
            DataTable dt = new DataTable();
            SqlParameter sq = new SqlParameter();
            string strSQL = @"SELECT Notes, Team
                FROM Teams
                WHERE ID = @sq";
            string connStr = @"Server =(local);Database=FFB;User Id=webuser;Password=w3bus3r!";
            SqlConnection conn = new SqlConnection(connStr);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.SelectCommand.Parameters.Add(new SqlParameter("sq", team));
                sa.Fill(dt);
            }            
            return dt;
        }

        public static DataTable GetPerformance(string team)
        {
            DataTable dt = new DataTable();
            SqlParameter @sq = new SqlParameter();
            //@sq.Value = team;
            string strSQL = @"SELECT PLAYERS.PLAYER, PLAYERS.ID, Players.Position POS,
            CASE 
	        WHEN (TeamPlayer.EFFYR = 2019 AND TeamPlayer.EXPWK = 1 AND TeamPlayer.EXPYR = 2078) THEN 'C'
			    WHEN (TeamPlayer.EFFWK = 1 and TeamPlayer.EFFYR = 2020 AND TeamPlayer.EXPWK = 1 AND TeamPlayer.EXPYR = 2078) THEN 'N'
				WHEN (TeamPlayer.EXPYR = 2019) THEN 'L'				
				ELSE 'I'
			END AS S,
            Coalesce(WEEK1.FPTS,0) W1, Coalesce(WEEK2.FPTS,0) W2, Coalesce(WEEK3.FPTS,0) W3, 
            Coalesce(Week4.FPTS,0) W4, Coalesce(Week5.FPTS,0) W5, Coalesce(Week6.FPTS,0) W6,
			Coalesce(Week7.FPTS,0) W7, Coalesce(Week8.FPTS,0) W8, Coalesce(Week9.FPTS,0) W9,
			Coalesce(Week10.FPTS,0) W10, Coalesce(Week11.FPTS,0) W11, Coalesce(Week12.FPTS, 0) W12,
			Coalesce(Week13.FPTS, 0) W13, Coalesce(Week14.FPTS, 0) W14, Coalesce(Week15.FPTS, 0) W15,
			Coalesce(Week16.FPTS, 0) W16, Coalesce(Week17.FPTS, 0) W17,
			Coalesce(WEEK1.FPTS,0) + Coalesce(WEEK2.FPTS,0) + Coalesce(WEEK3.FPTS,0) + 
			Coalesce(WEEK4.FPTS,0) + Coalesce(WEEK5.FPTS,0) + Coalesce(WEEK6.FPTS,0) +
			Coalesce(WEEK7.FPTS,0) + Coalesce(Week8.FPTS,0) + Coalesce(Week9.FPTS,0) +
			Coalesce(Week10.FPTS, 0) + Coalesce(Week11.FPTS,0) + Coalesce(Week12.FPTS, 0) +
			Coalesce(Week13.FPTS, 0) + Coalesce(Week14.FPTS, 0) + Coalesce(Week15.FPTS,0) +
			Coalesce(Week16.FPTS, 0) + Coalesce(Week17.FPTs,0)
			AS TOT, Floor MIN, Ceiling MAX
            FROM PLAYERS             	
	        INNER JOIN TeamPlayer ON Players.ID = TeamPlayer.PlayerID
	        INNER JOIN Teams on TeamPlayer.TeamID = Teams.ID
	        LEFT OUTER JOIN WEEK1 ON Week1.PlayerID = Players.ID --AND TeamPlayer.EFFWK <= 1
	        LEFT OUTER JOIN WEEK2 ON Week2.PlayerID = Players.ID --AND TeamPlayer.EFFWK <= 2
	        LEFT OUTER JOIN Week3 ON Week3.PlayerID = Players.ID --AND TeamPlayer.EFFWK <= 3
	        LEFT OUTER JOIN Week4 ON Week4.PlayerID = Players.ID --AND TeamPlayer.EFFWK <= 4
	        LEFT OUTER JOIN Week5 ON Week5.PlayerID = Players.ID --AND TeamPlayer.EFFWK <= 5
	        LEFT OUTER JOIN Week6 ON Week6.PlayerID = Players.ID --AND TeamPlayer.EFFWK <= 6
	        LEFT OUTER JOIN Week7 ON Week7.PlayerID = Players.ID --AND TeamPlayer.EFFWK <= 7
	        LEFT OUTER JOIN Week8 ON Week8.PlayerID = Players.ID --AND TeamPlayer.EFFWK <= 8
	        LEFT OUTER JOIN Week9 ON Week9.PlayerID = Players.ID --AND TeamPlayer.EFFWK <= 9
	        LEFT OUTER JOIN Week10 ON Week10.PlayerID = Players.ID --AND TeamPlayer.EFFWK <= 10
	        LEFT OUTER JOIN Week11 ON Week11.PlayerID = Players.ID --AND TeamPlayer.EFFWK <= 11
	        LEFT OUTER JOIN Week12 ON Week12.PlayerID = Players.ID --AND TeamPlayer.EFFWK <= 12
	        LEFT OUTER JOIN Week13 ON Week13.PlayerID = Players.ID --AND TeamPlayer.EFFWK <= 13
	        LEFT OUTER JOIN Week14 ON Week14.PlayerID = Players.ID --AND TeamPlayer.EFFWK <= 14
	        LEFT OUTER JOIN Week15 ON Week15.PlayerID = Players.ID --AND TeamPlayer.EFFWK <= 15
	        LEFT OUTER JOIN Week16 ON Week16.PlayerID = Players.ID --AND TeamPlayer.EFFWK <= 16
	        LEFT OUTER JOIN Week17 ON Week17.PlayerID = Players.ID --AND TeamPlayer.EFFWK <= 17
            WHERE Teams.ID = @sq
            ORDER BY Position, TOT DESC";
            string connStr = @"Server=(local);Database=FFB;User Id=webuser;Password=w3bus3r!";
            SqlConnection conn = new SqlConnection(connStr);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.SelectCommand.Parameters.Add(new SqlParameter("sq", team));
                sa.Fill(dt);
            }
            return dt;            
        }

        public static DataTable GetAllTeams()
        {
            DataTable dtTeams = new DataTable();
            string strSQL = @"SELECT ID, ABBR
                FROM Teams";
            string connStr = @"Server =(local);Database=FFB;User Id=webuser;Password=w3bus3r!";
            SqlConnection conn = new SqlConnection(connStr);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dtTeams);
            }
            return dtTeams;
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
                returnVal = x==1? true: false;
            }
            return returnVal;
        }

        public static bool PersistProjections(int playerID, int floor, int ceiling)
        {
            bool returnFlag = false;

            string strSQL = @"UPDATE PLAYERS
            SET FLOOR = @floor, Ceiling=@ceiling
            WHERE PLAYERS.ID = @ID";
            string connStr = @"Server =(local);Database=FFB;User Id=webuser;Password=w3bus3r!";
            SqlConnection conn = new SqlConnection(connStr);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                cmd.Parameters.Add(new SqlParameter("ceiling", ceiling));
                cmd.Parameters.Add(new SqlParameter("floor", floor));
                cmd.Parameters.Add(new SqlParameter("ID", playerID));

                int x = cmd.ExecuteNonQuery();
                returnFlag = x == 1 ? true : false;
            }

            return returnFlag;
        }
    }
}
