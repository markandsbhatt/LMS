<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="BulkLeadUpload.aspx.cs" Inherits="BulkLeadUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function InvalidFile() {
            swal(
'INVALID FILE',
'File is not Valid,Kindly Download Sample file and upload again',
'error'
);
        }
    </script>

    <script type="text/javascript">
        function FailedFIle() {
            swal(
'FILE FAILED',
'Kindly Check success Count and try again',
'error'
);
        }
    </script>

    <script type="text/javascript">
        function SuccessFIle() {
            swal(
'Uploaded successfully',
'Kindly Check success Count and Download file',
'success'
);
        }
    </script>

    <script type="text/javascript">
        function WaitTime() {
            swal({
                title: 'File Uploading!',
                text: 'Wait for Some time.',
                timer: 1000,
                onOpen: () => {
                    swal.showLoading()
                }
            }).then((result) => {
                if (result.dismiss === 'timer') {
                    console.log('I was closed by the timer')
                }
            });
        }
    </script>
    <div class="form-row">
        <div class="col-md-4">
            <h1>Bulk Upload Lead</h1>
            <hr>

            <asp:HyperLink runat="server" CssClass="btn btn-primary" ID="hypDownloadSampleEntity" Text="Click here to Download Sample File" NavigateUrl="~/Admin/LeadBulkUpload/ExampleForDomainDatabase.xlsx" Target="_blank"></asp:HyperLink>
            <%--  <a class="btn btn-primary" href="#" id="toggleNavPosition">Toggle Fixed/Static Navbar</a>
      <a class="btn btn-primary" href="#" id="toggleNavColor">Toggle Navbar Color</a>--%>
            <!-- Blank div to give the page height to preview the fixed vs. static navbar-->
        </div>
        <div class="col-md-6">
            <div class="form-row">
                <div class="col-md-8">
                    <h1>Upload Your File</h1>
                    <label>
                        Select File<span>*</span></label>
                    <asp:FileUpload ID="FUploadEntityDetails" runat="server" />
                    <asp:RequiredFieldValidator ID="reqfile" runat="server" ErrorMessage="Select file to upload"
                        Display="None" ControlToValidate="FUploadEntityDetails" ValidationGroup="ValEntity"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                        runat="server" Text="*" ErrorMessage="Only xls,xlsx extensions are allowed!"
                        ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.xls|.xlsx)$" ControlToValidate="FUploadEntityDetails" SetFocusOnError="true" ValidationGroup="ValEntity"
                        Display="None"></asp:RegularExpressionValidator>
                    <asp:LinkButton ID="lnkBulkUpload" runat="server" Text="Bulk Upload" CausesValidation="false"
                        CssClass="btn btn-primary" OnClick="lnkBulkUpload_Click"></asp:LinkButton>
                    <br />
                    <asp:Label ID="LblError" CssClass="alert-danger" runat="server"></asp:Label>
                    <br />

                    <br />
                    <asp:ValidationSummary ID="valfile" runat="server" ValidationGroup="ValEntity"
                        ShowMessageBox="true" ShowSummary="false" />
                </div>

            </div>



        </div>
    </div>




    <div class="table-responsive">
        <asp:GridView ID="GvFileUpload" runat="server" Width="100%" CssClass="admin_tb"
            CellPadding="5" CellSpacing="1" GridLines="None" PageSize="20"
            AllowPaging="true" AutoGenerateColumns="false" PagerStyle-CssClass="paging">
            <HeaderStyle CssClass="toptr" HorizontalAlign="Left" />
            <RowStyle CssClass="intr" HorizontalAlign="Left" />
            <EmptyDataTemplate>
                No Data found.
            </EmptyDataTemplate>
            <Columns>


                <asp:TemplateField>
                    <HeaderTemplate>
                        Upload Time
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblDateCreated" runat="server" Text='<%# Eval("DateCreated") %>'></asp:Label>

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Download Output FIle
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HyperLink runat="server" ID="hypDownloadInputEntity" Text="Download" NavigateUrl='<%# Eval("OutputFile") %>' Target="_blank"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        Upload Status
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblUploadStatus" runat="server" Text='<%# Eval("UploadStatus") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:BoundField DataField="SuccessCount" ControlStyle-Font-Bold="true" ItemStyle-Font-Bold="true" ItemStyle-ForeColor="Red" HeaderText="Success Count" />


            </Columns>
            <PagerStyle CssClass="gvheader" ForeColor="Black" BackColor="White" HorizontalAlign="Right" Font-Bold="true" />
            <PagerSettings Position="Bottom" Mode="NumericFirstLast" FirstPageText="« First" LastPageText="Last &#187;" PageButtonCount="10" />
        </asp:GridView>
    </div>


</asp:Content>

