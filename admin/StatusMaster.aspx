<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="StatusMaster.aspx.cs" Inherits="admin_StatusMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Breadcrumbs-->
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="#">Status Master</a>
        </li>

    </ol>


    <a class="btn btn-primary mtp10 " href="AddStatus.aspx">Add Status</a>

    <p></p>




    <!-- Example DataTables Card-->
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table"></i>&nbsp; Status
        </div>
        <div class="card-body">
            <div class="table-responsive">

              
                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                    <thead>
                        <tr>

                            <th>Status Name</th>
                            <th>Remark</th>
                           
                            <th>Active</th>
                           
                            <th>Date Created</th>
                           
                                 <th>Edit</th>
                        </tr>
                    </thead>

                    <tbody>
                        <asp:Repeater ID="rptUsers" runat="server" OnItemCommand="rptUsers_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("StatusName") %></td>
                                    <td><%#Eval("Remark") %></td>
                                  
                                    <td><%#Eval("Active") %></td>
                                     <td><%#Eval("DateCreated") %></td>
                                   
                                    <td> <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" CommandArgument='<%#Eval("StatusID") %>' 
                                        Text="Edit" CssClass="btn btn-success" ToolTip="Edit"  /></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>




                    </tbody>
                </table>
            </div>
        </div>

    </div>
</asp:Content>

