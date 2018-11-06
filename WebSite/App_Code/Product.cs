using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    int prodID;
    string prodName;
    string prodBrand;
    string prodCategory;
    string prodImgUrl;
    int prodPrice;
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

    public int ProdPrice
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

    public Product(int prodID, string prodName, string prodBrand, string prodCategory, string prodImgUrl, int prodPrice, string prodDiscription)
    {
        ProdID = prodID;
        ProdName = prodName;
        ProdBrand = prodBrand;
        ProdCategory = prodCategory;
        ProdImgUrl = prodImgUrl;
        ProdPrice = prodPrice;
        ProdDiscription = prodDiscription;
    }

    public List<Product> getProducts()
    {
        RikoshetWebService.RikoshetWebService t = new RikoshetWebService.RikoshetWebService();
        List<Product> temps = JsonConvert.DeserializeObject<List<Product>>(t.getProduct());
        return temps;
    }

    //public List<Product> getProducts()
    //{
    //    DBservices dbs = new DBservices();
    //    List<Product> prods = new List<Product>();
    //    prods = dbs.getProds("rikosheTDBConnectionString", "[ProductR]");
    //    return prods;
    //}

    //public List<Product> getProductsInfo()
    //{
    //    DBservices ds = new DBservices();
    //    DataTable dt = ds.ReadFromDataBase("rikosheTDBConnectionString", "ProductR");
    //    List<Product> ls = new List<Product>();
    //    foreach (DataRow row in dt.Rows)
    //    {
    //        Product temp = new Product(Convert.ToInt32(row["productId"]), Convert.ToString(row["title"]), Convert.ToDouble(row["price"]), Convert.ToString(row["imagePath"]), Convert.ToString(row["prd_cat"]), Convert.ToInt32(row["inventory"]), Convert.ToBoolean(row["status"]));
    //        ls.Add(temp);
    //    }
    //    ProductProxy.ProductWeb webPro = new ProductProxy.ProductWeb();
    //    ProductProxy.Product[] productES = webPro.getProducts();
    //    for (int i = 0; i < productES.Length; i++)
    //    {
    //        Product tempProduct = new Product();
    //        tempProduct.ProductId = productES[i].ProductId;
    //        tempProduct.Title = productES[i].Title;
    //        tempProduct.Status = productES[i].Status;
    //        tempProduct.CategoryName = productES[i].CategoryName;
    //        tempProduct.Inventory = productES[i].Inventory;
    //        tempProduct.ImagePath = productES[i].ImagePath;
    //        tempProduct.Price = productES[i].Price;
    //        ls.Add(tempProduct);
    //    }
    //    return ls;
    //}

}