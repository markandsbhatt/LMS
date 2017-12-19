using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["mode"] != null)
            {
                if (Request.QueryString["mode"].ToString() == "l")
                {
                    Session.Abandon();
                    Response.Redirect("login.aspx");
                }
            }

            txtUserName.Focus();

            if (Request.Browser.Cookies)
            {
                if (Request.Cookies["SZLOGIN"] != null)
                {
                    txtUserName.Text = Request.Cookies["SZLOGIN"]["UNAME"].ToString();
                    txtUserPass.Text = Request.Cookies["SZLOGIN"]["UPASS"].ToString();
                    chkRememberMe.Checked = true;
                }
            }
        }
    }

 

    private void SetCookieForRememberMe()
    {
        if (Request.Browser.Cookies)
        {
            if (Request.Cookies["SZLOGIN"] == null)
            {
                Response.Cookies["SZLOGIN"].Expires = DateTime.Now.AddDays(1000);
                Response.Cookies["SZLOGIN"]["UNAME"] = txtUserName.Text.Trim();
                Response.Cookies["SZLOGIN"]["UPASS"] = txtUserPass.Text.Trim();
            }
            else
            {
                Response.Cookies["SZLOGIN"]["UNAME"] = txtUserName.Text.Trim();
                Response.Cookies["SZLOGIN"]["UPASS"] = txtUserPass.Text.Trim();
            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (GlobalFunctions.chkMemberLogin(txtUserName.Text.Trim(), txtUserPass.Text.Trim()))
        {
            if (chkRememberMe.Checked)
            {
                SetCookieForRememberMe();
            }
            else if (Request.Cookies["SZLOGIN"] != null)
            {
                HttpCookie myCookie = new HttpCookie("SZLOGIN");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }


            Response.Redirect("BlockUserLead.aspx");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "LoginFailed();", true);
        }
    }
}