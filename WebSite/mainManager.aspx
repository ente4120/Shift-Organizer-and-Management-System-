<%@ Page Title="" Language="C#" MasterPageFile="~/MayaManagerMasterPage.master" AutoEventWireup="true" CodeFile="mainManager.aspx.cs" Inherits="mainManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="row" id="containDIV">
     <div class="col-lg-9" id="calDIV">
         <div id="calDIVson">
             <div id='calendar'></div>
         </div>
     </div>
     <div class="col-lg-2" id="calDas">

         <div class="card divBOX1">
              <div class="card-header">
                <h5>העברות יוצאות</h5>
              </div>
              <ul class="list-group list-group-flush">
  
                <li class="list-group-item"><div id="IDcountint" runat="server"></div></li>
              </ul>
        </div>
         <div class="card divBOX2">
              <div class="card-header">
                <h5>העברות נכנסות</h5>
              </div>
              <ul class="list-group list-group-flush">
                <li class="list-group-item"><div id="IDcountout" runat="server"></div></li>
              </ul>
        </div>
     </div>
 </div>
</asp:Content>

