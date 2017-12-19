﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SourceMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            populateGroupGrid();
        }
    }

    private void populateGroupGrid()
    {
        string strQry = @"select *  from SourceMaster  ";
        strQry += "order by SourceName";

        DataTable dt = DataAccessor.ExecuteQueryDataTable(strQry);
        rptUsers.DataSource = dt;
        rptUsers.DataBind();
    }


    protected void rptUsers_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("EditSource.aspx?SourceID=" + e.CommandArgument.ToString());
        }
    }
}