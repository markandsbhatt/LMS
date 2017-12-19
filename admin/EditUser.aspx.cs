using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_EditUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["UserID"].ToString() == "")
            {

            }
            else
            {
                Loaddata(Request.QueryString["UserID"].ToString());
            }
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {


        string strUserID = Request.QueryString["UserID"].ToString();
        string strDataMode = "";
        string strMsg = "";
       
        try
        {

            
            strDataMode = "Update";
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

    private void Loaddata(string UserID)
    {

        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@userid", SqlDbType.NVarChar);
        param[0].Value = UserID;
        DataTable dt = new DataTable();
        dt = DataAccessor.ExecuteQueryDataTable(@"
select *  from users  where userid =@userid", param);
        if (dt.Rows.Count > 0)
        {
            // txtProductName.Text= dt.Rows[0]["ProductCode"].ToString();
            txtNameOfUser.Text = dt.Rows[0]["NameofUser"].ToString();
            txtDesignation.Text = dt.Rows[0]["Designation"].ToString();
            txtUserName.Text = dt.Rows[0]["Username"].ToString();
            txtPassword.Text = dt.Rows[0]["Password"].ToString();
            txtMobileNo.Text = dt.Rows[0]["Mobile"].ToString();
            ddlActive.SelectedValue= dt.Rows[0]["Active"].ToString();

        }
    }
}