<%@ Page Title="" Language="C#" MasterPageFile="~/MayaManagerMasterPage.master" AutoEventWireup="true" CodeFile="Shifts.aspx.cs" Inherits="sample" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:PlaceHolder ID="PlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-10">
            <a class="btn btn-lg" href="ShiftEmployee.aspx" style="height:40px; width:160px; margin-bottom:5px;background-color:#ADFF2F; color:black;">הגשת משמרת <img src="img/add_shift.png" style="height:25px;"/></a>
            <a class="btn btn-lg" href="ShiftEditing.aspx" style="height:40px; width:160px; margin-bottom:5px;background-color:#ADFF2F; color:black;">יצירת משמרת <img src="img/create_sc.png" style="height:20px;"/></a>
            <a class="btn btn-lg" style="height:40px; width:160px; margin-bottom:5px;background-color:#ADFF2F; color:black;"  data-toggle="modal" data-target="#Modal1">החלפת משמרות <img src="img/change.png" style="height:20px;"/></a>
            <a class="btn btn-lg" href="ShiftManeger.aspx" style="height:40px; width:120px; margin-bottom:5px;background-color:#ADFF2F; color:black;">הגדרות <img src="img/setting.png" style="height:20px;"/></a>
        </div>
    </div>
<div id='wrap' class="col-lg-12">
    <div id='calendar'></div>
</div>

<%-- modal --%>
<div class="modal fade" id="Modal1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">החלפת משמרות</h5>
      </div>
      <div class="modal-body">
          <h5>משמרות שלי</h5>
            <table>                       
                 <tr>
                    <td style="width: 10%;">
                        <label for="exampleFormControlInput1">בחר</label>
                    </td>
                    <td style="width:270px;">
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="custom-select" style="width: 250px; margin: 0; display: inline-block;"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnLogin" class="btn btn-success" AutoPostBack="False" text="הגש בקשה" runat="server" OnClick="InsertChange"/>
                    </td>
                </tr>
          </table>
          <h5>משמרות להחלפה</h5>
            <table>                       
                 <tr>
                    <td style="width: 10%;">
                        <label for="exampleFormControlInput2">בחר</label>
                    </td>
                    <td style="width:270px;">
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="custom-select" style="width: 250px; margin: 0; display: inline-block;"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="Button1" class="btn btn-warning" AutoPostBack="False" text="בקש משמרת" runat="server" OnClick="updateSwitch"/>
                    </td>
                </tr>
          </table>
          <h5>משמרות לאישור</h5>
            <table>                       
                 <tr>
                    <td style="width: 10%;">
                        <label for="exampleFormControlInput2">בחר</label>
                    </td>
                    <td style="width:270px;">
                        <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="False" CssClass="custom-select" style="width: 250px; margin: 0; display: inline-block;"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="Button2" class="btn btn-info" text="אשר משמרת" runat="server" OnClick="ApproveSwitch"/>
                    </td>
                </tr>
          </table>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal" >סגירה</button>
      </div>
    </div>
  </div>
</div>
    </asp:PlaceHolder>
</asp:Content>

