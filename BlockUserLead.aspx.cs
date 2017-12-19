using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class BlockUserLead : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GeneralFunctions._ChkSession("UserID") == "")
            Response.Redirect("Login.aspx");

        
        if (!IsPostBack)
        {
            populateGroupGrid();
        }
    }

    private void populateGroupGrid()
    {
        string strQry = @"select * from Leadmaster where IsBlocked = 0 ";
        strQry += "order by DateCreated desc";

        DataTable dt = DataAccessor.ExecuteQueryDataTable(strQry);
        rptUsers.DataSource = dt;
        rptUsers.DataBind();
    }


    protected void rptUsers_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("EditleadMaster.aspx?LeadID=" + e.CommandArgument.ToString());
        }
    }

    public void DoBlock(object sender, EventArgs e)
    {
        try
        {
            foreach (RepeaterItem i in rptUsers.Items)
            {
                //Retrieve the state of the CheckBox
                CheckBox cb = (CheckBox)i.FindControl("selectUser");
                if (cb.Checked)
                {
                    string BlockID = GeneralFunctions._GenerateNewStringID("BL", "BlockID", "3", "20", "BlockLeadUser");
                    string strDataMode = "Insert";
                    //Retrieve the value associated with that CheckBox
                    HiddenField hdnLeadID = (HiddenField)i.FindControl("hdnLeadID");

                    MasterData.BlockLead(strDataMode,BlockID,hdnLeadID.Value.Trim(), Session["UserID"].ToString());

                    //Now we can use that value to do whatever we want

                }
            }
            populateGroupGrid();
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "SucsessMessage();", true);
            //Response.Redirect("SourceMaster.aspx");
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "FailMessage();", true);
        }
       
    }
}