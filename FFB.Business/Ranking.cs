using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using FFB.Data;

namespace FFB.Business
{
    public class Ranking
    {
        public DataTable dtRanking { get; set; }
        public string position { get; set; }
        public string team {get; set;}



        public Ranking(string pos)
        {
            position = pos;            
            populateRanking(pos);
        }
        
        private void populateRanking(string position)
        {           
            dtRanking = RankingData.GetRanking(position);
        }

    }
}
