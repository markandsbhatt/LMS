using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
 
/// <summary>
/// Summary description for GlobalFunctions
/// </summary>
public class GlobalFunctions
{
	public GlobalFunctions()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string SENDERCODE = "20370";
    public static bool chkAdminLogin(string strUsername, string strPassword)
    {
        bool result = false;

        string sqlQry1 = "select * from Users where Username=@Username and Password=@Password and Active=1";

        SqlParameter[] param1 = new SqlParameter[2];
        param1[0] = new SqlParameter("@Username", SqlDbType.NVarChar, 50);
        param1[0].Value = strUsername;

        param1[1] = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
        param1[1].Value = strPassword;

        SqlDataReader dr1 = DataAccessor.ExecuteQueryDataReader(sqlQry1, param1);
        while (dr1.Read())
        {
           
            HttpContext.Current.Session["UserID"] = dr1["UserID"].ToString();
            HttpContext.Current.Session["UserProfile"] = dr1["Profile"].ToString();
           
            HttpContext.Current.Session["NameofUser"] = dr1["NameofUser"].ToString();

            result = true;
        }
        dr1.Close();

        //if (result == true)
        //{
        //    DataTable aTable = new DataTable("AdminRights");
        //    aTable.Columns.Add("RightID", System.Type.GetType("System.String"));
        //    aTable.Columns.Add("Tab", System.Type.GetType("System.String"));
        //    aTable.Columns.Add("SubTab", System.Type.GetType("System.String"));
        //    aTable.Columns.Add("AllowAdd", System.Type.GetType("System.String"));
        //    aTable.Columns.Add("AllowEdit", System.Type.GetType("System.String"));
        //    aTable.Columns.Add("AllowDelete", System.Type.GetType("System.String"));
        //    aTable.Columns.Add("AllowView", System.Type.GetType("System.String"));
        //    aTable.Columns.Add("AllowExport", System.Type.GetType("System.String"));
        //    aTable.Columns.Add("AllowViewLog", System.Type.GetType("System.String"));

        //    HttpContext.Current.Session["AdminRights"] = aTable;

        //    DataRow dtRow;

        //    string sqlQryRight = "Select UserRights.*, Rights.Tab, Rights.SubTab FROM UserRights ";
        //    sqlQryRight += "INNER JOIN Rights ON Rights.RightID = UserRights.RightID ";
        //    sqlQryRight += "WHERE UserID = @UserID ";

        //    SqlParameter[] paramRights = new SqlParameter[1];
        //    paramRights[0] = new SqlParameter("@UserID", SqlDbType.NVarChar, 50);
        //    paramRights[0].Value = HttpContext.Current.Session["UserID"].ToString();

        //    SqlDataReader drRights = DataAccessor.ExecuteQueryDataReader(sqlQryRight, paramRights);
        //    while (drRights.Read())
        //    {
        //        dtRow = aTable.NewRow();
        //        dtRow["RightID"] = drRights["RightID"].ToString();
        //        dtRow["Tab"] = drRights["Tab"].ToString();
        //        dtRow["SubTab"] = drRights["SubTab"].ToString();
        //        dtRow["AllowAdd"] = drRights["AllowAdd"].ToString();
        //        dtRow["AllowEdit"] = drRights["AllowEdit"].ToString();
        //        dtRow["AllowDelete"] = drRights["AllowDelete"].ToString();
        //        dtRow["AllowView"] = drRights["AllowView"].ToString();
        //        dtRow["AllowExport"] = drRights["AllowExport"].ToString();
        //        dtRow["AllowViewLog"] = drRights["AllowViewLog"].ToString();
        //        aTable.Rows.Add(dtRow);
        //    }
        //    drRights.Close();
        //}

        

        //if (result == false)
        //{
        //    string sqlQry2 = "SELECT POSUsers.*, PointofSale.PartnerID FROM POSUsers ";
        //    sqlQry2 += "INNER JOIN PointofSale on PointofSale.POSID = POSUsers.POSID ";
        //    sqlQry2 += "WHERE Username=@Username and UserPass=@Password and POSUsers.Active=1";

        //    SqlParameter[] param2 = new SqlParameter[2];
        //    param2[0] = new SqlParameter("@Username", SqlDbType.NVarChar, 50);
        //    param2[0].Value = strUsername;

        //    param2[1] = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
        //    param2[1].Value = strPassword;

        //    SqlDataReader dr2 = DataAccessor.ExecuteQueryDataReader(sqlQry2, param2);
        //    while (dr2.Read())
        //    {
        //        HttpContext.Current.Session["ISPOSUser"] = "Yes";
        //        HttpContext.Current.Session["UserID"] = dr2["POSUserID"].ToString();
        //        HttpContext.Current.Session["POSID"] = dr2["POSID"].ToString();
        //        HttpContext.Current.Session["PartnerID"] = dr2["PartnerID"].ToString();

        //        result = true;
        //    }
        //    dr2.Close();
        //}


        return result;
    }

