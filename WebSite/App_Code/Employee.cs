using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

/// <summary>
/// Summary description for Employee
/// </summary>
public class Employee
{
    public Employee()
    {

    }

    string first_name;
    string last_name;
    private int user_name;
    string password;
    string type;
    string branch;
    private int minimum;
    private int have=0;
    private List<ShiftsEmployee> last_shift;

    public int User_name
    {
        get
        {
            return user_name;
        }

        set
        {
            user_name = value;
        }
    }

    public int Minimum
    {
        get
        {
            return minimum;
        }

        set
        {
            minimum = value;
        }
    }

    public int Have
    {
        get
        {
            return have;
        }

        set
        {
            have = value;
        }
    }

    public string First_name
    {
        get
        {
            return first_name;
        }

        set
        {
            first_name = value;
        }
    }

    public string Last_name
    {
        get
        {
            return last_name;
        }

        set
        {
            last_name = value;
        }
    }

    public string Password
    {
        get
        {
            return password;
        }

        set
        {
            password = value;
        }
    }

    public string Type
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

    public string Branch
    {
        get
        {
            return branch;
        }

        set
        {
            branch = value;
        }
    }

    public List<ShiftsEmployee> Last_shift
    {
        get
        {
            return last_shift;
        }

        set
        {
            last_shift = value;
        }
    }

    //public Employee(int user_name, int min, string shifts)
    //{
    //    User_name=user_name;
    //    Minimum = min;
    //    string[] tempArry = shifts.Split(',');
    //    List<int> tempList = new List<int>();
    //    for (int i = 0; i < tempArry.Length; i++)
    //    {
    //        int temp = Convert.ToInt32(tempArry[i]);
    //        tempList.Add(temp);
    //    }
    //    Last_shift = tempList;
    //}

    public Employee(int user_name, int minimum, int have, List<ShiftsEmployee> last_shift, string first_name, string last_name, string password, string type, string branch)
    {
        User_name = user_name;
        Minimum = minimum;
        Have = have;
        Last_shift = last_shift;
        First_name = first_name;
        Last_name = last_name;
        Password = password;
        Type = type;
        Branch = branch;
    }

    public int SaveShift(int id, string shift)
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        int temps = JsonConvert.DeserializeObject<int>(t.insertShift(id,shift));
        return temps;
    }

    public List<Employee> getEmployeeList()
    {
        List<Employee> tempEmpList = new List<Employee>();
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
        tempEmpList = jsonSerializer.Deserialize<List<Employee>>(t.getEmployees());
        return tempEmpList;
    }
    public int insertEmployee(string FirstName, string LastName, int UserName, string Password, string Type, string Branch, int Minimum)
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        int temps = JsonConvert.DeserializeObject<int>(t.insertEmployee(FirstName, LastName, UserName, Password, Type, Branch, Minimum));
        return temps;
    }

    public Employee LoginUser(int userNAME, string userPASS)
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        Employee temps = JsonConvert.DeserializeObject<Employee>(t.loginUser(userNAME, userPASS));
        return temps;
    }
}