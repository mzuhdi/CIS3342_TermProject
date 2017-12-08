<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="TermProject.AddCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblInvalidKey" runat="server"></asp:Label>
    <h1>Add/Manage Course</h1>
    <asp:Label ID="lblTerm" runat="server" Text="Select Term: "></asp:Label>
    <asp:DropDownList ID="ddlTerm" runat="server" AutoPostBack="true"></asp:DropDownList>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    <div id="addCourseDiv" runat="server" visible="false">
        <h2>Add Course</h2>
        <asp:Label ID="lblCCode" runat="server" Text="Course Code: "></asp:Label>
        <asp:TextBox ID="txtCCode" runat="server"></asp:TextBox>
        <asp:Label ID="lblName" runat="server" Text="Course Name: "></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:Label ID="lblCBID" runat="server" Text="Course Builder: "></asp:Label>
        <asp:DropDownList ID="ddlCB" runat="server" AutoPostBack="true"></asp:DropDownList>
        <asp:Button ID="btnAddCourse" runat="server" Text="Add Course" OnClick="btnAddCourse_Click" />
    </div>
    <div id="ManageCourseDiv" runat="server" visible="false">
        <h2>Manage Course</h2>
        <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="false"
            OnRowCommand="gvCourses_RowCommand" OnRowUpdating="gvCourses_RowUpdating" DataKeyNames="CourseID" OnRowDeleting="gvCourses_RowDeleting">
            <Columns>
                <asp:BoundField DataField="CourseID" HeaderText="CourseID" Visible="false" />
                <asp:BoundField DataField="CourseCode" HeaderText="Course Code" ReadOnly="true" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:ButtonField runat="server" Text="Update Course" HeaderText="Update Course" CommandName="Update" ButtonType="Button" />
                <asp:ButtonField runat="server" Text="Delete Course" HeaderText="Delete Course" CommandName="Delete" ButtonType="Button" />
                <asp:ButtonField runat="server" Text="Manage Student" HeaderText="Manage Students" CommandName="Manage Students" ButtonType="Button" />
            </Columns>
        </asp:GridView>
        <div id="ManageCourseFormDiv" runat="server" visible="false">
            <asp:Label ID="lblCourseID" runat="server"></asp:Label> 
            <asp:Label ID="lblCCodeUpdate" runat="server" Text="Course Code: "></asp:Label>
            <asp:TextBox ID="txtCCodeUpdate" runat="server"></asp:TextBox>
            <asp:Label ID="lblCNameUpdate" runat="server" Text="Course Name: "></asp:Label>
            <asp:TextBox ID="txtNameUpdate" runat="server"></asp:TextBox>
            <asp:Button ID="btnUpdate" runat="server" Text="Update Course" OnClick="btnUpdate_Click" />
        </div>
    </div>
    <asp:Label ID="lblSuccess" runat="server"></asp:Label>
</asp:Content>
