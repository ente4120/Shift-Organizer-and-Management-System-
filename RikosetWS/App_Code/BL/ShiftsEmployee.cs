using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script;
using System.Web.Script.Serialization;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ShiftsEmployee
/// </summary>
public class ShiftsEmployee
{
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




    public string writeToJson(List<ShiftsEmployee> shiftlist)
    {
        foreach (ShiftsEmployee shift in shiftlist)
        {
            int shifts = shift.Type;
            int tempDay = shifts / 10;
            int tempTime = shifts % 10;
            int temp = 0;
            
            DateTime da = DateTime.Today;
            if (shift.Start != null)
            {
                string[] arr = shift.End.Split('-');
                if (Convert.ToInt32(arr[1]) >= da.Month)
                {
                    if (Convert.ToInt32(arr[0]) >= da.Day)
                        temp = 1;
                }
            }
            else {
                temp = 1;
            }
            switch (tempDay)
            {
                case 1:
                    {
                        DateTime today = DateTime.Today;
                        int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)today.DayOfWeek) % 7;
                        if (temp > 0) daysUntilSunday += 7;
                        DateTime nextSunday = today.AddDays(daysUntilSunday);
                        shift.day = Convert.ToString(nextSunday);
                        break;
                    }
                case 2:
                    {
                        DateTime today = DateTime.Today;
                        int daysUntilMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek) % 7;
                        if (temp > 0) daysUntilMonday += 7;
                        DateTime nextMonday = today.AddDays(daysUntilMonday);
                        shift.day = Convert.ToString(nextMonday);
                        break;
                    }
                case 3:
                    {
                        DateTime today = DateTime.Today;
                        int daysUntilTuesday = ((int)DayOfWeek.Tuesday - (int)today.DayOfWeek) % 7;
                        if (temp > 0) daysUntilTuesday += 7;
                        DateTime nextTuesday = today.AddDays(daysUntilTuesday);
                        shift.day = Convert.ToString(nextTuesday);
                        break;
                    }
                case 4:
                    {
                        DateTime today = DateTime.Today;
                        int daysUntilWednesday = ((int)DayOfWeek.Wednesday - (int)today.DayOfWeek) % 7;
                        if (temp > 0) daysUntilWednesday += 7;
                        DateTime nextWednesday = today.AddDays(daysUntilWednesday);
                        shift.day = Convert.ToString(nextWednesday);
                        break;
                    }
                case 5:
                    {
                        DateTime today = DateTime.Today;
                        int daysUntilThursday = ((int)DayOfWeek.Thursday - (int)today.DayOfWeek) % 7;
                        if (temp > 0) daysUntilThursday += 7;
                        DateTime nextThursday = today.AddDays(daysUntilThursday);
                        shift.day = Convert.ToString(nextThursday);
                        break;
                    }
                case 6:
                    {
                        DateTime today = DateTime.Today;
                        int daysUntilFriday = ((int)DayOfWeek.Friday - (int)today.DayOfWeek) % 7;
                        if (temp > 0) daysUntilFriday += 7;
                        DateTime nextFriday = today.AddDays(daysUntilFriday);
                        shift.day = Convert.ToString(nextFriday);
                        break;
                    }
                case 7:
                    {
                        DateTime today = DateTime.Today;
                        int daysUntilSaturday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek) % 7;
                        if (temp > 0) daysUntilSaturday += 7;
                        DateTime nextSaturday = today.AddDays(daysUntilSaturday);
                        shift.day = Convert.ToString(nextSaturday);
                        break;
                    }
            }
            switch (tempTime)
            {
                case 1:
                    {
                        shift.start = "09:30";
                        shift.end = "15:30";
                        break;
                    }
                case 2:
                    {
                        shift.start = "12:00";
                        shift.end = "15:30";
                        break;
                    }
                case 3:
                    {
                        if (day!="7")
                        {
                            shift.start = "15:30";
                            shift.end = "21:30";
                            break;
                        }
                        else
                        {
                            shift.start = "19:30";
                            shift.end = "22:00";
                            break;
                        }

                    }
            }
        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(shiftlist);
        return jsonString;
    }

    public string getCalenderShifts()
    {
        List<ShiftsEmployee> shiftlist = new List<ShiftsEmployee>();
        DBservices ds = new DBservices();
        DataTable dt = ds.ReadFromDataBaseCalender("rikosheTDBConnectionString", "[ShiftAfterScheduling]");
        foreach (DataRow row in dt.Rows)
        {
            string shiftsString = Convert.ToString(row["Content"]);
            string[] shifts = shiftsString.Split(',');
            string emp = Convert.ToString(row["FirstName"]);
            string start = Convert.ToString(row["StartTime"]);
            string startDate = start.Split(' ')[0];
            string[] startArr = startDate.Split('/');
            start = startArr[2] + "-" + startArr[1] + "-" + startArr[0];
            string end = Convert.ToString(row["FinishTime"]);
            string endDate = end.Split(' ')[0];
            string[] endArr = endDate.Split('/');
            end = endArr[2] + "-" + endArr[1] + "-" + endArr[0];
            foreach (string item in shifts)
            {
                ShiftsEmployee se = new ShiftsEmployee();
                se.Title = emp;
                se.Start = start;
                se.End = end;
                se.Type=Convert.ToInt32(item);
                shiftlist.Add(se);
            }

        }
        string temp = writeToJson(shiftlist);
        return temp;

    }

    public string getSwitch(int Id)
    {
        DBservices ds = new DBservices();
        DataTable dt = ds.ReadFromDataBaseByS("rikosheTDBConnectionString", "[ShiftAfterScheduling]",Id);
        string ls = "";
        foreach (DataRow row in dt.Rows)
        {
            if (ls != "") ls += "/";
            ls += Convert.ToString(row["Content"]);
        }
        return ls;
    }

    public int insertSwitch(int emp, int shift, string type)
    {
        DBservices ds = new DBservices();
        int numAffected = ds.insertDataBaseChange("rikosheTDBConnectionString", "[Changes]", emp, shift, type);
        return numAffected;
    }

    public int updateSwitch(int empTake, int empAsk, int shift, string type)
    {
        DBservices ds = new DBservices();
        int numAffected = ds.updateDataBaseChange("rikosheTDBConnectionString", "[Changes]", empTake, empAsk, shift, type);
        return numAffected;
    }

    public int approveSwitch(int empTake, int empAsk, int shift, string type)
    {
        DBservices ds = new DBservices();
        int numAffected = ds.approveDataBaseChange("rikosheTDBConnectionString", "[Changes]", empTake,empAsk, shift, type);
        return numAffected;
    }

    public List<string> getEmployeeSObjects()
    {
        DBservices dbs = new DBservices();
        List<string> listEmployeesChanges = new List<string>();
        DataTable dt = dbs.getEmployeeSObjects("rikosheTDBConnectionString", "[Changes]");
        foreach (DataRow row in dt.Rows)
        {
            listEmployeesChanges.Add(Convert.ToString(row["Shifts"])+"|"+ Convert.ToString(row["EmployeeAsk"])+"|"+ row["Change_time"] + "|" + Convert.ToString(row["EmployeeTake"]));
        }
        return listEmployeesChanges;
    }

    public int insertShiftAfterEditing(string shift)
    {
        DBservices db = new DBservices();
        int numAffected = db.insertShiftAfterEditing(shift);
        return numAffected;
    }
}