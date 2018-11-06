using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using Newtonsoft.Json;


public partial class ShiftEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["userID"] != null)
        {
            shiftSettings();
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void shiftSettings()
    {
        Shift shift = new Shift();
        Shift temp = shift.getShiftSetting();
        List<int> tempList = temp.Shifts;
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(tempList);
        HttpContext.Current.Session["ListShift"] = jsonString;
        HttpContext.Current.Session["userShifts"] = "";
    }

    protected void SaveTheShift(object sender, EventArgs e)
    {
        int choose = Convert.ToInt32((string)Session["userID"]);
        Employee tempEmp = new Employee();
        try
        {
            string num = Request.Cookies["userShifts"].Value;
            int numEffected = tempEmp.SaveShift(choose,num);
            Response.Redirect("Shifts.aspx");
        }
        catch (Exception ex)
        {
            Response.Write("There was an error when trying to insert the shift into the database" + ex.Message);
        }
    }
}