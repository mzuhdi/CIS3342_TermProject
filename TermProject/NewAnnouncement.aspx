<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewAnnouncement.aspx.cs" Inherits="TermProject.NewAnnouncement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #FFFFFF;
        }
        #TextArea1 {
            height: 113px;
            width: 296px;
        }
        #txtDescription {
            height: 109px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1 class="auto-style1" style="text-align: center; background-color: #990000">New Annoucement</h1>
    
    </div>
        <h2>
            <asp:Label ID="lblName" runat="server" style="font-weight: 700"></asp:Label>
        </h2>
        <p>
            Title:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtTitle" runat="server" Width="214px"></asp:TextBox>
        </p>
        <p>
            Description:
            <asp:TextBox ID="txtDescription" runat="server" Height="86px" TextMode="MultiLine"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
        </p>
        <p>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
