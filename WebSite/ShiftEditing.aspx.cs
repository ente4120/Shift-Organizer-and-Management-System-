using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Xml.XPath;


public partial class ShiftEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["userID"] != null)
        {
            LoadEmployees();
        }
        else
        {
            Response.Redirect("login.aspx");
        }
        
    }

    protected void LoadAlgorithm(object sender, EventArgs e)
    {
        ShiftsEmployee shiftEmp = new ShiftsEmployee();
        List<ShiftsEmployee> shiftEmpList = shiftEmp.GetShiftsList();
        Employee emp = new Employee();
        List<Employee> empL = emp.getEmployeeList();
        foreach (ShiftsEmployee shift in shiftEmpList)
        {
            HtmlGenericControl divShift = new HtmlGenericControl("button");
            divShift.Attributes["class"] = "btn btn-light";
            foreach (Employee empT in empL)
            {
                if(shift.Title==empT.First_name) divShift.ID = empT.User_name + "_" + shift.Type;
            }
            divShift.Attributes.CssStyle.Add("width", "80px");
            divShift.Attributes.CssStyle.Add("margin-bottom", "2px");
            divShift.InnerHtml = shift.Title + "   <img src='img/delete.png' style='height: 15px; '/>";
            if (shift.Type == 11) { PlaceHolder11.Controls.Add(divShift); continue; }
            else if (shift.Type == 21) { PlaceHolder21.Controls.Add(divShift); continue; }
            else if (shift.Type == 31) { PlaceHolder31.Controls.Add(divShift); continue; }
            else if (shift.Type == 41) { PlaceHolder41.Controls.Add(divShift); continue; }
            else if (shift.Type == 51) { PlaceHolder51.Controls.Add(divShift); continue; }
            else if (shift.Type == 61) { PlaceHolder61.Controls.Add(divShift); continue; }
            else if (shift.Type == 71) { PlaceHolder71.Controls.Add(divShift); continue; }
            else if (shift.Type == 12) { PlaceHolder12.Controls.Add(divShift); continue; }
            else if (shift.Type == 22) { PlaceHolder22.Controls.Add(divShift); continue; }
            else if (shift.Type == 32) { PlaceHolder32.Controls.Add(divShift); continue; }
            else if (shift.Type == 42) { PlaceHolder42.Controls.Add(divShift); continue; }
            else if (shift.Type == 52) { PlaceHolder52.Controls.Add(divShift); continue; }
            else if (shift.Type == 62) { PlaceHolder62.Controls.Add(divShift); continue; }
            else if (shift.Type == 72) { PlaceHolder72.Controls.Add(divShift); continue; }
            else if (shift.Type == 13) { PlaceHolder13.Controls.Add(divShift); continue; }
            else if (shift.Type == 23) { PlaceHolder23.Controls.Add(divShift); continue; }
            else if (shift.Type == 33) { PlaceHolder33.Controls.Add(divShift); continue; }
            else if (shift.Type == 43) { PlaceHolder43.Controls.Add(divShift); continue; }
            else if (shift.Type == 53) { PlaceHolder53.Controls.Add(divShift); continue; }
            else if (shift.Type == 63) { PlaceHolder63.Controls.Add(divShift); continue; }
            else if (shift.Type == 73) { PlaceHolder73.Controls.Add(divShift); continue; }
        }
        EmployeeList.Controls.Clear();
        foreach (Employee empTemp in empL)
        {
            HtmlGenericControl divEmpl = new HtmlGenericControl("div");
            divEmpl.Attributes["class"] = "btn list";
            divEmpl.ID = empTemp.First_name;
            divEmpl.Attributes["draggable"] = "true";
            divEmpl.Attributes["ondragstart"] = "drag(event)";
            string list = "";
            foreach (ShiftsEmployee item in empTemp.Last_shift)
            {
                if (list == "") list = Convert.ToString(item.Type);
                else list += "0"+Convert.ToString(item.Type);
            }
            divEmpl.Attributes["onmouseover"] = "employeePerfernce("+list+")";
            divEmpl.Attributes["onmouseout"] = "clearShiftTable()";
            divEmpl.InnerHtml = empTemp.First_name + " " + empTemp.Last_name;
            int counter = 0;
            foreach (ShiftsEmployee shift in shiftEmpList)
            {
                if (shift.Title == empTemp.First_name) counter++;
            }
            if (counter > empTemp.Minimum) divEmpl.InnerHtml += "  <span class='badge badge-pill badge-primary tooltipC'> <span class='tooltiptext'>" + empTemp.Minimum + " משמרות</span><span id='" + empTemp.User_name + "'>" + counter + "<span></span>";
            else if (counter == empTemp.Minimum) divEmpl.InnerHtml += "  <span class='badge badge-pill badge-success tooltipC'> <span class='tooltiptext'>" + empTemp.Minimum + " משמרות</span><span id='" + empTemp.User_name + "'>" + counter + "<span></span>";
            else if (counter >  empTemp.Minimum) divEmpl.InnerHtml += "  <span class='badge badge-pill badge-warning tooltipC'> <span class='tooltiptext'>" + empTemp.Minimum + " משמרות</span><span id='" + empTemp.User_name + "'>" + counter + "<span></span>";
            else if (counter == 0) divEmpl.InnerHtml += "  <span class='badge badge-pill badge-danger tooltipC'> <span class='tooltiptext'>" + empTemp.Minimum + " משמרות</span><span id='" + empTemp.User_name + "'>" + 0 + "<span></span>";
            divEmpl.ID = Convert.ToString(empTemp.First_name + "_" + empTemp.Last_name + "_" + empTemp.User_name);
            EmployeeList.Controls.Add(divEmpl);
        }
    }

    protected void Clear(object sender, EventArgs e)
    {
        PlaceHolder11.Controls.Clear();
        PlaceHolder21.Controls.Clear();
        PlaceHolder31.Controls.Clear();
        PlaceHolder41.Controls.Clear();
        PlaceHolder51.Controls.Clear();
        PlaceHolder61.Controls.Clear();
        PlaceHolder71.Controls.Clear();
        PlaceHolder12.Controls.Clear();
        PlaceHolder22.Controls.Clear();
        PlaceHolder32.Controls.Clear();
        PlaceHolder42.Controls.Clear();
        PlaceHolder52.Controls.Clear();
        PlaceHolder62.Controls.Clear();
        PlaceHolder72.Controls.Clear();
        PlaceHolder13.Controls.Clear();
        PlaceHolder23.Controls.Clear();
        PlaceHolder33.Controls.Clear();
        PlaceHolder43.Controls.Clear();
        PlaceHolder53.Controls.Clear();
        PlaceHolder63.Controls.Clear();
        PlaceHolder73.Controls.Clear();
        EmployeeList.Controls.Clear();
        Employee emp = new Employee();
        List<Employee> empL = emp.getEmployeeList();
        foreach (Employee empTemp in empL)
        {
            HtmlGenericControl divEmpl = new HtmlGenericControl("div");
            divEmpl.Attributes["class"] = "btn";
            divEmpl.Attributes["draggable"] = "true";
            divEmpl.Attributes["ondragstart"] = "drag(event)";
            string list = "";
            foreach (ShiftsEmployee item in empTemp.Last_shift)
            {
                if (list == "") list = Convert.ToString(item.Type);
                else list += "0" + Convert.ToString(item.Type);
            }
            divEmpl.Attributes["onmouseover"] = "employeePerfernce(" + list + ")";
            divEmpl.Attributes["onmouseout"] = "clearShiftTable()";
            divEmpl.InnerHtml = empTemp.First_name + " " + empTemp.Last_name;
            divEmpl.InnerHtml += "  <span class='badge badge-pill badge-danger tooltipC'> <span class='tooltiptext'>" + empTemp.Minimum + " משמרות</span><span id='" + empTemp.User_name + "'>" + 0 + "<span></span>";
            divEmpl.ID = Convert.ToString(empTemp.First_name+"_"+ empTemp.Last_name+"_"+ empTemp.User_name);
            EmployeeList.Controls.Add(divEmpl);
        }
    }

    protected void LoadEmployees()
    {
        Employee emp = new Employee();
        List<Employee> empL = emp.getEmployeeList();
        ShiftsEmployee shiftEmp = new ShiftsEmployee();
        List<ShiftsEmployee> shiftEmpList = shiftEmp.GetShiftsList();
        foreach (Employee empTemp in empL)
        {
            HtmlGenericControl divEmpl = new HtmlGenericControl("div");
            divEmpl.Attributes["class"] = "btn list";
            divEmpl.ID = empTemp.First_name;
            divEmpl.Attributes["draggable"] = "true";
            divEmpl.Attributes["ondragstart"] = "drag(event)";
            string list = "";
            foreach (ShiftsEmployee item in empTemp.Last_shift)
            {
                if (list == "") list = Convert.ToString(item.Type);
                else list += "0" + Convert.ToString(item.Type);
            }
            divEmpl.Attributes["onmouseover"] = "employeePerfernce(" + list + ")";
            divEmpl.Attributes["onmouseout"] = "clearShiftTable()";
            divEmpl.InnerHtml = empTemp.First_name + " " + empTemp.Last_name;
            divEmpl.InnerHtml += " <span class='badge badge-pill badge-danger tooltipC'> <span class='tooltiptext'>" + empTemp.Minimum+" משמרות</span><span id='"+ empTemp.User_name+"'>" + 0 + "<span></span>";
            divEmpl.ID = Convert.ToString(empTemp.First_name + "_" + empTemp.Last_name + "_" + empTemp.User_name);
            EmployeeList.Controls.Add(divEmpl);
        }
    }

    //protected void Counter()
    //{
    //    Employee emp = new Employee();
    //    List<Employee> empL = emp.getEmployeeList();

    //    foreach (Employee empTemp in empL)
    //    {
    //        HtmlGenericControl divEmpl = new HtmlGenericControl("div");
    //        divEmpl.Attributes["class"] = "btn list";
    //        divEmpl.InnerHtml = empTemp.First_name + " " + empTemp.Last_name;
    //        int counter = 0;
    //        divEmpl.InnerHtml += " <span class='badge badge-pill badge-danger'>" + counter + "</span>";
    //        divEmpl.ID = Convert.ToString(empTemp.User_name);
    //        EmployeeList.Controls.Add(divEmpl);
    //    }
    //}

    protected void AddEmployee()
    {
        Employee emp = new Employee();
        List<Employee> empL = emp.getEmployeeList();
        foreach (Employee empTemp in empL)
        {
            HtmlGenericControl divEmpl = new HtmlGenericControl("div");
            divEmpl.Attributes["class"] = "btn";
            divEmpl.InnerHtml = empTemp.First_name + " " + empTemp.Last_name;
            divEmpl.InnerHtml += "  <span class='badge badge-pill badge-danger tooltipC'> <span class='tooltiptext'>" + empTemp.Minimum + " משמרות</span><span id='" + empTemp.User_name + "'>" + 0 + "<span></span>";
            divEmpl.ID = Convert.ToString(empTemp.User_name);
            EmployeeList.Controls.Add(divEmpl);
        }
    }

    protected void SaveShift(object sender, EventArgs e)
    {
        ShiftsEmployee tempEmp = new ShiftsEmployee();
        try
        {
            string stringList = Request.Cookies["ListShiftAfterEditing"].Value;
            int numEffected = tempEmp.SaveShiftsAfterEditing(stringList);
            Response.Redirect("Shifts.aspx");
        }
        catch (Exception ex)
        {
            Response.Write("There was an error when trying to insert the shift into the database" + ex.Message);
        }
    }

    protected void XmlReader(object sender, EventArgs e)
    {
        //קבלת הנתונים
        List<Employee> l = new List<Employee>();
        String xmlFile = Server.MapPath("~/App_Code/Rikushet.xml");
        XPathNavigator nav;
        XPathDocument docNav;
        docNav = new XPathDocument(xmlFile);
        nav = docNav.CreateNavigator();
        XPathNodeIterator NodeIter;
        NodeIter = nav.Select("/Employees/employee");
        while (NodeIter.MoveNext())
        {
            Employee tempE = new Employee();
            tempE.First_name = Convert.ToString(NodeIter.Current.SelectSingleNode("first_name").Value);
            tempE.Last_name = Convert.ToString(NodeIter.Current.SelectSingleNode("last_name").Value);
            tempE.User_name = Convert.ToInt32(NodeIter.Current.SelectSingleNode("user_name").Value);
            tempE.Minimum = Convert.ToInt32(NodeIter.Current.SelectSingleNode("minimum").Value);
            tempE.Password = Convert.ToString(NodeIter.Current.SelectSingleNode("password").Value);
            tempE.Type = Convert.ToString(NodeIter.Current.SelectSingleNode("type").Value);
            tempE.Branch = Convert.ToString(NodeIter.Current.SelectSingleNode("branch").Value);
            tempE.Have = 0;
            List<ShiftsEmployee> EmplL = new List<ShiftsEmployee>();
            string temp = Convert.ToString(NodeIter.Current.SelectSingleNode("shiftsEmployees").Value);
            string[] tempString = temp.Split(',');
            foreach (string item in tempString) //כל העדפה של עובד תשמר באובייקט מיטחד של משמרת
            {
                ShiftsEmployee tempSE2 = new ShiftsEmployee();
                tempSE2.Title = tempE.First_name;
                tempSE2.Type = Convert.ToInt32(item);
                EmplL.Add(tempSE2);
            }
            tempE.Last_shift = EmplL;
            l.Add(tempE);
        }
        Shift thisweekshift = new Shift();
        Shift tempSh = new Shift();
        thisweekshift = tempSh.getShiftSetting();
        List<Employee> employee = l;
        List<ShiftsEmployee> tempSE = new List<ShiftsEmployee>();
        //Create Sort List to Make the Different Algoritm
        int plusN = 1;
        SortedList<double, Employee> sl = new SortedList<double, Employee>();
        foreach (Employee em in employee)
        {
            Random rnd = new Random();
            double plus = Convert.ToDouble(rnd.Next(1, 50)) * 0.0001;
            if (em.First_name != "בר")
            {
                double keys = (double)em.Minimum / (em.Last_shift.Count());
                sl.Add(keys + plus * plusN, em);
                plusN++;
            }
            else
            {
                sl.Add(0, em);
            }
        }

        //Create new List of employees
        List<Employee> employeeList = new List<Employee>();
        foreach (KeyValuePair<double, Employee> item in sl)
        {
            if (item.Value.First_name != "בר")
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
        foreach (Employee emp2 in employeeList) //Running on employees list
        {
            if (emp2.Minimum > emp2.Have) //Running just on employees who dont have enough shifts
            {
                foreach (ShiftsEmployee shift in emp2.Last_shift) //Running in shift list of each employee
                {
                    for (int i = 0; i < thisweekshift.Possibles.Count; i++) //Running on possible shifts of employees
                    {
                        if (shift.Type == thisweekshift.Shifts[i] && thisweekshift.Possibles[i] > 0) //Match shifts and updating
                        {
                            thisweekshift.Possibles[i] -= 1;
                            emp2.Have++;
                            tempSE.Add(shift);
                        }
                    }
                }
            }
        }
        //Checking that all shifts are done
        for (int i = 0; i < thisweekshift.Possibles.Count; i++) //Running on possible shifts of employees
        {
            if (thisweekshift.Possibles[i] > 0) //Match shifts and updating
            {
                foreach (Employee emp3 in employeeList)
                {
                    foreach (ShiftsEmployee shift in emp3.Last_shift)
                    {
                        if (shift.Type == thisweekshift.Shifts[i] && thisweekshift.Possibles[i] > 0) //Match shifts and updating
                        {
                            int temp = 0;
                            foreach (ShiftsEmployee shifts in tempSE)
                            {
                                if (shifts.Title == emp3.First_name && shifts.Type == thisweekshift.Shifts[i])
                                {
                                    temp++;
                                }
                            }
                            if (temp == 0)
                            {
                                thisweekshift.Possibles[i] -= 1;
                                emp3.Have++;
                                tempSE.Add(shift);
                            }
                        }
                    }
                }
            }
        }
        PlaceHolder11.Controls.Clear();
        PlaceHolder21.Controls.Clear();
        PlaceHolder31.Controls.Clear();
        PlaceHolder41.Controls.Clear();
        PlaceHolder51.Controls.Clear();
        PlaceHolder61.Controls.Clear();
        PlaceHolder71.Controls.Clear();
        PlaceHolder12.Controls.Clear();
        PlaceHolder22.Controls.Clear();
        PlaceHolder32.Controls.Clear();
        PlaceHolder42.Controls.Clear();
        PlaceHolder52.Controls.Clear();
        PlaceHolder62.Controls.Clear();
        PlaceHolder72.Controls.Clear();
        PlaceHolder13.Controls.Clear();
        PlaceHolder23.Controls.Clear();
        PlaceHolder33.Controls.Clear();
        PlaceHolder43.Controls.Clear();
        PlaceHolder53.Controls.Clear();
        PlaceHolder63.Controls.Clear();
        PlaceHolder73.Controls.Clear();
        EmployeeList.Controls.Clear();
        Employee emp = new Employee();
        List<Employee> empL = emp.getEmployeeList();
        foreach (ShiftsEmployee shift in tempSE)
        {
            HtmlGenericControl divShift = new HtmlGenericControl("button");
            divShift.Attributes["class"] = "btn btn-light";
            foreach (Employee empT in empL)
            {
                if (shift.Title == empT.First_name) divShift.ID = empT.User_name + "_" + shift.Type;
            }
            divShift.Attributes.CssStyle.Add("width", "80px");
            divShift.Attributes.CssStyle.Add("margin-bottom", "2px");
            divShift.InnerHtml = shift.Title + "   <img src='img/delete.png' style='height: 15px; '/>";
            if (shift.Type == 11) { PlaceHolder11.Controls.Add(divShift); continue; }
            else if (shift.Type == 21) { PlaceHolder21.Controls.Add(divShift); continue; }
            else if (shift.Type == 31) { PlaceHolder31.Controls.Add(divShift); continue; }
            else if (shift.Type == 41) { PlaceHolder41.Controls.Add(divShift); continue; }
            else if (shift.Type == 51) { PlaceHolder51.Controls.Add(divShift); continue; }
            else if (shift.Type == 61) { PlaceHolder61.Controls.Add(divShift); continue; }
            else if (shift.Type == 71) { PlaceHolder71.Controls.Add(divShift); continue; }
            else if (shift.Type == 12) { PlaceHolder12.Controls.Add(divShift); continue; }
            else if (shift.Type == 22) { PlaceHolder22.Controls.Add(divShift); continue; }
            else if (shift.Type == 32) { PlaceHolder32.Controls.Add(divShift); continue; }
            else if (shift.Type == 42) { PlaceHolder42.Controls.Add(divShift); continue; }
            else if (shift.Type == 52) { PlaceHolder52.Controls.Add(divShift); continue; }
            else if (shift.Type == 62) { PlaceHolder62.Controls.Add(divShift); continue; }
            else if (shift.Type == 72) { PlaceHolder72.Controls.Add(divShift); continue; }
            else if (shift.Type == 13) { PlaceHolder13.Controls.Add(divShift); continue; }
            else if (shift.Type == 23) { PlaceHolder23.Controls.Add(divShift); continue; }
            else if (shift.Type == 33) { PlaceHolder33.Controls.Add(divShift); continue; }
            else if (shift.Type == 43) { PlaceHolder43.Controls.Add(divShift); continue; }
            else if (shift.Type == 53) { PlaceHolder53.Controls.Add(divShift); continue; }
            else if (shift.Type == 63) { PlaceHolder63.Controls.Add(divShift); continue; }
            else if (shift.Type == 73) { PlaceHolder73.Controls.Add(divShift); continue; }
        }
        EmployeeList.Controls.Clear();
        foreach (Employee empTemp in empL)
        {
            HtmlGenericControl divEmpl = new HtmlGenericControl("div");
            divEmpl.Attributes["class"] = "btn list";
            divEmpl.ID = empTemp.First_name;
            divEmpl.Attributes["draggable"] = "true";
            divEmpl.Attributes["ondragstart"] = "drag(event)";
            string list = "";
            foreach (ShiftsEmployee item in empTemp.Last_shift)
            {
                if (list == "") list = Convert.ToString(item.Type);
                else list += "," + Convert.ToString(item.Type);
            }
            divEmpl.Attributes["onmouseover"] = "employeePerfernce(" + list + ")";
            divEmpl.Attributes["onmouseout"] = "clearShiftTable()";
            divEmpl.InnerHtml = empTemp.First_name + " " + empTemp.Last_name;
            int counter = 0;
            foreach (ShiftsEmployee shift in tempSE)
            {
                if (shift.Title == empTemp.First_name) counter++;
            }
            if (counter > 0) divEmpl.InnerHtml += "  <span class='badge badge-pill badge-danger tooltipC'> <span class='tooltiptext'>" + empTemp.Minimum + " משמרות</span>" + counter + "</span>";
            else divEmpl.InnerHtml += "  <span class='badge badge-pill badge-danger tooltipC'> <span class='tooltiptext'>" + empTemp.Minimum + " משמרות</span>" + counter + "</span>";
            divEmpl.ID = Convert.ToString(empTemp.First_name + "_" + empTemp.Last_name + "_" + empTemp.User_name);
            EmployeeList.Controls.Add(divEmpl);
        }
    }
}