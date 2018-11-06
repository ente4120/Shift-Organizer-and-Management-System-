using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Message
/// </summary>
public class Message
{

    int msId;
    string msTitle;
    string msWriter;
    string msDate;
    string msContent;
    string msBranch;
    public Message()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int MsId
    {
        get
        {
            return msId;
        }

        set
        {
            msId = value;
        }
    }

    public string MsWriter
    {
        get
        {
            return msWriter;
        }

        set
        {
            msWriter = value;
        }
    }

    public string MsDate
    {
        get
        {
            return msDate;
        }

        set
        {
            msDate = value;
        }
    }

    public string MsContent
    {
        get
        {
            return msContent;
        }

        set
        {
            msContent = value;
        }
    }

    public string MsBranch
    {
        get
        {
            return msBranch;
        }

        set
        {
            msBranch = value;
        }
    }

    public string MsTitle
    {
        get
        {
            return msTitle;
        }

        set
        {
            msTitle = value;
        }
    }



    public Message(int msId, string msWriter, string msDate, string msContent, string msBranch, string msTitle)
    {
        MsId = msId;
        MsTitle = msTitle;
        MsWriter = msWriter;
        MsDate = msDate;
        MsContent = msContent;
        MsBranch = msBranch;
    }

    public List<Message> getMessagesObjects()
    {
        DBservices dbs = new DBservices();
        List<Message> Message = new List<Message>();
        Message = dbs.getMessagesObjects("rikosheTDBConnectionString", "[Message]");
        return Message;
    }
    public int insertMessage(string writer, string content, string title, string branch)
    {
        DBservices db = new DBservices();
        int numAffected = db.insertMessage(writer, content, title, branch);
        return numAffected;
    }
    //public DataTable IsMessageInDB(string ID)
    //{
    //    DBservices dbs = new DBservices();
    //    dbs = dbs.ReadMessageCheckDB("rikosheTDBConnectionString", "[Message]", ID);
    //    // save the dataset in a session object
    //    //HttpContext.Current.Session["emploCehckDataSet"] = dbs;
    //    return dbs.dt;
    //}
}