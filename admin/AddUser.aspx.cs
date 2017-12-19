using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_AddUser : System.Web.UI.Page
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

            strUserID = GeneralFunctions._GenerateNewStringID("U", "UserID", "2", "20", "Users");
            strDataMode = "Insert";
            strMsg = "Data added successfully";
            MasterData.Users(
                   strDataMode,
                   strUserID,
                   txtNameOfUser.Text.Trim(),
                   txtDesignation.Text.Trim(),
                   "0",
                   "staff",
                  txtUserName.Text.Trim(),
                   txtUserName.Text.Trim(),
                   txtPassword.Text.Trim(),
                   bool.Parse(ddlActive.SelectedValue),
                   "0",
                   txtMobileNo.Text.Trim(),
                   "-",
                   "-"

               );
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "SucsessMessage();", true);
            Response.Redirect("users.aspx");
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "FailMessage();", true);
        }
    }
}