<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageAssignments.aspx.cs" Inherits="TermProject.ManageAssignments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    
    
    
    
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: center;
            background-color: #FFFFFF;
        }
        .auto-style3 {
            text-align: center;
            color: #FFFFFF;
            background-color: #990000;
        }
        .auto-style4 {
            text-align: center;
            margin-left: 40px;
        }
    </style>
    
    
    
    
    
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="auto-style3">Manage Assignments</h1>
        <br />
        <div class="auto-style2">
            <asp:Button ID="btnNewAssignment" runat="server" Text="New Assignment" EnableTheming="True" Enabled="False" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnGradeAssignments" runat="server" Text="Grade Assignments" OnClick="btnGradeAssignments_Click" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Manage Assignments" />
        </div>
        <asp:Panel ID="newAssignment" runat="server">
            <h2>New Assignment</h2>
            <p>
                Title:
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </p>
            <p>
                Due Date:
                <asp:Calendar ID="calendarDueDate" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="381px">
                    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                    <OtherMonthDayStyle ForeColor="#CC9966" />
                    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                    <SelectorStyle BackColor="#FFCC66" />
                    <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                    <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                </asp:Calendar>
            </p>
            <p>
                Maximum Grade:
                <asp:TextBox ID="txtMaxGrade" runat="server"></asp:TextBox>
                &nbsp;&nbsp; Description:
                <asp:TextBox ID="txtDescription" runat="server" Width="222px"></asp:TextBox>
                &nbsp; Select file:&nbsp;
                <asp:FileUpload ID="FileUpload1" runat="server" />
                &nbsp;
                <asp:Label ID="lblUpload" runat="server" />
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" Text="Create Assignment" Width="179px" OnClick="btnSubmit_Click" />
                &nbsp;
                <asp:Label ID="lblSuccess" runat="server"></asp:Label>
            </p>
        </asp:Panel>
        <asp:Panel ID="panManageAssignment" runat="server" Visible="False">
            <div class="auto-style4">
                <asp:GridView ID="gvAssignmentCB" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="AssignmentID" ForeColor="#333333" GridLines="None" OnRowCommand="gvAssignment_RowCommand" OnRowDeleting="gvAssignment_RowDeleting" Width="1058px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="AssignmentID" Visible="false" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="DueDate" HeaderText="Due Date" />
                        <asp:BoundField DataField="MaximumGrade" HeaderText="Maximum" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="FileTitle" HeaderText="Attached File" />
                        <asp:ButtonField runat="server" ButtonType="Button" CommandName="Delete" HeaderText="Delete Assignment" Text="Delete Assignment" />
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
                <br />
            </div>
        </asp:Panel>
        <asp:Panel ID="paGradeAssignments" runat="server" Visible="False">
            <div id="gvAssignmentCBDiv" runat="server">
                <h2>Grade Assignments</h2>
                <p>
                    Select Assignment:
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                </p>
            </div>
            <br />
            <div id="gvCBGradeDiv" runat="server">
                <h2>Submitted Assignment</h2>
                <div class="auto-style4">
                    <asp:GridView ID="gvCBGrade" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="GradeID" ForeColor="#333333" GridLines="None" OnRowCommand="gvCBGrade_RowCommand" OnSelectedIndexChanged="gvCBGrade_SelectedIndexChanged" Width="1058px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="GradeID" Visible="false" />
                            <asp:BoundField DataField="FK_StudentID" HeaderText="StudentID" />
                            <asp:BoundField DataField="FileTitle" HeaderText="Attached File" />
                            <asp:BoundField DataField="Grade" HeaderText="Grade" />
                            <asp:ButtonField runat="server" ButtonType="Button" CommandName="Download" HeaderText="Attached File" Text="Download" />
                            <asp:ButtonField runat="server" ButtonType="Button" CommandName="Grade" HeaderText="Grade Assignment" Text="Grade" />
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
                <asp:Label ID="lblGradeID" runat="server" Visible="false"></asp:Label>
            </div>
            <div id="GradeForm" runat="server" visible="false">
                <asp:Label ID="lblGrade" runat="server" Text="Grade: "></asp:Label>
                <asp:TextBox ID="txtGrade" runat="server" TextMode="Number"></asp:TextBox>
                &nbsp;
                <asp:Button ID="btnSubmit0" runat="server" OnClick="btnSubmit0_Click1" Text="Submit" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                <asp:Label ID="lblSuccess0" runat="server"></asp:Label>
            </div>
            <br />
        </asp:Panel>
    </form>
</body>
</html>
