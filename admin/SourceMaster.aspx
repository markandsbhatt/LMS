<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="SourceMaster.aspx.cs" Inherits="SourceMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="#">Source Master</a>
        </li>

    </ol>


    <a class="btn btn-primary mtp10 " href="AddSource.aspx">Add Source</a>

    <p></p>




    <!-- Example DataTables Card-->
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table"></i>&nbsp; Source
        </div>
        <div class="card-body">
            <div class="table-responsive">


                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                    <thead>
                        <tr>

                            <th>Source Name</th>
                            <th>City</th>
                            <th>State</th>
                            <th>Country</th>
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
                                    <td><%#Eval("SourceName") %></td>
                                    <td><%#Eval("City") %></td>
                                    <td><%#Eval("State") %></td>

                                    <td><%#Eval("Country") %></td>
                                    <td><%#Eval("Remark") %></td>
                                    <td><%#Eval("Active") %></td>
                                    <td><%#Eval("DateCreated") %></td>

                                    <td>
                                        <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" CommandArgument='<%#Eval("SourceID") %>'
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

