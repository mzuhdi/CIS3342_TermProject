<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewCourses.ascx.cs" Inherits="TermProject.ViewCourses" %>

<asp:Label ID="title" runat="server"></asp:Label>

<asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="false" OnRowCommand="gvCourses_RowCommand"
     OnRowUpdating="gvCourses_RowUpdating">
    <Columns>
        <asp:BoundField DataField="CourseCode" HeaderText="Course Code" />
        <asp:BoundField DataField="Name" HeaderText="Name" />
        <asp:BoundField DataField="FK_TermID" HeaderText="Term" />
    </Columns>
</asp:GridView>
