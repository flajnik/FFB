using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using FFB.Data;

namespace FFB.Business
{
    public class Player
    {
        public static DataTable GetAllPlayers()
        {
            return PlayerData.GetAllPlayers();
        }

        public static void UpdatePlayer(string playerID, string teamID, string effWk, string effYr, string expWk, string expYr)
        {
            int player = Convert.ToInt32(playerID);
            int team = Convert.ToInt32(teamID);
            int effwk = Convert.ToInt32(effWk);
            int effyr = Convert.ToInt32(effYr);
            int expwk = Convert.ToInt32(expWk);
            int expyr = Convert.ToInt32(expYr);
            PlayerData.UpdatePlayer(player, team, effwk, effyr, expwk, expyr);
        }

        public static void NewContract(string playerID, string teamID)
        {
            int player = Convert.ToInt32(playerID);
            int team = Convert.ToInt32(teamID);
            PlayerData.InsertPlayer(player, team, 1, DateTime.Now.Year, 1, 2078);
        }
    }
}
