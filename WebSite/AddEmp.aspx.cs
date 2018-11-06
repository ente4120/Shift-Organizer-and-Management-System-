using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class AddEmp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["userID"] != null)
        {

        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }
    
    protected void SaveaddEmpl(object sender, EventArgs e)
    {

        Employee tempM = new Employee();
        try
        {
            string first_name = Convert.ToString(NameInput.Value);
            string last_name = Convert.ToString(LnameInput.Value);
            int user_name = Convert.ToInt32(UserName.Value);
            string password = Convert.ToString(PasswordI.Value);
            string type = Convert.ToString(TypeInput.Value);
            string branch= Convert.ToString(BDDL.SelectedValue);
            int minimum = Convert.ToInt32(MinInput.Value);
            tempM.insertEmployee(first_name, last_name, user_name, password, type, branch, minimum);
        }


        catch (Exception ex)
        {
            Response.Write("There was an error when trying to insert the shift into the database" + ex.Message);
        }
    }

}





