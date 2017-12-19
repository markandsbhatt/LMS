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
using System.Data.SqlTypes;

/// <summary>
/// Summary description for MasterData
/// </summary>
public class MasterData
{
    static SqlDateTime sqlDateTimeNull = SqlDateTime.Null;
    static SqlInt32 sqlInt32null = SqlInt32.Null;

    private static SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

    public MasterData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void Users
    (
        string DataMode,
        string UserID,
        string NameofUser,
        string Designation,
        string PartnerID,
        string Profile,
        string EmailID,
        string Username,
        string Password,
        bool Active,
        string LevelID,
        string Mobile,
        string FirstName,
        string LastName
    )
    {
        string strSPName = "";

        if (DataMode == "Update")
            strSPName = "User_Update";
        else
            strSPName = "usp_insUsers";

        SqlCommand cmd = new SqlCommand(strSPName, cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserID;
        cmd.Parameters.Add("@NameofUser", SqlDbType.NVarChar).Value = NameofUser;
        cmd.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = Designation;
        cmd.Parameters.Add("@PartnerID", SqlDbType.NVarChar).Value = PartnerID;
        cmd.Parameters.Add("@Profile", SqlDbType.NVarChar).Value = Profile;
        cmd.Parameters.Add("@EmailID", SqlDbType.NVarChar).Value = EmailID;
        cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = Username;
        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Password;
        cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        cmd.Parameters.Add("@LevelID", SqlDbType.NVarChar).Value = LevelID;
        cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = Mobile;
        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName;
        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = LastName;
        if (cnn.State == ConnectionState.Closed)
        {
            cnn.Open();
        }

        cmd.ExecuteNonQuery();
        cnn.Close();
    }


    public static void LeadMaster
  (
        string DataMode,
      string _leadid,
     string _domainsource,
     string _domainname,
     string _comapanyname,
     string _mobile,
     string _landline,
     string _emailid,
     string _address,
     string _state,
     string _city,
       string _Country,
     string _zipcode,
     string _contactperson,
     string _contactpersonmobile,
     bool _acitve,
     bool _isblocked,
     string _domainCreatedDate,
     string  _sourceID,
     bool _multipledomain


  )
    {
        string strSPName = "";

        if (DataMode == "Update")
            strSPName = "usp_updLeadMaster";
        else
            strSPName = "usp_insLeadMaster";

        SqlCommand cmd = new SqlCommand(strSPName, cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@LeadID", SqlDbType.NVarChar).Value = _leadid;
        cmd.Parameters.Add("@DomainSource", SqlDbType.NVarChar).Value = _domainsource;
        cmd.Parameters.Add("@DomainName", SqlDbType.NVarChar).Value = _domainname;
        cmd.Parameters.Add("@ComapanyName", SqlDbType.NVarChar).Value = _comapanyname;
        cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = _mobile;
        cmd.Parameters.Add("@Landline", SqlDbType.NVarChar).Value = _landline;
        cmd.Parameters.Add("@EmailID", SqlDbType.NVarChar).Value = _emailid;
        cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = _address;
      
        cmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = _state;
        cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = _city;
        cmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value = _Country;
        cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = _zipcode;
        cmd.Parameters.Add("@ContactPerson", SqlDbType.NVarChar).Value = _contactperson;
        cmd.Parameters.Add("@ContactPersonMobile", SqlDbType.NVarChar).Value = _contactpersonmobile;
      
        cmd.Parameters.Add("@Acitve", SqlDbType.Bit).Value = _acitve;
        cmd.Parameters.Add("@IsBlocked", SqlDbType.Bit).Value = _isblocked;
        cmd.Parameters.Add("@DomainCreatedDate", SqlDbType.NVarChar).Value = _domainCreatedDate;
        cmd.Parameters.Add("@SourceID", SqlDbType.NVarChar).Value = _sourceID;
        cmd.Parameters.Add("@MultipleDomain", SqlDbType.Bit).Value = _multipledomain;
        if (cnn.State == ConnectionState.Closed)
        {
            cnn.Open();
        }

        cmd.ExecuteNonQuery();
        cnn.Close();
    }

    public static void StatusMaster
(
        string DataMode,
         string _statusid,
     string _statusname,
     string _remark,
     bool _active

        )
    {
        string strSPName = "";

        if (DataMode == "Update")
            strSPName = "usp_updStatusMaster";
        else
            strSPName = "usp_insStatusMaster";

        SqlCommand cmd = new SqlCommand(strSPName, cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@StatusID", SqlDbType.NVarChar).Value = _statusid;
        cmd.Parameters.Add("@StatusName", SqlDbType.NVarChar).Value = _statusname;
        cmd.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = _remark;
        cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = _active;
        if (cnn.State == ConnectionState.Closed)
        {
            cnn.Open();
        }

        cmd.ExecuteNonQuery();
        cnn.Close();
    }

    public static void SourceMaster
(
      string DataMode,
       string _sourceid,
     string _sourcename,
     string _state,
     string _city,
     string _country,
     string _remark,
     bool _active
  

      )
    {
        string strSPName = "";

        if (DataMode == "Update")
            strSPName = "usp_updSourceMaster";
        else
            strSPName = "usp_insSourceMaster";

        SqlCommand cmd = new SqlCommand(strSPName, cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@SourceID", SqlDbType.NVarChar).Value = _sourceid;
        cmd.Parameters.Add("@SourceName", SqlDbType.NVarChar).Value = _sourcename;
        cmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = _state;
        cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = _city;
        cmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value = _country;
        cmd.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = _remark;
        cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = _active;
        if (cnn.State == ConnectionState.Closed)
        {
            cnn.Open();
        }

        cmd.ExecuteNonQuery();
        cnn.Close();
    }


    public static void BlockLead
(
  string DataMode,
   string BlockID,
 string LeadID,
 string UserID

  )
    {
        string strSPName = "";

        if (DataMode == "Update")
            strSPName = "usp_updSourceMaster";
        else
            strSPName = "usp_insBlockLeadUser";

        SqlCommand cmd = new SqlCommand(strSPName, cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@BlockID", SqlDbType.NVarChar).Value = BlockID;
        cmd.Parameters.Add("@LeadID", SqlDbType.NVarChar).Value = LeadID;
        cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserID;
        
        if (cnn.State == ConnectionState.Closed)
        {
            cnn.Open();
        }

        cmd.ExecuteNonQuery();
        cnn.Close();
    }

    public static void BlockLeadFollowup
(
     string DataMode,
     string _followupid,
     string _blockid,
     string _leadid,
     string _userid,
     string _statusid,
     string _statusname,
     DateTime _followupdate,
     DateTime _nextfollowupdate,
     string _tags,
     string _comment,
     string _followupemail,
     bool _isopen


 )
    {
        string strSPName = "";

        if (DataMode == "Update")
            strSPName = "usp_updSourceMaster";
        else
            strSPName = "usp_insBlockFollowUp";

        SqlCommand cmd = new SqlCommand(strSPName, cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@FollowupID", SqlDbType.NVarChar).Value = _followupid;
        cmd.Parameters.Add("@BlockID", SqlDbType.NVarChar).Value = _blockid;
        cmd.Parameters.Add("@LeadID", SqlDbType.NVarChar).Value = _leadid;
        cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = _userid;
        cmd.Parameters.Add("@StatusID", SqlDbType.NVarChar).Value = _statusid;
        cmd.Parameters.Add("@StatusName", SqlDbType.NVarChar).Value = _statusname;
        cmd.Parameters.Add("@FollowUpDate", SqlDbType.DateTime).Value = _followupdate;
        cmd.Parameters.Add("@NextFollowUpDate", SqlDbType.DateTime).Value = _nextfollowupdate;
        cmd.Parameters.Add("@Tags", SqlDbType.NVarChar).Value = _tags;
        cmd.Parameters.Add("@Comment", SqlDbType.NVarChar).Value = _comment;
        cmd.Parameters.Add("@FollowUpEmail", SqlDbType.NVarChar).Value = _followupemail;
        cmd.Parameters.Add("@IsOpen", SqlDbType.Bit).Value = _isopen;

        if (cnn.State == ConnectionState.Closed)
        {
            cnn.Open();
        }

        cmd.ExecuteNonQuery();
        cnn.Close();
    }
}