    public static string GetCompanyName()
    {
        string strCompanyName = string.Empty;
        
        string strQry = "SELECT CompanyName FROM Settings";

        SqlDataReader drEmails = DataAccessor.ExecuteQueryDataReader(strQry, null);

        while (drEmails.Read())
        {
            strCompanyName = drEmails["CompanyName"].ToString();
        }

        drEmails.Close();

        return strCompanyName;
    }

    public static string GetDefaultCurrency(string prefixText)
    {
        string strCurrency = string.Empty;

        string strQry = "SELECT Symbol FROM CurrencyMaster WHERE IsDefault = 1";

        SqlDataReader drEmails = DataAccessor.ExecuteQueryDataReader(strQry, null);

        while (drEmails.Read())
        {
            strCurrency = drEmails["Symbol"].ToString();
        }

        drEmails.Close();

        if (!string.IsNullOrEmpty(prefixText))
        {
            strCurrency = prefixText + " " + strCurrency;
        }

        return strCurrency;
    }

    public static string GetDefaultCurrencyID()
    {
        string strCurrencyID = string.Empty;

        string strQry = "SELECT CurrencyID FROM CurrencyMaster WHERE IsDefault = 1";

        SqlDataReader drEmails = DataAccessor.ExecuteQueryDataReader(strQry, null);

        while (drEmails.Read())
        {
            strCurrencyID = drEmails["CurrencyID"].ToString();
        }

        drEmails.Close();

        return strCurrencyID;
    }

    public static string GetCompanyPhone()
    {
        string strCompanyPhone = string.Empty;

        string strQry = "SELECT CompanyPhone FROM Settings";

        SqlDataReader drEmails = DataAccessor.ExecuteQueryDataReader(strQry, null);

        while (drEmails.Read())
        {
            strCompanyPhone = drEmails["CompanyPhone"].ToString();
        }

        drEmails.Close();

        return strCompanyPhone;
    }

    public static string GetCompanyTerms()
    {
        string strCompanyTerms = string.Empty;

        string strQry = "SELECT CompanyTermsConditions FROM Settings";

        SqlDataReader drEmails = DataAccessor.ExecuteQueryDataReader(strQry, null);

        while (drEmails.Read())
        {
            strCompanyTerms = GetWebsiteURL() + "/images/" + drEmails["CompanyTermsConditions"].ToString();
        }

        drEmails.Close();

        return strCompanyTerms;
    }

    public static string GetWebsiteURL()
    {
        string strCompanyTerms = string.Empty;

        string strQry = "SELECT WebsiteURL FROM Settings";

        SqlDataReader drEmails = DataAccessor.ExecuteQueryDataReader(strQry, null);

        while (drEmails.Read())
        {
            strCompanyTerms = drEmails["WebsiteURL"].ToString();
        }

        drEmails.Close();

        return strCompanyTerms;
    }

    public static string GetCompanyLogo()
    {
        string strCompanyLogo = string.Empty;

        string strQry = "SELECT CompanyLogo1 FROM Settings";

        SqlDataReader drEmails = DataAccessor.ExecuteQueryDataReader(strQry, null);

        while (drEmails.Read())
        {
            strCompanyLogo = GetWebsiteURL() + "/images/" + drEmails["CompanyLogo1"].ToString();
        }

        drEmails.Close();

        return strCompanyLogo;
    }

