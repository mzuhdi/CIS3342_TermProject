<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="TermProject.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            color: #FFFFFF;
            background-color: #990000;
        }
        .auto-style2 {
            font-size: larger;
        }
        .auto-style4 {
            background-color: #CCCCCC;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="auto-style1">New Account</h1>
    <br />
    <asp:Label ID="lblUsertype" runat="server" Text="User type:"></asp:Label>
    &nbsp;<asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged"></asp:DropDownList>
    <asp:Label ID="lblInvalidKey" runat="server"></asp:Label>
    <div id="studentRegister" runat="server" visible="false" class="text-center">
        <h2 class="auto-style4">Student Registration</h2>
        <div class="text-center">
            <span class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblSFirstName" runat="server" Text="First Name: "></asp:Label>
            </span>
        <asp:TextBox ID="txtSFirstName" runat="server" CssClass="auto-style2"></asp:TextBox>
            <span class="auto-style2">&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblSLastName" runat="server" Text="Last Name: "></asp:Label>
            </span>
        <asp:TextBox ID="txtSLastName" runat="server" CssClass="auto-style2"></asp:TextBox>
            <span class="auto-style2">&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMajor" runat="server" Text="Major: "></asp:Label>
            </span>
        <asp:TextBox ID="txtMajor" runat="server" CssClass="auto-style2"></asp:TextBox>
            <span class="auto-style2">
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblSUsername" runat="server" Text="Username: "></asp:Label>
            </span>
        <asp:TextBox ID="txtSUsername" runat="server" Enabled="False" CssClass="auto-style2"></asp:TextBox>
            <span class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblSPassword" runat="server" Text="Password: "></asp:Label>
            </span>
        <asp:TextBox ID="txtSPassword" runat="server" CssClass="auto-style2"></asp:TextBox>
            <span class="auto-style2">&nbsp;&nbsp;&nbsp;
            <br />
            <br />
&nbsp;&nbsp;&nbsp; </span>
        <asp:Button ID="btnStudentSubmit" runat="server" Text="Register" OnClick="btnStudentSubmit_Click" CssClass="auto-style2" />
        </div>
    </div>
    <div id="courseBuilderRegister" runat="server" visible="false" class="text-center">
        <h2 class="auto-style4">Course Builder Registration</h2>
        <div class="text-center">
            <span class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCFirstName" runat="server" Text="First Name: "></asp:Label>
            </span>
        <asp:TextBox ID="txtCFirstName" runat="server" CssClass="auto-style2"></asp:TextBox>
            <span class="auto-style2">&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCLastName" runat="server" Text="Last Name: "></asp:Label>
            </span>
        <asp:TextBox ID="txtCLastName" runat="server" CssClass="auto-style2"></asp:TextBox>
            <span class="auto-style2">&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblDepartment" runat="server" Text="Department: "></asp:Label>
            </span>
        <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" CssClass="auto-style2"></asp:DropDownList>
            <span class="auto-style2">
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCUserName" runat="server" Text="Username: "></asp:Label>
            </span>
        <asp:TextBox ID="txtCUserName" runat="server" CssClass="auto-style2"></asp:TextBox>
            <span class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCPassword" runat="server" Text="Password: "></asp:Label>
            </span>
        <asp:TextBox ID="txtCPassword" runat="server" CssClass="auto-style2"></asp:TextBox>
            <span class="auto-style2">
            <br />
            <br />
&nbsp;&nbsp;&nbsp; </span>
        <asp:Button ID="btnCBSubmit" runat="server" Text="Register" OnClick="btnCBSubmit_Click" CssClass="auto-style2" />
        </div>
    </div>
    <div id="adminRegister" runat="server" visible="false" class="text-center">
        <h2 class="auto-style4">Administrator Registration</h2>
        <div class="text-center">
        <asp:Label ID="lblAFirstName" runat="server" Text="First Name: " CssClass="auto-style2"></asp:Label>
        <asp:TextBox ID="txtAFirstName" runat="server" CssClass="auto-style2"></asp:TextBox>
            <span class="auto-style2">&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblALastName" runat="server" Text="Last Name: "></asp:Label>
            </span>
        <asp:TextBox ID="txtALastName" runat="server" CssClass="auto-style2"></asp:TextBox>
            <span class="auto-style2">
            <br />
            <br />
            <br />
&nbsp;<asp:Label ID="lblAUserName" runat="server" Text="Username: "></asp:Label>
            </span>
        <asp:TextBox ID="txtAUserName" runat="server" CssClass="auto-style2"></asp:TextBox>
            <span class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblAPassword" runat="server" Text="Password: "></asp:Label>
            </span>
        <asp:TextBox ID="txtAPassword" runat="server" CssClass="auto-style2"></asp:TextBox>
            <span class="auto-style2">
            <br />
            <br />
            </span>
        <asp:Button ID="btnAdminSubmit" runat="server" Text="Register" OnClick="btnAdminSubmit_Click" CssClass="auto-style2" />
        </div>
    </div>
    <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnReturn" runat="server" Text="Return to Login" OnClick="btnReturn_Click" />
</asp:Content>
