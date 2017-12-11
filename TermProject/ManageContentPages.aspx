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
            font-size: 35pt;
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
        <h2 style="text-align: center">
            <asp:Label ID="lblName" runat="server" Style="text-align: center"></asp:Label>
        </h2>
        <p class="auto-style2">
            <asp:Button ID="btnManage" runat="server" Text="Manage Content Page" Enabled="False" OnClick="btnManage_Click" />
            &nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Text="Create Content Page" OnClick="Button3_Click" />
            &nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDelete" runat="server" Text="Delete Content Page" />
        </p>
        <asp:Panel ID="Panel1" runat="server" Visible="False">
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
        &nbsp;<asp:Panel ID="Panel2" runat="server">
            <h2>Manage Content Page Details</h2>
            <br />
            Select Page:
            <asp:DropDownList ID="ddlContentPages" runat="server" OnSelectedIndexChanged="ddlContentPages_SelectedIndexChanged" DataTextField="Title" DataValueField="Id" AutoPostBack="True">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAddPost" runat="server" Enabled="False" OnClick="btnAddPost_Click" Text="Add Post" />
            <br />
            <br />
            <div class = "center">
                <asp:GridView ID="gvContentPages" runat="server" OnRowCommand="gvContentPages_RowCommand" OnRowDeleting="gvContentPages_RowDeleting" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvContentPages_SelectedIndexChanged"
                    DataKeyNames="Id" Width="749px" Style="text-align: center">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Id" Visible="false" />
                        <asp:BoundField DataField="Title" HeaderText="Title" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="FileTitle" HeaderText="File Name" />
                        <asp:ButtonField runat="server" Text="Edit" CommandName="Change" ButtonType="Button" />
                        <asp:ButtonField CommandName="Remove" ShowHeader="True" Text="Delete" />
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
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Visible="False">
            <h2>Edit Content Page Details</h2>
            <p>
                Title:
                <asp:TextBox ID="txtEditTitle" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
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
                <asp:Button ID="btnEditCancel" runat="server" Text="Cancel" OnClick="btnEditCancel_Click" />
            </p>
            <p>
                <asp:Label ID="lblEditMessage" runat="server"></asp:Label>
            </p>
            <p>
                &nbsp;
            </p>
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server" Visible="False">
            <h2>Add Content Page Post</h2>
            <p>
                Title:
                <asp:TextBox ID="txtAddTitle" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Label ID="lblAddID" runat="server"></asp:Label>
            </p>
            <p>
                Description:
                <asp:TextBox ID="txtAddDescription" runat="server" Height="111px" TextMode="MultiLine" Width="298px"></asp:TextBox>
            </p>
            <p>
                File:&nbsp;
                <asp:FileUpload ID="FileUpload3" runat="server" />
                &nbsp;&nbsp;
                <asp:Label ID="lblAddFileName" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Button ID="btnAddOK" runat="server" OnClick="btnAddOK_Click" Text="OK" />
                &nbsp;
                <asp:Button ID="btnAddCanel" runat="server" OnClick="btnAddCanel_Click" Text="Cancel" />
            </p>
            <p>
                <asp:Label ID="lblEditMessage0" runat="server"></asp:Label>
            </p>
            <p>
                &nbsp;
            </p>
        </asp:Panel>
        &nbsp;&nbsp;<asp:Panel ID="Panel5" runat="server" Visible="False">
            <h2>Delete Content Page</h2>
            <p>
                <asp:GridView ID="gvContent" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames= "ContentPageID" ForeColor="#333333" GridLines="None" OnRowCommand="gvContent_RowCommand" OnRowDeleting="gvContentPages_RowDeleting" OnSelectedIndexChanged="gvContentPages_SelectedIndexChanged" Style="text-align: center" Width="749px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ContentPageID" Visible="false" />
                        <asp:BoundField DataField="Title" HeaderText="Title" />
                        <asp:ButtonField CommandName="Remove" ShowHeader="True" Text="Delete" />
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
&nbsp;
            </p>
        </asp:Panel>
        &nbsp;
        <div style="text-align: center; margin-left: 120px">
            <asp:Button ID="Back" runat="server" OnClick="Back_Click" Text="Back" />
        </div>
    </form>
</body>
</html>
