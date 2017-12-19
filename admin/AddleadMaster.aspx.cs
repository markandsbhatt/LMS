using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class admin_AddleadMaster : System.Web.UI.Page
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
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {


        string strLeadID = "";
        string strDataMode = "";
        string strMsg = "";
        strDataMode = "Insert";
      
        try
        {

            strLeadID = GeneralFunctions._GenerateNewStringID("L", "LeadID", "2", "20", "LeadMaster");
            strDataMode = "Insert";
            strMsg = "Data added successfully";
            MasterData.LeadMaster(strDataMode, strLeadID, "Google.com", txtDomainName.Text.Trim(), txtComapanyName.Text.Trim(), txtMobile.Text.Trim(), txtLandline.Text.Trim(),
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
}