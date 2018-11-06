using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
// REMEMBER TO ADD THIS NAMESPACE
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using Newtonsoft.Json;

/// <summary>
/// Summary description for RikoshetWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getShiftCal()
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        string temp = t.getCalenderShifts();
        return temp;
    }




    #region 2.1 מוצרים
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getProducts()
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        return t.getProduct();
    }
    #endregion 


    #region מידע מוצר 2.1.2
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getFullProduct(string id)
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        return t.getFullProduct(id);
    }
    #endregion


    #region קטלוג 2.2
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getGuide()
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        return t.getGuide();
    }
    #endregion


    #region מידע קטלוג 2.2.2
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getFullGuide(string id)
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        return t.getFullGuide(id);
    }
    #endregion


    #region הודעות 3
    //דף הודעות - page 3
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getMessage()
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        return t.getMessage();
    }
    #endregion


    #region משמרות 4
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getShiftSettings()
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        return t.getShiftsettings();
    }
    #endregion


    #region העברות 5
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getTransfer()
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        return t.getTransfer();
    }
    #endregion

    #region יצירת משמרות 6
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int insertShift(int id, string shift)
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        return Convert.ToInt32(t.insertShift(id, shift));
    }
    #endregion

    #region רשימת עובדים 7
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetEmployees()
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        return t.getEmployees();
    }
    #endregion

    #region רשימת משמרות על פי אלגוריתם 8
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getShiftsAlg()
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        return t.getShifts();
    }
    #endregion

    #region 9 יצירת הודעה חדשה
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int insertMessge()
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        int temps = JsonConvert.DeserializeObject<int>(t.insertMessage("2", "2", "2", "2"));
        return temps;
    }
    #endregion

    #region 10 החלפות בין עובדים
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getsChanges()
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        List<string> temps = JsonConvert.DeserializeObject<List<string>>(t.getChanges());
        string tempList = "";
        foreach (string item in temps)
        {
            if (tempList == "") tempList = item;
            else tempList += "," + item;
        }
        return tempList;
    }
    #endregion

    #region 11 יצירת החלפה חדשה
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int insertSwitch(int emp, int shift, string type)
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        int temps = JsonConvert.DeserializeObject<int>(t.insertSwitch(emp, shift, type));
        return temps;
    }
    #endregion

    #region 12 עדכון החלפה
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int UpdateSwitch(int empTake, int empAsk, int shift, string type)
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        int temps = JsonConvert.DeserializeObject<int>(t.updateSwitch(empTake, empAsk, shift, type));
        return temps;
    }
    #endregion

    #region 13 אישור החלפה
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int ApproveSwitch(int empTake, int empAsk, int shift, string type)
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        int temps = JsonConvert.DeserializeObject<int>(t.approveSwitch(empTake, empAsk, shift, type));
        return temps;
    }
    #endregion

    #region 14 משמרות של עובד
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getShiftsAfterEditing(string emp)
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        int empN = Convert.ToInt32(emp);
        string temps = JsonConvert.DeserializeObject<string>(t.getSwitch(empN));
        return temps;
    }
    #endregion

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string loginUser(string userNAME, string userPASS)
    {
        int usern = Convert.ToInt32(userNAME);
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        Employee temps = JsonConvert.DeserializeObject<Employee>(t.loginUser(usern, userPASS));
        if (temps.User_name != 0)
        {
            string empInFO = temps.First_name + "|" + temps.Last_name + "|" + Convert.ToString(temps.User_name) + "|" + Convert.ToString(temps.Type);
            return empInFO;
        }
        return "0";
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getShiftSetting()
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        Shift temps = JsonConvert.DeserializeObject<Shift>(t.getShiftsettings());
        string setting = "";
        List<int> shifts = temps.Shifts;
        foreach (int item in shifts)
        {
            if (setting == "") setting = Convert.ToString(item);
            else setting += "," + Convert.ToString(item);
        }
        return setting;
    }
}