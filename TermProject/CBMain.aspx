<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CBMain.aspx.cs" Inherits="TermProject.CBMain" %>

<%@ Register Src="~/ViewCourses.ascx" TagName="ViewCourses" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style type="text/css">
        .auto-style2 {
            color: #FFFFFF;
            background-color: #990000;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="auto-style2">Welcome,
        <asp:Label ID="lblName" runat="server"></asp:Label>
        !</h1>
    <br />
    <br />
    <%--<uc1:ViewCourses ID="gvCourses" runat="server"> </uc1:ViewCourses>--%>
    <uc1:viewCourses runat="server" id="viewCourseButton" />

</asp:Content>
