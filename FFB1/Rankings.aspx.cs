using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FFB.Business;

namespace FFB1
{
    public partial class Rankings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //initial load with all positions
                Ranking myRanking = new Ranking("ALL");

                gvRanking.DataSource = myRanking.dtRanking;
                gvRanking.DataBind();
            }
        }

        protected void ddlScoring_SelectedIndexChanged(object sender, EventArgs e)
        {            
            //gvRanking.DataSource=
            //gvRanking.DataBind();
        }

        protected void ddlPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            //rankings for this position
            Ranking myRanking = new Ranking(ddlPosition.SelectedValue);
            gvRanking.DataSource = myRanking.dtRanking;
            gvRanking.DataBind();
        }

        protected void gvRanking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                //highlight positions
                switch (e.Row.Cells[2].Text)
                {
                    case "WR":
                        e.Row.Cells[0].BackColor = System.Drawing.Color.SkyBlue;
                        e.Row.Cells[1].BackColor = System.Drawing.Color.SkyBlue;
                        e.Row.Cells[2].BackColor = System.Drawing.Color.SkyBlue;
                        break;
                    case "RB":
                        e.Row.Cells[0].BackColor = System.Drawing.Color.IndianRed;
                        e.Row.Cells[1].BackColor = System.Drawing.Color.IndianRed;
                        e.Row.Cells[2].BackColor = System.Drawing.Color.IndianRed;
                        break;
                    case "QB":
                        e.Row.Cells[0].BackColor = System.Drawing.Color.LightGray;
                        e.Row.Cells[1].BackColor = System.Drawing.Color.LightGray;
                        e.Row.Cells[2].BackColor = System.Drawing.Color.LightGray;
                        break;
                    case "TE":
                        e.Row.Cells[0].BackColor = System.Drawing.Color.LightGreen;
                        e.Row.Cells[1].BackColor = System.Drawing.Color.LightGreen;
                        e.Row.Cells[2].BackColor = System.Drawing.Color.LightGreen;
                        break;
                    default:
                        break;
                }
            }
            
        }

        protected void gvRanking_RowEditing(object sender, GridViewEditEventArgs e)
        {
           
        }

        protected void gvRanking_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
    }
}