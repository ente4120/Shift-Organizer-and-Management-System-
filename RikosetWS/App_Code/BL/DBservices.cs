using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Web.Script.Serialization;


/// <summary>
/// Summary description for DBservices
/// </summary>
public class DBservices

{
    public DataTable dt;
    public SqlDataAdapter da;
    public DBservices()
    {
        //
        // TODO: Add constructor logic here
        //
    }
  
    public SqlConnection connect(String conString)
    {
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }
    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

        return cmd;
    }
   
    public List<Employee> getEmployeeObjects(string conString)
    {
        List<Employee> l = new List<Employee>();
        SqlConnection con = null;
        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file
            //String selectSTR = "select * from Employee E inner join [Employee Type] ET ON E.Type=ET.ID INNER JOIN [Shift Before Scheduling] SBS ON E.ID=SBS.EmployeeID";

            String selectSTR = "select * from Employee E inner join [Employee Type] ET ON E.Type=ET.ID INNER JOIN (SELECT [ID],[FirstTime],[FinishTime],[Content],[EmployeeID] FROM [igroup80_test2].[dbo].[Shift Before Scheduling]WHERE [ID] IN (SELECT [ID] FROM (SELECT [ID],RANK() OVER (PARTITION BY [EmployeeID] ORDER BY [ID] DESC) AS RankNO FROM [igroup80_test2].[dbo].[Shift Before Scheduling])AS T WHERE T.RankNO='1')) SBS ON E.ID=SBS.EmployeeID";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end


            while (dr.Read())
            {   // Read till the end of the data into a row
                Employee Empl = new Employee();
                Empl.First_name = Convert.ToString(dr["FirstName"]);
                Empl.Last_name = Convert.ToString(dr["LastName"]);
                Empl.User_name = Convert.ToInt32(dr["UserName"]);
                Empl.Type= Convert.ToString(dr["NAME"]);
                Empl.Branch = Convert.ToString(dr["Branch"]);
                Empl.Minimum = Convert.ToInt32(dr["Minimum"]);
                List<ShiftsEmployee> EmplL = new List<ShiftsEmployee>();
                string temp = Convert.ToString(dr["Content"]);
                string[] tempString = temp.Split(',');
                foreach (string item in tempString) //כל העדפה של עובד תשמר באובייקט מיטחד של משמרת
                {
                    ShiftsEmployee tempSE = new ShiftsEmployee();
                    tempSE.Title = Empl.First_name;
                    tempSE.Type = Convert.ToInt32(item);
                    EmplL.Add(tempSE);
                }
                Empl.Last_shift = EmplL;
                l.Add(Empl);
            }

            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }
    public DataTable getEmployeeSObjects(string conString, string table)
    {
        List<string> listChanges = new List<string>();
        DBservices dbS = new DBservices(); // create a helper class
        SqlConnection con = null;

        try
        {
            con = dbS.connect(conString); // open the connection to the database/

            String selectStr = "SELECT * FROM " + table+"WHERE [Active]=1";

            SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter


            DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
            da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

            DataTable dt = ds.Tables[0];

            // add the datatable and the dataa adapter to the dbS helper class in order to be able to save it to a Session Object
            dbS.dt = dt;
            dbS.da = da;

            return dbS.dt;
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public DBservices ReademploCheckDB(string conString, string tableName, string _emploNameF)
    {

        DBservices dbS = new DBservices(); // create a helper class
        SqlConnection con = null;

        try
        {
            con = dbS.connect(conString); // open the connection to the database

            String selectStr = "SELECT * FROM " + tableName + " WHERE ID = '" + _emploNameF +  "'";
            SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

            DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
            da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

            DataTable dt = ds.Tables[0];

            // add the datatable and the data adapter to the dbS helper class in order to be able to save it to a Session Object
            dbS.dt = dt;
            dbS.da = da;

            return dbS;
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
    public DBservices ReadGuideCheckDB(string conString, string tableName, string _GuName)
    {

        DBservices dbS = new DBservices(); // create a helper class
        SqlConnection con = null;

        try
        {
            con = dbS.connect(conString); // open the connection to the database

            String selectStr = "SELECT * FROM " + tableName + " WHERE ID = '" + _GuName + "'";
            SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

            DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
            da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

            DataTable dt = ds.Tables[0];

            // add the datatable and the data adapter to the dbS helper class in order to be able to save it to a Session Object
            dbS.dt = dt;
            dbS.da = da;

            return dbS;
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
    public DBservices ReadTransferCheckDB(string conString, string tableName)
    {

        DBservices dbS = new DBservices(); // create a helper class
        SqlConnection con = null;

        try
        {
            con = dbS.connect(conString); // open the connection to the database

            String selectStr = "SELECT * FROM " + tableName;
            SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

            DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
            da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

            DataTable dt = ds.Tables[0];

            // add the datatable and the data adapter to the dbS helper class in order to be able to save it to a Session Object
            dbS.dt = dt;
            dbS.da = da;

            return dbS;
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
    public DBservices ReaProductCheckDB(string conString, string tableName, string _productName)
    {

        DBservices dbS = new DBservices(); // create a helper class
        SqlConnection con = null;

        try
        {
            con = dbS.connect(conString); // open the connection to the database

            String selectStr = "SELECT * FROM " + tableName + " WHERE ID = '" + _productName + "'";
            SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

            DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
            da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

            DataTable dt = ds.Tables[0];

            // add the datatable and the data adapter to the dbS helper class in order to be able to save it to a Session Object
            dbS.dt = dt;
            dbS.da = da;

            return dbS;
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
   
    public DBservices ReadprodCheckDB(string conString, string tableName, int id)
    {

        DBservices dbS = new DBservices(); // create a helper class
        SqlConnection con = null;

        try
        {
            con = dbS.connect(conString); // open the connection to the database

            String selectStr = "SELECT * FROM " + tableName + " WHERE ID = '" + id + "'";
            SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

            DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
            da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

            DataTable dt = ds.Tables[0];

            // add the datatable and the data adapter to the dbS helper class in order to be able to save it to a Session Object
            dbS.dt = dt;
            dbS.da = da;

            return dbS;
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
    public DataTable ReadFromDataBase(string conString, string tableName)
    {

        DBservices dbS = new DBservices(); // create a helper class
        SqlConnection con = null;

        try
        {
            con = dbS.connect(conString); // open the connection to the database/

            String selectStr = "SELECT * FROM " + tableName; // create the select that will be used by the adapter to select data from the DB

            SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

            DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
            da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

            DataTable dt = ds.Tables[0];

            // add the datatable and the dataa adapter to the dbS helper class in order to be able to save it to a Session Object
            dbS.dt = dt;
            dbS.da = da;

            return dbS.dt;
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public DataTable ReadFromDataBaseByID(string conString, string tableName, string id)
    {

        DBservices dbS = new DBservices(); // create a helper class
        SqlConnection con = null;

        try
        {
            con = dbS.connect(conString); // open the connection to the database/

            String selectStr = "SELECT * FROM " + tableName+ " where ID="+id; // create the select that will be used by the adapter to select data from the DB

            SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

            DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
            da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

            DataTable dt = ds.Tables[0];

            // add the datatable and the dataa adapter to the dbS helper class in order to be able to save it to a Session Object
            dbS.dt = dt;
            dbS.da = da;

            return dbS.dt;
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
    public DataTable ReadFromDataBaseByIDG(string conString, string tableName, string id)
    {

        DBservices dbS = new DBservices(); // create a helper class
        SqlConnection con = null;

        try
        {
            con = dbS.connect(conString); // open the connection to the database/

            String selectStr = "SELECT * FROM " + tableName + " where ID=" + id; // create the select that will be used by the adapter to select data from the DB

            SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

            DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
            da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

            DataTable dt = ds.Tables[0];

            // add the datatable and the dataa adapter to the dbS helper class in order to be able to save it to a Session Object
            dbS.dt = dt;
            dbS.da = da;

            return dbS.dt;
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
    public DataTable ReadFromDataBaseByS(string conString, string tableName, int Id)
    {

        DBservices dbS = new DBservices(); // create a helper class
        SqlConnection con = null;

        try
        {
            con = dbS.connect(conString); // open the connection to the database/

            String selectStr = "select top 2 EmployeeID, Content from [dbo].[Shift After Scheduling] where EmployeeID='" + Id + "' order by FinishTime desc"; 

            SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

            DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
            da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

            DataTable dt = ds.Tables[0];

            // add the datatable and the dataa adapter to the dbS helper class in order to be able to save it to a Session Object
            dbS.dt = dt;
            dbS.da = da;

            return dbS.dt;
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public DataTable ReadFromDataBaseCalender(string conString, string tableName)
    {
        DBservices dbS = new DBservices(); // create a helper class
        SqlConnection con = null;

        try
        {
            con = dbS.connect(conString); // open the connection to the database/

            String selectStr = "select * from [dbo].[Shift After Scheduling] SAS INNER JOIN [dbo].[Employee] E ON SAS.EmployeeID=E.UserName ";

            SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

            DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
            da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

            DataTable dt = ds.Tables[0];

            // add the datatable and the dataa adapter to the dbS helper class in order to be able to save it to a Session Object
            dbS.dt = dt;
            dbS.da = da;

            return dbS.dt;
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<Guide> getGuideObjects(string conString, string tableName)
    {
        List<Guide> G = new List<Guide>();
        SqlConnection con = null;
        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM " + tableName;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end


            while (dr.Read())
            {   // Read till the end of the data into a row
                Guide Gui = new Guide(Convert.ToInt32(dr["ID"]),Convert.ToString(dr["GuideName"]), Convert.ToString(dr["Path"]), Convert.ToString(dr["Writer"]), Convert.ToString(dr["Discription"]));
                
                G.Add(Gui);

            }

            return G;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }

    public List<Product> getProductsObjects(string conString)
    {
        List<Product> p = new List<Product>();
        SqlConnection con = null;
        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Product P inner join Category C ON P.Category=C.ID";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Product temp = new Product(Convert.ToInt32(dr["ID"]), Convert.ToString(dr["ProductName"]), Convert.ToString(dr["Brand"]), Convert.ToString(dr["CategoryName"]), Convert.ToString(dr["ImageURL"]), Convert.ToDouble(dr["Price"]), Convert.ToString(dr["Discription"]));
                p.Add(temp);
            }

            return p;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }
    public List<Transfer> getTransferObjects(string conString, string tableName)
    {
        List<Transfer> T= new List<Transfer>();
        SqlConnection con = null;
        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT  T.ID, E.FirstName AS 'Creator',B.Name as 'FROM',b2.Name as 'TO',Date,P.ProductName,T.Amount FROM [igroup80_test2].[dbo].[Transfer] T INNER JOIN Branch B ON T.[From]=B.ID INNER JOIN Branch b2 ON T.[To]=b2.ID INNER JOIN Employee E ON T.Creator=E.ID INNER JOIN Product P ON P.ID=T.ProductID";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end


            while (dr.Read())
            {   // Read till the end of the data into a row
                Transfer Tra = new Transfer(Convert.ToInt32(dr["ID"]), Convert.ToString(dr["Date"]), Convert.ToString(dr["ProductName"]), Convert.ToString(dr["From"]), Convert.ToString(dr["To"]), Convert.ToString(dr["Amount"]),Convert.ToString(dr["Creator"]));
               
                T.Add(Tra);

            }

            return T;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }
    public List<Message> getMessagesObjects( string conString, string tableName)
    {


        List<Message> MessagesList = new List<Message>();
        SqlConnection con = null;
        try
        {
            con = connect(conString);
            String selectSTR = "SELECT * FROM " + tableName+ " M INNER JOIN [dbo].[Employee] E ON M.Writer=E.ID ORDER BY M.[ID] DESC";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            
            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end


            while (dr.Read())
            {   // Read till the end of the data into a row    

                Message m = new Message(Convert.ToInt32(dr["ID"]),Convert.ToString(dr["FirstName"]),Convert.ToString(dr["Date"]),Convert.ToString(dr["Content"]), Convert.ToString(dr["Branch"]), Convert.ToString(dr["Title"]));
                
               
              
            
                MessagesList.Add(m);

            }
            return MessagesList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
    
    public List<string> getCategories(string conString, string tableName, string fieldName)
    {
        List<string> l = new List<string>();
        SqlConnection con = null;
        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT " + fieldName + " FROM " + tableName;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end


            while (dr.Read())
            {   // Read till the end of the data into a row
                
                l.Add((string)dr[fieldName]);
            }

            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }
    public Shift getShiftObjects(string conString, string tableName) {
        SqlConnection con = null;
        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT TOP 1 * FROM " + tableName + "Order by [ID] DESC";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
            Shift sh = new Shift();

            while (dr.Read())
            {   // Read till the end of the data into a row
                sh = new Shift(Convert.ToString(dr["Shifts"]), Convert.ToString(dr["Possibles"]));
            }

            return sh;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }

    public int insertShift(int id, string shift)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("rikosheTDBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String pStr = BuildInsertCommand(id,shift);     // helper method to build the insert string

        cmd = CreateCommand(pStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    private String BuildInsertCommand(int id, string shift)
    {
        String command;

        //get next sunday:
        DateTime today = DateTime.Today;
        int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)today.DayOfWeek + 7) % 7;
        DateTime nextSunday = today.AddDays(daysUntilSunday);


        //get next saterday:
        int daysUntilSaturday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;
        if (daysUntilSaturday < 7)
        {
            daysUntilSaturday += 7;
        }
        DateTime nextSaturday = today.AddDays(daysUntilSaturday);

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}')", Convert.ToString(nextSunday), Convert.ToString(nextSaturday), shift, id);
        String prefix = "INSERT INTO [Shift Before Scheduling] " + "( FirstTime, FinishTime, Content, EmployeeID)";
        command = prefix + sb.ToString();
        return command;
    }

    public int insertShiftSettings(string shift, string possible)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("rikosheTDBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String pStr = BuildInsertCommandSettings(shift, possible);     // helper method to build the insert string

        cmd = CreateCommand(pStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    public int insertShiftAfterEditing(string shift)
    {
        SqlConnection con;
        SqlCommand cmd;
        try
        {
            con = connect("rikosheTDBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String pStr = BuildInsertCommandShifts(shift);     // helper method to build the insert string

        cmd = CreateCommand(pStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    public int insertMessage(string writer, string content, string title, string branch)
    {
        SqlConnection con;
        SqlCommand cmd;        
        try
        {
            con = connect("rikosheTDBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String pStr = BuildInsertCommandMessage(writer, content,title, branch);     // helper method to build the insert string

        cmd = CreateCommand(pStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    public int insertTransfer(string writer, string amount, string from, string to, string Prod)
    {
        SqlConnection con;
        SqlCommand cmd;
        try
        {
            con = connect("rikosheTDBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String pStr = BuildInsertCommandTransfer(writer, amount, from, to, Prod);     // helper method to build the insert string

        cmd = CreateCommand(pStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    private String BuildInsertCommandMessage(string writer, string content, string title, string branch)
    {
        String command;
        // use a string builder to create the dynamic string
        DateTime today = DateTime.Now;
        String sb = "Values('"+writer+"',"+ "CURRENT_TIMESTAMP"+",'"+content+"','"+title + "','" + branch +"')";
        String prefix = "INSERT INTO [Message] "+"([Writer],[Date],[Content],[Title],[Branch])";
        command = prefix + sb;
        return command;
    }
    private String BuildInsertCommandTransfer(string Creator, string amount, string from, string to, string Prod)
    {
        String command;
        // use a string builder to create the dynamic string
        String sb = "Values('" + Creator + "'," + "CURRENT_TIMESTAMP" + ",'" + amount + "','" + from + "','" + to +   "','" + Prod + "')";
        String prefix = "INSERT INTO [Transfer] " + "([Creator],[Date],[From],[To],[ProductID],[Amount])";
        command = prefix + sb;
        return command;
    }
    public int insertEmployee(string FirstName, string LastName, int UserName, string Password, string Type, string Branch, int Minimum)
    {
        SqlConnection con;
        SqlCommand cmd;
        try
        {
            con = connect("rikosheTDBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String pStr = BuildInsertCommandEmployee(FirstName, LastName, UserName, Password, Type, Branch, Minimum);     // helper method to build the insert string

        cmd = CreateCommand(pStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    private String BuildInsertCommandEmployee(string FirstName, string LastName, int UserName, string Password, string Type, string Branch, int Minimum)
    {
        String command;
        //use a string builder to create the dynamic string
        String sb = "Values('" + FirstName + "','" + LastName + "','" + UserName + "','" + Password + "','" + Type + "','" + Branch + "','" + Minimum + "','1')";
        String prefix = "INSERT INTO [Employee] " + "([FirstName],[LastName],[UserName],[Password],[Type],[Branch],[Minimum],[Active])";
        command = prefix + sb;
        return command;
    }


    private String BuildInsertCommandSettings(string shift, string possible)
    {
        String command;
        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}')", shift, possible);
        String prefix = "INSERT INTO [Shift] " + "( Shifts, Possibles)";
        command = prefix + sb.ToString();
        return command;
    }

    private String BuildInsertCommandShifts(string shift)
    {
        String command =null;
        
        // use a string builder to create the dynamic string
        string[] shiftsArray = shift.Split('/');
        DateTime sunday = DateTime.Now.AddDays(DayOfWeek.Sunday - DateTime.Now.DayOfWeek);
        DateTime saterday = DateTime.Now.AddDays(DayOfWeek.Friday - DateTime.Now.DayOfWeek);
        string StartTime = Convert.ToString(sunday.AddDays(7));
        string FinishTime = Convert.ToString(saterday.AddDays(7));
        foreach (string item in shiftsArray)
        {
            StringBuilder sb = new StringBuilder();
            string[] temp = item.Split('|');
            sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}')", StartTime, FinishTime, temp[1], temp[0]);
            String prefix = "INSERT INTO [Shift After Scheduling] " + "( [StartTime], [FinishTime], [Content], [EmployeeID])";
            command += prefix + sb.ToString()+";";
        }
        return command;
    }

    public Employee loginUser(int userName, string Password)
    {
        Employee emp = new Employee();
        SqlConnection con = null;
        try
        {
            con = connect("rikosheTDBConnectionString"); // create a connection to the database using the connection String defined in the web config file
            //String selectSTR = "select * from Employee E inner join [Employee Type] ET ON E.Type=ET.ID INNER JOIN [Shift Before Scheduling] SBS ON E.ID=SBS.EmployeeID";

            String selectSTR = "SELECT * FROM [igroup80_test2].[dbo].[Employee] E INNER JOIN (SELECT [ID],[FirstTime],[FinishTime],[Content],[EmployeeID] FROM [igroup80_test2].[dbo].[Shift Before Scheduling]WHERE [ID] IN (SELECT [ID] FROM (SELECT [ID],RANK() OVER (PARTITION BY [EmployeeID] ORDER BY [ID] DESC) AS RankNO FROM [igroup80_test2].[dbo].[Shift Before Scheduling])AS T WHERE T.RankNO='1')) SBS ON E.ID=SBS.EmployeeID WHERE [UserName]=" + userName + " AND [Password]='" + Password + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end


            while (dr.Read())
            {   // Read till the end of the data into a row
                Employee Empl = new Employee();
                Empl.First_name = Convert.ToString(dr["FirstName"]);
                Empl.Last_name = Convert.ToString(dr["LastName"]);
                Empl.User_name = Convert.ToInt32(dr["UserName"]);
                Empl.Password = Convert.ToString(dr["Password"]);
                Empl.Type = Convert.ToString(dr["Type"]);
                Empl.Branch = Convert.ToString(dr["Branch"]);
                Empl.Minimum = Convert.ToInt32(dr["Minimum"]);
                List<ShiftsEmployee> EmplL = new List<ShiftsEmployee>();
                string temp = Convert.ToString(dr["Content"]);
                string[] tempString = temp.Split(',');
                foreach (string item in tempString) //כל העדפה של עובד תשמר באובייקט מיטחד של משמרת
                {
                    ShiftsEmployee tempSE = new ShiftsEmployee();
                    tempSE.Title = Empl.First_name;
                    tempSE.Type = Convert.ToInt32(item);
                    EmplL.Add(tempSE);
                }
                Empl.Last_shift = EmplL;
                emp = Empl;
            }

            return emp;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }

    public int insertDataBaseChange(string connection, string table, int emp, int shift, string type)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect(connection); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String pStr = BuildInsertCommandChange(table, emp, shift, type);     // helper method to build the insert string

        cmd = CreateCommand(pStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    private String BuildInsertCommandChange(string table, int emp, int shift, string type
        )
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}')",emp,0,1,shift, type );
        String prefix = "INSERT INTO "+table+ " ( [EmployeeAsk], [EmployeeTake], [Active], [Shifts], [Change_time])";
        command = prefix + sb.ToString();
        return command;
    }

    public int updateDataBaseChange(string connection, string table, int empTake, int empAsk, int shift, string type)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect(connection); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String pStr = UpdateInsertCommandChange(table, empTake, empAsk, shift, type);     // helper method to build the insert string

        cmd = CreateCommand(pStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    private String UpdateInsertCommandChange(string table, int empTake, int empAsk, int shift, string type
        )
    {
        String command;
        command = "UPDATE "+table+ " SET [EmployeeTake]='"+empTake+ "' WHERE [EmployeeAsk]='"+empAsk + "' AND [Shifts]=" + shift + "AND [Change_time]='" + type + "'";
        return command;
    }

    public int approveDataBaseChange(string connection, string table, int empTake, int empAsk, int shift, string type)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect(connection); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String pStr = ApproveInsertCommandChange(table,empTake, empAsk, shift, type);     // helper method to build the insert string

        cmd = CreateCommand(pStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    private String ApproveInsertCommandChange(string table, int empTake, int empAsk, int shift, string type)
    {
        String command;
        String command2;
        String command3;
        command = "UPDATE " + table + " SET [Active]=0 WHERE [EmployeeAsk]='" + empAsk + "' AND [Shifts]=" + shift + " AND [Change_time]='" + type + "'";
        RikoshetWebService t = new RikoshetWebService();
        JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
        String tempTake = jsonSerializer.Deserialize <String>(t.getSwitch(empTake));
        String[] listTake = tempTake.Split('/');
        String tempAsk = jsonSerializer.Deserialize<String>(t.getSwitch(empAsk));
        String[] listAsk = tempAsk.Split('/');
        if (type == "w")
        {
            String newASK = "";
            String newTake = "";
            String[] takeContent = listTake[1].Split(',');
            String[] askContent = listAsk[1].Split(',');
            foreach (String letter in takeContent)
            {
                if (newTake != "") newTake += "," + letter;
                else newTake = letter;
            }
            if (newTake != "") newTake += "," + shift;
            else newTake = Convert.ToString(shift);
            foreach (String letter in askContent)
            {
                if (Convert.ToInt32(letter) != shift)
                {
                    if (newASK != "") newASK += "," + letter;
                    else newASK = letter;
                }

            }
            command2 = "UPDATE [Shift After Scheduling] SET [Content]='"+ newTake + "' WHERE [ID]=(SELECT TOP 1  A.[ID] FROM (SELECT TOP (2) * FROM [Shift After Scheduling] WHERE [EmployeeID]="+ empTake + " ORDER BY [ID] DESC) A ORDER BY A.[ID] ASC)";
            command3 = "UPDATE [Shift After Scheduling] SET [Content]='" + newASK + "' WHERE [ID]=(SELECT TOP 1  A.[ID] FROM (SELECT TOP (2) * FROM [Shift After Scheduling] WHERE [EmployeeID]=" + empAsk + " ORDER BY [ID] DESC) A ORDER BY A.[ID] ASC)";
        }
        else
        {
            String newASK = "";
            String newTake = "";
            String[] takeContent = listTake[0].Split(',');
            String[] askContent = listAsk[0].Split(',');
            foreach (String letter in takeContent)
            {
                if (newTake != "") newTake += "," + letter;
                else newTake = letter;
            }
            if (newTake != "") newTake += "," + shift;
            else newTake = Convert.ToString(shift);
            foreach (String letter in askContent)
            {
                if (Convert.ToInt32(letter) != shift)
                {
                    if (newASK != "") newASK += "," + letter;
                    else newASK = letter;
                }

            }
            command2 = "UPDATE [Shift After Scheduling] SET [Content]='" + newTake + "' WHERE [ID]=(SELECT TOP 1  A.[ID] FROM (SELECT TOP (2) * FROM [Shift After Scheduling] WHERE [EmployeeID]=" + empTake + " ORDER BY [ID] DESC) A ORDER BY A.[ID] DESC)";
            command3 = "UPDATE [Shift After Scheduling] SET [Content]='" + newASK + "' WHERE [ID]=(SELECT TOP 1  A.[ID] FROM (SELECT TOP (2) * FROM [Shift After Scheduling] WHERE [EmployeeID]=" + empAsk + " ORDER BY [ID] DESC) A ORDER BY A.[ID] DESC)";
        }
        String sqlComm= command + "; " + command2 + "; " + command3;
        return sqlComm;
    }
}