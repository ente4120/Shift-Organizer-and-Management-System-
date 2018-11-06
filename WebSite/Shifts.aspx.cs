using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script;
using System.Web.Script.Serialization;

public partial class sample : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["userID"] != null)
        {
            ShiftEmployee();
            Changes();
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void ShiftEmployee()
    {
        ShiftsEmployee se = new ShiftsEmployee();
        List<string> listE = new List<string>();
        List<string> listE2 = new List<string>();
        int emp = Convert.ToInt32((string)Session["userID"]);
        string tempList = se.getShiftsAfterEditing(emp);
        string[] arrayList = tempList.Split('/');
        listE = arrayList[0].Split(',').ToList<string>();
        foreach (string shift in listE)
        {
            ListItem l = new ListItem();
            if (shift == "11") l = new ListItem("ראשון בוקר (שבוע הבא)", "11n");
            else if (shift == "12") l = new ListItem("ראשון אמצע (שבוע הבא)", "12n");
            else if (shift == "13") l = new ListItem("ראשון ערב (שבוע הבא)", "13n");
            else if (shift == "21") l = new ListItem("שני בוקר (שבוע הבא)", "21n");
            else if (shift == "22") l = new ListItem("שני אמצע (שבוע הבא)", "22n");
            else if (shift == "23") l = new ListItem("שני ערב (שבוע הבא)", "22n");
            else if (shift == "31") l = new ListItem("שלישי בוקר (שבוע הבא)", "32n");
            else if (shift == "32") l = new ListItem("שלישי אמצע (שבוע הבא)", "32n");
            else if (shift == "33") l = new ListItem("שלישי ערב (שבוע הבא)", "32n");
            else if (shift == "41") l = new ListItem("רביעי בוקר (שבוע הבא)", "42n");
            else if (shift == "42") l = new ListItem("רביעי אמצע (שבוע הבא)", "42n");
            else if (shift == "43") l = new ListItem("רביעי ערב (שבוע הבא)", "42n");
            else if (shift == "51") l = new ListItem("חמישי בוקר (שבוע הבא)", "51n");
            else if (shift == "52") l = new ListItem("חמישי אמצע (שבוע הבא)", "52n");
            else if (shift == "53") l = new ListItem("חמישי ערב (שבוע הבא)", "53n");
            else if (shift == "61") l = new ListItem("שישי בוקר (שבוע הבא)", "61n");
            else if (shift == "71") l = new ListItem("צאת שבת (שבוע הבא)", "73n");
            DropDownList1.Items.Add(l);
        }
        if (arrayList.Length > 1)
        {
            listE2 = arrayList[1].Split(',').ToList<string>();
            foreach (string shift in listE2)
            {
                ListItem l = new ListItem();
                if (shift == "11") l = new ListItem("ראשון בוקר (השבוע)", "11w");
                else if (shift == "12") l = new ListItem("ראשון אמצע (השבוע)", "12w");
                else if (shift == "13") l = new ListItem("ראשון ערב (השבוע)", "13w");
                else if (shift == "21") l = new ListItem("שני בוקר (השבוע)", "21w");
                else if (shift == "22") l = new ListItem("שני אמצע (השבוע)", "22w");
                else if (shift == "23") l = new ListItem("שני ערב (השבוע)", "22w");
                else if (shift == "31") l = new ListItem("שלישי בוקר (השבוע)", "32w");
                else if (shift == "32") l = new ListItem("שלישי אמצע (השבוע)", "32w");
                else if (shift == "33") l = new ListItem("שלישי ערב (השבוע)", "32w");
                else if (shift == "41") l = new ListItem("רביעי בוקר (השבוע)", "42w");
                else if (shift == "42") l = new ListItem("רביעי אמצע (השבוע)", "42w");
                else if (shift == "43") l = new ListItem("רביעי ערב (השבוע)", "42w");
                else if (shift == "51") l = new ListItem("חמישי בוקר (השבוע)", "51w");
                else if (shift == "52") l = new ListItem("חמישי אמצע (השבוע)", "52w");
                else if (shift == "53") l = new ListItem("חמישי ערב (השבוע)", "53w");
                else if (shift == "61") l = new ListItem("שישי בוקר (השבוע)", "61w");
                else if (shift == "71") l = new ListItem("צאת שבת (השבוע)", "73w");
                DropDownList1.Items.Add(l);
            }
        }
    }

    protected void Changes()
    {
        ShiftsEmployee se = new ShiftsEmployee();
        List<string> listE = new List<string>();
        listE = se.getChanges();
        foreach (string shift in listE)
        {
            string[] temp = shift.Split('|');
            string whenTemp = temp[2];
            string when = "";
            if (whenTemp == "w") when = " (השבוע)";
            else when = " (שבוע הבא)";
            ListItem l = new ListItem();
            ListItem l2 = new ListItem();
            if (temp[0] == "11") l = new ListItem("ראשון בוקר "+temp[1] + when, "11"+ whenTemp);
            else if (temp[0] == "12") l = new ListItem( "ראשון אמצע " + temp[1]+ when, "12" + whenTemp);
            else if (temp[0] == "13") l = new ListItem("ראשון ערב " + temp[1] + when, "13" + whenTemp);
            else if (temp[0] == "21") l = new ListItem("שני בוקר " + temp[1] + when, "21" + whenTemp);
            else if (temp[0] == "22") l = new ListItem("שני אמצע " + temp[1] + when, "22" + whenTemp);
            else if (temp[0] == "23") l = new ListItem("שני ערב " + temp[1] + when, "22" + whenTemp);
            else if (temp[0] == "31") l = new ListItem("שלישי בוקר " + temp[1] + when, "32" + whenTemp);
            else if (temp[0] == "32") l = new ListItem("שלישי אמצע " + temp[1] + when, "32" + whenTemp);
            else if (temp[0] == "33") l = new ListItem("שלישי ערב " + temp[1] + when, "32" + whenTemp);
            else if (temp[0] == "41") l = new ListItem("רביעי בוקר " + temp[1] + when, "42" + whenTemp);
            else if (temp[0] == "42") l = new ListItem("רביעי אמצע " + temp[1] + when, "42" + whenTemp);
            else if (temp[0] == "43") l = new ListItem("רביעי ערב " + temp[1] + when, "42" + whenTemp);
            else if (temp[0] == "51") l = new ListItem("חמישי בוקר " + temp[1] + when, "51" + whenTemp);
            else if (temp[0] == "52") l = new ListItem("חמישי אמצע " + temp[1] + when, "52" + whenTemp);
            else if (temp[0] == "53") l = new ListItem("חמישי ערב " + temp[1] + when, "53" + whenTemp);
            else if (temp[0] == "61") l = new ListItem("שישי בוקר " + temp[1] + when, "61" + whenTemp);
            else if (temp[0] == "71") l = new ListItem("צאת שבת " + temp[1] + when, "73" + whenTemp);
            if(temp[3]=="0") DropDownList2.Items.Add(l);
            else DropDownList3.Items.Add(l);
        }
    }

    protected void InsertChange(object sender, EventArgs e)
    {
        ShiftsEmployee se = new ShiftsEmployee();
        int emp = Convert.ToInt32((string)Session["userID"]);
        string temp = DropDownList1.SelectedValue;
        int shift = Convert.ToInt32(temp.Substring(0,2));
        string type = temp.Substring(2);
        int numEff = se.insertSwitch(emp,shift,type);
        DropDownList1.Items.Clear();
        DropDownList2.Items.Clear();
        DropDownList3.Items.Clear();
        ShiftEmployee();
        Changes();
    }

    
    protected void updateSwitch(object sender, EventArgs e)
    {
        ShiftsEmployee se = new ShiftsEmployee();
        int empTake = Convert.ToInt32((string)Session["userID"]);
        string temp = DropDownList2.SelectedValue;
        string[] tempArr = DropDownList2.SelectedItem.Text.Split(' ');
        int empAsk = Convert.ToInt32(tempArr[2]);
        int shift = Convert.ToInt32(temp.Substring(0, 2));
        string type = temp.Substring(2);
        int numEff = 0;
        if (empAsk!=empTake) numEff = se.updateSwitch(empTake, empAsk, shift, type);
        DropDownList1.Items.Clear();
        DropDownList2.Items.Clear();
        DropDownList3.Items.Clear();
        ShiftEmployee();
        Changes();
    }

    protected void ApproveSwitch(object sender, EventArgs e)
    {
        ShiftsEmployee se = new ShiftsEmployee();
        int empTake = Convert.ToInt32((string)Session["userID"]);
        string temp = DropDownList3.SelectedValue;
        string[] tempArr = DropDownList3.SelectedItem.Text.Split(' ');
        int empAsk = Convert.ToInt32(tempArr[2]);
        int shift = Convert.ToInt32(temp.Substring(0, 2));
        string type = temp.Substring(2);
        int numEff = 0;
        if (empAsk != empTake) numEff = se.approveSwitch(empTake, empAsk, shift, type);
        DropDownList1.Items.Clear();
        DropDownList2.Items.Clear();
        DropDownList3.Items.Clear();
        ShiftEmployee();
        Changes();
    }
}