<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="StudentMain.aspx.cs" Inherits="TermProject.StudentMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblSuccess" runat="server"></asp:Label>
    <div id="myGradesTool" runat="server">
        <asp:DropDownList ID="courses" runat="server" AutoPostBack="true">
        </asp:DropDownList>

        <asp:GridView ID="gvGrades" runat="server">

        </asp:GridView>
    </div>
</asp:Content>
