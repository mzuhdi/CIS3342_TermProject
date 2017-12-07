<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Announcement.aspx.cs" Inherits="TermProject.AddAnnouncement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="gvAnnoucementDiv" runat="server">
        <h1>Annoucement</h1>
        <asp:GridView ID="gvAnnoucement" runat="server" AutoGenerateColumns="false" DataKeyNames="AnnoucementID" OnRowCommand="gvAnnoucement_RowCommand"
            OnRowUpdating="gvAnnoucement_RowUpdating" OnRowDeleting="gvAnnoucement_RowDeleting">
            <Columns>
                <asp:BoundField DataField="AnnoucementID" HeaderText="AnnouncementID" Visible="false" />
                <asp:BoundField DataField="FK_CourseID" HeaderText="CourseID" Visible="false" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:ButtonField runat="server" Text="Update Annoucement" HeaderText="Update Annoucement" CommandName="Update" ButtonType="Button" />
                <asp:ButtonField runat="server" Text="Delete Annoucement" HeaderText="Delete Annoucement" CommandName="Delete" ButtonType="Button" />
            </Columns>
        </asp:GridView>
    </div>
    <div id="AddAnnoucement" runat="server">
        <h1 id="h1Add" runat="server">Add Annoucement</h1>
        <h1 id="h1Manage" runat="server" visible="false">Manage Annoucement</h1>
        <asp:Label ID="lblAnnoucementID" runat="server" Visible="false"></asp:Label>
        <br />
        <asp:Label ID="lblTitle" runat="server" Text="Title: "></asp:Label>
        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
        <br />
        <asp:CheckBox ID="cbEmail" runat="server" Text="Email to all Student" />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update " OnClick="btnUpdate_Click" Visible="false"/>
        <asp:Label ID="lblSuccess" runat="server"></asp:Label>
    </div>
</asp:Content>
