using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_EditStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["StatusID"].ToString() == "")
            {

            }
            else
            {
                Loaddata(Request.QueryString["StatusID"].ToString());
            }
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {


        string strStatusID = Request.QueryString["StatusID"].ToString();
        string strDataMode = "";
        string strMsg = "";

        try
        {


            strDataMode = "Update";
            strMsg = "Data added successfully";
            MasterData.StatusMaster(
                    strDataMode,
                    strStatusID,
                    txtStatus.Text.Trim(),
                    txtRemark.Text.Trim(),
                     bool.Parse(ddlActive.SelectedValue)



                );
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "SucsessMessage();", true);
            Response.Redirect("StatusMaster.aspx");
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "FailMessage();", true);
        }
    }

    private void Loaddata(string StatusID)
    {

        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@StatusID", SqlDbType.NVarChar);
        param[0].Value = StatusID;
        DataTable dt = new DataTable();
        dt = DataAccessor.ExecuteQueryDataTable(@"
select *  from statusmaster  where StatusID =@StatusID", param);
        if (dt.Rows.Count > 0)
        {
            // txtProductName.Text= dt.Rows[0]["ProductCode"].ToString();
            txtStatus.Text = dt.Rows[0]["StatusName"].ToString();
            txtRemark.Text = dt.Rows[0]["Remark"].ToString();
            
            ddlActive.SelectedValue = dt.Rows[0]["Active"].ToString();

        }
    }
}