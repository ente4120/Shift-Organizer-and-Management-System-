<%@ Page Title="" Language="C#" MasterPageFile="~/MayaManagerMasterPage.master" AutoEventWireup="true" CodeFile="ShiftsForManager.aspx.cs" Inherits="sample" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:PlaceHolder ID="PlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-10">
            <a class="btn btn-light btn-lg" href="ShiftEmployee.aspx" style="height:40px; width:200px; margin-bottom:5px;">הגשת משמרת <img src="img/add_shift.png" style="height:25px;"/></a>
            <a class="btn btn-light btn-lg" href="ShiftEmployee.aspx" style="height:40px; width:200px; margin-bottom:5px;">יצירת משמרת <img src="img/add_shift.png" style="height:25px;"/></a>
        </div>
        <div class="col-lg-2">
        <a class="btn btn-light btn-lg" href="ShiftManeger.aspx" style="height:40px; width:120px; margin-bottom:5px;">הגדרות <img src="img/setting.png" style="height:20px;"/></a>
        </div>
    </div>
<div id='wrap' class="col-lg-12">
    <div id='external-events'>
      <h4>רשימת עובדים</h4>
      <div class='fc-event'>My Event 1</div>
      <p>
        <input type='checkbox' id='drop-remove' />
        <label for='drop-remove'>remove after drop</label>
      </p>
</div>
    <div id='calendar'></div>
  </div>
    </asp:PlaceHolder>
</asp:Content>

