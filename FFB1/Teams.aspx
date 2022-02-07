<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Teams.aspx.cs" Inherits="FFB1.Teams" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h2>Team Analysis:
            <asp:Label ID="lblTeamHeader" runat="server" /></h2>
        <div class="col-md-4">
            <strong>Team: </strong>
            <asp:DropDownList ID="ddlTeam" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTeam_SelectedIndexChanged" >
            </asp:DropDownList>

        </div>
        <div class="col-md-4">
            <strong>Scoring System: </strong>
            <asp:DropDownList ID="ddlScoring" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlScoring_SelectedIndexChanged">
                <asp:ListItem Text="TD Only" Value="TD" />
                <asp:ListItem Text="1/2 Pt PPR" Value="Half" />
                <asp:ListItem Text="PPR" Value="PPR" />
            </asp:DropDownList>
        </div>
    </div>
    <div style="padding-top: 10px;" class="row">
        <asp:GridView ID="gvTeam" runat="server" CssClass="table table-striped bg-primary"
            OnRowDataBound="gvTeam_RowDataBound" OnRowEditing="gvTeam_RowEditing" AutoGenerateColumns="false" DataKeyNames="ID" >
            <Columns>
                <asp:BoundField DataField="PLAYER" HeaderText="PLAYER"  ReadOnly="true" />              
                <asp:BoundField DataField="POS" HeaderText="POS" ReadOnly="true" />
                <asp:BoundField DataField="S" HeaderText="S" ReadOnly="true"/>
                <asp:BoundField DataField="W1" HeaderText="W1" ReadOnly="true" />
                <asp:BoundField DataField="W2" HeaderText="W2" ReadOnly="true"/>
                <asp:BoundField DataField="W3" HeaderText="W3" ReadOnly="true"/>
                <asp:BoundField DataField="W4" HeaderText="W4" ReadOnly="true" />
                <asp:BoundField DataField="W5" HeaderText="W5" ReadOnly="true" />
                <asp:BoundField DataField="W6" HeaderText="W6" ReadOnly="true" />
                <asp:BoundField DataField="W7" HeaderText="W7" ReadOnly="true" />
                <asp:BoundField DataField="W8" HeaderText="W8" ReadOnly="true" />
                <asp:BoundField DataField="W9" HeaderText="W9" ReadOnly="true" />
                <asp:BoundField DataField="W10" HeaderText="W10"  ReadOnly="true" />
                <asp:BoundField DataField="W11" HeaderText="W11"  ReadOnly="true" />
                <asp:BoundField DataField="W12" HeaderText="W12" ReadOnly="true"  />
                <asp:BoundField DataField="W13" HeaderText="W13" ReadOnly="true"  />
                <asp:BoundField DataField="W14" HeaderText="W14" ReadOnly="true"  />
                <asp:BoundField DataField="W15" HeaderText="W15" ReadOnly="true"  />
                <asp:BoundField DataField="W16" HeaderText="W16" ReadOnly="true" />
                <asp:BoundField DataField="W17" HeaderText="W17" ReadOnly="true"  />
                <asp:BoundField DataField="TOT" HeaderText="TOT" ReadOnly="true"  />
                <asp:BoundField DataField="MIN" HeaderText="MIN" ItemStyle-Width="50" />
                <asp:BoundField DataField="MAX" HeaderText="MAX" ItemStyle-Width="50" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Edit" runat="server" CommandName="Edit" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton Text="Update" runat="server" OnClick="OnUpdate" />
                        <asp:LinkButton Text="Cancel" runat="server" OnClick="OnCancel" />
                    </EditItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
    <div style="float:left;">
        <span style="background-color:purple;color:red;"> RB0 </span> 
        <span style="background-color:crimson;"> RB1 </span> 
        <span style="background-color:darkorange;"> RB2 </span> 
        <span style="background-color:khaki"> RB3 </span> 
        
        <span style="background-color:purple;color:red;"> WR0 </span> 
        <span style="background-color:crimson;"> WR1 </span> 
        <span style="background-color:darkorange;"> WR2 </span> 
        <span style="background-color:khaki"> WR3 </span> 

        <span style="background-color:purple;color:red;"> QB0 </span> 
        <span style="background-color:crimson;"> QB1 </span> 
        <span style="background-color:darkorange;"> QB2 </span> 
        RB1:22 RB2:16 WR1:19 WR2:13
    </div>
    <div style="float: right;">
        <strong>Team Notes: </strong>
        <asp:TextBox TextMode="MultiLine" Height="75px" Width="450px" ID="txtNotes" runat="server" Enabled="false" />
        <asp:Button ID="btnEditNotes" runat="server" Text="Edit" OnClick="btnEditNotes_Click" />
        <asp:Panel ID="pnlNoteButtons" runat="server" Visible="false">
            <asp:Button ID="btnUpdateNotes" runat="server" Text="Update" OnClick="btnUpdateNotes_Click" />
            <asp:Button ID="btnCancelNotes" runat="server" Text="Cancel" OnClick="btnCancelNotes_Click" />
        </asp:Panel>
    </div>
    <div style="float: none;"></div>

    <script src="Scripts/Chart.min.js"></script>   

    <div style="width:300px;height:300px;">
        <canvas id="myChart"></canvas>
    </div>

    <script>

        var ctx = document.getElementById('myChart').getContext('2d');
        var myChart = new Chart(ctx, {
            type: 'pie',
            data: {
                labels: ['RB', 'WR', 'TE', 'QB'],
                datasets: [{
                    label: 'Scoring',
                    data: [12, 19, 3, 5],
                    backgroundColor: [
                        'rgba(235, 0, 0, 0.8)',
                        'rgba(54, 162, 235, 0.8)',
                        'rgba(75, 192, 192, 0.8)',
                        'rgba(255, 159, 64, 0.8)'
                    ],
                    borderColor: [
                        'rgba(235, 0, 0, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(255, 159, 64, 1)'
                    ],
                    borderWidth: 1
                }]
            },
            options: {
                scales: {
                    yAxes: [{

                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });
    </script>
</asp:Content>
