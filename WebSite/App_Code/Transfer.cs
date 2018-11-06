using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
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

    public Transfer(int traId, string traDate,string traProd, string traFrom, string traTo, string traAmount, string traWriter)
    {
        TraId = traId;
        TraDate = traDate;
        TraProd = traProd;
        TraFrom = traFrom;
        TraTo = traTo;
        TraAmount = traAmount;
        TraWriter = traWriter;
    }
    public int insertTransfer(string writer, string amount, string from, string to, string Prod)
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        int temps = JsonConvert.DeserializeObject<int>(t.insertTransfer(writer, amount, from, to, Prod));
        return temps;
    }
    public List<Transfer> getTransfer()
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        List<Transfer> temps = JsonConvert.DeserializeObject <List<Transfer>>(t.getTransfer());
        return temps;
    }
}