    public static string GetCompanyLogo2()
    {
        string strCompanyLogo = string.Empty;

        string strQry = "SELECT CompanyLogo2 FROM Settings";

        SqlDataReader drEmails = DataAccessor.ExecuteQueryDataReader(strQry, null);

        while (drEmails.Read())
        {
            strCompanyLogo = "images/" + drEmails["CompanyLogo2"].ToString();
        }

        drEmails.Close();

        return strCompanyLogo;
    }

    public static string GetPageTitle()
    {
        string PageTitle = string.Empty;
        
        string strQry = "SELECT PageTitle FROM Settings";

        SqlDataReader drPageTitle = DataAccessor.ExecuteQueryDataReader(strQry,null);

        while (drPageTitle.Read())
        {
            PageTitle = drPageTitle["PageTitle"].ToString();
        }

        drPageTitle.Close();

        return PageTitle;
    }

    public static bool chkMemberLogin(string strLoginid, string strPass)
    {
        bool result = false;

        string sqlQry = "select * from Users where Username=@Username and Password=@Password and Userid !='A1' and Active=1";

        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@UserName", SqlDbType.NVarChar, 150);
        param[0].Value = strLoginid;

        param[1] = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
        param[1].Value = strPass;

        SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(sqlQry, param);
        while (dr.Read())
        {
            HttpContext.Current.Session["UserID"] = dr["UserID"].ToString();
            HttpContext.Current.Session["UserProfile"] = dr["Profile"].ToString();

            HttpContext.Current.Session["EmailID"] = dr["NameofUser"].ToString();


            result = true;
        }
        dr.Close();

        return result;
    }

    public static bool chkIfReedemCartExists()
    {

        bool result = false;

        string sqlQry = "select top 1 CartID from TempLoyaltyTransactions where SessionID=@SessionID";

        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@SessionID", SqlDbType.NVarChar);
        param[0].Value = HttpContext.Current.Session.SessionID.ToString();

        SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(sqlQry, param);
        while (dr.Read())
        {
            result = true;
        }
        dr.Close();

        return result;
    }

    public static bool chkIfDuplicateTransactionExistsInCart(string strEPointID)
    {
        bool result = false;

        string sqlQry = "select top 1 CartID from TempLoyaltyTransactions where SessionID=@SessionID and EPointID=@EPointID";

        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@SessionID", SqlDbType.NVarChar);
        param[0].Value = HttpContext.Current.Session.SessionID.ToString();

        param[1] = new SqlParameter("@EPointID", SqlDbType.NVarChar);
        param[1].Value = strEPointID;

        SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(sqlQry, param);
        while (dr.Read())
        {
            result = true;
        }
        dr.Close();

        return result;
    }

    public static bool chkIfNewMembershipCartExists(string strMemberID)
    {

        bool result = false;

        string sqlQry = "select top 1 CartID from TempMembershipOrders where SessionID=@SessionID and MemberID=@MemberID";

        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@SessionID", SqlDbType.NVarChar);
        param[0].Value = HttpContext.Current.Session.SessionID.ToString();

        param[1] = new SqlParameter("@MemberID", SqlDbType.NVarChar);
        param[1].Value = strMemberID;

        SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(sqlQry, param);
        while (dr.Read())
        {
            result = true;
        }
        dr.Close();

        return result;
    }

