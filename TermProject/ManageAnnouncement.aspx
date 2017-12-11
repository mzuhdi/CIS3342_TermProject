<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ManageAnnouncement.aspx.cs" Inherits="TermProject.AddAnnouncement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        .auto-style1 {
            text-align: center;
            color: #FFFFFF;
            background-color: #800000;
        }

        .auto-style2 {
            margin-left: 98px;
        }

        .auto-style3 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">


        <div id="gvAnnoucementDiv" runat="server">
            <h1 class="auto-style1">Manage Annoucements</h1>
            <br />
            <div class="auto-style3">
                <asp:GridView ID="gvAnnoucement" runat="server" AutoGenerateColumns="False" DataKeyNames="AnnoucementID" OnRowCommand="gvAnnoucement_RowCommand"
                    OnRowUpdating="gvAnnoucement_RowUpdating" OnRowDeleting="gvAnnoucement_RowDeleting" CellPadding="4" CssClass="auto-style2" ForeColor="#333333" GridLines="None" Width="1219px" OnSelectedIndexChanged="gvAnnoucement_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="AnnoucementID" HeaderText="AnnouncementID" Visible="false" />
                        <asp:BoundField DataField="FK_CourseID" HeaderText="CourseID" Visible="false" />
                        <asp:BoundField DataField="Title" HeaderText="Title" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="Date" HeaderText="Date" />
                        <asp:ButtonField runat="server" Text="Update" CommandName="Update" ButtonType="Button" />
                        <asp:ButtonField runat="server" Text="Delete" CommandName="Delete" ButtonType="Button" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                <br />
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
            </div>
            <asp:Panel ID="Panel1" runat="server" Visible="False">
                <h2 class="auto-style3">Update Announcement</h2>
                <div class="auto-style3">
                    <asp:Label ID="lblAnnoucementID" runat="server" Visible="false"></asp:Label>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblTitle" runat="server" Text="Title"></asp:Label>
                    :&nbsp;
                    <asp:TextBox ID="txtTitle" runat="server" Width="250px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                    :&nbsp;
                    <asp:TextBox ID="txtDescription" runat="server" Height="106px" TextMode="MultiLine" Width="250px"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update " />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cancel" />
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
