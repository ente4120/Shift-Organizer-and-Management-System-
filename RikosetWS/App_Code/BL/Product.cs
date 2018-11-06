using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ProductR
/// </summary>
public class Product
{
    int prodID;
    string prodName;
    string prodBrand;
    string prodCategory;
    string prodImgUrl;
    double prodPrice;
    string prodDiscription;

    public Product()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int ProdID
    {
        get
        {
            return prodID;
        }

        set
        {
            prodID = value;
        }
    }

    public string ProdName
    {
        get
        {
            return prodName;
        }

        set
        {
            prodName = value;
        }
    }

    public string ProdBrand
    {
        get
        {
            return prodBrand;
        }

        set
        {
            prodBrand = value;
        }
    }

    public string ProdCategory
    {
        get
        {
            return prodCategory;
        }

        set
        {
            prodCategory = value;
        }
    }

    public string ProdImgUrl
    {
        get
        {
            return prodImgUrl;
        }

        set
        {
            prodImgUrl = value;
        }
    }

    public double ProdPrice
    {
        get
        {
            return prodPrice;
        }

        set
        {
            prodPrice = value;
        }
    }

    public string ProdDiscription
    {
        get
        {
            return prodDiscription;
        }

        set
        {
            prodDiscription = value;
        }
    }

    public Product(int prodID, string prodName, string prodBrand, string prodCategory, string prodImgUrl, double prodPrice, string prodDiscription)
    {
        ProdID = prodID;
        ProdName = prodName;
        ProdBrand = prodBrand;
        ProdCategory = prodCategory;
        ProdImgUrl = prodImgUrl;
        ProdPrice = prodPrice;
        ProdDiscription = prodDiscription;
    }
    public List<Product> getProductsObjects()
    {
        DBservices dbs = new DBservices();
        List<Product> Product = new List<Product>();
        Product = dbs.getProductsObjects("rikosheTDBConnectionString");
        return Product;
    }
    //public List<Product> getFullProduct()
    //{
    //    DBservices dbs = new DBservices();
    //    List<Product> Product = new List<Product>();
    //    Product = dbs.getFullProduct("rikosheTDBConnectionString","[Product]");
    //    return Product;
    //}
    public Product getFullProduct(string prodID)
    {
        DBservices ds = new DBservices();
        DataTable dt = ds.ReadFromDataBaseByID("rikosheTDBConnectionString", "Product", prodID);
        Product ls = new Product();
        foreach (DataRow row in dt.Rows)
        {
            ls=new Product(Convert.ToInt32(row["ID"]), Convert.ToString(row["ProductName"]), Convert.ToString(row["Brand"]), Convert.ToString(row["Category"]), Convert.ToString(row["ImageURL"]), Convert.ToDouble(row["Price"]), Convert.ToString(row["Discription"]));
        }
        return ls;
    }
}


