using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;

/// <summary>
/// Summary description for Message
/// </summary>
public class Message
{
    int msId;
    string msTitle;
    string msWriter;
    DateTime msDate;
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

    public DateTime MsDate
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

    

    public Message(int msId, string msWriter, DateTime msDate, string msContent, string msBranch, string msTitle)
    {
        MsId = msId;
        MsTitle = msTitle;
        MsWriter = msWriter;
        MsDate = msDate;
        MsContent = msContent;
        MsBranch = msBranch;
    }

    public List<Message> getMessage()
    {
        //call the method getCategory from DBService
        DBservices dbs = new DBservices();
        List<Message> msgList = new List<Message>();
        msgList = dbs.getMessageObjects("rikosheTDBConnectionString", "[Message]");
        return msgList;
    }

    public List<Message> getSMessages()
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        List<Message> temps = JsonConvert.DeserializeObject<List<Message>>(t.getMessage());
        return temps;
    }
    public int SaveMessege(string writer, string content, string title, string branch)
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        int temps = JsonConvert.DeserializeObject<int>(t.insertMessage(writer,content,title,branch));
        return temps;
    }

}