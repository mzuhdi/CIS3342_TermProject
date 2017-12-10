<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AssignmentPage.aspx.cs" Inherits="TermProject.AssignmentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="CreateAssignmentDiv" runat="server" visible="true">
        <h1>Create Assignment</h1>
        <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:Label ID="lblDueDate" runat="server" Text="Due Date:"></asp:Label>
        <asp:Calendar ID="calendarDueDate" runat="server"></asp:Calendar>
        <asp:Label ID="lblMaximumGrade" runat="server" Text="Maximum Grade: "></asp:Label>
        <asp:TextBox ID="txtMaxGrade" runat="server" TextMode="Number"></asp:TextBox>
        <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" Text="Create Assignment" OnClick="btnSubmit_Click" />
        <asp:Label ID="lblSuccess" runat="server"></asp:Label>
    </div>
    <div id="upload" runat="server" visible="true">
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Label ID="lblUpload" runat="server" />
        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Visible="false" />
    </div>
    <div id="gvAssignmentCBDiv" runat="server">
        <h2>Assignments</h2>
        <asp:GridView ID="gvAssignmentCB" runat="server" AutoGenerateColumns="false" DataKeyNames="AssignmentID" OnRowCommand="gvAssignment_RowCommand"
             OnRowDeleting="gvAssignment_RowDeleting">
            <Columns>
                <asp:BoundField DataField="AssignmentID" Visible="false" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="DueDate" HeaderText="Due Date"/>
                <asp:BoundField DataField="MaximumGrade" HeaderText="Maximum" />
                <asp:BoundField DataField="Description" HeaderText="Description"/>
                <asp:BoundField DataField="FileTitle" HeaderText="Attached File"/>
                <asp:ButtonField runat="server" Text="Delete Course" HeaderText="Delete Course" CommandName="Delete" ButtonType="Button" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblAssgnID" runat="server" Visible="false"></asp:Label>
        <asp:Button ID="btnDownload" runat="server" Text="download" OnClick="btnDownload_Click" />
    </div>
    <div = "gvAssignmentStudentDiv" runat="server">
        <asp:GridView ID="gvAssignmentStudent" runat="server" AutoGenerateColumns="false" DataKeyNames="AssignmentID" OnRowCommand="gvAssignmentStudent_RowCommand" OnSelectedIndexChanged="gvAssignmentStudent_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="AssignmentID" Visible="false" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="DueDate" HeaderText="Due Date"/>
                <asp:BoundField DataField="MaximumGrade" HeaderText="Maximum" />
                <asp:BoundField DataField="Description" HeaderText="Description"/>
                <asp:BoundField DataField="FileTitle" HeaderText="Attached File"/>
                <asp:ButtonField runat="server" Text="Download" HeaderText="Attached File" CommandName="Download" ButtonType="Button" />
                <asp:ButtonField runat="server" Text="View" HeaderText="Submit Assignment" CommandName="View" ButtonType="Button" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
    </div>
</asp:Content>
