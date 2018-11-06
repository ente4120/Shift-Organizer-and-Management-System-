<%@ Page Title="" Language="C#" MasterPageFile="~/MayaManagerMasterPage.master" AutoEventWireup="true" CodeFile="KnowledgeM.aspx.cs" Inherits="KnowledgeM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 

<button class="tablink" onclick="openPage('Contact', this, 'orange')">קטלוגים</button>
<button class="tablink" id="defaultOpen" onclick="openPage('About', this, 'orange')" style="background-color: orange;">מוצרים</button>

<div id="Contact" class="tabcontent">
  <div id="phCatalogs" class="row" runat="server"></div>
</div>

<div id="About" class="tabcontent" style="display: block;">
  
    <div class="row">
        <div class="col-lg-5">
            <nav>
                <form class="form-inline">
                    <input id="searchText" runat="server" class="form-control mr-sm-2" type="search" placeholder="חיפוש" aria-label="Search" >
                </form>
            </nav>
        </div>
        <div class="col-lg-1">
            <asp:button class="btn btn-orangered" runat="server" Text="בצע סינון" OnClick="SearchProduct" />
        </div>
    </div>
     <div id="PhProduct" class="row" runat="server"></div> 
</div>
      
       

   
  


<script>
function openFunction(adress) {
  var win = window.open(adress.id, '_newtab');
  win.focus();
}
</script>
</asp:Content>

