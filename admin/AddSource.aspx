<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="AddSource.aspx.cs" Inherits="admin_AddSource" %>

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
            <a href="#">Add Source</a>
        </li>

    </ol>


    <div class="card-body">

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-4">
                    <label>Source Name * </label>
                    <asp:TextBox ID="txtSourceName" runat="server" class="form-control" placeholder=" Source Name "></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqForgotEmailId" runat="server" ValidationGroup="Login" ControlToValidate="txtSourceName" ErrorMessage="Please enter Source Name" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <label>Source Remark *</label>
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
                <div class="col-md-4">
                    <label>City </label>
                    <asp:TextBox ID="txtCity" runat="server" class="form-control" placeholder=" Source Name "></asp:TextBox>
                   
                </div>
                <div class="col-md-4">
                    <label>State</label>
                    <asp:TextBox ID="txtState" runat="server" class="form-control" placeholder="Remark"></asp:TextBox>
                   
                </div>
                  <div class="col-md-4">
                    <label>Country</label>
                   <asp:TextBox ID="txtCountry" runat="server" class="form-control" placeholder="Remark"></asp:TextBox>
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