    public static int recalculateMemberBalancePoints(string strMemberID)
    {
        int intRedeemedPoints = 0;
        int intEarnedPoints = 0;
        int intBalancePoints = 0;

        SqlParameter[] paramR = new SqlParameter[1];
        paramR[0] = new SqlParameter("@MemberID", SqlDbType.NVarChar);
        paramR[0].Value = strMemberID;

        string sqlQryR = "select isnull(sum(Points),0) as RedeemedPoints from LoyaltyTransactions ";
        sqlQryR += "where Status = 'Confirmed' and Activity = 'Redeemed' and MemberID = @MemberID";

        SqlDataReader drR = DataAccessor.ExecuteQueryDataReader(sqlQryR, paramR);
        while (drR.Read())
        {
            intRedeemedPoints = GeneralFunctions._parseStringToInt(drR["RedeemedPoints"].ToString());
        }
        drR.Close();


        SqlParameter[] paramE = new SqlParameter[1];
        paramE[0] = new SqlParameter("@MemberID", SqlDbType.NVarChar);
        paramE[0].Value = strMemberID;

        string sqlQryE = "select isnull(sum(Points),0) as EarnedPoints from LoyaltyTransactions ";
        sqlQryE += "where Status = 'Confirmed' and Activity = 'Earned' and MemberID = @MemberID";

        SqlDataReader drE = DataAccessor.ExecuteQueryDataReader(sqlQryE, paramE);
        while (drE.Read())
        {
            intEarnedPoints = GeneralFunctions._parseStringToInt(drE["EarnedPoints"].ToString());
        }
        drE.Close();

        intBalancePoints = intEarnedPoints - intRedeemedPoints;

        SqlParameter[] paramU = new SqlParameter[2];
        paramU[0] = new SqlParameter("@MemberID", SqlDbType.NVarChar);
        paramU[0].Value = strMemberID;

        paramU[1] = new SqlParameter("@BalancePoints", SqlDbType.Int);
        paramU[1].Value = intBalancePoints;

        DataAccessor.ExecuteQuery("Update Members set BalancePoints=@BalancePoints where MemberID=@MemberID", paramU);

        return intBalancePoints;

    }

    public static int recalculateMemberBalancePoints1(string strMemberID, string strUpdateType, int intPoints, string strLoyaltyTranID)
    {
        int intExistingPoints = 0;
        int intBalancePoints = 0;


        SqlParameter[] paramR = new SqlParameter[1];
        paramR[0] = new SqlParameter("@MemberID", SqlDbType.NVarChar);
        paramR[0].Value = strMemberID;

        string sqlQryR = "select BalancePoints from Members where MemberID = @MemberID";

        SqlDataReader drR = DataAccessor.ExecuteQueryDataReader(sqlQryR, paramR);
        while (drR.Read())
        {
            intExistingPoints = GeneralFunctions._parseStringToInt(drR["BalancePoints"].ToString());
        }
        drR.Close();

        SqlParameter[] paramU = new SqlParameter[2];
        paramU[0] = new SqlParameter("@MemberID", SqlDbType.NVarChar);
        paramU[0].Value = strMemberID;

        paramU[1] = new SqlParameter("@BalancePoints", SqlDbType.Int);
        paramU[1].Value = intBalancePoints;

        DataAccessor.ExecuteQuery("Update Members set BalancePoints=@BalancePoints where MemberID=@MemberID", paramU);

        return intBalancePoints;

    }

    public static int getMemberBalancePoints(string strMemberID)
    {
        int intBalancePoints = 0;

        SqlParameter[] paramR = new SqlParameter[1];
        paramR[0] = new SqlParameter("@MemberID", SqlDbType.NVarChar);
        paramR[0].Value = strMemberID;

        string sqlQryR = "select BalancePoints from Members where MemberID = @MemberID";

        SqlDataReader drR = DataAccessor.ExecuteQueryDataReader(sqlQryR, paramR);
        while (drR.Read())
        {
            intBalancePoints = GeneralFunctions._parseStringToInt(drR["BalancePoints"].ToString());
        }
        drR.Close();

        return intBalancePoints;
    }

    public static string getPageContent(string strPageID)
    {
        string result = "";

        string sqlQry = "select pagecontent from PageContent where pagecontentid=@pagecontentid";

        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@pagecontentid", SqlDbType.NVarChar);
        param[0].Value = strPageID;

        SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(sqlQry, param);
        while (dr.Read())
        {
            result = dr["pagecontent"].ToString();
        }
        dr.Close();

        return result;
    }

