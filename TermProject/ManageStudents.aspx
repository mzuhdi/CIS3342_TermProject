<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageStudents.aspx.cs" Inherits="TermProject.ManageStudents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h1>Manage Students</h1>

        </div>
        <h2>Students Enrolled</h2>
        <p>
            <asp:GridView ID="gvStudents" runat="server" DataKeyNames ="StudentID" OnRowCommand="gvStudents_RowCommand" OnRowUpdating="gvStudents_RowUpdating" OnSelectedIndexChanged="gvStudents_SelectedIndexChanged" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="Username" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="Major" HeaderText="Major" />
                    <asp:BoundField DataField="StudentID" HeaderText="StudentID" Visible ="true" />
                    <asp:ButtonField runat="server" Text="Email Student" CommandName="Email" ButtonType="Button" />
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblStudentError" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btnAddStudents" runat="server" Text="Add Students" OnClick="btnAddStudents_Click" />
            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnEmailAll" runat="server" OnClick="Button1_Click" Text="Email All Students" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        </p>
        <asp:Panel ID="PanelAddStudents" runat="server" Visible="False">
            <h2>Add Student(s)</h2>
            <p>
                Username:
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="Search" />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblSearchError" runat="server"></asp:Label>
            </p>
            <asp:GridView ID="gvSearch" runat="server" AutoGenerateColumns="false" DataKeyNames="StudentID">
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                         <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                         </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Username" HeaderText="Username" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="Major" HeaderText="Major" />
                    <asp:BoundField DataField="StudentID" HeaderText="StudentID" Visible ="false" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" />
            <br />
            <h2>&nbsp;</h2>
        </asp:Panel>
        <p>
        </p>
    </form>
</body>
</html>