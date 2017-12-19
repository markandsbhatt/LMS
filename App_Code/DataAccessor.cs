using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for DataAccessor
/// </summary>
public class DataAccessor
{
	public DataAccessor()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static String ConnectionString
    {
        get { return ConfigurationManager.AppSettings["ConnectionString"].ToString(); }
    }

    public static string GetInsertedIdWithExecuteNonQuery(String storedProcedureName, params SqlParameter[] arrParam)
    {
        SqlConnection cn = new SqlConnection(ConnectionString);
        SqlCommand cmd = new SqlCommand(storedProcedureName, cn);
        cmd.CommandType = CommandType.StoredProcedure;

        if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken)
            cn.Open();

        try
        {
            if (arrParam != null)
            {
                foreach (SqlParameter param in arrParam)
                    cmd.Parameters.Add(param);
            }

            cmd.ExecuteNonQuery();

            string insertedId = (string)cmd.Parameters[cmd.Parameters.Count - 1].Value;
            return insertedId;
        }
        catch (Exception ex)
        {
            throw new Exception("Error: " + ex.Message);
        }
        finally
        {
            cmd.Dispose();
            cn.Close();
        }
    }

    public static int ExecuteNonQuery(string storedProcedureName, params SqlParameter[] arrParam)
    {
        SqlConnection cn = new SqlConnection(ConnectionString);
        SqlCommand cmd = new SqlCommand(storedProcedureName, cn);
        cmd.CommandType = CommandType.StoredProcedure;

        if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken)
            cn.Open();

        try
        {
            if (arrParam != null)
            {
                foreach (SqlParameter param in arrParam)
                    cmd.Parameters.Add(param);
            }
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected;
        }
        catch (Exception ex)
        {
            throw new Exception("Error: " + ex.Message);
        }
        finally
        {
            cmd.Dispose();
            cn.Close();
        }
    }

    public static DataTable ExecuteQueryDataTable(string CsQuery, params SqlParameter[] arrParam)
    {
        DataTable dt = new DataTable();
        SqlConnection cn = new SqlConnection(ConnectionString);

        SqlCommand cmd = new SqlCommand(CsQuery, cn);

        if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken)
            cn.Open();

        try
        {
            if (arrParam != null)
            {
                foreach (SqlParameter param in arrParam)
                    cmd.Parameters.Add(param);
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception("Error: " + ex.Message);
        }
        finally
        {
            cmd.Dispose();
            cn.Close();
        }
    }

    public static DataTable ExecuteProcDataTable(string storedProcedureName, params SqlParameter[] arrParam)
    {
        DataTable dt = new DataTable();
        SqlConnection cn = new SqlConnection(ConnectionString);

        SqlCommand cmd = new SqlCommand(storedProcedureName, cn);
        cmd.CommandType = CommandType.StoredProcedure;

        if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken)
            cn.Open();

        try
        {
            if (arrParam != null)
            {
                foreach (SqlParameter param in arrParam)
                    cmd.Parameters.Add(param);
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception("Error: " + ex.Message);
        }
        finally
        {
            cmd.Dispose();
            cn.Close();
        }
    }

    public static SqlDataReader ExecuteQueryDataReader(string CsQuery, params SqlParameter[] arrParam)
    {
        SqlConnection cn = new SqlConnection(ConnectionString);
        SqlCommand cmd = new SqlCommand(CsQuery, cn);

        if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken)
            cn.Open();

        try
        {
            if (arrParam != null)
            {
                foreach (SqlParameter param in arrParam)
                    cmd.Parameters.Add(param);
            }

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
        catch (Exception ex)
        {
            throw new Exception("Error: " + ex.Message);
        }
        finally
        {
            cmd.Dispose();
        }
    }

    public static SqlDataReader ExecuteProcDataReader(string storedProcedureName, params SqlParameter[] arrParam)
    {
        SqlConnection cn = new SqlConnection(ConnectionString);

        SqlCommand cmd = new SqlCommand(storedProcedureName, cn);
        cmd.CommandType = CommandType.StoredProcedure;

        if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken)
            cn.Open();

        try
        {
            if (arrParam != null)
            {
                foreach (SqlParameter param in arrParam)
                    cmd.Parameters.Add(param);
            }

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
        catch (Exception ex)
        {
            throw new Exception("Error: " + ex.Message);
        }
        finally
        {
            cmd.Dispose();
        }
    }

    public static void ExecuteQuery(string CsQuery, params SqlParameter[] arrParam)
    {
        SqlConnection cn = new SqlConnection(ConnectionString);

        if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken)
            cn.Open();

        SqlCommand cmd = new SqlCommand(CsQuery, cn);

        try
        {
            if (arrParam != null)
            {
                foreach (SqlParameter param in arrParam)
                    cmd.Parameters.Add(param);
            }

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception("Error: " + ex.Message);
        }
        finally
        {
            cmd.Dispose();
            cn.Close();
        }
    }
}
