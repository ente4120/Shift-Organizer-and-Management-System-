<%@ Page Title="" Language="C#" MasterPageFile="~/MayaUserMasterPage.master" AutoEventWireup="true" CodeFile="MessegU.aspx.cs" Inherits="MessegU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <h2>הודעות</h2>
   
            <div class="col-lg-12">
                <ul class="list-group " id="titles" runat="server">
                </ul>
            </div>
            <p>
            </p>
        <div id="messageBody" runat="server"></div>
</asp:Content>

