using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mainUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["userID"] != null)
        {
            initiateTransferCount();
        }
        else
        {
            Response.Redirect("login.aspx");
        }

    }
    protected void initiateTransferCount()
    {
        Transfer T = new Transfer();
        List<Transfer> TS = T.getTransfer();
        int countint = 0;
        int countout = 0;
        foreach (Transfer trnsfer in TS)
        {
            if (trnsfer.TraFrom == "ריקושט עיר ימים")
            {
                countint++;
            }
            if (trnsfer.TraTo == "ריקושט עיר ימים")
            {
                countout++;
            }
        }
        IDcountint.InnerText = Convert.ToString(countint);

        IDcountout.InnerText = Convert.ToString(countout);
    }
}