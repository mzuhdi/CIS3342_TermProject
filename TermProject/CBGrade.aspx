<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CBGrade.aspx.cs" Inherits="TermProject.CBGrade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gradebook</h1>
    <div id="gvAssignmentCBDiv" runat="server">
            <h2>Assignment</h2>
            <asp:GridView ID="gvAssignmentCB" runat="server" AutoGenerateColumns="false" DataKeyNames="AssignmentID" OnSelectedIndexChanged="gvAssignmentCB_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="AssignmentID" Visible="false" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="DueDate" HeaderText="Due Date" />
                    <asp:BoundField DataField="MaximumGrade" HeaderText="Maximum Grade" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                </Columns>
            </asp:GridView>
        </div>
    <br />
        <div id="gvCBGradeDiv" runat="server">
            <h2>Submitted Assignment</h2>
            <asp:GridView ID="gvCBGrade" runat="server" AutoGenerateColumns="false" DataKeyNames="GradeID" OnRowCommand="gvCBGrade_RowCommand">
                <Columns>
                    <asp:BoundField DataField="GradeID" Visible="false" />
                    <asp:BoundField DataField="FK_StudentID" HeaderText="StudentID" />
                    <asp:BoundField DataField="FileTitle" HeaderText="Attached File" />
                    <asp:BoundField DataField="Grade" HeaderText="Grade" />
                    <asp:ButtonField runat="server" Text="Download" HeaderText="Attached File" CommandName="Download" ButtonType="Button" />
                    <asp:ButtonField runat="server" Text="Grade" HeaderText="Grade Assignment" CommandName="Grade" ButtonType="Button" />
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblGradeID" runat="server" Visible="false"></asp:Label>
        </div>
    <div id="GradeForm" runat="server" visible="false">
        <asp:Label ID ="lblGrade" runat="server" Text="Grade: "></asp:Label>
        <asp:Textbox ID="txtGrade" runat="server" TextMode="Number"></asp:Textbox> 
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <asp:Label ID="lblSuccess" runat="server"></asp:Label>
    </div>
</asp:Content>
