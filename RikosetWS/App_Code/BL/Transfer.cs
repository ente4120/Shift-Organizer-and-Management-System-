using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Transfer
/// </summary>
public class Transfer
{
    int traId;
    string traDate;
    string traProd;
    string traFrom;
    string traTo;
    string traAmount;
    string traWriter;
    public Transfer()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int TraId
    {
        get
        {
            return traId;
        }

        set
        {
            traId = value;
        }
    }

   

    public string TraDate
    {
        get
        {
            return traDate;
        }

        set
        {
            traDate = value;
        }
    }
    public string TraProd
    {
        get
        {
            return traProd;
        }

        set
        {
            traProd = value;
        }
    }

    public string TraFrom
    {
        get
        {
            return traFrom;
        }

        set
        {
            traFrom = value;
        }
    }

    public string TraTo
    {
        get
        {
            return traTo;
        }

        set
        {
            traTo = value;

        }
    }

    

    public string TraAmount
    {
        get
        {
            return traAmount;
        }

        set
        {
            traAmount = value;
        }
    }
    public string TraWriter
    {
        get
        {
            return traWriter;
        }

        set
        {
            traWriter = value;
        }
    }

    public Transfer(int traId, string traDate, string traProd, string traFrom, string traTo, string traAmount, string traWriter)
    {
        TraId = traId;
        TraDate = traDate;
        TraProd = traProd;
        TraFrom = traFrom;
        TraTo = traTo;
        TraAmount = traAmount;
        TraWriter = traWriter;
    }

    public List<Transfer> getTransferObjects()
    {
        DBservices dbs = new DBservices();
        List<Transfer> Transfer = new List<Transfer>();
        Transfer = dbs.getTransferObjects("rikosheTDBConnectionString", "[Transfer]");
        return Transfer;
    }
    public DataTable IsTransferInDB(string _catName)
    {
        DBservices dbs = new DBservices();
        dbs = dbs.ReadTransferCheckDB("rikoshTDBConnectionString", "[Transfer]");
        // save the dataset in a session object
        //HttpContext.Current.Session["emploCehckDataSet"] = dbs;
        return dbs.dt;
    }
    public int insertTransfer(string writer, string amount, string from, string to, string Prod)
    {
        DBservices db = new DBservices();
        int numAffected = db.insertTransfer(writer, amount, from, to, Prod);
        return numAffected;
    }

}