<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="TermProject.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Registration</h1>
    <asp:Label ID="lblUsertype" runat="server" Text="I want to register as "></asp:Label>
    <asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged"></asp:DropDownList>
    <asp:Label ID="lblInvalidKey" runat="server"></asp:Label>
    <div id="studentRegister" runat="server" visible="false">
        <h2>Student Registration</h2>
        <asp:Label ID="lblSFirstName" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtSFirstName" runat="server"></asp:TextBox>
        <asp:Label ID="lblSLastName" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtSLastName" runat="server"></asp:TextBox>
        <asp:Label ID="lblMajor" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtMajor" runat="server"></asp:TextBox>
        <asp:Label ID="lblSUsername" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtSUsername" runat="server"></asp:TextBox>
        <asp:Label ID="lblSPassword" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtSPassword" runat="server"></asp:TextBox>
    </div>
    <div id="courseBuilderRegister" runat="server" visible="false">
        <h2>Course Builder Registration</h2>
        <asp:Label ID="lblCFirstName" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtCFirstName" runat="server"></asp:TextBox>
        <asp:Label ID="lblCLastName" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtCLastName" runat="server"></asp:TextBox>
        <asp:Label ID="lblCUserName" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtCUserName" runat="server"></asp:TextBox>
        <asp:Label ID="lblCPassword" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtCPassword" runat="server"></asp:TextBox>
    </div>
    <div id="adminRegister" runat="server" visible="false">
        <h2>Administrator Registration</h2>
        <asp:Label ID="lblAFirstName" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtAFirstName" runat="server"></asp:TextBox>
        <asp:Label ID="lblALastName" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtALastName" runat="server"></asp:TextBox>
        <asp:Label ID="lblAUserName" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtAUserName" runat="server"></asp:TextBox>
        <asp:Label ID="lblAPassword" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtAPassword" runat="server"></asp:TextBox>
    </div>
</asp:Content>
