<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseAssignments.aspx.cs" Inherits="TermProject.CourseAssignments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }

        .auto-style14 {
            text-align: center;
            background-color: #990000;
        }
        .auto-style15 {
            color: #FFFFFF;
            font-size: 45pt;
            font-weight: normal;
        }

        .auto-style16 {
            margin-left: 520px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
            <div class="auto-style1">
        <h1 class="auto-style14">
            <asp:Label ID="lblName" runat="server" CssClass="auto-style15" Font-Names="Arial"></asp:Label>
        </h1>
                <h2>Assignments</h2>
    
            <asp:GridView ID="gvAssignmentStudent" runat="server" AutoGenerateColumns="False" DataKeyNames="AssignmentID" OnRowCommand="gvAssignmentStudent_RowCommand" OnSelectedIndexChanged="gvAssignmentStudent_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" Height="332px" Width="1100px">
                <AlternatingRowStyle BackColor="White" />
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
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
            </div>
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
        <div class="auto-style16">
            <br />
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>
