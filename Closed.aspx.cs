using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Closed : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GeneralFunctions._ChkSession("UserID") == "")
            Response.Redirect("Login.aspx");
        if (!IsPostBack)
        {
            populateGroupGrid();
            GeneralFunctions._FillDropDown("Select StatusName,StatusID from statusmaster where Active=1 order by StatusName", "StatusName", "StatusID", "-Select-", "", ddlstatus);
        }
    }

    private void populateGroupGrid()
    {
        string strQry = @"
	   select distinct  leadmaster.leadid,BlockLeadUser.BlockID,DomainName,ComapanyName,EmailID,Mobile,ContactPerson,City,State,Country,ZipCode
       from leadmaster
	    inner join BlockLeadUser
	    on BlockLeadUser.LeadID  = leadmaster. LeadID 
		inner join  [BlockFollowUp]
		on [BlockFollowUp].BlockID = BlockLeadUser.BlockID
 where  BlockLeadUser.UserID = @UserID and StatusID ='C2'  ";
        strQry += " group by leadmaster.leadid,BlockLeadUser.BlockID,DomainName,ComapanyName,EmailID,Mobile,ContactPerson,City,State,Country,ZipCode";

        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@UserID", SqlDbType.NVarChar, 150);
        param[0].Value = Session["UserID"].ToString();
        DataTable dt = DataAccessor.ExecuteQueryDataTable(strQry, param);
        rptUsers.DataSource = dt;
        rptUsers.DataBind();
    }



    protected void BindModalPopup(string DomainName)
    {
        txtFollowupDate.Text = "Markand";
        lblHeading.Text = DomainName;
    }


    protected void GetModelData(object sender, EventArgs e)
    {

        //  int id = int.Parse((sender as Button).CommandArgument);
        string BlockID = (sender as Button).CommandArgument.ToString();
        string strQry = @"
	    select * from leadmaster
	    inner join BlockLeadUser
	    on BlockLeadUser.LeadID  = leadmaster. LeadID  where  BlockLeadUser.UserID = @UserID and BlockLeadUser.BlockID = @BlockID  ";
        strQry += "order by BlockLeadUser.DateCreated desc";

        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@UserID", SqlDbType.NVarChar, 150);
        param[0].Value = Session["UserID"].ToString();


        param[1] = new SqlParameter("@BlockID", SqlDbType.NVarChar, 150);
        param[1].Value = BlockID;

        DataTable dt = DataAccessor.ExecuteQueryDataTable(strQry, param);


        string query2 = @"select *  from BlockFollowUp where BlockID =@BlockID";
        SqlParameter[] param1 = new SqlParameter[1];
        param1[0] = new SqlParameter("@BlockID", SqlDbType.NVarChar, 150);
        param1[0].Value = BlockID;

        DataTable dt2 = DataAccessor.ExecuteQueryDataTable(query2, param1);

        if (dt.Rows.Count > 0)
        {
            txtComments.Text = "";
            txttags.Text = "";
            txtFollowupDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txtNextFollowupDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            lblHeading.Text = dt.Rows[0]["DomainName"].ToString();
            hdnLeadID.Value = dt.Rows[0]["LeadID"].ToString();
            hdnBlockID.Value = dt.Rows[0]["BlockID"].ToString();
            rptModalPopupFollowup.DataSource = dt2;
            rptModalPopupFollowup.DataBind();
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "FailMessage();", true);
        }
    }

    protected void btnFollowup_Click(object sender, EventArgs e)
    {
        string strFollowupID = "";
        string strDataMode = "";
        string strMsg = "";
        strDataMode = "Insert";
        try
        {

            strFollowupID = GeneralFunctions._GenerateNewStringID("BF", "FollowupID", "3", "20", "BlockFollowUp");
            strDataMode = "Insert";
            strMsg = "Data added successfully";
            MasterData.BlockLeadFollowup(strDataMode, strFollowupID, hdnBlockID.Value.Trim(), hdnLeadID.Value.Trim(),
                Session["UserID"].ToString(), ddlstatus.SelectedValue.Trim(), ddlstatus.SelectedItem.Text.Trim(),
                Convert.ToDateTime(txtFollowupDate.Text.Trim()), Convert.ToDateTime(txtNextFollowupDate.Text.Trim()), txttags.Text.Trim(), txtComments.Text.Trim(),
                "", true);
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "CloseModal();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "SucsessMessage();", true);
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "FailMessage();", true);
        }
    }
}