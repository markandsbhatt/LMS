<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="AddStatus.aspx.cs" Inherits="admin_AddStatusaspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
            <a href="#">Add Status</a>
        </li>

    </ol>


    <div class="card-body">

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-4">
                    <label>Status Name * </label>
                    <asp:TextBox ID="txtStatus" runat="server" class="form-control" placeholder="Status"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqForgotEmailId" runat="server" ValidationGroup="Login" ControlToValidate="txtStatus" ErrorMessage="Please enter Status" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <label>Status Remark *</label>
                    <asp:TextBox ID="txtRemark" runat="server" class="form-control" placeholder="Remark"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Login" ControlToValidate="txtRemark" ErrorMessage="Please enter Remark" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
                  <div class="col-md-4">
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

