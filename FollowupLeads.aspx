<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="FollowupLeads.aspx.cs" Inherits="FollowupLeads" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
    <style type="text/css">
        .clearfix:before, .clearfix:after {
            content: " ";
            display: table; /* 2 */
        }

        .clearfix:after {
            clear: both;
        }

        .clearfix {
            *zoom: 1;
        }

        .options {
            margin-bottom: 8px;
        }

        /* Style checkboxes as Toggle Buttons */
        .ck-button {
            margin: 2px;
            background-color: #EFEFEF;
            border-radius: 4px;
            border: 1px solid #aaa;
            overflow: auto;
            float: left;
            color: #aaa;
        }

            .ck-button:hover {
                background-color: #ddd;
            }

            .ck-button label {
                float: left;
                width: auto;
                margin-bottom: 0;
            }

                .ck-button label span {
                    text-align: center;
                    padding: 3px 8px;
                    display: block;
                }

                .ck-button label input {
                    position: absolute;
                    top: -20px;
                }

            .ck-button input:checked + span {
                color: #111;
            }
    </style>
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
                title: 'Followup Done Successfully',
                showConfirmButton: false,
                timer: 3000
            });
        }
    </script>
    <script>
    </script>
    <!-- Breadcrumbs-->
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="#">My Followup Lead</a>


        </li>

    </ol>


    <%--<a class="btn btn-primary mtp10 " href="AddleadMaster.aspx">Add Lead</a>
    <a class="btn btn-primary mtp10 " href="BulkLeadUpload.aspx">Bulk Upload Lead</a>--%>
   <p>Choose Fields:</p>
  
        <div class="options clearfix">
            <div class="ck-button">
                <label>
                    <input type="checkbox" value="1" name="domain_name" checked="checked"><span>Domain Name</span></label>
            </div>
            <div class="ck-button">
                <label>
                    <input type="checkbox" value="1" name="Company_name" checked="checked"><span>Company Name</span></label>
            </div>
            <div class="ck-button">
                <label>
                    <input type="checkbox" value="1" checked="checked" name="email_id"><span>Email ID</span></label>
            </div>
            <div class="ck-button">
                <label>
                    <input type="checkbox" value="1" checked="checked" name="mobile"><span>Mobile</span></label>
            </div>
            <div class="ck-button">
                <label>
                    <input type="checkbox" value="1" checked="checked" name="Contact_Person"><span>Contact Person</span></label>
            </div>
            <div class="ck-button">
                <label>
                    <input type="checkbox" value="1" name="City"><span>City</span></label>
            </div>
            <div class="ck-button">
                <label>
                    <input type="checkbox" value="1" name="State"><span>State</span></label>
            </div>
              <div class="ck-button">
                <label>
                    <input type="checkbox" value="1" name="Country"><span>Country</span></label>
            </div>
             <div class="ck-button">
                <label>
                    <input type="checkbox" value="1" checked="checked" name="Zip"><span>Zip Code</span></label>
            </div>
              
        </div>



    <!-- Example DataTables Card-->
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table"></i>&nbsp;My Followup Lead
         
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                    <thead>
                        <tr>
                            <th>Action</th>

                            

                            <th class="domain_name">Domain Name</th>


                            <th class="Company_name">Company Name</th>
                            <th class="email_id">Email ID</th>
                            <th class="mobile">Mobile Number</th>

                            <th class="Contact_Person">Contact Person</th>
                            <th class="City">City</th>
                            <th class="State">State</th>
                            <th class="Country">Country</th>
                            <th class="Zip">ZipCode</th>
                            <%-- <th>Created Date</th>
                            <th  class="active">Active</th>--%>
                        </tr>
                    </thead>

                    <tbody>
                        <asp:Repeater ID="rptUsers" runat="server">
                            <ItemTemplate>
                                <tr>

                                    <td>
                                        <asp:Button ID="btnEdit" CommandArgument='<%#Eval("BlockID") %>' Text="Followup" OnClick="GetModelData"
                                            CssClass="btn btn-info" runat="server" />

                                        <%-- <button   class="btnView"  data-prop="<%#Eval("DomainName") %> ">Show</button>
                                        <a class="btn btn-primary lnk" data-toggle="modal" data-target="#exampleModal">Followup</a></td>--%>
                                    <td class="domain_name"><%#Eval("DomainName") %>   </td>


                                    <td class="Company_name"><%#Eval("ComapanyName") %></td>
                                    <td class="email_id"><%#Eval("EmailID") %></td>
                                    <td class="mobile"><%#Eval("Mobile") %></td>
                                    <td class="Contact_Person"><%#Eval("ContactPerson") %></td>
                                    <td class="City"><%#Eval("City") %></td>
                                    <td class="State"><%#Eval("State") %></td>
                                    <td class="Country"><%#Eval("Country") %></td>
                                    <td class="Zip"><%#Eval("ZipCode") %></td>
                                    <%--<td><%#Eval("DateCreated") %></td>
                                    <td class="active"><%#Eval("Acitve") %></td>--%>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>




                    </tbody>
                </table>
            </div>
        </div>

    </div>
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Followup for Domain(<asp:Label ID="lblHeading" runat="server"></asp:Label>)</h5>
                    <asp:HiddenField ID="hdnBlockID" runat="server" />
                    <asp:HiddenField ID="hdnLeadID" runat="server" />
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">

                    <div class="form-group">
                        <div class="form-row">
                            <div class="col-md-6">
                                <label>Followup Date</label>
                                <asp:TextBox ID="txtFollowupDate" runat="server" CssClass="form-control"></asp:TextBox>
                                <cc1:CalendarExtender ID="cc1Calander" runat="server" TargetControlID="txtFollowupDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ValidationGroup="Login" ControlToValidate="txtFollowupDate" ErrorMessage="Please enter Followup Date" CssClass="alert-danger"></asp:RequiredFieldValidator>
                                <%-- <input class="form-control" type="text">--%>
                            </div>
                            <div class="col-md-6">
                                <label>Next Followup Date</label>
                                <asp:TextBox ID="txtNextFollowupDate" runat="server" CssClass="form-control"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtNextFollowupDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Login" ControlToValidate="txtNextFollowupDate" ErrorMessage="Please enter Next Domain Date" CssClass="alert-danger"></asp:RequiredFieldValidator>

                                <%--<input class="form-control" type="text">--%>
                            </div>
                            <%-- <div class="col-md-12">
                                <label>Email-Id</label>
                                <input class="form-control" type="text">
                            </div>--%>
                            <div class="col-md-12">
                                <label>Status</label>
                                <asp:DropDownList ID="ddlstatus" runat="server" class="form-control"></asp:DropDownList>
                                <%-- <select class="form-control">

                                    <option>Interested</option>
                                    <option>Not Interested</option>
                                </select>--%>
                            </div>
                            <div class="col-md-12">
                                <label>Tags</label>
                                <asp:TextBox ID="txttags" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Login" ControlToValidate="txttags" ErrorMessage="Please enter tags" CssClass="alert-danger"></asp:RequiredFieldValidator>
                                <%-- <input class="form-control" type="text">--%>
                            </div>

                            <div class="col-md-12">
                                <label>Comments</label>
                                <asp:TextBox ID="txtComments" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Login" ControlToValidate="txtComments" ErrorMessage="Please enter Comments" CssClass="alert-danger"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                    </div>



                    <h5 class="modal-title" id="H1">History</h5>
                    <br />




                    <div class="form-row">

                        <div class="table-responsive">
                            <table class="table table-bordered" id="dataTable3" width="100%" cellspacing="0">
                                <thead>
                                    <tr>

                                        <th>Status Name</th>
                                        <th>Comment</th>

                                        <th>FollowUpDate</th>

                                        <th>NextFollowUpDate</th>

                                        <th>Date Created</th>


                                    </tr>
                                </thead>

                                <tbody>
                                    <asp:Repeater ID="rptModalPopupFollowup" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("StatusName") %></td>
                                                <td><%#Eval("Comment") %></td>

                                                <td><%#Eval("FollowUpDate") %></td>
                                                <td><%#Eval("NextFollowUpDate") %></td>
                                                <td><%#Eval("DateCreated") %></td>

                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>




                                </tbody>
                            </table>



                        </div>
                    </div>
                    <div class="modal-footer">

                        <asp:Button ID="btnFollowup" ValidationGroup="Login" CssClass="btn btn-primary" Text="Save" OnClick="btnFollowup_Click" runat="server" />
                        <button class="btn btn-primary" type="button" data-dismiss="modal">Cancel</button>
                        <%--  <a class="btn btn-primary" href="login.html">Save</a>--%>
                    </div>
                </div>
            </div>
        </div>
        <!-- Bootstrap core JavaScript-->
        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
        <!-- Core plugin JavaScript-->
        <script src="vendor/jquery-easing/jquery.easing.min.js"></script>
        <!-- Page level plugin JavaScript-->
        <script src="vendor/chart.js/Chart.min.js"></script>
        <script src="vendor/datatables/jquery.dataTables.js"></script>
        <script src="vendor/datatables/dataTables.bootstrap4.js"></script>
        <!-- Custom scripts for all pages-->
        <script src="js/sb-admin.min.js"></script>
        <!-- Custom scripts for this page-->
        <script src="js/sb-admin-datatables.min.js"></script>
        <script src="js/sb-admin-charts.min.js"></script>
    </div>
    <script type='text/javascript'>
        function openModal() {
            $('#exampleModal').modal('show');
        }
    </script>
    <script type='text/javascript'>
        function CloseModal() {
            $('#exampleModal').modal('hide');
        }
    </script>
    <script type="text/javascript">
        $("input:checkbox:not(:checked)").each(function () {
            debugger;
            var column = "table ." + $(this).attr("name");
            $(column).hide();
        });

        $("input:checkbox").click(function () {
            debugger;
            var column = "table ." + $(this).attr("name");
            $(column).toggle();
        });
    </script>
</asp:Content>

