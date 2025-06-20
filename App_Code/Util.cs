using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Globalization;
using System.ComponentModel;
using PSS.App_Code;
/// <summary>
/// Summary description for Util
/// </summary>

public static class ExtensionMethods
{
    public static DataTable ToDataTable<T>(this IList<T> data)
    {
        PropertyDescriptorCollection props =
            TypeDescriptor.GetProperties(typeof(T));
        DataTable table = new DataTable();
        for (int i = 0; i < props.Count; i++)
        {
            PropertyDescriptor prop = props[i];
            table.Columns.Add(prop.Name, prop.PropertyType);
        }
        object[] values = new object[props.Count];
        foreach (T item in data)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = props[i].GetValue(item);
            }
            table.Rows.Add(values);
        }
        return table;
    }
}

public static class Util
{
    public static string SerializeObject(object obj, string type)
    {
        String XmlizedString = null;
        MemoryStream memoryStream = new MemoryStream();
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
        XmlSerializer xs;

        switch (type)
        {
            case "Attachments":
                xs = new XmlSerializer(typeof(Attachments));
                obj = (Attachments)obj;
                xs.Serialize(xmlTextWriter, obj);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                break;
            case "clsMenu":
                xs = new XmlSerializer(typeof(clsMenu));
                obj = (clsMenu)obj;
                xs.Serialize(xmlTextWriter, obj);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                break;
            
            case "clsDelete":
                xs = new XmlSerializer(typeof(clsDelete));
                obj = (clsDelete)obj;
                xs.Serialize(xmlTextWriter, obj);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                break;
            
        }
        return XmlizedString;      
    }

    private static String UTF8ByteArrayToString(Byte[] characters)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        String constructedString = encoding.GetString(characters);
        return (constructedString);
    }

    public static string Encrypt(string clearText, string Keyvalue)
    {
        string EncryptionKey = "PSS";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }

    public static string Decrypt(string cipherText)
    {

        string EncryptionKey = "PSS";
        cipherText = cipherText.Replace(" ", "+");
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }

    

    public static string LocalEncrypt(string clearText)
    {
        string EncryptionKey = "PSS";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }

    public static void AddCss(string path, Page page)
    {
        Literal cssFile = new Literal() { Text = @"<link href=""" + page.ResolveUrl(path) + @""" type=""text/css"" rel=""stylesheet"" />" };
        page.Header.Controls.Add(cssFile);
    }

    public static void RemoveCss(string path, Page page)
    {
        Literal cssFile = new Literal() { Text = @"<link href=""" + page.ResolveUrl(path) + @""" type=""text/css"" rel=""stylesheet"" />" };
        page.Header.Controls.Remove(cssFile);

    }

    public static DateTime ConvertDate_DDMMYYYY_To_MMDDYYYY(string param)
    {
        var cultue = CultureInfo.CurrentCulture.Name;
        int paramLength = param.Trim().Length;
        string dd = string.Empty;
        string mm = string.Empty;
        string yyyy = string.Empty;
        string convertedDate = string.Empty;

        if (paramLength == 10)
        {
            dd = param.Substring(0, 2);
            mm = param.Substring(3, 2);
            yyyy = param.Substring(6, 4);
            convertedDate = mm + "/" + dd + "/" + yyyy;
        }
        return Convert.ToDateTime(convertedDate);

    }

    public static void InsertRowAtZeroInCombo(ref DropDownList ddl, string key, string value)
    {
        ddl.Items.Insert(0, new ListItem(value, key));
        //if (ddl.Items.Count == 1)
        //    ddl.Enabled = false;
        //else
        //    ddl.Enabled = true;
    }

    public static void FillDropdown(ref DropDownList ddl, DataTable dt, string textField, string valueField, int isReqSelect)
    {
        ddl.DataSource = dt;
        ddl.DataTextField = textField;
        ddl.DataValueField = valueField;
        ddl.DataBind();

        if (isReqSelect == 1)
        {
            InsertRowAtZeroInCombo(ref ddl, "0", "Please Select");
        }
        else if (isReqSelect == 2)
        {
            InsertRowAtZeroInCombo(ref ddl, "0", "ALL");
        }
        else if (isReqSelect == 3)
        {
            InsertRowAtZeroInCombo(ref ddl, "0", "Not Applicable");
        }
        else if (isReqSelect == 4)
        {
            InsertRowAtZeroInCombo(ref ddl, "0", "None");
        }
        else if (isReqSelect == 5)
        {
            InsertRowAtZeroInCombo(ref ddl, "0", "Admin");
        }
    }

    public static bool IsDataSetContainInfo(ref DataSet ds)
    {
        bool result = false;
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
        }
        else
        {
            result = false;
        }
        return result;
    }

}

