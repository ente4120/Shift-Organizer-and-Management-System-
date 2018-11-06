using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Net;


public partial class KnowledgeM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["userID"] != null)
        {
            initiatebuttenGuide();
            initiatebuttenProducts();

        }
        else
        {
            Response.Redirect("login.aspx");
        }


    }

    protected void initiatebuttenGuide()
    {
        List<Button> buttons = new List<Button>();
        Guide guide = new Guide();
        List<Guide> Glist = guide.getSGUide();
        int i = 0;
        foreach (Guide item in Glist)
        {
            i++;
            HtmlGenericControl divph = new HtmlGenericControl("div");
            divph.Attributes["class"] = "col-lg-4";
            divph.InnerHtml = "<div class='card'><div class='cardHead'><img class='card-img-top' src='img/" + item.GuWriter + ".jpg' alt='Card image cap'><div class='centeredCard'></div></div><div class='card-body'><h5 class='card-title'>" + item.GuWriter + "</h5><p class='card-text'>"+item.GuDiscription+ "</p><a class='btn btn-primary' id='"+item.GuPath+"' href='#' onclick='openFunction(this)'>פתיחה</a></div></div>";
            phCatalogs.Controls.Add(divph);
        }
    }
    protected void initiatebuttenProducts()
    {
        List<Button> buttons = new List<Button>();
        Product Product = new Product();
        List<Product> Plist = Product.getProducts();
        int i = 0;
        foreach (Product item in Plist)
        {
            i++;
            HtmlGenericControl divph = new HtmlGenericControl("div");
            divph.Attributes["class"] = "col-lg-3";
            divph.InnerHtml = "<div class='card'><div class='cardHead'><img class='card-img-top' src='" + item.ProdImgUrl + "' alt='Card image cap'><div class='centeredCard'></div></div><div class='card-body'><h5>" + item.ProdName + "</h5><h6 class='card-title'>" + item.ProdDiscription + "</h6><p class='card-text'>" + item.ProdCategory + "</p></div></div>";
            PhProduct.Controls.Add(divph);
        }
    }
    protected void SearchProduct(object sender, EventArgs e)

    {
        PhProduct.Controls.Clear();
        List<Button> buttons = new List<Button>();
        Product Product = new Product();
        List<Product> Plist = Product.getProducts();
        int i = 0;
        
        foreach (Product item in Plist)
        {
            if (item.ProdName.Contains(searchText.Value)|| item.ProdBrand.Contains(searchText.Value)|| item.ProdCategory.Contains(searchText.Value)) { 
                i++;
                HtmlGenericControl divph = new HtmlGenericControl("div");
                divph.Attributes["class"] = "col-lg-3";
                divph.InnerHtml = "<div class='card'><div class='cardHead'><img class='card-img-top' src='" + item.ProdImgUrl + "' alt='Card image cap'><div class='centeredCard'></div></div><div class='card-body'><h5>" + item.ProdName + "</h5><h6 class='card-title'>" + item.ProdDiscription + "</h6><p class='card-text'>" + item.ProdCategory + "</p></div></div>";
                PhProduct.Controls.Add(divph);
            }
        }
    }


}

