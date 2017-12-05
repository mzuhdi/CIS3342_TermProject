<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AssignmentPage.aspx.cs" Inherits="TermProject.AssignmentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="CreateAssignmentDiv" runat="server">
        <h1>Create Assignment</h1>
        <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:Label ID="lblDueDate" runat="server" Text="Due Date:"></asp:Label>
        <asp:Calendar ID="calendarDueDate" runat="server"></asp:Calendar>
        <asp:Label ID="lblMaximumGrade" runat="server" Text="Maximum Grade: "></asp:Label>
        <asp:TextBox ID="txtMaxGrade" runat="server" TextMode="Number"></asp:TextBox>
        <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" Text="Create Assignment" OnClick="btnSubmit_Click" />
        <asp:Label ID="lblSuccess" runat="server" ></asp:Label>
    </div>

</asp:Content>
