<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="TermProject.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ID="ddlUserType" runat="server"></asp:DropDownList>
    <div id="studentRegister" runat="server" visible="false">
        <h2>Student Registration</h2>
        <asp:Label ID="lblFirstName" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        <asp:Label ID="lblLastName" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        <asp:Label ID="" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </div>
    <div id="courseBuilderRegister" runat="server" visible="false"></div>
    <div id="adminRegister" runat="server" visible="false"></div>
</asp:Content>
