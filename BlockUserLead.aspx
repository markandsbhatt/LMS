<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="BlockUserLead.aspx.cs" Inherits="BlockUserLead" %>

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
                title: 'Lead Blocked Successfully',
                showConfirmButton: false,
                timer: 5000
            });
        }
    </script>
    <!-- Breadcrumbs-->
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="#">Block Your Lead</a>
        </li>

    </ol>


    <%--<a class="btn btn-primary mtp10 " href="AddleadMaster.aspx">Add Lead</a>
    <a class="btn btn-primary mtp10 " href="BulkLeadUpload.aspx">Bulk Upload Lead</a>--%>
    <p></p>




    <!-- Example DataTables Card-->
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table"></i>&nbsp; Block Your Lead  
            <asp:Button Text="Block Your Lead" CssClass="btn btn-primary mtp10 " OnClick="DoBlock" runat="server" />
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                    <thead>
                        <tr>

                            <th>select</th>
                            <th>Domain Name</th>


                            <th>Company Name</th>
                            <th>Email ID</th>
                            <th>Mobile Number</th>

                            <th>Contact Person</th>
                            <th>City</th>
                            <th>State</th>
                            <th>Country</th>
                            <th>ZipCode</th>
                            <th>Created Date</th>
                            <th>Active</th>
                          
                        </tr>
                    </thead>

                    <tbody>
                        <asp:Repeater ID="rptUsers" runat="server" OnItemCommand="rptUsers_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="selectUser" CssClass="form-control" runat="server" />
                                        <asp:HiddenField ID="hdnLeadID" runat="server" Value='<%#Eval("LeadID")%>' />
                                    </td>
                                    <td><%#Eval("DomainName") %>   </td>


                                    <td><%#Eval("ComapanyName") %></td>
                                    <td><%#Eval("EmailID") %></td>
                                    <td><%#Eval("Mobile") %></td>
                                    <td><%#Eval("ContactPerson") %></td>
                                    <td><%#Eval("City") %></td>
                                    <td><%#Eval("State") %></td>
                                    <td><%#Eval("Country") %></td>
                                    <td><%#Eval("ZipCode") %></td>
                                    <td><%#Eval("DateCreated") %></td>
                                    <td><%#Eval("Acitve") %></td>
                                   
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>




                    </tbody>
                </table>
            </div>
        </div>

    </div>
</asp:Content>

