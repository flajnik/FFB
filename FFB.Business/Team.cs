using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using FFB.Data;

namespace FFB.Business
{
    public class Team
    {
        public string TeamName { get; set; }
        public string HC { get; set; }
        public string OC { get; set; }
        public string DC { get; set; }
        public string Notes { get; set; }
        public int ID { get; set; }
        public DataTable dtPerformance { get; set; }


        public Team(string team)
        {
            populateHeader(team);
            populatePerformance(team);
        }
        private void populateHeader(string team)
        {
            DataTable dt = TeamData.GetTeamHeader(team);
            Notes = dt.Rows[0]["Notes"].ToString();
            TeamName = dt.Rows[0]["Team"].ToString();
            int teamID = 0;
            int.TryParse(team, out teamID);
            ID = teamID;
        }
      
        private void populatePerformance(string team)
        {
            DataTable myData = TeamData.GetPerformance(team);
            //manipulation

            dtPerformance = myData;
            
        }

        public static DataTable GetAllTeams()
        {
            DataTable myTeams = TeamData.GetAllTeams();
            return myTeams;
        }

        public void PersistNotes(string notes, int teamID)
        {
            bool x = TeamData.PersistNotes(notes, teamID);
        }

        public void PersistProjectsions(string playerID, string Min, string Max)
        {
            int player_ID = 0;
            int minPTS = 0;
            int maxPTS = 0;
            int.TryParse(playerID, out player_ID);
            int.TryParse(Min, out minPTS);
            int.TryParse(Max, out maxPTS);

            bool x = TeamData.PersistProjections(player_ID, minPTS, maxPTS);
        }
    }
}
