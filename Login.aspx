<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>EchoFeel LMS</title>
    <!-- Bootstrap core CSS-->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Custom fonts for this template-->
    <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Custom styles for this template-->
    <link href="css/sb-admin.css" rel="stylesheet" />
    <script src="js/sweetalert.min.js"></script>
    <link href="css/sweetalert.css" rel="stylesheet" />
</head>
<body class="bg-dark">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="sc1" runat="server"></asp:ScriptManager>
        <script type="text/javascript">
            function LoginFailed() {
                swal(
   'Invalid Credential',
   'Login Again!',
   'error'
 );
            }
        </script>
        <div class="container">
            <div class="card card-login mx-auto mt-5">
                <div class="card-header">EchoFeel LMS  USER PANEL</div>
                <div class="card-body">

                    <div class="form-group">
                        <label for="exampleInputEmail1">Email ID</label>
                        <asp:TextBox ID="txtUserName" runat="server" class="form-control" placeholder="User Name (Email ID)"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqForgotEmailId" runat="server" ValidationGroup="Login" ControlToValidate="txtUserName" ErrorMessage="Please enter email id" CssClass="alert-danger"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Password</label>
                        <asp:TextBox ID="txtUserPass" runat="server" class="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqUserName" runat="server" ValidationGroup="Login" ControlToValidate="txtUserPass" ErrorMessage="Please enter a Password" CssClass="alert-danger"></asp:RequiredFieldValidator>

                    </div>
                    <div class="form-group">
                        <div class="form-check">
                            <label class="form-check-label">
                                <asp:CheckBox ID="chkRememberMe" runat="server"   class="form-check-input" />
                                <%--<input class="form-check-input" type="checkbox">--%>
                                Remember Password</label>
                        </div>
                    </div>


                    <asp:Button ID="btnLogin" runat="server" ValidationGroup="Login" OnClick="btnLogin_Click"
                          CssClass="btn btn-primary btn-block" Text="Login" />


                    <!--  <div class="text-center">
          <a class="d-block small mt-3" href="register.html">Register an Account</a>
          <a class="d-block small" href="forgot-password.html">Forgot Password?</a>
        </div>-->
                </div>
            </div>
        </div>
        <!-- Bootstrap core JavaScript-->
        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
        <!-- Core plugin JavaScript-->
        <script src="vendor/jquery-easing/jquery.easing.min.js"></script>
    </form>
</body>
</html>
