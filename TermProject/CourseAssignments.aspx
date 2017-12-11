<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseAssignments.aspx.cs" Inherits="TermProject.CourseAssignments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
            <asp:GridView ID="gvAssignmentStudent" runat="server" AutoGenerateColumns="false" DataKeyNames="AssignmentID" OnRowCommand="gvAssignmentStudent_RowCommand" OnSelectedIndexChanged="gvAssignmentStudent_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="AssignmentID" Visible="false" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="DueDate" HeaderText="Due Date" />
                    <asp:BoundField DataField="MaximumGrade" HeaderText="Maximum" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="FileTitle" HeaderText="Attached File" />
                    <asp:ButtonField runat="server" Text="Download" HeaderText="Attached File" CommandName="Download" ButtonType="Button" />
                    <asp:ButtonField runat="server" Text="Submit" HeaderText="Submit Assignment" CommandName="Submit" ButtonType="Button" />
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblStudentAssgnID" runat="server" Visible="false"></asp:Label>
            <br />
            <br />
    
    </div>
        <div>
    
            <asp:Panel ID="Panel1" runat="server" Visible="False">
                <h2>Submit Assignment</h2>
                <br />
                <asp:FileUpload ID="FileUpload2" runat="server" />
                <asp:Label ID="lblUpload2" runat="server" />
                &nbsp;&nbsp;
                <asp:Button ID="btnSubmitAssgn" runat="server" Text="Submit Assignment" OnClick="btnSubmitAssgn_Click" />
            </asp:Panel>
    
    </div>
    </form>
</body>
</html>
