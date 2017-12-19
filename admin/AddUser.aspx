<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="admin_AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function FailMessage() {
            swal(
'OOPS',
'Something Wrong Kindly try again',
'error'
);
        }
    </script>
    <script type="text/javascript">
        function SucsessMessage() {
            swal({
                position: 'top-right',
                type: 'success',
                title: 'User Added Successfully',
                showConfirmButton: false,
                timer: 5000
            });
        }
    </script>
    <!-- Breadcrumbs-->
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="#">Add User</a>
        </li>

    </ol>


    <div class="card-body">

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-6">
                    <label>Name Of User * </label>
                    <asp:TextBox ID="txtNameOfUser" runat="server" class="form-control" placeholder="Name Of User"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqForgotEmailId" runat="server" ValidationGroup="Login" ControlToValidate="txtNameOfUser" ErrorMessage="Please enter Name Of User" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6">
                    <label>Designation *</label>
                    <asp:TextBox ID="txtDesignation" runat="server" class="form-control" placeholder="User Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Login" ControlToValidate="txtDesignation" ErrorMessage="Please enter Designation" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="form-group">

            <div class="form-row">
                <div class="col-md-6">

                    <label>User Name (EmailID) * </label>
                    <asp:TextBox ID="txtUserName" runat="server" class="form-control" placeholder="User Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Login" ControlToValidate="txtUserName" ErrorMessage="Please enter Email ID" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6">
                    <label>Password *</label>
                    <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqUserName" runat="server" ValidationGroup="Login" ControlToValidate="txtPassword" ErrorMessage="Please enter a Password" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
            </div>





        </div>






        <div class="form-group">
            <div class="form-row">

                <div class="col-md-6">
                    <label>Mobile No *</label>
                    <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" placeholder="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Login" ControlToValidate="txtMobileNo" ErrorMessage="Please enter a Mobile Number" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>


                <div class="col-md-6">
                    <label>Active *</label>
                    <asp:DropDownList ID="ddlActive" class="form-control" runat="server">
                        <asp:ListItem Value="True">Yes</asp:ListItem>
                        <asp:ListItem Value="False">No</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>



        <div class="form-group">
            <div class="form-row">
            </div>
        </div>


        <div class="form-row">

            <div class="col-md-6">
                <asp:Button ID="btnLogin" runat="server" ValidationGroup="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary mtp10" Text="Add" />

            </div>

        </div>




    </div>
</asp:Content>

