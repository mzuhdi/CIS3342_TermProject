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
        <h2>Studnets Enrolled</h2>
        <p>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <asp:Label ID="lblStudentError" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btnAddStudents" runat="server" Text="Add Students" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        </p>
        <asp:Panel ID="PanelAddStudents" runat="server">
            <h2>Add Student(s)</h2>
            <p>
                Major:
                <asp:DropDownList ID="ddlMajor" runat="server" OnSelectedIndexChanged="ddlMajor_SelectedIndexChanged">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp; Username:
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
                    <asp:BoundField DataField="StudentID" HeaderText="StudentID" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnClose" runat="server" Text="Close" />
            <br />
            <h2>&nbsp;</h2>
        </asp:Panel>
        <p>
        </p>
    </form>
</body>
</html>