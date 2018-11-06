using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;

/// <summary>
/// Summary description for DBservices
/// </summary>
public class DBservices
{
    public DataTable dt;
    public SqlDataAdapter da;


    public DBservices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public SqlConnection connect(String conString)
    {
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    //public List<Product> getProds(string conString, string tableName)
    //{
    //    List<Product> plist = new List<Product>();
    //    SqlConnection con = null;
    //    try
    //    {
    //        con = connect(conString); // create a connection to the database using the connection String defined in the web config file

    //        String selectSTR = "SELECT * FROM " + tableName;
    //        SqlCommand cmd = new SqlCommand(selectSTR, con);

    //        // get a reader
    //        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end


    //        while (dr.Read())
    //        {   // Read till the end of the data into a row
    //            Product prd = new Product();
    //            prd.ProdName = (string)(dr["Product"]);
    //            plist.Add(prd);

    //        }

    //        return plist;
    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw (ex);
    //    }
    //    finally
    //    {
    //        if (con != null)
    //        {
    //            con.Close();
    //        }

    //    }

    //}

    public DataTable ReadFromDataBase(string conString, string tableName)
    {

        DBservices dbS = new DBservices(); // create a helper class
        SqlConnection con = null;

        try
        {
            con = dbS.connect(conString); // open the connection to the database/

            String selectStr = "SELECT * FROM " + tableName; // create the select that will be used by the adapter to select data from the DB

            SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

            DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
            da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

            DataTable dt = ds.Tables[0];

            // add the datatable and the dataa adapter to the dbS helper class in order to be able to save it to a Session Object
            dbS.dt = dt;
            dbS.da = da;

            return dbS.dt;
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<Message> getMessageObjects(string conString, string tableName)
    {
        List<Message> msgList = new List<Message>();
        SqlConnection con = null;
        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM " + tableName;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end


            while (dr.Read())
            {   // Read till the end of the data into a row
                Message msg = new Message();
                msg.MsTitle = (string)(dr["Title"]);
                msg.MsWriter = (string)(dr["Writer"]);
                msg.MsDate = (DateTime)(dr["Date"]);
                msg.MsBranch = (string)(dr["Branch"]);
                msg.MsContent = (string)(dr["Content"]);
                msgList.Add(msg);
            }

            return msgList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }


    }




}