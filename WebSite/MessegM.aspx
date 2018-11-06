<%@ Page Title="" Language="C#" MasterPageFile="~/MayaManagerMasterPage.master" AutoEventWireup="true" CodeFile="MessegM.aspx.cs" Inherits="MessegM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>הודעות</h2>
    <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#exampleModal">הודעה חדשה</button>
            <div class="col-lg-12">
                <ul class="list-group " id="titles" runat="server">
                </ul>
            </div>
            <p>
            </p>
        <div id="messageBody" runat="server"></div>
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">הודעה חדשה</h5>
                    </div>
                    <div class="modal-body">
                        <form>
                            <div class="form-group">
                                <table>
                                    <tr>
                                        <td>
                                            <label for="exampleFormControlInput1">נושא ההודעה</label>
                                        </td>
                                        <td>
                                            <input type="text" class="form-control" id="TitleInput" placeholder="הזן כותרת להודעה" style="width: 50%; margin: 0; display: inline-block;" runat="server">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="exampleFormControlInput1">שם מנהל</label>
                                        </td>
                                        <td>
                                            <input type="text" class="form-control" id="NameMID" placeholder="הזן שם מנהל" style="width: 50%; margin: 0; display: inline-block;" runat="server">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="exampleFormControlSelect1">בחר סניף</label>

                                        </td>
                                        <td>
                                            <asp:DropDownList ID="BDDL" runat="server" AutoPostBack="True" DataSourceID="messegSql" DataTextField="Name" DataValueField="Name"></asp:DropDownList>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="exampleFormControlTextarea1">תוכן ההודעה</label>
                                        </td>
                                        <td>
                                            <textarea class="form-control" id="TextM" rows="3" runat="server"></textarea>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </form>
                        <div class="modal-footer">
                            
                            <asp:Button ID="SButton" class="btn btn-primary" runat="server" Text="שמור" OnClick="SaveTheMesseg" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">סגור</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <asp:SqlDataSource ID="messegSql" runat="server" ConnectionString="<%$ ConnectionStrings:rikosheTDBConnectionString %>" SelectCommand="SELECT [Name] FROM [Branch]"></asp:SqlDataSource>
</asp:Content>
