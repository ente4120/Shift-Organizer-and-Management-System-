<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>מאיה</title>
    <script src="js/jquery-3.3.1.min.js"></script>

    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.min.js"></script> 
    <script src="js/bootstrap.bundle.min.js"></script>
    <link href="css/LoginStyle.css" rel="stylesheet" />
</head>
  <body class="text-center">
    <form class="form-signin"  runat="server">
        <div class="text-center mb-4">
        <img class="mb-4" src="img/MAYA.png" alt="" width="100%">
        </div>

      <div class="form-label-group">
        <input id="userNAME" runat="server" class="form-control" placeholder="שם משתמש" required autofocus/>
        <label for="inputEmail">שם משתמש</label>
        <small id="emailHelp" class="form-text text-muted">שם משתמש כפי שהוגדר במערכת אביב</small>
      </div>

      <div class="form-label-group">
        <input type="password" id="userPASS" runat="server" class="form-control" placeholder="סיסמא" required/>
        <label for="inputPassword">סיסמא</label>
      </div>

      <div class="custom-control custom-checkbox mb-3 text-left">
         <input type="checkbox" runat="server" class="custom-control-input" />
         <label class="custom-control-label" for="customCheck1">זכור אותי פעם הבאה</label>
      </div>

        <asp:Button class="btn btn-lg btn-primary btn-block" ID="Button1" runat="server" Text="התחברות" OnClick="LoginUser"/>
      <p class="mt-5 mb-3 text-muted text-center">&copy; 2017-2018</p>
    </form>

  </body></html>
