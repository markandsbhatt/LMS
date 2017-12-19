using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_AddStatusaspx : System.Web.UI.Page
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

            strUserID = GeneralFunctions._GenerateNewStringID("ST", "StatusID", "3", "20", "statusmaster");
            strDataMode = "Insert";
            strMsg = "Data added successfully";
            MasterData.StatusMaster(
                   strDataMode,
                   strUserID,
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
}