<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="users.aspx.cs" Inherits="admin_users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Breadcrumbs-->
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="#">Users</a>
        </li>

    </ol>


    <a class="btn btn-primary mtp10 " href="AddUser.aspx">Add User</a>

    <p></p>




    <!-- Example DataTables Card-->
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table"></i>&nbsp; Users
        </div>
        <div class="card-body">
            <div class="table-responsive">

                <%--<asp:GridView class="table table-bordered" Width="100%" CellSpacing="0" ID="dataTable" runat="server"
                    DataKeyNames="UserID" AutoGenerateColumns="false">


                    <EmptyDataTemplate>
                        Sorry there are no records
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField HeaderStyle-Width="17%" DataField="NameofUser" HeaderText="Name"
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField HeaderStyle-Width="15%" DataField="Profile" HeaderText="Profile"
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField HeaderStyle-Width="19%" DataField="EmailID" HeaderText="Email"
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />


                        <asp:BoundField HeaderStyle-Width="8%" DataField="Active" HeaderText="Active"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />



                    </Columns>


                </asp:GridView>--%>
                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                    <thead>
                        <tr>

                            <th>User Name</th>
                            <th>Designation</th>
                           
                            <th>UserName</th>
                            <th>Password</th>
                             <th>EmailID</th>
                            <th>Date Created</th>
                            
                            <th>Active</th>
                                 <th>Edit</th>
                        </tr>
                    </thead>

                    <tbody>
                        <asp:Repeater ID="rptUsers" runat="server" OnItemCommand="rptUsers_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("NameofUser") %></td>
                                    <td><%#Eval("Designation") %></td>
                                  
                                    <td><%#Eval("Username") %></td>
                                     <td><%#Eval("Password") %></td>
                                    <td><%#Eval("EmailID") %></td>
                                   <td><%#Eval("Datecreated") %></td>
                                    <td><%#Eval("Active") %></td>
                                    <td> <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" CommandArgument='<%#Eval("UserID") %>' 
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

