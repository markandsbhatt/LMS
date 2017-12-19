<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="EditleadMaster.aspx.cs" Inherits="admin_EditleadMaster" %>

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
            <a href="#">Edit Lead </a>
        </li>

    </ol>


    <div class="card-body">

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-4">
                    <label>Lead Source * </label>
                    <asp:DropDownList ID="ddlSource" runat="server" class="form-control"></asp:DropDownList>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Login" ControlToValidate="ddlSource" ErrorMessage="Please enter Source Name" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <label>Domain Name *</label>
                    <asp:TextBox ID="txtDomainName" runat="server" class="form-control" placeholder="Domain Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Login" ControlToValidate="txtDomainName" ErrorMessage="Please enter Domain Name" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <label>Domain Created Date *</label>
                    <asp:TextBox ID="txtDomainDate" runat="server" class="form-control" placeholder="dd/MM/yyyy"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ValidationGroup="Login" ControlToValidate="txtDomainDate" ErrorMessage="Please enter Domain Date" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="form-group">

            <div class="form-row">
                <div class="col-md-6">

                    <label>Comapany Name * </label>
                    <asp:TextBox ID="txtComapanyName" runat="server" class="form-control" placeholder="Comapany Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Login" ControlToValidate="txtComapanyName" ErrorMessage="Please enter ComapanyName" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6">
                    <label>Mobile *</label>
                    <asp:TextBox ID="txtMobile" runat="server" class="form-control" placeholder="Mobile"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqUserName" runat="server" ValidationGroup="Login" ControlToValidate="txtMobile" ErrorMessage="Please enter a Mobile" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
            </div>





        </div>

        <div class="form-group">

            <div class="form-row">
                <div class="col-md-6">

                    <label>EmailID * </label>
                    <asp:TextBox ID="txtEmailID" runat="server" class="form-control" placeholder="EmailID"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="Login" ControlToValidate="txtEmailID" ErrorMessage="Please enter EmailID" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6">
                    <label>Landline </label>
                    <asp:TextBox ID="txtLandline" runat="server" class="form-control" placeholder="Landline"></asp:TextBox>
                  
                </div>
            </div>





        </div>

        <div class="form-group">

            <div class="form-row">
                <div class="col-md-12">

                    <label>Address * </label>
                    <asp:TextBox ID="txtAddress" runat="server" class="form-control" TextMode="MultiLine" placeholder="Address"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="Login" ControlToValidate="txtAddress" ErrorMessage="Please enter Address" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
               
            </div>





        </div>

        <div class="form-group">

            <div class="form-row">
                <div class="col-md-6">

                    <label>City * </label>
                    <asp:TextBox ID="txtCity" runat="server" class="form-control" placeholder="City"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="Login" ControlToValidate="txtCity" ErrorMessage="Please enter City" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6">
                    <label>State  *</label>
                    <asp:TextBox ID="txtState" runat="server" class="form-control" placeholder="State"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="Login" ControlToValidate="txtState" ErrorMessage="Please enter state" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
            </div>





        </div>

        <div class="form-group">

            <div class="form-row">
                <div class="col-md-6">

                    <label>Country * </label>
                    <asp:TextBox ID="txtCountry" runat="server" class="form-control" placeholder="Country"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="Login" ControlToValidate="txtCountry" ErrorMessage="Please enter Country" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6">
                    <label>ZipCode  *</label>
                    <asp:TextBox ID="txtZipCode" runat="server" class="form-control" placeholder="ZipCode"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="Login" ControlToValidate="txtZipCode" ErrorMessage="Please enter ZipCode" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
            </div>





        </div>

        <div class="form-group">

            <div class="form-row">
                <div class="col-md-6">

                    <label>ContactPerson * </label>
                    <asp:TextBox ID="txtContactPerson" runat="server" class="form-control" placeholder="ContactPerson"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ValidationGroup="Login" ControlToValidate="txtContactPerson" ErrorMessage="Please enter ContactPerson" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6">
                    <label>ContactPersonMobile  *</label>
                    <asp:TextBox ID="txtContactPersonMobile" runat="server" class="form-control" placeholder="ContactPersonMobile"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="Login" ControlToValidate="txtContactPersonMobile" ErrorMessage="Please enter ContactPersonMobile" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
            </div>





        </div>
        <div class="form-group">
            <div class="form-row">

                <div class="col-md-6">
                    <label>MultipleDomain </label>
                    <asp:DropDownList ID="ddlMultipleDomain" class="form-control" runat="server">
                        <asp:ListItem Value="True">Yes</asp:ListItem>
                        <asp:ListItem Value="False">No</asp:ListItem>
                    </asp:DropDownList>
                </div>


                <div class="col-md-6">
                    <label>Active *</label>
                    <asp:DropDownList ID="ddlActive" class="form-control" runat="server">
                        <asp:ListItem Value="True">Yes</asp:ListItem>
                        <asp:ListItem Selected="True" Value="False">No</asp:ListItem>
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
                <asp:Button ID="btnLogin" runat="server" ValidationGroup="Login"  OnClick="btnLogin_Click"  CssClass="btn btn-primary mtp10" Text="Edit Lead" />

            </div>

        </div>




    </div>
</asp:Content>

