using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;



public partial class MessegM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["userID"] != null)
        {
            initiateMessages();
        }
        else
        {
            Response.Redirect("login.aspx");
        }
        
    }
    public void initiateMessages()
    {
        Message Message_new = new Message();
        List<Message> Mlist = Message_new.getSMessages();
        int i = 0;
        foreach (Message item in Mlist)
        {
            i++;
            HtmlGenericControl divCard = new HtmlGenericControl("div");
            HtmlGenericControl divCard2 = new HtmlGenericControl("div");
            divCard.InnerHtml= "<li class='list-group-item stripe-5'><a data-toggle='modal' data-target='#" + i+ "'><h3 class='mb - 1'>" + item.MsTitle + "</h3><small>"+item.MsWriter + "-" + item.MsDate+ "</small></a></li>";
            divCard2.InnerHtml = "<div class='modal fade bd-example-modal-lg' id=" + i + " tabindex='-1' role='dialog' aria-labelledby='exampleModalLabel' aria-hidden='true'><div class='modal-dialog modal-lg' role='document'><div class='modal-content' style='height:500px;'><div class='modal-header stripe-5'><h5 class='modal-title'>" + item.MsTitle + "</h5></div><div class='modal-body'>" + item.MsContent + "</div><div class='modal-footer'><button type = 'button' class='btn btn-secondary' data-dismiss='modal'>סגור</button></div></div></div></div>";
            titles.Controls.Add(divCard);
            messageBody.Controls.Add(divCard2);
        }
    }
    protected void SaveTheMesseg(object sender, EventArgs e)
    {
        
        Message tempM = new Message();
        try
        {
            //string num = Request.Cookies["userShifts"].Value;
            string title = Convert.ToString(TitleInput.Value);
            string writer= Convert.ToString(NameMID.Value);
            string branch = Convert.ToString(BDDL.SelectedValue);
            string content = Convert.ToString(TextM.Value);
            int numEffected = tempM.SaveMessege(writer, content, title, branch);
           
        }
        catch (Exception ex)
        {
            Response.Write("There was an error when trying to insert the shift into the database" + ex.Message);
        }
    }
}