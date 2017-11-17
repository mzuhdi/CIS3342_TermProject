<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TermProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous" />

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->

    <!-- Custom CSS -->
    <link href="css/base.css" rel="stylesheet" />
    <link href="css/login.css" rel="stylesheet" />

    <!-- Web Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Arvo|Open+Sans|PT+Sans" rel="stylesheet" />
</head>
<body class="login-background parent">
    <form class="" id="form1" runat="server">
        <div class="container">
            <div class="row justify-content-center align-items-center">
                <div id="login-form">
                    <div class="card card-container">
                        <asp:Label ID="lblLoginError" CssClass="alert alert-danger" runat="server" Text="" Visible="False"><i class="fa fa-exclamation-circle" aria-hidden="true"></i> Please enter a valid email</asp:Label>
                        <%--<img id="profile-img" class="" src="Img/checkmark.png" />--%>
                        <div id="login-inputs">
                            <div class="input-group">
                                <div class="input-group-addon" id="email-addon"><span class="glyphicon glyphicon-user" aria-hidden="true"></span></div>
                                <asp:TextBox ID="txtEmail" class="form-control" placeholder="Username" runat="server" required autofocus></asp:TextBox>
                            </div>
                            <div class="input-group">
                                <div class="input-group-addon" id="password-addon"><span class="glyphicon glyphicon-lock" aria-hidden="true"></span></div>
                                <asp:TextBox ID="txtPassword" class="form-control" type="password" placeholder="Password" runat="server" required></asp:TextBox>
                            </div>
                            <div id="remember" class="checkbox">
                                <label class="form-check-label">
                                    <asp:CheckBox ID="chkRememberMe" class="form-check-input" runat="server" /> Remember me
                                </label>
                            </div>
                            <asp:Button ID="btnLogin" class="btn btn-lg btn-primary btn-block btn-signin" runat="server" Text="Sign In" OnClick="btnLogin_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
