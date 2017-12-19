using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_adminlogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Abandon();

         
        }

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        bool isLoggedIn = GlobalFunctions.chkAdminLogin(txtLogin.Text.Trim(), txtPassword.Text.Trim());
        if (isLoggedIn)
        {
            Response.Redirect("Dashboard.aspx");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "LoginFailed();", true);
        }
    }
}