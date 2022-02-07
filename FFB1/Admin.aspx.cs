using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using FFB.Business;

namespace FFB1
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlPlayers.DataSource = Player.GetAllPlayers();
                ddlPlayers.DataTextField = "Player";
                ddlPlayers.DataValueField = "ID";
                ddlPlayers.DataBind();

                ddlTeams.DataSource = Team.GetAllTeams();
                ddlTeams.DataTextField = "ABBR";
                ddlTeams.DataValueField = "ID";
                ddlTeams.DataBind();

                int[] weeks = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
                ddlEffWk.DataSource = weeks;
                ddlEffWk.DataBind();

                int[] years = new int[] { 2019, 2020, 2021, 2078 };
                ddlEffYr.DataSource = years;
                ddlEffYr.DataBind();

                ddlExpWk.DataSource = weeks;
                ddlExpWk.DataBind();

                ddlExpYr.DataSource = years;
                ddlExpYr.DataBind();
                
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Player.UpdatePlayer(ddlPlayers.SelectedValue, ddlTeams.SelectedValue, ddlEffWk.SelectedValue, ddlEffYr.SelectedValue, ddlExpWk.SelectedValue, ddlExpYr.SelectedValue);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Player.NewContract(ddlPlayers.SelectedValue, ddlTeams.SelectedValue);
        }
    }
}