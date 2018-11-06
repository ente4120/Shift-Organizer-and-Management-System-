using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

/// <summary>
/// Summary description for shift
/// </summary>
public class Shift
{
    public Shift()
    {

    }
        private List<int> shifts;
        private List<int> possibles;

    public List<int> Shifts
    {
        get
        {
            return shifts;
        }
        set
        {
            shifts = value;
        }
    }

    public List<int> Possibles
    {
        get
        {
            return possibles;
        }
        set
        {
            possibles = value;
        }
    }

    public Shift(string a, string b)
    {
        string[] tempa = a.Split(',');
        string[] tempb = b.Split(',');
        List<int> tempListA = new List<int>();
        List<int> tempListB = new List<int>();
        for (int i = 0; i < tempa.Length; i++)
        {
            tempListA.Add(Convert.ToInt32(tempa[i]));
        }
        for (int i = 0; i < tempb.Length; i++)
        {
            tempListB.Add(Convert.ToInt32(tempb[i]));
        }
        Shifts = tempListA;
        Possibles = tempListB;
    }

    public Shift getShiftSetting()
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        Shift temps = JsonConvert.DeserializeObject<Shift>(t.getShiftsettings());
        return temps;
    }

    public int SaveShift(string shift, string possible)
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        int temps = JsonConvert.DeserializeObject<int>(t.insertShiftSettings(shift, possible));
        return temps;
    }
}