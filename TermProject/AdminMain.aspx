<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminMain.aspx.cs" Inherits="TermProject.AdminMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblSuccess" runat="server"></asp:Label>
    <asp:Label ID="lblInvalidKey" runat="server"></asp:Label>
    <div id="Admin" runat="server" visible="false">
        <h1>Blackboard Administrator</h1>
        <asp:Label ID="lblTerm" runat="server" Text="Select Term: "></asp:Label>
        <asp:DropDownList ID="ddlTerm" runat="server" AutoPostBack="true"></asp:DropDownList>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
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
        <h2>Courses</h2>
        <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="CourseID" HeaderText="CourseID" Visible="false" />
                <asp:BoundField DataField="CourseCode" HeaderText="Course Code" ReadOnly="true" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="FK_TermID" HeaderText="Term" />
            </Columns>
        </asp:GridView>
     </div>
    <asp:Label ID="lblCreated" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnReturn" runat="server" Text="Return to Login" OnClick="btnReturn_Click" />
</asp:Content>
