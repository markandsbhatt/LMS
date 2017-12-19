using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_EditleadMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GeneralFunctions._ChkSession("UserID") == "")
            Response.Redirect("adminlogin.aspx");

        if (GeneralFunctions._ChkSession("UserID") == "")
            Response.Redirect("adminlogin.aspx");

        if (!IsPostBack)
        {
            GeneralFunctions._FillDropDown("Select SourceName,SourceID from sourcemaster where Active=1 order by SourceName", "SourceName", "SourceID", "-Select-", "", ddlSource);
            if (Request.QueryString["LeadID"].ToString() == "")
            {

            }
            else
            {
                Loaddata(Request.QueryString["LeadID"].ToString());
            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {


        string strLeadID = "";
        string strDataMode = "";
        string strMsg = "";
   

        try
        {

            
            strDataMode = "Update";
            strMsg = "Data added successfully";
            MasterData.LeadMaster(strDataMode, Request.QueryString["LeadID"].ToString(), "Google.com", txtDomainName.Text.Trim(), txtComapanyName.Text.Trim(), txtMobile.Text.Trim(), txtLandline.Text.Trim(),
                txtEmailID.Text.Trim(), txtAddress.Text.Trim(), txtState.Text.Trim(), txtCity.Text.Trim(), txtCountry.Text.Trim(),
                txtZipCode.Text.Trim(), txtContactPerson.Text.Trim(), txtContactPersonMobile.Text.Trim(), bool.Parse(ddlActive.SelectedValue),
                 false,txtDomainDate.Text.Trim(), ddlSource.SelectedValue.Trim(), false
                );
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "SucsessMessage();", true);
            Response.Redirect("leadmaster.aspx");
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "FailMessage();", true);
        }
    }

    private void Loaddata(string LeadID)
    {

        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LeadID", SqlDbType.NVarChar);
        param[0].Value = LeadID;
        DataTable dt = new DataTable();
        dt = DataAccessor.ExecuteQueryDataTable(@"
select *  from [LeadMaster]  where LeadID =@LeadID", param);
        if (dt.Rows.Count > 0)
        {
            // txtProductName.Text= dt.Rows[0]["ProductCode"].ToString();
            ddlSource.SelectedValue = dt.Rows[0]["SourceID"].ToString();
            txtDomainName.Text = dt.Rows[0]["DomainName"].ToString();
            txtDomainDate.Text = dt.Rows[0]["DomainCreatedDate"].ToString();
            txtComapanyName.Text = dt.Rows[0]["ComapanyName"].ToString();
            txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
            txtEmailID.Text = dt.Rows[0]["EmailID"].ToString();
            txtLandline.Text = dt.Rows[0]["Landline"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            txtCity.Text = dt.Rows[0]["City"].ToString();
            txtState.Text = dt.Rows[0]["State"].ToString();
            txtCountry.Text = dt.Rows[0]["Country"].ToString();
            txtZipCode.Text = dt.Rows[0]["ZipCode"].ToString();
            txtContactPerson.Text = dt.Rows[0]["ContactPerson"].ToString();
            txtContactPersonMobile.Text = dt.Rows[0]["ContactPersonMobile"].ToString();
            ddlMultipleDomain.SelectedValue = dt.Rows[0]["MultipleDomain"].ToString();
            ddlActive.SelectedValue = dt.Rows[0]["Acitve"].ToString();

        }
    }
}