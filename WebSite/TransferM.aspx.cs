using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;


public partial class TransferM : System.Web.UI.Page
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



    //protected void TransferFromDDl_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //string from = TransferFromDDl.SelectedValue;
    //    //string query = "SELECT [title] ,[saleId], [amount], [totalprice], [saleUser], [date], [payment],[prd_cat] ,[productSaleId] FROM Sales2 S inner join productN P on S.productSaleId = P.productId where P.prd_cat= '" + category + "'; ";
    //    //string query = "SELECT T.ID, E.FirstName AS 'Creator',B.Name as 'FROM',b2.Name as 'TO',Date,P.ProductName,TP.Amount  FROM [igroup80_test2].[dbo].[Transfer] T INNER JOIN Branch B ON T.[From]=B.ID INNER JOIN Branch b2 ON T.[To]=b2.ID INNER JOIN Employee E ON T.Creator=E.ID INNER JOIN Transfer_Product TP ON T.ID=TP.TransferID INNER JOIN Product P ON P.ID=TP.ProductID where B.Name= '" + from + "'; ";
    //    transferSql22.SelectCommand = query;
    //    transferGV.DataBind();
    //}

    //protected void TransferFromDDl_SelectedIndexChanged2(object sender, EventArgs e)
    //{
    //    //string to = TransferFromDDl.SelectedValue;
    //    //string query = "SELECT [title] ,[saleId], [amount], [totalprice], [saleUser], [date], [payment],[prd_cat] ,[productSaleId] FROM Sales2 S inner join productN P on S.productSaleId = P.productId where P.prd_cat= '" + category + "'; ";
    //    //string query = "SELECT T.ID, E.FirstName AS 'Creator',B.Name as 'FROM',b2.Name as 'TO',Date,P.ProductName,TP.Amount  FROM [igroup80_test2].[dbo].[Transfer] T INNER JOIN Branch B ON T.[From]=B.ID INNER JOIN Branch b2 ON T.[To]=b2.ID INNER JOIN Employee E ON T.Creator=E.ID INNER JOIN Transfer_Product TP ON T.ID=TP.TransferID INNER JOIN Product P ON P.ID=TP.ProductID where b2.Name= '" + to + "'; ";
    //    transferSql22.SelectCommand = query;
    //    transferGV.DataBind();
    //}
    protected void SaveaTransfer(object sender, EventArgs e)
    {

        Transfer tempM = new Transfer();
        try
        {


            string writer = Convert.ToString(NameIn.Value);
            string amount= Convert.ToString(AmountIn.Value);
            string from= Convert.ToString(FromIn.SelectedValue);
            string to= Convert.ToString(ToIn.SelectedValue);
            string Prod= Convert.ToString(ProdIN.SelectedValue);
            tempM.insertTransfer(writer, amount, from, to, Prod);
        }


        catch (Exception ex)
        {
            Response.Write("There was an error when trying to insert the shift into the database" + ex.Message);
        }
    }

}