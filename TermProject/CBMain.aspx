<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CBMain.aspx.cs" Inherits="TermProject.CBMain" %>

<%@ Register Src="~/ViewCourses.ascx" TagName="ViewCourses" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblSuccess" runat="server"></asp:Label>
    <uc1:ViewCourses ID="gvCourses" runat="server"> </uc1:ViewCourses>
</asp:Content>