    public static string formatTestimonialName(string strExistingMemberName, string strExistingCityTown, string strExistingCountry, string strMemberName, string strMemberCityTown, string strMemberCountry)
    {
        string result = "";

        if (strExistingMemberName.Trim() != "")
        {
            result = GeneralFunctions.ConvertStringToTitleCase(strExistingMemberName.Trim());

            if (strExistingCityTown.Trim() != "")
            {
                result += " , " + strExistingCityTown.Trim();
            }
            if (strExistingCountry.Trim() != "")
            {
                result += " , " + strExistingCountry.Trim();
            }
        }
        else
        {
            result = GeneralFunctions.ConvertStringToTitleCase(strMemberName.Trim());

            if (strMemberCityTown.Trim() != "")
            {
                result += " , " + strMemberCityTown.Trim();
            }
            if (strMemberCountry.Trim() != "")
            {
                result += " , " + strMemberCountry.Trim();
            }
        }

        return result;

    }

    public static bool setAdminRights(string strTab, string strSubTab, string strMode)
    {
        bool result = false;

        DataTable AdminRights = (DataTable)HttpContext.Current.Session["AdminRights"];

        string expression = "Tab = '" + strTab + "' and SubTab = '" + strSubTab + "'";
        string sortOrder = "Tab ASC";

        DataRow[] foundRows = AdminRights.Select(expression, sortOrder);

        for (int i = 0; i < foundRows.Length; i++)
        {
            try
            {
                result = bool.Parse(foundRows[i][strMode].ToString());
            }
            catch
            {
            }
        }

        foundRows = null;
        AdminRights.Dispose();
        expression = null;
        sortOrder = null;

        return result;
    }

   

    public static string GetsPointFromCode(string ScratchCode, ref int Points)
    {
        string Result = "";

        string sqlQry = "Select EarnPoints, EPointID from EarnPointsScheme ";
        sqlQry += "Inner Join ProductPoints on ProductPoints.PPID = EarnPointsScheme.PPID ";
        sqlQry += "where Ltrim(Rtrim(ProductPoints.ScratchCode)) like '%' + @ScratchCode +'%' ";

        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@ScratchCode", SqlDbType.NVarChar, 255);
        param[0].Value = ScratchCode;

        SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(sqlQry, param);
        while (dr.Read())
        {
            Result = dr["EPointID"].ToString();
            Points = GeneralFunctions._parseStringToInt(dr["EarnPoints"].ToString());
        }
        dr.Close();

        return Result;
    }

    public static bool ChkIsCodeRedeemed(string MemberID, string ScratchCode)
    {
        bool Result = false;

        string sqlQry = "Select LoyaltyTranID from LoyaltyTransactions ";
        sqlQry += "Inner Join EarnPointsScheme on EarnPointsScheme.EPointID = LoyaltyTransactions.EPointID ";
        sqlQry += "Inner Join ProductPoints on ProductPoints.PPID = EarnPointsScheme.PPID ";
        sqlQry += "WHERE Ltrim(Rtrim(ProductPoints.ScratchCode)) like '%' + @ScratchCode +'%' AND LoyaltyTransactions.MemberID=@MemberID ";

        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@MemberID", SqlDbType.NVarChar, 50);
        param[0].Value = MemberID;

        param[1] = new SqlParameter("@ScratchCode", SqlDbType.NVarChar, 255);
        param[1].Value = ScratchCode;

        SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(sqlQry, param);
        while (dr.Read())
        {
            Result = true;
        }
        dr.Close();

        return Result;
    }

    public static string GetMemberIDFromMobileNo(string MobileNo)
    {
        string Result = "";

        string sqlQry = "Select MemberID from Members where MobileNo=@MobileNo ";

        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@MobileNo", SqlDbType.NVarChar, 50);
        param[0].Value = MobileNo;

        SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(sqlQry, param);
        while (dr.Read())
        {
            Result = dr["MemberID"].ToString();
        }
        dr.Close();

        return Result;
    }

