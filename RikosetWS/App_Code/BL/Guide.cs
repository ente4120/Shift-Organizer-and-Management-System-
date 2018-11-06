using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Guide
/// </summary>
public class Guide
{
    int guId;
    string guName;
    string guPath;
    string guWriter;
    string guDiscription;

    public Guide()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int GuId
    {
        get
        {
            return guId;
        }

        set
        {
            guId = value;
        }
    }

    public string GuName
    {
        get
        {
            return guName;
        }

        set
        {
            guName = value;
        }
    }

    public string GuPath
    {
        get
        {
            return guPath;
        }

        set
        {
            guPath = value;
        }
    }

    public string GuWriter
    {
        get
        {
            return guWriter;
        }

        set
        {
            guWriter = value;
        }
    }

    public string GuDiscription
    {
        get
        {
            return guDiscription;
        }

        set
        {
            guDiscription = value;
        }
    }

    public Guide(int guId, string guName, string guPath, string guWriter, string guDiscription)
    {
        GuId = guId;
        GuName = guName;
        GuPath = guPath;
        GuWriter = guWriter;
        GuDiscription = guDiscription;
    }
    public List<Guide> getGuideObjects()
    {
        DBservices dbs = new DBservices();
        List<Guide> Guide = new List<Guide>();
        Guide = dbs.getGuideObjects("rikosheTDBConnectionString", "[Guide]");
        return Guide;
    }
    public DataTable IsGuideInDB(string _catName)
    {
        DBservices dbs = new DBservices();
        dbs = dbs.ReadGuideCheckDB("rikosheTDBConnectionString", "[Guide]", GuName);
        // save the dataset in a session object
        //HttpContext.Current.Session["emploCehckDataSet"] = dbs;
        return dbs.dt;
    }
    public Guide getFullGuide(string GuId)
    {
        DBservices ds = new DBservices();
        DataTable dt = ds.ReadFromDataBaseByIDG("rikosheTDBConnectionString", "Guide", GuId);
        Guide ls = new Guide();
        foreach (DataRow row in dt.Rows)
        {
            ls = new Guide(Convert.ToInt32(row["ID"]), Convert.ToString(row["GuideName"]), Convert.ToString(row["Path"]), Convert.ToString(row["Writer"]), Convert.ToString(row["Discription"]));
        }
        return ls;
    }
}