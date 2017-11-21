<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="TermProject.AddCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblInvalidKey" runat="server"></asp:Label>
    <div id="addCourseDiv" runat="server">
        <h1>Add Course</h1>
        <asp:Label ID="lblTerm" runat="server" Text="Select Term: "></asp:Label>
        <asp:DropDownList ID="ddlTerm" runat="server" AutoPostBack="true"></asp:DropDownList>
        <asp:Label ID="lblID" runat="server" Text="Course ID: "></asp:Label>
        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        <asp:Label ID="lblName" runat="server" Text="Course Name: "></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:Label ID="lblCBID" runat="server" visible="false"></asp:Label>
        <asp:Button ID="btnAddCourse" runat="server" Text="Add Course" />
    </div>
    <asp:Label ID="lblSuccess" runat="server"></asp:Label>
</asp:Content>
