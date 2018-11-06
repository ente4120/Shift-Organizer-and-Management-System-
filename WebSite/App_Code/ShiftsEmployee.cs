using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script;
using System.Web.Script.Serialization;
using System.Globalization;
using Newtonsoft.Json;

public class ShiftsEmployee
{
    public ShiftsEmployee()
    {

    }

    public ShiftsEmployee(string day, string title, int type, string start, string end)
    {
        Day = day;
        Title = title;
        Type = type;
        Start = start;
        End = end;
    }

    string title;
    int type;
    string day;
    string start;
    string end;

    public string Title
    {
        get
        {
            return title;
        }

        set
        {
            title = value;
        }
    }

    public int Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
        }
    }

    public string Day
    {
        get
        {
            return day;
        }

        set
        {
            day = value;
        }
    }

    public string Start
    {
        get
        {
            return start;
        }

        set
        {
            start = value;
        }
    }

    public string End
    {
        get
        {
            return end;
        }

        set
        {
            end = value;
        }
    }

   public List<ShiftsEmployee> GetShiftsList()
    {
        List<ShiftsEmployee> tempShiftsALG = new List<ShiftsEmployee>();
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
        tempShiftsALG = jsonSerializer.Deserialize<List<ShiftsEmployee>>(t.getShifts());
        return tempShiftsALG;
    }

    public int SaveShiftsAfterEditing(string shifts)
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        int temps = JsonConvert.DeserializeObject<int>(t.insertShiftAfterEditing(shifts));
        return temps;
    }

    public string getShiftsAfterEditing(int emp)
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        string temps = JsonConvert.DeserializeObject<string>(t.getSwitch(emp));
        return temps;
    }

    public List<string> getChanges()
    {
        List<string> temps = new List<string>();
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        temps = JsonConvert.DeserializeObject<List<string>>(t.getChanges());
        return temps;
    }

    public int insertSwitch(int emp, int shift, string type)
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        int temps = JsonConvert.DeserializeObject<int>(t.insertSwitch(emp,shift,type));
        return temps;
    }

    public int updateSwitch(int empTake, int empAsk, int shift, string type)
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        int temps = JsonConvert.DeserializeObject<int>(t.updateSwitch(empTake, empAsk, shift, type));
        return temps;
    }

    public int approveSwitch(int empTake, int empAsk, int shift, string type)
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        int temps = JsonConvert.DeserializeObject<int>(t.approveSwitch(empTake, empAsk, shift, type));
        return temps;
    }
}