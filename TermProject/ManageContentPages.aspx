<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageContentPages.aspx.cs" Inherits="TermProject.ManageContentPages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            color: #FFFFFF;
            background-color: #800000;
        }

        .auto-style2 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div>

            <h1 class="auto-style1">Manage Content Pages</h1>

        </div>
        <h2>
            <asp:Label ID="lblName" runat="server"></asp:Label>
        </h2>
        <p class="auto-style2">
            <asp:Button ID="Button3" runat="server" Text="Create Content Page" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" Text="Edit Content Page" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button5" runat="server" Text="Delete Content Page" />
        </p>
        <asp:Panel ID="Panel1" runat="server">
            <h2>New Content Page</h2>
            <p>
                Content Page Name:
                <asp:TextBox ID="txtPageName" runat="server"></asp:TextBox>
            </p>
            <p>
                Post Title:
                <asp:TextBox ID="txtPostTitle" runat="server"></asp:TextBox>
            </p>
            <p>
                Description:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtDescription" runat="server" Height="111px" TextMode="MultiLine" Width="298px"></asp:TextBox>
            </p>
            <p>
                File:&nbsp;
                <asp:FileUpload ID="FileUpload1" runat="server" />
                &nbsp;&nbsp;
                <asp:Label ID="lblFileName" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="Back" OnClick="Button2_Click" />
            </p>
            <p>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </p>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <h2>Manage Content Page Details</h2>
            <br />
            Select Page:
            <asp:DropDownList ID="ddlContentPages" runat="server" OnSelectedIndexChanged="ddlContentPages_SelectedIndexChanged" DataTextField="Title" DataValueField="Id" AutoPostBack="True" >
            </asp:DropDownList>
            <br />
            <br />
            <asp:GridView ID="gvContentPages" runat="server" OnRowCommand="gvContentPages_RowCommand" OnRowDeleting="gvContentPages_RowDeleting" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvContentPages_SelectedIndexChanged"
                          DataKeyNames="Id">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Id" Visible="false" />
                    <asp:BoundField DataField="Title" HeaderText="Title"/>
                    <asp:BoundField DataField="Description" HeaderText="Description"/>
                    <asp:BoundField DataField="FileTitle" HeaderText="File Name"/>
                    <asp:ButtonField runat="server" Text="Edit" CommandName="Change" ButtonType="Button" />
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
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server">
            <h2>Edit Content Page Details</h2>
            <p>
                Title:
                <asp:TextBox ID="txtEditTitle" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Label ID="lblId" runat="server"></asp:Label>
            </p>
            <p>
                Description:
                <asp:TextBox ID="txtEditDescription" runat="server" Height="111px" TextMode="MultiLine" Width="298px"></asp:TextBox>
            </p>
            <p>
                File:&nbsp;
                <asp:FileUpload ID="FileUpload2" runat="server" />
                &nbsp;&nbsp;
                <asp:Label ID="lblEditFileName" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="OK" />
                &nbsp;
                <asp:Button ID="btnEditCancel" runat="server" Text="Cancel" />
            </p>
            <p>
                <asp:Label ID="lblEditMessage" runat="server"></asp:Label>
            </p>
            <p>
                &nbsp;</p>
        </asp:Panel>
    </form>
</body>
</html>
