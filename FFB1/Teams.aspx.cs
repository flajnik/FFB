using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FFB.Business;

namespace FFB1
{
    public partial class Teams : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //populate team list
                ddlTeam.DataSource = Team.GetAllTeams();
                ddlTeam.DataTextField = "ABBR";
                ddlTeam.DataValueField = "ID";
                ddlTeam.DataBind();

                Team myTeam = new Team(ddlTeam.SelectedValue);
                populateTeamHeader(myTeam);
                populatePerformanceGrid(myTeam);
                lblTeamHeader.Text = myTeam.TeamName;
            }
        }

        private void populatePerformanceGrid(Team myTeam)
        {
            gvTeam.DataSource = myTeam.dtPerformance;
            gvTeam.DataBind();
        }

        private void populateTeamHeader(Team myTeam)
        {
            txtNotes.Text = myTeam.Notes;
        }

        protected void ddlScoring_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change scoring method
            //gv.data source = GetSomething(ddlTeam.SelectedIndex, ddlScoring.SelectedIndex)
            //gvTeam.DataBind()
        }

        protected void gvTeam_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                switch (e.Row.Cells[1].Text)
                {
                    case "WR":
                        e.Row.Cells[0].BackColor = System.Drawing.Color.SkyBlue;
                        e.Row.Cells[1].BackColor = System.Drawing.Color.SkyBlue;
                        formatScoring("WR", e);
                        break;
                    case "RB":
                        e.Row.Cells[0].BackColor = System.Drawing.Color.IndianRed;
                        e.Row.Cells[1].BackColor = System.Drawing.Color.IndianRed;
                        formatScoring("RB", e);
                        break;
                    case "QB":
                        e.Row.Cells[0].BackColor = System.Drawing.Color.LightGray;
                        e.Row.Cells[1].BackColor = System.Drawing.Color.LightGray;
                        formatScoring("QB", e);
                        break;
                    case "TE":
                        e.Row.Cells[0].BackColor = System.Drawing.Color.LightGreen;
                        e.Row.Cells[1].BackColor = System.Drawing.Color.LightGreen;
                        formatScoring("TE", e);
                        break;
                    default:
                        break;
                }
                //hilight new/old players
                switch (e.Row.Cells[2].Text)
                {
                    case "N":
                        e.Row.Font.Italic = true;
                        e.Row.Font.Bold = true;
                       // e.Row.ForeColor = System.Drawing.Color.OrangeRed;
                        break;
                    case "L":
                       // e.Row.ForeColor = System.Drawing.Color.MediumBlue;
                        e.Row.Font.Italic = true;
                        e.Row.Font.Bold = true;
                        e.Row.Font.Strikeout = true;
                        break;
                    default:
                        break;
                }

            }
        }

        //Highlight scoring cells basesd on position
        private void formatScoring(string position, GridViewRowEventArgs e)
        {
            //RB1: 22 RB2: 16 WR1: 19 WR2: 13
            int RB0 = 33;
            int RB1 = 22;
            int RB2 = 16;
            int RB3 = 10;
            int WR0 = 27;
            int WR1 = 19;
            int WR2 = 13;
            int WR3 = 10;
            int QB0 = 28;
            int QB1 = 20;
            int QB2 = 9;
            int TE0 = 15;
            int TE1 = 10;
            int score = 0;
            switch (position)
            {
                case "WR":
                    for (int i = 3; i < e.Row.Cells.Count - 1; i++)
                    {
                        string strScore = e.Row.Cells[i].Text;
                        int.TryParse(strScore, out score);
                        if (score == 0)
                        {
                            e.Row.Cells[i].BackColor = System.Drawing.Color.DarkGray;
                        }
                        else if (score >= WR0)
                        {
                            e.Row.Cells[i].BackColor = System.Drawing.Color.Purple;
                            e.Row.Cells[i].ForeColor = System.Drawing.Color.Red;
                        }
                        else if (score >= WR1)
                        {
                            e.Row.Cells[i].BackColor = System.Drawing.Color.Crimson;
                        }
                        else if (score >= WR2)
                        {
                            e.Row.Cells[i].BackColor = System.Drawing.Color.DarkOrange;
                        }
                        else if (score >= WR3)
                        {
                            e.Row.Cells[i].BackColor = System.Drawing.Color.Khaki;
                        }
                        else
                        {
                            e.Row.Cells[i].BackColor = System.Drawing.Color.LightSteelBlue;
                        }
                    }
                    break;
                case "RB":
                    {
                        for (int i = 3; i < e.Row.Cells.Count - 1; i++)
                        {
                            string strScore = e.Row.Cells[i].Text;
                            int.TryParse(strScore, out score);
                            if (score == 0)
                            {
                                e.Row.Cells[i].BackColor = System.Drawing.Color.DarkGray;
                            }
                            else if (score >= RB0)
                            {
                                e.Row.Cells[i].BackColor = System.Drawing.Color.Purple;
                                e.Row.Cells[i].ForeColor = System.Drawing.Color.Red;
                            }
                            else if (score >= RB1)
                            {
                                e.Row.Cells[i].BackColor = System.Drawing.Color.Crimson;
                            }
                            else if (score >= RB2)
                            {
                                e.Row.Cells[i].BackColor = System.Drawing.Color.DarkOrange;
                            }
                            else if (score >= RB3)
                            {
                                e.Row.Cells[i].BackColor = System.Drawing.Color.Khaki;
                            }
                            else
                            {
                                e.Row.Cells[i].BackColor = System.Drawing.Color.LightSteelBlue;
                            }

                        }
                    }
                    break;
                case "QB":
                    {
                        for (int i = 3; i < e.Row.Cells.Count - 1; i++)
                        {
                            string strScore = e.Row.Cells[i].Text;
                            int.TryParse(strScore, out score);
                            if (score == 0)
                            {
                                e.Row.Cells[i].BackColor = System.Drawing.Color.DarkGray;
                            }
                            else if (score >= QB0)
                            {
                                e.Row.Cells[i].BackColor = System.Drawing.Color.Purple;
                                e.Row.Cells[i].ForeColor = System.Drawing.Color.Red;
                            }
                            else if (score >= QB1)
                            {
                                e.Row.Cells[i].BackColor = System.Drawing.Color.Crimson;
                            }
                            else if (score >= QB2)
                            {
                                e.Row.Cells[i].BackColor = System.Drawing.Color.DarkOrange;
                            }                            
                            else
                            {
                                e.Row.Cells[i].BackColor = System.Drawing.Color.LightSteelBlue;
                            }
                        }
                        break;
                    }
                case "TE":
                    {
                        for (int i = 3; i < e.Row.Cells.Count - 1; i++)
                        {
                            string strScore = e.Row.Cells[i].Text;
                            int.TryParse(strScore, out score);
                            if (score == 0)
                            {
                                e.Row.Cells[i].BackColor = System.Drawing.Color.DarkGray;
                            }
                            else if (score >= TE0)
                            {
                                e.Row.Cells[i].BackColor = System.Drawing.Color.Purple;
                                e.Row.Cells[i].ForeColor = System.Drawing.Color.Red;
                            }
                            else if (score >= TE1)
                            {
                                e.Row.Cells[i].BackColor = System.Drawing.Color.Crimson;
                            }                           
                            else
                            {
                                e.Row.Cells[i].BackColor = System.Drawing.Color.LightSteelBlue;
                            }
                        }
                        break;
                    }
            }
            for (int i = -4; i < -1 ; i++)
            {
                e.Row.Cells[e.Row.Cells.Count + i].BackColor = System.Drawing.Color.White;
                e.Row.Cells[e.Row.Cells.Count + i].ForeColor = System.Drawing.Color.Black;
            }
            //TODO 
            //code total by position




        }

        protected void gvTeam_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTeam.EditIndex = e.NewEditIndex;
            Team myTeam = new Team(ddlTeam.SelectedValue);
            gvTeam.DataSource = myTeam.dtPerformance;
            gvTeam.DataBind();
        }

        protected void btnEditNotes_Click(object sender, EventArgs e)
        {         
            pnlNoteButtons.Visible = true;
            btnEditNotes.Visible = false;
            txtNotes.Enabled = true;
        }

        protected void btnUpdateNotes_Click(object sender, EventArgs e)
        {
            Team myTeam = new Team(ddlTeam.SelectedValue);
            myTeam.PersistNotes(txtNotes.Text, myTeam.ID);
            pnlNoteButtons.Visible = false;
            btnEditNotes.Visible = true;
            txtNotes.Enabled = false;
        }

        protected void btnCancelNotes_Click(object sender, EventArgs e)
        {
            pnlNoteButtons.Visible = false;
            btnEditNotes.Visible = true;
            txtNotes.Enabled = false;
        }

        protected void ddlTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            Team myTeam = new Team(ddlTeam.SelectedValue);
            populateTeamHeader(myTeam);
            populatePerformanceGrid(myTeam);
            lblTeamHeader.Text = myTeam.TeamName;
        }

        protected void OnUpdate(object sender, EventArgs e)
        {
            
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            string minPTS = (row.Cells[21].Controls[0] as TextBox).Text;
            string maxPTS = (row.Cells[22].Controls[0] as TextBox).Text;
            //string playerID = row.Cells[1].Text;
            string playerID = gvTeam.DataKeys[row.RowIndex]["ID"].ToString();
            Team myTeam = new Team(ddlTeam.SelectedValue);
            myTeam.PersistProjectsions(playerID, minPTS, maxPTS);
            Team updatedTeam = new Team(ddlTeam.SelectedValue);
            gvTeam.DataSource = updatedTeam.dtPerformance;
            gvTeam.EditIndex = -1;
            gvTeam.DataBind();        
        }

        protected void OnCancel(object sender, EventArgs e)
        {
            gvTeam.EditIndex = -1;
            Team myTeam = new Team(ddlTeam.SelectedValue);
            gvTeam.DataSource = myTeam.dtPerformance;
            gvTeam.DataBind();
        }
    }
}