<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="E-Mail.aspx.cs" Inherits="TermProject.E_Mail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        table { border-width: 0;
            width: 639px;
        }
        tr { vertical-align: top; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <h1>Email</h1>
   
        <table>
            <tr>
                <td>From: </td>
                <td><asp:TextBox ID="txtEmailFROM" runat="server" Height="22px" Width="200px" /></td>
            </tr>
            <tr>
                <td>To: </td>
                <td><asp:TextBox ID="txtEmailTO" runat="server" Height="22px" Width="324px" /></td>
            </tr>
            <tr>
                <td>Subject: </td>
                <td><asp:TextBox ID="txtSubject" runat="server" Height="22px" Width="330px" /></td>
            </tr>
            <tr>
                <td>Message: </td>
                <td><asp:TextBox ID="txtMessage" runat="server" Height="88px" Rows="5"
                        TextMode="MultiLine" Width="330px" /></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSendMail" runat="server" Height="29px" Text="Send Mail"
                        Width="107px" OnClick="btnSendMail_Click" />
                &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="lblDisplay" runat="server" Text="" /></td>
            </tr>
        </table>
       
    </div>
    </form>
</body>
</html>
