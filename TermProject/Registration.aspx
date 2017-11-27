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
        <asp:Label ID="lblSFirstName" runat="server" Text="First Name: "></asp:Label>
        <asp:TextBox ID="txtSFirstName" runat="server"></asp:TextBox>
        <asp:Label ID="lblSLastName" runat="server" Text="Last Name: "></asp:Label>
        <asp:TextBox ID="txtSLastName" runat="server"></asp:TextBox>
        <asp:Label ID="lblMajor" runat="server" Text="Major: "></asp:Label>
        <asp:TextBox ID="txtMajor" runat="server"></asp:TextBox>
        <asp:Label ID="lblSUsername" runat="server" Text="Username: "></asp:Label>
        <asp:TextBox ID="txtSUsername" runat="server" Enabled="False"></asp:TextBox>
        <asp:Label ID="lblSPassword" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txtSPassword" runat="server"></asp:TextBox>
        <asp:Button ID="btnStudentSubmit" runat="server" Text="Register" OnClick="btnStudentSubmit_Click" />
    </div>
    <div id="courseBuilderRegister" runat="server" visible="false">
        <h2>Course Builder Registration</h2>
        <asp:Label ID="lblCFirstName" runat="server" Text="First Name: "></asp:Label>
        <asp:TextBox ID="txtCFirstName" runat="server"></asp:TextBox>
        <asp:Label ID="lblCLastName" runat="server" Text="Last Name: "></asp:Label>
        <asp:TextBox ID="txtCLastName" runat="server"></asp:TextBox>
        <asp:Label ID="lblDepartment" runat="server" Text="Department: "></asp:Label>
        <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"></asp:DropDownList>
        <asp:Label ID="lblCUserName" runat="server" Text="Username: "></asp:Label>
        <asp:TextBox ID="txtCUserName" runat="server"></asp:TextBox>
        <asp:Label ID="lblCPassword" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txtCPassword" runat="server"></asp:TextBox>
        <asp:Button ID="btnCBSubmit" runat="server" Text="Register" OnClick="btnCBSubmit_Click" />
    </div>
    <div id="adminRegister" runat="server" visible="false">
        <h2>Administrator Registration</h2>
        <asp:Label ID="lblAFirstName" runat="server" Text="First Name: "></asp:Label>
        <asp:TextBox ID="txtAFirstName" runat="server"></asp:TextBox>
        <asp:Label ID="lblALastName" runat="server" Text="Last Name: "></asp:Label>
        <asp:TextBox ID="txtALastName" runat="server"></asp:TextBox>
        <asp:Label ID="lblAUserName" runat="server" Text="Username: "></asp:Label>
        <asp:TextBox ID="txtAUserName" runat="server"></asp:TextBox>
        <asp:Label ID="lblAPassword" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txtAPassword" runat="server"></asp:TextBox>
        <asp:Button ID="btnAdminSubmit" runat="server" Text="Register" OnClick="btnAdminSubmit_Click" />
    </div>
    <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
</asp:Content>