    public static bool CheckDuplicateMobile(string strMobileNo)
    {
        bool result = false;

        string sqlQry = "select MemberID from Members where MobileNo=@MobileNo ";

        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@MobileNo", SqlDbType.NVarChar);
        param[0].Value = strMobileNo;

        SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(sqlQry, param);
        while (dr.Read())
        {
            result = true;
        }
        dr.Close();

        return result;
    }

    public static bool CheckDuplicateFFMember(string strMobileNo)
    {
        bool result = false;

        string sqlQry = "select MFFID from memberFFList where MobileNo=@MobileNo ";

        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@MobileNo", SqlDbType.NVarChar);
        param[0].Value = strMobileNo;

        SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(sqlQry, param);
        while (dr.Read())
        {
            result = true;
        }
        dr.Close();

        return result;
    }

    public static string GetsPointFormCode(string ScratchCode, ref int Points)
    {
        string Result = "";

        string sqlQry = "Select EarnPoints, EPointID from EarnPointsScheme ";
        sqlQry += "Inner Join ProductPoints on ProductPoints.PPID = EarnPointsScheme.PPID ";
        sqlQry += "where Ltrim(Rtrim(ProductPoints.ScratchCode)) like '%' + @ScratchCode +'%' ";

        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@ScratchCode", SqlDbType.NVarChar, 255);
        param[0].Value = ScratchCode;

        SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(sqlQry, param);
        while (dr.Read())
        {
            Result = dr["EPointID"].ToString();
            Points = GeneralFunctions._parseStringToInt(dr["EarnPoints"].ToString());
        }
        dr.Close();

        return Result;
    }

    public static int GetsPointByID(string EPointID)
    {
        int Result = 0;

        string sqlQry = "Select ReedemPoints, EPointID from EarnPointsScheme ";
        sqlQry += "where EarnPointsScheme.EPointID = @EPointID  ";

        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@EPointID", SqlDbType.NVarChar, 255);
        param[0].Value = EPointID;

        SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(sqlQry, param);
        while (dr.Read())
        {
            Result = GeneralFunctions._parseStringToInt(dr["ReedemPoints"].ToString());
        }
        dr.Close();

        return Result;
    }

    public static void GetMemberPoints(string MemberID, ref int Earned, ref int Redeemed, ref int Transfered)
    {        

        try
        {

            string sqlQry = "Select isnull(Sum(Points),0) as EarnedPoints from LoyaltyTransactions where MemberID=@MemberID AND Activity='Earned' AND Status='Confirmed'";

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MemberID", SqlDbType.NVarChar, 50);
            param[0].Value = MemberID;

            SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(sqlQry, param);
            while (dr.Read())
            {
                Earned = GeneralFunctions._parseStringToInt(dr["EarnedPoints"].ToString());                
            }
            dr.Close();


            string sqlQry1 = "Select isnull(Sum(Points),0) as TransferedPoints from LoyaltyTransactions where FromMemberID=@MemberID AND Activity='Transfer' AND Status='Confirmed'";

            SqlParameter[] param1 = new SqlParameter[1];
            param1[0] = new SqlParameter("@MemberID", SqlDbType.NVarChar, 50);
            param1[0].Value = MemberID;

            SqlDataReader dr1 = DataAccessor.ExecuteQueryDataReader(sqlQry1, param1);
            while (dr1.Read())
            {
                Transfered = GeneralFunctions._parseStringToInt(dr1["TransferedPoints"].ToString());
                
            }
            dr1.Close();

            string sqlQry2 = "Select isnull(Sum(Points),0) as RedeemedPoints from LoyaltyTransactions where MemberID=@MemberID AND Activity='Redeemed' AND Status='Confirmed'";

            SqlParameter[] param2 = new SqlParameter[1];
            param2[0] = new SqlParameter("@MemberID", SqlDbType.NVarChar, 50);
            param2[0].Value = MemberID;

            SqlDataReader dr2 = DataAccessor.ExecuteQueryDataReader(sqlQry2, param2);
            while (dr2.Read())
            {
                Redeemed = GeneralFunctions._parseStringToInt(dr2["RedeemedPoints"].ToString());
                
            }
            dr2.Close();
        }
        catch (Exception ex)
        {
               
        }
        
    }
}
