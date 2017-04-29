<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Adm_Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Login sistema</title>
     <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"
        integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u"
        crossorigin="anonymous">
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css"
        integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp"
        crossorigin="anonymous">
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"
        integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa"
        crossorigin="anonymous"></script>
    <link href="Login.css" rel="stylesheet" />
</head>
<body>
     <div class="container">
    <form id="form1" class="form-signin" runat="server">
    <asp:Panel ID="pnLogin" runat="server" DefaultButton="btnLogin">
        <h1>Sistema de Notícias C#</h1>
        <h2 class="form-signin-heading">Login</h2>
        <label for="inputEmail" class="sr-only">Login</label>
        <asp:TextBox ID="edLogin" CssClass="form-control" runat="server" />
        <label for="inputPassword" class="sr-only">Senha</label>
        <asp:TextBox ID="edSenha" CssClass="form-control" runat="server" TextMode="Password"/>
         <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnLogin_Click" Text="Login"/>
        </asp:Panel>
    </form>
    </div>
</body>
</html>
