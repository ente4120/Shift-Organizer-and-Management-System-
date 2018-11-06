using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

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
    public Shift getShiftObjects()
    {
        DBservices dbs = new DBservices();
        Shift Shift = dbs.getShiftObjects("rikosheTDBConnectionString", "[Shift]");
        return Shift;
    }

    public int insertShiftSettings(string shift, string possible)
    {
        DBservices db = new DBservices();
        int numAffected = db.insertShiftSettings(shift, possible);
        return numAffected;
    }
}