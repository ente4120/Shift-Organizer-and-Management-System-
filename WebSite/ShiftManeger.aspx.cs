using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

public partial class ShiftManeger : System.Web.UI.Page
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
        //Shift deserializedShift = JsonConvert.DeserializeObject<Shift>(temp);
        List<int> tempListShift = temp.Shifts;
        List<int> tempListPossibles = temp.Possibles;
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString1 = js.Serialize(tempListShift);
        string jsonString2 = js.Serialize(tempListPossibles);
        HttpContext.Current.Session["ListShift"] = jsonString1;
        HttpContext.Current.Session["ListPossibles"] = jsonString2;
    }

    protected void SaveTheShift(object sender, EventArgs e)
    {
        Shift sh = new Shift();
        try
        {

            string shift = Request.Cookies["ListShift"].Value;
            string possible = Request.Cookies["ListPossibles"].Value;
            int numEffected = sh.SaveShift(shift, possible);
            Response.Redirect("Shifts.aspx");
        }
        catch (Exception ex)
        {
            Response.Write("There was an error when trying to insert the product into the database" + ex.Message);
        }
    }
}