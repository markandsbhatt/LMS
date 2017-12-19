using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditSource : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["SourceID"].ToString() == "")
            {

            }
            else
            {
                Loaddata(Request.QueryString["SourceID"].ToString());
            }
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {


        string strSourceID = Request.QueryString["SourceID"].ToString();
        string strDataMode = "";
        string strMsg = "";

        try
        {


            strDataMode = "Update";
            strMsg = "Data added successfully";
            MasterData.SourceMaster(
                    strDataMode,
                    strSourceID,
                    txtSourceName.Text.Trim(),
                 txtState.Text.Trim(), txtCity.Text.Trim(), txtCountry.Text.Trim(),

                    txtRemark.Text.Trim(),
                     bool.Parse(ddlActive.SelectedValue)



                );
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "SucsessMessage();", true);
            Response.Redirect("SourceMaster.aspx");
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "FailMessage();", true);
        }
    }

    private void Loaddata(string SourceID)
    {

        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@SourceID", SqlDbType.NVarChar);
        param[0].Value = SourceID;
        DataTable dt = new DataTable();
        dt = DataAccessor.ExecuteQueryDataTable(@"
select *  from SourceMaster  where SourceID =@SourceID", param);
        if (dt.Rows.Count > 0)
        {
            // txtProductName.Text= dt.Rows[0]["ProductCode"].ToString();
            txtSourceName.Text = dt.Rows[0]["SourceName"].ToString();
            txtRemark.Text = dt.Rows[0]["Remark"].ToString();
            txtState.Text  = dt.Rows[0]["State"].ToString();
            txtCity.Text = dt.Rows[0]["City"].ToString();
            txtCountry.Text = dt.Rows[0]["Country"].ToString();

            ddlActive.SelectedValue = dt.Rows[0]["Active"].ToString();

        }
    }
}