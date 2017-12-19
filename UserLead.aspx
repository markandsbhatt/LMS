<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="UserLead.aspx.cs" Inherits="UserLead" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="#">User Lead Status</a>
        </li>

    </ol>


    <p>Date Range</p>
    <a class="btn btn-primary mtp10 " href="#">Today</a>
    <a class="btn btn-primary mtp10 " href="#">Last 1 week</a>
    <a class="btn btn-primary mtp10 " href="#">Last 1 month</a>
    <a class="btn btn-primary mtp10 " href="block-lead.html">Block Lead</a>
    <p></p>



    <div class="row">


        <div class="col-md-auto">
            <label>Search :</label>
        </div>
        <div class="col-md-auto">
            <input class="form-control" />
        </div>
        <div class="col-md-auto">
            <div class="dataTables_length">

                <select name="dataTable_length" aria-controls="dataTable" class="form-control">
                    <option value="">Company Name</option>

                    <option value="">City</option>

                    <option value="">Domain Name</option>
                    <option value="">Mobile No</option>
                    <option value="">Contact Person</option>

                </select>
            </div>
        </div>

        <div class="col-md-auto">
            <a class="btn btn-primary mtp10" href="add-new-user-lead.html">Add New User Lead</a>
        </div>



    </div>

    <p></p>
    <div class="row">
        <div class="col-md-auto">
            <label>Choose Fields:</label>
        </div>
        <div class="col-md-auto">
            <div class="dataTables_length">
                <div class="button-group">
                    <button type="button" class="btn btn-default btn-sm dropdown-toggle" data-toggle="dropdown">Select<span class="caret"></span></button>
                    <ul class="dropdown-menu">
                        <li><a href="#" class="small" data-value="option1" tabindex="-1">
                            <input type="checkbox" />&nbsp;Lead No</a></li>
                        <li><a href="#" class="small" data-value="option1" tabindex="-1">
                            <input type="checkbox" />&nbsp;Domain Name</a></li>
                        <li><a href="#" class="small" data-value="option1" tabindex="-1">
                            <input type="checkbox" />&nbsp;Company Name</a></li>
                        <li><a href="#" class="small" data-value="option1" tabindex="-1">
                            <input type="checkbox" />&nbsp;Mobile No</a></li>
                        <li><a href="#" class="small" data-value="option1" tabindex="-1">
                            <input type="checkbox" />&nbsp;Landline No</a></li>
                        <li><a href="#" class="small" data-value="option1" tabindex="-1">
                            <input type="checkbox" />&nbsp;Email ID</a></li>
                        <li><a href="#" class="small" data-value="option1" tabindex="-1">
                            <input type="checkbox" />&nbsp;Address</a></li>

                        <li><a href="#" class="small" data-value="option1" tabindex="-1">
                            <input type="checkbox" />&nbsp;Date Created</a></li>

                        <li><a href="#" class="small" data-value="option1" tabindex="-1">
                            <input type="checkbox" />&nbsp;Country</a></li>
                        <li><a href="#" class="small" data-value="option1" tabindex="-1">
                            <input type="checkbox" />&nbsp;City</a></li>

                        <li><a href="#" class="small" data-value="option1" tabindex="-1">
                            <input type="checkbox" />&nbsp;Contact Person</a></li>


                        <li><a href="#" class="small" data-value="option1" tabindex="-1">
                            <input type="checkbox" />&nbsp;Status</a></li>
                        <li><a href="#" class="small" data-value="option1" tabindex="-1">
                            <input type="checkbox" />&nbsp;Latest Comment</a></li>

                    </ul>
                </div>
            </div>
        </div>


    </div>
    <p></p>

    <!-- Example DataTables Card-->
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table"></i>&nbsp; User Lead Status
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                    <thead>
                        <tr>
                            <th>
                                <input type="checkbox"></th>
                            <th>Lead No</th>
                            <th>Domain Name</th>
                            <th>Company Name</th>
                            <th>Mobile No</th>
                            <th>Landline No</th>

                            <th>Email ID</th>
                            <th>Address</th>
                            <th>Date Created</th>

                            <th>Country</th>
                            <th>City</th>

                            <th>Contact Person</th>



                            <th>Status</th>
                            <th>Latest Comment</th>
                            <th>Action</th>


                        </tr>
                    </thead>

                    <tbody>


                        <tr>
                            <td>
                                <input type="checkbox"></td>
                            <td>LN1</td>
                            <td>academy.com</td>
                            <td>Achiever's Academy</td>
                            <td>98213 46220</td>
                            <td>022 2433 0121</td>
                            <td>mehul@academy.com</td>
                            <td>112, United Industrial Estate, Mogul Lane, Mahim, Mumbai 400016</td>
                            <td>05-12-2017</td>
                            <td>India</td>
                            <td>Mumbai</td>
                            <td>Mehul Shah</td>
                            <td>Blocked</td>
                            <td>Ringing</td>
                            <td><a class="btn btn-primary lnk" data-toggle="modal" data-target="#exampleModal">Edit</a></td>

                        </tr>

                        <tr>
                            <td>
                                <input type="checkbox"></td>
                            <td>LN2</td>
                            <td>academy.com</td>
                            <td>Achiever's Academy</td>
                            <td>98213 46220</td>
                            <td>022 2433 0121</td>
                            <td>mehul@academy.com</td>
                            <td>112, United Industrial Estate, Mogul Lane, Mahim, Mumbai 400016</td>
                            <td>05-12-2017</td>
                            <td>India</td>
                            <td>Mumbai</td>
                            <td>Mehul Shah</td>
                            <td>Blocked</td>
                            <td>Ringing</td>
                            <td><a class="btn btn-primary lnk" data-toggle="modal" data-target="#exampleModal">Edit</a></td>

                        </tr>

                        <tr>
                            <td>
                                <input type="checkbox"></td>
                            <td>LN3</td>
                            <td>academy.com</td>
                            <td>Achiever's Academy</td>
                            <td>98213 46220</td>
                            <td>022 2433 0121</td>
                            <td>mehul@academy.com</td>
                            <td>112, United Industrial Estate, Mogul Lane, Mahim, Mumbai 400016</td>
                            <td>05-12-2017</td>
                            <td>India</td>
                            <td>Mumbai</td>
                            <td>Mehul Shah</td>
                            <td>Blocked</td>
                            <td>Ringing</td>
                            <td><a class="btn btn-primary lnk" data-toggle="modal" data-target="#exampleModal">Edit</a></td>

                        </tr>


                    </tbody>
                </table>
            </div>
        </div>

    </div>

    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Action</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">

                    <div class="form-group">
                        <div class="form-row">
                            <div class="col-md-12">
                                <label>Followup Date</label>
                                <input class="form-control" type="text">
                            </div>
                            <div class="col-md-12">
                                <label>Email-Id</label>
                                <input class="form-control" type="text">
                            </div>
                            <div class="col-md-12">
                                <label>Status</label>
                                <select class="form-control">

                                    <option>Interested</option>
                                    <option>Not Interested</option>
                                </select>
                            </div>
                            <div class="col-md-12">
                                <label>Tags</label>
                                <input class="form-control" type="text">
                            </div>

                            <div class="col-md-12">
                                <label>Comments</label>
                                <textarea rows="2" class="form-control" style="height: 38px;"></textarea>
                            </div>
                        </div>
                    </div>



                    <h5 class="modal-title" id="H1">History</h5>
                    <br />




                    <div class="form-row">

                        <div class="table-responsive">
                            <table class="table table-bordered" id="Table1" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th>Date Posted</th>
                                        <th>Date of Followup</th>
                                        <th>Status</th>
                                        <th>Commets</th>
                                </thead>

                                <tbody>


                                    <tr>


                                        <td>30-11-2017</td>
                                        <td>28-11-2017</td>
                                        <td>Opened</td>
                                        <td>Interested</td>



                                    </tr>

                                    <tr>
                                        <td>30-11-2017</td>
                                        <td>28-11-2017</td>
                                        <td>Opened</td>
                                        <td>Interested</td>

                                    </tr>
                            </table>



                        </div>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                        <a class="btn btn-primary" href="login.html">Save</a>
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
</asp:Content>

