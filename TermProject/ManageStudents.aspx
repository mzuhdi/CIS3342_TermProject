<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageStudents.aspx.cs" Inherits="TermProject.ManageStudents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #FFFFFF;
            text-align: center;
            background-color: #990000;
        }
        .auto-style2 {
            margin-left: 33px;
        }
        .auto-style3 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h1 class="auto-style1">Manage Students</h1>

        </div>
        <h2 class="auto-style3">Students Enrolled</h2>
        <p>
            <div class="auto-style3">
            <asp:GridView ID="gvStudents" runat="server" DataKeyNames ="StudentID" OnRowCommand="gvStudents_RowCommand" OnRowUpdating="gvStudents_RowUpdating" OnSelectedIndexChanged="gvStudents_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="4" CssClass="auto-style2" ForeColor="#333333" GridLines="None" Width="1284px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="Username" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="Major" HeaderText="Major" />
                    <asp:BoundField DataField="StudentID" HeaderText="StudentID" Visible ="true" />
                    <asp:ButtonField runat="server" Text="Email" CommandName="Email" ButtonType="Button" />
                    <asp:ButtonField runat="server" Text="Remove" CommandName="Remove" ButtonType="Button" />
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
            <asp:Label ID="lblStudentError" runat="server"></asp:Label>
        </p>
        <p class="auto-style3">
            <asp:Button ID="btnAddStudents" runat="server" Text="Add Students" OnClick="btnAddStudents_Click" />
            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnEmailAll" runat="server" OnClick="Button1_Click" Text="Email All Students" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </p>
        <asp:Panel ID="PanelAddStudents" runat="server" Visible="False">
            <h2 class="auto-style3">Add Student(s)</h2>
            <div class="auto-style3">
                <asp:GridView ID="gvSearch" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="auto-style2" DataKeyNames="StudentID" ForeColor="#333333" GridLines="None" Width="1286px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Username" HeaderText="Username" />
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                        <asp:BoundField DataField="Major" HeaderText="Major" />
                        <asp:BoundField DataField="StudentID" HeaderText="StudentID" Visible="false" />
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
            <div class="auto-style3">
                <br />
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Close" />
                <br />
            </div>
            <h2>&nbsp;</h2>
        </asp:Panel>
        <p>
        </p>
    </form>
</body>
</html>