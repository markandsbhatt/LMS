using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_AddSource : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {


        string strUserID = "";
        string strDataMode = "";
        string strMsg = "";
        strDataMode = "Insert";
        try
        {

            strUserID = GeneralFunctions._GenerateNewStringID("SC", "SourceID", "3", "20", "SourceMaster");
            strDataMode = "Insert";
            strMsg = "Data added successfully";
            MasterData.SourceMaster(
                   strDataMode,
                   strUserID,
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
}