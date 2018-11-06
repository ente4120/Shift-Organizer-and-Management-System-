<%@ Page Title="" Language="C#" MasterPageFile="~/MayaManagerMasterPage.master" AutoEventWireup="true" CodeFile="TransferM.aspx.cs" Inherits="TransferM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>העברות בין סניפים</h2>
  <%--  <a class="btn btn-primary" data-toggle="collapse" href="#multiCollapseExample1" role="button" aria-expanded="false" aria-controls="multiCollapseExample1">מסנן</a>--%>
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">העברה חדשה</button>
    <div class="row">
        <div class="col">
            <div class="collapse multi-collapse col-lg-3" id="multiCollapseExample1">
              <%--  <div class="card card-body">
                    <h4>מסניף</h4>
                    <asp:DropDownList ID="TransferFromDDl" runat="server" AutoPostBack="True" DataSourceID="TransferSql" DataTextField="Name" DataValueField="ID" OnSelectedIndexChanged="TransferFromDDl_SelectedIndexChanged"></asp:DropDownList>
                    <h4>אל סניף</h4>
                    <asp:DropDownList ID="TransferToDDl" runat="server" DataSourceID="TransferSql" DataTextField="Name" DataValueField="ID" OnSelectedIndexChanged="TransferFromDDl_SelectedIndexChanged2"></asp:DropDownList>
                 </div>--%>
             </div>
        </div>
    </div>
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">העברה חדשה</h5>
      </div>
      <div class="modal-body">
       <form>
           <table>
               <tr>
                   <td>
                      <label for="exampleFormControlInput1">שם העובד</label>
                   </td>
                   <td>
                      <input type="text" class="form-control" id="NameIn" placeholder="הזן שם עובד" style="width:50%; margin:0; display:inline-block;" runat="server">
                   </td>
               </tr>
                <tr>
                   <td>
                      <label for="exampleFormControlSelect1">מסניף</label>
                   </td>
                   <td>
                      <asp:DropDownList ID="FromIn" type="text" CssClass="custom-select" runat="server" AutoPostBack="False" DataSourceID="TransferSql" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                   </td>
               </tr>
               <tr>
                   <td>
                      <label for="exampleFormControlSelect1">אל סניף</label>
                   </td>
                   <td>
                     <asp:DropDownList ID="ToIn" type="text" CssClass="custom-select" runat="server" AutoPostBack="False" DataSourceID="TransferSql" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                   </td>
               </tr>
               <tr>
                   <td>
                      <label for="exampleFormControlSelect1">מוצר</label>
                   </td>
                   <td>
                    <asp:DropDownList ID="ProdIN" type="text" CssClass="custom-select" runat="server" AutoPostBack="False" DataSourceID="transferSql3" DataTextField="ProductName" DataValueField="ID"></asp:DropDownList>
                   </td>
               </tr>
               <tr>
                   <td>
                       <label for="exampleFormControlInput1">כמות</label>
                   </td>
                   <td>
                     <input type="text" class="form-control" id="AmountIn" placeholder="הזן כמות מוצר" style="width:50%; margin:0; display:inline-block;" runat="server">
                   </td>
               </tr>
           </table>
      
       </form>
      </div>
         
      <div class="modal-footer">
      <asp:Button ID="SButton" class="btn btn-primary" runat="server" Text="שמור" OnClick="SaveaTransfer" />
        <button type="button" class="btn btn-secondary" data-dismiss="modal">סגור</button>     
      </div>
    </div>
  </div>
</div>
    
    <asp:SqlDataSource ID="TransferSql" runat="server" ConnectionString="<%$ ConnectionStrings:rikosheTDBConnectionString %>" SelectCommand="SELECT [Name], [ID] FROM [Branch]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="transferSql3" runat="server" ConnectionString="<%$ ConnectionStrings:rikosheTDBConnectionString %>" SelectCommand="SELECT [ProductName], [ID] FROM [Product]"></asp:SqlDataSource>
    <asp:GridView class="table" ID="transferGV" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" Style="text-align:center; margin-top:10px;" DataSourceID="transferSql22" AllowPaging="True" AllowSorting="True"  CellPadding="4" ForeColor="#333333" GridLines="None" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="מזהה" SortExpression="ID" ReadOnly="True" />
            <asp:BoundField DataField="Name" HeaderText="מסניף" SortExpression="Name" />
<asp:BoundField DataField="Expr1" HeaderText="אל סניף" SortExpression="Expr1"></asp:BoundField>
            <asp:BoundField DataField="Date" HeaderText="תאריך" SortExpression="Date" />
            <asp:BoundField DataField="FirstName" HeaderText="יוצר" SortExpression="FirstName" />
            <asp:CheckBoxField DataField="Active" HeaderText="פעיל" SortExpression="Active" />
            <asp:BoundField DataField="ProductName" HeaderText="שם מוצר" SortExpression="ProductName" />
            <asp:BoundField DataField="Amount" HeaderText="כמות" SortExpression="Amount" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:SqlDataSource ID="transferSql22" runat="server" ConnectionString="<%$ ConnectionStrings:rikosheTDBConnectionString %>" SelectCommand="SELECT * FROM [transfer_view]">
    </asp:SqlDataSource>
</asp:Content>

