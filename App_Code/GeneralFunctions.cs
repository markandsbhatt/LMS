using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Net;
using System.Collections;
using OfficeOpenXml;

/// <summary>
/// Summary description for GeneralFunctions
/// </summary>
public class GeneralFunctions
{
    public GeneralFunctions()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static byte[] _ImageResize(int MaxSideSize, int MaxHeightSize, Stream Buffer, string fileName, string filePath)
    {
        byte[] byteArray = null;  // really make this an error gif 

        try
        {

            Bitmap bitMap = new Bitmap(Buffer);
            int intOldWidth = bitMap.Width;
            int intOldHeight = bitMap.Height;

            decimal lnRatio;
            int intNewWidth = 0;
            int intNewHeight = 0;

            //*** If the image is smaller than a thumbnail just return it
            if (intOldWidth < MaxSideSize && intOldHeight < MaxHeightSize)
            {
                intNewWidth = MaxSideSize;
                intNewHeight = MaxHeightSize;
            }

            if (intOldWidth > intOldHeight)
            {
                lnRatio = (decimal)MaxSideSize / intOldWidth;
                intNewWidth = MaxSideSize;
                decimal lnTemp = intOldHeight * lnRatio;
                intNewHeight = (int)lnTemp;
            }
            else
            {
                lnRatio = (decimal)MaxHeightSize / intOldHeight;
                intNewHeight = MaxHeightSize;
                decimal lnTemp = intOldWidth * lnRatio;
                intNewWidth = (int)lnTemp;
            }

            Size ThumbNailSize = new Size(intNewWidth, intNewHeight);
            System.Drawing.Image oImg = System.Drawing.Image.FromStream(Buffer);
            System.Drawing.Image oThumbNail = new Bitmap(ThumbNailSize.Width, ThumbNailSize.Height);

            Graphics oGraphic = Graphics.FromImage(oThumbNail);
            oGraphic.CompositingQuality = CompositingQuality.HighQuality;
            oGraphic.SmoothingMode = SmoothingMode.HighQuality;
            oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Rectangle oRectangle = new Rectangle
                (0, 0, ThumbNailSize.Width, ThumbNailSize.Height);

            oGraphic.DrawImage(oImg, oRectangle);

            //Save File
            string newFileName = string.Format(System.Web.HttpContext.Current.Server.MapPath("~/{0}/{1}.jpg"), filePath, fileName);
            oThumbNail.Save(newFileName, ImageFormat.Jpeg);

            MemoryStream ms = new MemoryStream();
            oThumbNail.Save(ms, ImageFormat.Jpeg);
            byteArray = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(byteArray, 0, Convert.ToInt32(ms.Length));

            oGraphic.Dispose();
            oImg.Dispose();
            ms.Close();
            ms.Dispose();
        }
        catch (Exception)
        {
            int newSize = MaxSideSize - 20;
            Bitmap bitMap = new Bitmap(newSize, newSize);
            Graphics g = Graphics.FromImage(bitMap);
            g.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(0, 0, newSize, newSize));

            Font font = new Font("Courier", 8);
            SolidBrush solidBrush = new SolidBrush(Color.Red);
            g.DrawString("Failed To Save File or Failed File", font, solidBrush, 10, 5);
            g.DrawString(fileName, font, solidBrush, 10, 50);

            MemoryStream ms = new MemoryStream();
            bitMap.Save(ms, ImageFormat.Jpeg);
            byteArray = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(byteArray, 0, Convert.ToInt32(ms.Length));

            ms.Close();
            ms.Dispose();
            bitMap.Dispose();
            solidBrush.Dispose();
            g.Dispose();
            font.Dispose();

        }
        return byteArray;
    }

    /// <summary>
    /// Attachments seperate with "|" seperator
    /// </summary>
    public static void _SendMail(string ToId, string FromId, string FromFullName, string Subject, string Message, string Attachment)
    {
        string strCCEmail1 = string.Empty;
        string strCCEmail2 = string.Empty;

        string strQry = "SELECT CompanyCCEmail1,CompanyCCEmail2 FROM Settings";

        SqlDataReader drCCEmails = DataAccessor.ExecuteQueryDataReader(strQry, null);

        while (drCCEmails.Read())
        {
            strCCEmail1 = drCCEmails["CompanyCCEmail1"].ToString();
            strCCEmail2 = drCCEmails["CompanyCCEmail2"].ToString();
        }

        drCCEmails.Close();

        NetworkCredential logininfo = new NetworkCredential("parag@echofeel.com", "Password12");
        //NetworkCredential logininfo = new NetworkCredential("paresh@khubi.com", "oshwal");

        System.Net.Mail.MailMessage msgmail = new System.Net.Mail.MailMessage();

        msgmail.From = new MailAddress(FromId, FromFullName);
        msgmail.To.Add(new MailAddress(ToId));

        if (!string.IsNullOrEmpty(strCCEmail1))
        {
            msgmail.CC.Add(new MailAddress(strCCEmail1));
        }

        if (!string.IsNullOrEmpty(strCCEmail2))
        {
            msgmail.CC.Add(new MailAddress(strCCEmail2));
        }

        msgmail.Subject = Subject;
        msgmail.Body = Message;



        if (Attachment.Trim() != "")
        {
            string[] s1 = Attachment.Split('|');

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i].ToString().Trim() != "")
                    msgmail.Attachments.Add((new System.Net.Mail.Attachment(s1[i].ToString().Trim())));
            }
        }

        msgmail.IsBodyHtml = true;
        SmtpClient client = new SmtpClient("monthly.smtp.com", 25);
        client.EnableSsl = false;
        client.UseDefaultCredentials = false;
        client.Credentials = logininfo;
        client.Send(msgmail);
    }

    public static void _SendMail(string ToId, string FromId, string FromFullName, string Subject, string Message, Stream Attachment, string fileName)
    {
        NetworkCredential logininfo = new NetworkCredential("parag@echofeel.com", "Password12");
        //NetworkCredential logininfo = new NetworkCredential("paresh@khubi.com", "oshwal");

        System.Net.Mail.MailMessage msgmail = new System.Net.Mail.MailMessage();

        msgmail.From = new MailAddress(FromId, FromFullName);
        msgmail.To.Add(new MailAddress(ToId));
        msgmail.Subject = Subject;
        msgmail.Body = Message;
        if (Attachment != null)
            msgmail.Attachments.Add((new System.Net.Mail.Attachment(Attachment, fileName)));
        msgmail.IsBodyHtml = true;
        SmtpClient client = new SmtpClient("monthly.smtp.com", 25);
        client.EnableSsl = false;
        client.UseDefaultCredentials = false;
        client.Credentials = logininfo;
        client.Send(msgmail);
    }

    public static void _SendMail(string ToId, string FromId, string FromFullName, string Subject, string Message, string Attachment, string copyTo)
    {
        NetworkCredential logininfo = new NetworkCredential("parag@echofeel.com", "Password12");

        System.Net.Mail.MailMessage msgmail = new System.Net.Mail.MailMessage();

        msgmail.From = new MailAddress(FromId, FromFullName);
        msgmail.To.Add(new MailAddress(ToId));
        string[] cC = copyTo.Split(',');
        for (int i = 0; i < cC.Length; i++)
        {
            cC[i] = cC[i].Replace(" ", "");
            if (!string.IsNullOrEmpty(cC[i]))
                msgmail.CC.Add(cC[i].Trim());
        }
        msgmail.Subject = Subject;
        msgmail.Body = Message;
        if (Attachment.Trim() != "")
            msgmail.Attachments.Add((new System.Net.Mail.Attachment(Attachment)));
        msgmail.IsBodyHtml = true;
        SmtpClient client = new SmtpClient("monthly.smtp.com", 25);
        client.EnableSsl = false;
        client.UseDefaultCredentials = false;
        client.Credentials = logininfo;
        client.Send(msgmail);
    }

    public static string _TruncateString(string input, int charaterlimit)
    {
        int characterLimit = charaterlimit;
        string output = input;

        // Check if the string is longer than the allowed amount
        // otherwise do nothing
        if (output.Length > characterLimit && characterLimit > 0)
        {
            // cut the string down to the maximum number of characters
            output = output.Substring(0, characterLimit);
            // Check if the character right after the truncate point was a space
            // if not, we are in the middle of a word and need to remove the rest of it
            if (input.Substring(output.Length, 1) != " ")
            {
                int LastSpace = output.LastIndexOf(" ");

                // if we found a space then, cut back to that space
                if (LastSpace != -1)
                {
                    output = output.Substring(0, LastSpace);
                }
            }
            // Finally, add the "..."
            output += "...";
        }
        return output;
    }

    public static string _FormatAmount(string input)
    {
        string output = "0.00";

        try
        {
            output = string.Format("{0:#0.00}", double.Parse(input));
        }
        catch
        {
            output = "0.00";
        }

        return output;
    }

    public static string _FormatAmountComma(string input)
    {
        string output = "0.00";

        double buffNumber = 0;
        if (double.TryParse(input, out buffNumber))
        {
            output = double.Parse(input).ToString("#,#0.00");
        }
        else
            output = "0.00";

        return output;
    }

    /// <summary>
    /// input type (DD/MM/YYYY OR DD-MM-YYYY) Output (10 Jun, 2010)
    /// </summary>    
    public static string _FormatDate(string input)
    {
        if (input != "")
        {
            if (input.Contains("/"))
            {
                string[] r = input.Split('/');
                string dt = r[0] + " " + GetMonthName(r[1]) + ", " + r[2];
                return dt;
            }
            if (input.Contains("-"))
            {
                string[] r = input.Split('-');
                return r[0] + " " + GetMonthName(r[1]) + ", " + r[2];
            }
            else
                return "";

        }
        else
            return "";
    }

    public static string GetMonthName(string dtmonth)
    {
        string result = "";

        if (dtmonth == "01" || dtmonth == "1")
            result = "Jan";
        if (dtmonth == "02" || dtmonth == "2")
            result = "Feb";
        if (dtmonth == "03" || dtmonth == "3")
            result = "Mar";
        if (dtmonth == "04" || dtmonth == "4")
            result = "Apr";
        if (dtmonth == "05" || dtmonth == "5")
            result = "May";
        if (dtmonth == "06" || dtmonth == "6")
            result = "Jun";
        if (dtmonth == "07" || dtmonth == "7")
            result = "Jul";
        if (dtmonth == "08" || dtmonth == "8")
            result = "Aug";
        if (dtmonth == "09" || dtmonth == "9")
            result = "Sep";
        if (dtmonth == "10")
            result = "Oct";
        if (dtmonth == "11")
            result = "Nov";
        if (dtmonth == "12")
            result = "Dec";

        return result;
    }

    public static void _FillDropDown(string qry, string textfield, string valuefield, string defaultsel, string defaultval, DropDownList ddl, params SqlParameter[] arrParam)
    {
        if (defaultsel != "")
        {
            ListItem li = new ListItem(defaultsel, defaultval);
            ddl.Items.Add(li);
        }

        SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(qry, arrParam);
        while (dr.Read())
        {
            ListItem li1 = new ListItem(dr[textfield].ToString(), dr[valuefield].ToString());
            ddl.Items.Add(li1);
        }
        dr.Close();
    }

    /// <summary>
    /// input type filename with path EX "mywebsite/images/test.jpg"    
    /// </summary>    
    public static void _DeleteFile(string filename)
    {
        if (filename.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(filename);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
        }
    }

    public static double _parseStringToDouble(string value)
    {
        double result = 0;
        double.TryParse(value, out result);
        return result;
    }

    public static Int32 _parseStringToInt(string value)
    {
        Int32 result = 0;
        Int32.TryParse(value, out result);
        return result;
    }

    public static decimal _parseStringToDecimal(string value)
    {
        decimal result = 0.00M;

        try
        {
            result = decimal.Parse(value);
        }
        catch
        {
        }

        return result;
    }


    public static string _GenerateNewStringID(string initialCharacter, string columnName, string substringStartIndex, string substringEndIndex, string tableName)
    {
        string NewId = "";

        string strQry = "Select '" + initialCharacter + "' + CAST(ISNULL(max(CAST(substring(" + columnName + "," + substringStartIndex + "," + substringEndIndex + ") AS int))+1, 1) as nvarchar) as NewId from " + tableName;
        SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(strQry);
        while (dr.Read())
        {
            NewId = dr["NewId"].ToString();
        }
        dr.Close();

        return NewId;
    }

    public static int _GenerateNewIntID(string columnName, string tableName)
    {
        int NewId = 1;

        string strQry = "Select ISNULL(max(" + columnName + ")+1, 1)  as NewId from " + tableName;
        SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(strQry);
        while (dr.Read())
        {
            NewId = GeneralFunctions._parseStringToInt(dr["NewId"].ToString());
        }
        dr.Close();

        return NewId;
    }

    public static void _ChkSession(string sessionid, string redirectpage)
    {
        if (HttpContext.Current.Session[sessionid] != null)
        {
            if (HttpContext.Current.Session[sessionid].ToString() == "")
                HttpContext.Current.Response.Redirect(redirectpage);
        }
        else
            HttpContext.Current.Response.Redirect(redirectpage);
    }

    public static string _ChkSession(string sessionid)
    {
        if (HttpContext.Current.Session[sessionid] != null)
        {
            if (HttpContext.Current.Session[sessionid].ToString() != "")
                return HttpContext.Current.Session[sessionid].ToString();
            else
                return "";
        }
        else
            return "";
    }

    public static string RemoveSpecialCharactersFromFileName(string strFileName)
    {
        System.Text.RegularExpressions.Regex objSpChar = new System.Text.RegularExpressions.Regex(@"[^\w\-]");
        System.Text.RegularExpressions.Regex objWhiteSpace = new System.Text.RegularExpressions.Regex(@"\s+");

        strFileName = objSpChar.Replace(strFileName, " ");
        strFileName = objWhiteSpace.Replace(strFileName, @" ");

        strFileName = strFileName.Replace("_", "");
        strFileName = strFileName.Replace(" ", "_");

        if (strFileName.Length > 150)
        {
            strFileName = strFileName.Substring(0, 150);
        }

        return strFileName;
    }

    public static DateTime GetDate(string date)
    {
        if (string.IsNullOrEmpty(date))
            date = "01/01/1753";
        char[] del = { '/' };

        string[] dateParts = date.Split(del);
        int day = Convert.ToInt32(dateParts[0]);
        int month = Convert.ToInt32(dateParts[1]);
        int year = Convert.ToInt32(dateParts[2]);

        return new DateTime(year, month, day);
    }

    public static DataTable RemoveDuplicateRows(DataTable dTable, string colName)
    {
        Hashtable hTable = new Hashtable();
        ArrayList duplicateList = new ArrayList();

        //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
        //And add duplicate item value in arraylist.
        foreach (DataRow drow in dTable.Rows)
        {
            if (hTable.Contains(drow[colName]))
                duplicateList.Add(drow);
            else
                hTable.Add(drow[colName], string.Empty);
        }

        //Removing a list of duplicate items from datatable.
        foreach (DataRow dRow in duplicateList)
            dTable.Rows.Remove(dRow);

        //Datatable which contains unique records will be return as output.
        return dTable;
    }

    /// <summary>
    /// strExtensions e.g (JPEG|GIF|PNG)    
    /// strFileNamePath e.g (C:\web\myproject\)
    /// </summary>    
    public static bool ChkValidateFileExtension(string strExtentions, string strFileNameWithExt)
    {
        bool result = false;

        string[] ext = strExtentions.Split('|');

        for (int i = 0; i <= ext.Length - 1; i++)
        {
            if (System.IO.Path.GetExtension(strFileNameWithExt.Trim().ToLower()) == "." + ext[i].ToString().ToLower())
            {
                result = true;
                break;
            }
        }


        return result;
    }

    public static string ConvertStringToTitleCase(string strInput)
    {
        return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(strInput.ToLower());

    }


    //Newlly added By Markand 
    public static MemoryStream DataTableToExcelXlsx(DataSet ds, string[] sheetName)
    {
        MemoryStream Result = new MemoryStream();
        ExcelPackage pack = new ExcelPackage();

        for (int i = 0; i < sheetName.Length; i++)
        {
            DataTable table = ds.Tables[(i + 1).ToString()];
            ExcelWorksheet ws = pack.Workbook.Worksheets.Add(sheetName[i].ToString());

            int col = 1;
            int row = 1;

            foreach (DataColumn cl in table.Columns)
            {
                ws.Cells[row, col].Value = cl.ColumnName;
                col++;
            }
            col = 1;
            foreach (DataRow rw in table.Rows)
            {
                foreach (DataColumn cl in table.Columns)
                {
                    if (rw[cl.ColumnName] != DBNull.Value)
                        ws.Cells[row + 1, col].Value = rw[cl.ColumnName].ToString();
                    col++;
                }
                row++;
                col = 1;
            }
        }
        pack.SaveAs(Result);
        return Result;
    }

    public static string CreateRandomPassword(int PasswordLength)
    {
        string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
        Random randNum = new Random();
        char[] chars = new char[PasswordLength];
        int allowedCharCount = _allowedChars.Length;
        for (int i = 0; i < PasswordLength; i++)
        {
            chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
        }
        return new string(chars);
    }


}
