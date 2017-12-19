using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BulkLeadUpload : System.Web.UI.Page
{
    DataSet ds;
    DataTable Dt;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            BindGridBulk();
        }
    }
    private void BindGridBulk()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@CreatedBy", SqlDbType.NVarChar);
        param[0].Value = "s";
        DataTable DtEntityUpload;
        DtEntityUpload = DataAccessor.ExecuteProcDataTable("GetEntityBulkUpload", param);

        GvFileUpload.DataSource = DtEntityUpload;
        GvFileUpload.DataBind();
    }

    protected void lnkBulkUpload_Click(object sender, EventArgs e)
    {
      //  ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "WaitTime();", true);
        ImporttoDatatable();
    }

    private void ImporttoDatatable()
    {
        //
        //read tab separated csv file 
        string strFileID = string.Empty;
        string strInputFileName = string.Empty;
        string strOutputFileName = string.Empty;
        string strEntityID = string.Empty;
        string strName = string.Empty;
        string MainStatus = "";
        int SuccessData = 0;
        string StrErrorList = string.Empty;
        string colName = "";
        try
        {
            if (FUploadEntityDetails.HasFile)
            {
                string strDataMode = string.Empty;
                string strEntityCode = string.Empty;
                string strEntityBankID = string.Empty;
                string LeadID= string.Empty;

                strFileID = GeneralFunctions._GenerateNewStringID("F", "FileID", "2", "14", "EntityBulkUpload");

                string FileName = FUploadEntityDetails.FileName;

                string path = string.Concat(Server.MapPath("LeadBulkUpload/") + FUploadEntityDetails.PostedFile.FileName);

                FUploadEntityDetails.PostedFile.SaveAs(path);

                OleDbConnection OleDbcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;");

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", OleDbcon);
                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter(cmd);
                ds = new DataSet();
                objAdapter1.Fill(ds);
                Dt = ds.Tables[0];

                //remove empty rows
                for (int i = Dt.Rows.Count - 1; i >= 0; i += -1)
                {
                    DataRow row = Dt.Rows[i];
                    if (row[0] == null)
                    {
                        Dt.Rows.Remove(row);
                    }
                    else if (string.IsNullOrEmpty(row[0].ToString()))
                    {
                        Dt.Rows.Remove(row);
                    }
                }

                Dt.Columns.Add("Status", typeof(string));

                foreach (DataRow dr in Dt.Rows)
                {
                    // strEntityID = "";
                   // ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "WaitTime();", true);

                    if (!string.IsNullOrEmpty(dr["domain_name"].ToString())
                        && !string.IsNullOrEmpty(dr["create_date"].ToString()) && !string.IsNullOrEmpty(dr["registrant_email"].ToString())
                         && !string.IsNullOrEmpty(dr["registrant_phone"].ToString()) 
                       //    && !string.IsNullOrEmpty(dr["State"].ToString()) && !string.IsNullOrEmpty(dr["City"].ToString())
                       // && !string.IsNullOrEmpty(dr["Country"].ToString()) && !string.IsNullOrEmpty(dr["ZipCode"].ToString())
                       //&& !string.IsNullOrEmpty(dr["ContactPerson"].ToString()) && !string.IsNullOrEmpty(dr["ContactPersonMobile"].ToString())
                       //)
                       )
                    {
                        dr["Status"] = "Success";



                        //entity logic
                        SqlParameter[] sqlPar = new SqlParameter[1];

                        sqlPar[0] = new SqlParameter("@EntityCode", SqlDbType.NVarChar);
                        sqlPar[0].Value = dr["registrant_email"].ToString();

                        SqlDataReader dr1 = DataAccessor.ExecuteProcDataReader("check_EntityCode", sqlPar);
                        while (dr1.Read())
                        {
                            if (dr1["Exists"].ToString() == "True")
                            {
                                dr["Status"] = "EmailID  already Exixst";
                            }

                            else
                            {
                                SuccessData += 1;
                                LeadID = GeneralFunctions._GenerateNewStringID("L", "LeadID", "2", "20", "LeadMaster");
                                MasterData.LeadMaster("Insert", LeadID, "Google.com",
                                   dr["domain_name"].ToString(), dr["registrant_company"].ToString(), dr["registrant_phone"].ToString(), "",
               dr["registrant_email"].ToString(), dr["registrant_address"].ToString(), dr["registrant_state"].ToString(), dr["registrant_city"].ToString(), dr["registrant_country"].ToString(),
               dr["registrant_zip"].ToString(), dr["registrant_name"].ToString(), "-", true,
                false, dr["create_date"].ToString(), "SC1",false
               );


                                //GetEntityYpe

                                //MasterData.ProductPoint(strPPID, dr["PartnerID"].ToString(), "", dr["Product Code"].ToString(), dr["Product Desc"].ToString(), dr["ScratchCode"].ToString(), ProdcutValue, stratdate, enddate, true, "", true);

                                //MasterData.NewEarnPointsScheme("Insert", strEPointID, strECode, "", "", strPPID, decSpendKSH, decSpendUSD, intEarnPoints, intReedemPoints, strFromDate, strToDate, true, "Earn", "", "", "", "", "", "", "", true, strUserID, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");




                                //lblErrorMsg.Text = ep.Message.ToString() + "<br>" + ep.StackTrace.ToString() + "<br>" + ep.Source.ToString();
                                //lblErrorMsg.Visible = true;









                            }

                        }
                        dr1.Close();

                    }
                    else
                    {
                        //if (dr["Domain Source"].ToString() == "")
                        //{
                        //    colName = "Domain Source";
                        //    StrErrorList += colName + ",";
                        //}
                        if (dr["domain_name"].ToString() == "")
                        {
                            colName = "domain_name";
                            StrErrorList += colName;
                        }
                        if (dr["registrant_phone"].ToString() == "")
                        {
                            colName = "registrant_phone";
                            StrErrorList += colName;
                        }
                        if (dr["registrant_email"].ToString() == "")
                        {
                            colName = "registrant_email";
                            StrErrorList += colName;
                        }

                        //if (dr["EmailID"].ToString() == "")
                        //{
                        //    colName = "EmailID";
                        //    StrErrorList += colName;
                        //}

                        //if (dr["Address"].ToString() == "")
                        //{
                        //    colName = "Address";
                        //    StrErrorList += colName;
                        //}
                        //if (dr["State"].ToString() == "")
                        //{
                        //    colName = "State";
                        //    StrErrorList += colName;
                        //}
                        //if (dr["City"].ToString() == "")
                        //{
                        //    colName = "City";
                        //    StrErrorList += colName;
                        //}
                        //if (dr["Country"].ToString() == "")
                        //{
                        //    colName = "Country";
                        //    StrErrorList += colName;
                        //}
                        //if (dr["ZipCode"].ToString() == "")
                        //{
                        //    colName = "ZipCode";
                        //    StrErrorList += colName;
                        //}
                        //if (dr["ContactPerson"].ToString() == "")
                        //{
                        //    colName = "ContactPerson";
                        //    StrErrorList += colName;
                        //}
                        //if (dr["ContactPersonMobile"].ToString() == "")
                        //{
                        //    colName = "ContactPersonMobile";
                        //    StrErrorList += colName;
                        //}



                        //Bank1 IFSC
                        dr["Status"] = "Failed " + "Kindly Insert " + StrErrorList;
                        StrErrorList = "";
                    }

                    if (SuccessData == dr.Table.Rows.Count)
                    {
                        MainStatus = "File successfully Uplaoded";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "SuccessFIle();", true);
                    }
                    else
                    {
                        MainStatus = "File Failed";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "FailedFIle();", true);
                    }
                }


                CreateOutput(Dt, Server.MapPath("LeadBulkUpload/") + strFileID + (".xlsx"));


                DataTable DtEntityUpload;
                DtEntityUpload = InsertEntityBulkUpload(strFileID, "~/Admin/LeadBulkUpload/" + strFileID + ".xlsx", "~/Admin/LeadBulkUpload/" + strFileID + ".xlsx", MainStatus, SuccessData, System.DateTime.Now, System.DateTime.Now, Session["UserID"].ToString(), Session["UserID"].ToString());

                BindGridBulk();
                LblError.Text = "";
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "InvalidFile();", true);
            // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "InvalidArgs", "alert('File is not valid " + ex + " , Upload File Again');", true);
            //LblError.Text = "File is not Valid,Kindly Download Sample file and upload again";

        }
    }

    protected void CreateOutput(DataTable dt, string strFileName)
    {
        // objCommonFunctions.ExportToXLSX(strFileName, dt, "Test");
        ExportToXLSX(strFileName, dt, "Test");



        /*
        StringBuilder sb = new StringBuilder();

        string[] columnNames = dt.Columns.Cast<DataColumn>().
                                          Select(column => column.ColumnName).
                                          ToArray();
        sb.AppendLine(string.Join("\t", columnNames));

        foreach (DataRow row in dt.Rows)
        {
            string[] fields = row.ItemArray.Select(field => field.ToString()).
                                            ToArray();
            sb.AppendLine(string.Join("\t", fields));
        }

        File.WriteAllText(strFileName, sb.ToString());
          */
    }
    public static bool ExportToXLSX(string sheetToCreate, System.Data.DataTable dtToExport, string tableName)
    {
        bool status = false;
        try
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (DataRow row in dtToExport.Rows) rows.Add(row);
            status = ExportToXLSX(sheetToCreate, rows, dtToExport, tableName);
        }
        catch (Exception ex)
        {
            status = false;
        }
        return status;
    }

    public static bool ExportToXLSX(string sheetToCreate, List<DataRow> selectedRows, System.Data.DataTable origDataTable, string tableName)
    {
        bool status = false;
        System.Data.OleDb.OleDbConnection cn = new OleDbConnection();
        try
        {
            char Space = ' ';
            string dest = sheetToCreate;


            if (File.Exists(dest))
            {
                File.Delete(dest);
            }

            sheetToCreate = dest;

            if (tableName == null)
            {
                tableName = string.Empty;
            }

            tableName = tableName.Trim().Replace(Space, '_');
            if (tableName.Length == 0)
            {
                tableName = origDataTable.TableName.Replace(Space, '_');
            }

            if (tableName.Length == 0)
            {
                tableName = "NoTableName";
            }

            if (tableName.Length > 30)
            {
                tableName = tableName.Substring(0, 30);
            }

            //Excel names are less than 31 chars
            string queryCreateExcelTable = "CREATE TABLE [" + tableName + "] (";
            Dictionary<string, string> colNames = new Dictionary<string, string>();

            foreach (DataColumn dc in origDataTable.Columns)
            {
                //Cause the query to name each of the columns to be created.
                string modifiedcolName = dc.ColumnName;//.Replace(Space, '_').Replace('.', '#');
                string origColName = dc.ColumnName;
                colNames.Add(modifiedcolName, origColName);

                queryCreateExcelTable += "[" + modifiedcolName + "]" + " text,";

            }

            queryCreateExcelTable = queryCreateExcelTable.TrimEnd(new char[] { Convert.ToChar(",") }) + ")";

            //adds the closing parentheses to the query string
            if (selectedRows.Count > 65000 && sheetToCreate.ToLower().EndsWith(".xls"))
            {
                //use Excel 2007 for large sheets.
                sheetToCreate = sheetToCreate.ToLower().Replace(".xls", string.Empty) + ".xlsx";
            }

            string strCn = string.Empty;
            string ext = System.IO.Path.GetExtension(sheetToCreate).ToLower();
            if (ext == ".xls") strCn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sheetToCreate + "; Extended Properties='Excel 8.0;HDR=YES'";
            if (ext == ".xlsx") strCn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sheetToCreate + ";Extended Properties='Excel 12.0 Xml;HDR=YES' ";
            if (ext == ".xlsb") strCn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sheetToCreate + ";Extended Properties='Excel 12.0;HDR=YES' ";
            if (ext == ".xlsm") strCn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sheetToCreate + ";Extended Properties='Excel 12.0 Macro;HDR=YES' ";

            cn = new System.Data.OleDb.OleDbConnection(strCn);
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(queryCreateExcelTable, cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [" + tableName + "]", cn);
            System.Data.OleDb.OleDbCommandBuilder cb = new System.Data.OleDb.OleDbCommandBuilder(da);

            //creates the INSERT INTO command
            cb.QuotePrefix = "[";
            cb.QuoteSuffix = "]";
            cmd = cb.GetInsertCommand();

            //gets a hold of the INSERT INTO command.
            foreach (DataRow row in selectedRows)
            {
                foreach (System.Data.OleDb.OleDbParameter param in cmd.Parameters)
                {
                    param.Value = row[colNames[param.SourceColumn.Replace('#', '.')]];
                }

                cmd.ExecuteNonQuery(); //INSERT INTO command.
            }

            cn.Close();
            cn.Dispose();
            da.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            status = true;
        }
        catch (Exception ex)
        {
            status = false;
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        return status;
    }

    public DataTable InsertEntityBulkUpload(string FileID, string InputFile, string OutputFile, string UploadStatus, int SuccessCount, DateTime DateCreated, DateTime DateUpdated, string CreatedBy, string LastUpdatedBy)
    {
        SqlParameter[] param = new SqlParameter[9];

        param[0] = new SqlParameter("@FileID", SqlDbType.NVarChar);
        if (!string.IsNullOrEmpty(FileID))
        {
            param[0].Value = FileID;
        }
        else
        {
            param[0].Value = DBNull.Value;
        }

        param[1] = new SqlParameter("@InputFile", SqlDbType.NVarChar);
        if (!string.IsNullOrEmpty(InputFile))
        {
            param[1].Value = InputFile;
        }
        else
        {
            param[1].Value = DBNull.Value;
        }

        param[2] = new SqlParameter("@OutputFile", SqlDbType.NVarChar);
        if (!string.IsNullOrEmpty(OutputFile))
        {
            param[2].Value = OutputFile;
        }
        else
        {
            param[2].Value = DBNull.Value;
        }

        param[3] = new SqlParameter("@UploadStatus", SqlDbType.NVarChar);
        if (!string.IsNullOrEmpty(UploadStatus))
        {
            param[3].Value = UploadStatus;
        }
        else
        {
            param[3].Value = DBNull.Value;
        }
        param[4] = new SqlParameter("@SuccessCount", SqlDbType.Int);
        param[4].Value = SuccessCount;


        param[5] = new SqlParameter("@DateCreated", SqlDbType.DateTime);
        param[5].Value = DateCreated;

        param[6] = new SqlParameter("@DateUpdated", SqlDbType.DateTime);
        param[6].Value = DateUpdated;

        param[7] = new SqlParameter("@CreatedBy", SqlDbType.NVarChar);
        if (!string.IsNullOrEmpty(CreatedBy))
        {
            param[7].Value = CreatedBy;
        }
        else
        {
            param[7].Value = DBNull.Value;
        }

        param[8] = new SqlParameter("@LastUpdatedBy", SqlDbType.NVarChar);
        if (!string.IsNullOrEmpty(LastUpdatedBy))
        {
            param[8].Value = LastUpdatedBy;
        }
        else
        {
            param[8].Value = DBNull.Value;
        }


        DataTable dtable = DataAccessor.ExecuteProcDataTable("Insert_EntityBulkUpload", param);
        return dtable;
    }
}