<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="leadMaster.aspx.cs" Inherits="admin_leadMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Breadcrumbs-->
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="#">Lead Master</a>
        </li>

    </ol>


    <a class="btn btn-primary mtp10 " href="AddleadMaster.aspx">Add Lead</a>
    <a class="btn btn-primary mtp10 " href="BulkLeadUpload.aspx">Bulk Upload Lead</a>
    <p></p>




    <!-- Example DataTables Card-->
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table"></i>&nbsp; Lead Master
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                    <thead>
                        <tr>


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
                            <th>Edit</th>
                        </tr>
                    </thead>

                    <tbody>
                        <asp:Repeater ID="rptUsers" runat="server" OnItemCommand="rptUsers_ItemCommand">
                            <ItemTemplate>
                                <tr>

                                    <td><%#Eval("DomainName") %></td>

                                  
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
                                    <td>
                                        <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" CommandArgument='<%#Eval("LeadID") %>'
                                            Text="Edit" CssClass="btn btn-success" ToolTip="Edit" /></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>




                    </tbody>
                </table>
            </div>
        </div>

    </div>
</asp:Content>

