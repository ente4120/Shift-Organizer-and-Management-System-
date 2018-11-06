using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LoginUser(object sender, EventArgs e)
    {
        Employee emp = new Employee();
        int username = Convert.ToInt32(userNAME.Value);
        string pass = Convert.ToString(userPASS.Value);
        Employee user = emp.LoginUser(username, pass);
        if (user.User_name != 0) {
            Session["userName"] = user.First_name+" "+user.Last_name;
            Session["userID"] = Convert.ToString(user.User_name);
            Session["userMinimum"] = user.Minimum;
            if(user.Type=="4") Response.Redirect("mainManager.aspx");
            else Response.Redirect("mainUser.aspx");
        }
    }
}