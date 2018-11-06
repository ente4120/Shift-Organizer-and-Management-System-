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
    public List<Guide> getSGUide()
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        List<Guide> temps = JsonConvert.DeserializeObject<List<Guide>>(t.getGuide());
        return temps;
    }
}