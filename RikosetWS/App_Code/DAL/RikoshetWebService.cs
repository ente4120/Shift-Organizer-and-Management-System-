using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
 /// <summary>
/// Summary description for RikoshetWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class RikoshetWebService : System.Web.Services.WebService
{

    public RikoshetWebService()
    {
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getEmployees()
    {
        Employee empl = new Employee();
        List<Employee> emplList = empl.getEmployeeObjects();
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(emplList);
        return jsonString;
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getChanges()
    {
        ShiftsEmployee empl = new ShiftsEmployee();
        List<string> emplList = empl.getEmployeeSObjects();
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(emplList);
        return jsonString;
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getShiftsettings()
    {
        Shift Sh = new Shift();
        Shift temp = Sh.getShiftObjects();
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(temp);
        return jsonString;
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getGuide()
    {
        Guide G = new Guide();
        List<Guide> GList = G.getGuideObjects();
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(GList);
        return jsonString;
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getTransfer()
    {
        Transfer T = new Transfer();
        List<Transfer> TList = T.getTransferObjects();
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(TList);
        return jsonString;
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getProduct()
    {
        Product prod = new Product();
        List<Product> listp = prod.getProductsObjects();
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(listp);
        return jsonString;
    }

    [WebMethod]
    public List<string> getCategories()
    {
        DBservices dbs = new DBservices();
        List<string> categories = new List<string>();
        categories = dbs.getCategories("rikosheTDBConnectionString", "[Category]", fieldName: "CategoryName");
        return categories;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getMessage()
    {
        Message M = new Message();
        List<Message> MList = M.getMessagesObjects();
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(MList);
        return jsonString;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getShifts()
    {
        Employee empl = new Employee();
        //List<string> tempList = new List<string>();
        Shift thisweekshift = new Shift();
        Shift tempSh = new Shift();
        thisweekshift = tempSh.getShiftObjects();
        List<Employee> employee = empl.getEmployeeObjects();
        List<ShiftsEmployee> tempSE = new List<ShiftsEmployee>();


        //Create Sort List to Make the Different Algoritm
        int plusN = 1;
        SortedList<double,Employee> sl = new SortedList<double, Employee>();
        foreach (Employee emp in employee)
        {
            Random rnd = new Random();
            double plus = Convert.ToDouble(rnd.Next(1, 50)) * 0.0001;
            if (emp.First_name != "בר")
            {
                double keys = (double)emp.Minimum / (emp.Last_shift.Count());
                sl.Add(keys + plus* plusN, emp);
                plusN++;
            }
            else
            {
                sl.Add(0, emp);
            }
        }

        //Create new List of employees
        List<Employee> employeeList = new List<Employee>();
        foreach (KeyValuePair<double, Employee> item in sl)
        {
            if(item.Value.First_name!="בר")
            employeeList.Add(item.Value);
        }
        //Adding the mananger the the end of list
        foreach (KeyValuePair<double, Employee> item in sl)
        {
            if (item.Value.First_name == "בר")
                employeeList.Add(item.Value);
        }

        //Revese the list
        employeeList.Reverse();

        ////////////
        //Algoritm//
        ////////////
        foreach (Employee emp in employeeList) //Running on employees list
        {
            if (emp.Minimum > emp.Have) //Running just on employees who dont have enough shifts
            {
                foreach (ShiftsEmployee shift in emp.Last_shift) //Running in shift list of each employee
                {
                    for (int i = 0; i < thisweekshift.Possibles.Count; i++) //Running on possible shifts of employees
                    {
                        if (shift.Type == thisweekshift.Shifts[i] && thisweekshift.Possibles[i] > 0) //Match shifts and updating
                        {
                            thisweekshift.Possibles[i] -= 1;
                            emp.Have++;
                            tempSE.Add(shift);
                        }
                    }
                }
            }
        }
        //Checking that all shifts are done
        employeeList.Reverse();
        for (int i = 0; i < thisweekshift.Possibles.Count; i++) //Running on possible shifts of employees
        {
            if (thisweekshift.Possibles[i] > 0) //Match shifts and updating
            {
                foreach (Employee emp in employeeList)
                {
                    foreach (ShiftsEmployee shift in emp.Last_shift)
                    {
                        if (shift.Type == thisweekshift.Shifts[i] && thisweekshift.Possibles[i] > 0) //Match shifts and updating
                        {
                            int temp = 0;
                            foreach (ShiftsEmployee shifts in tempSE)
                            {
                                if(shifts.Title==emp.First_name && shifts.Type== thisweekshift.Shifts[i])
                                {
                                    temp++;
                                }
                            }
                            if (temp==0)
                            {
                                thisweekshift.Possibles[i] -= 1;
                                emp.Have++;
                                tempSE.Add(shift);
                            }
                        }
                    }
                }
            }
        }
        ShiftsEmployee SE = new ShiftsEmployee();
        string p = SE.writeToJson(tempSE);
        return p;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getFullProduct(string id)
    {
        Product p = new Product();
        Product listp = p.getFullProduct(id);
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(listp);
        return jsonString;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getFullGuide(string id)
    {
        Guide G = new Guide();
        Guide listG = G.getFullGuide(id);
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(listG);
        return jsonString;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getSwitch(int id)
    {
        ShiftsEmployee se = new ShiftsEmployee();
        string S = se.getSwitch(id);
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(S);
        return jsonString;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string insertSwitch(int emp, int shift, string type)
    {
        ShiftsEmployee se = new ShiftsEmployee();
        int S = se.insertSwitch(emp,shift,type);
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(S);
        return jsonString;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string updateSwitch(int empTake,int empAsk, int shift, string type)
    {
        ShiftsEmployee se = new ShiftsEmployee();
        int S = se.updateSwitch(empTake, empAsk, shift, type);
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(S);
        return jsonString;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string approveSwitch(int empTake, int empAsk, int shift, string type)
    {
        ShiftsEmployee se = new ShiftsEmployee();
        int S = se.approveSwitch(empTake, empAsk, shift, type);
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(S);
        return jsonString;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string insertShift(int id, string shift)
    {
        Employee tempEmp = new Employee();
        int numAffected = tempEmp.insertShift(id,shift);
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(numAffected);
        return jsonString;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string insertShiftSettings(string shift, string possible)
    {
        Shift sh = new Shift();
        int numAffected = sh.insertShiftSettings(shift, possible);
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(numAffected);
        return jsonString;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string insertShiftAfterEditing(string shift)
    {
        ShiftsEmployee sh = new ShiftsEmployee();
        int numAffected = sh.insertShiftAfterEditing(shift);
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(numAffected);
        return jsonString;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string insertMessage(string writer, string content,string title,string branch)
    {
        Message message = new Message();
        int numAffected = message.insertMessage(writer, content, title,branch);
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(numAffected);
        return jsonString;
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string insertTransfer(string writer, string amount, string from, string to,string Prod)
    {
        Transfer transfer = new Transfer();
        int numAffected = transfer.insertTransfer( writer, amount,  from,  to,  Prod);
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(numAffected);
        return jsonString;
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string insertEmployee(string FirstName, string LastName, int UserName, string Password, string Type, string Branch, int Minimum)
    {
        Employee Employee = new Employee();
        int numAffected = Employee.insertEmployee(FirstName, LastName, UserName, Password, Type, Branch, Minimum);
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(numAffected);
        return jsonString;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string loginUser(int userName, string Password)
    {
        Employee sh = new Employee();
        Employee emp = sh.loginUser(userName, Password);
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(emp);
        return jsonString;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getCalenderShifts()
    {
        ShiftsEmployee SE = new ShiftsEmployee();
        string p = SE.getCalenderShifts();
        return p;
    }
}