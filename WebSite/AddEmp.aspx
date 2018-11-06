<%@ Page Title="" Language="C#" MasterPageFile="~/MayaManagerMasterPage.master" AutoEventWireup="true" CodeFile="AddEmp.aspx.cs" Inherits="AddEmp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <h2>משתמשים</h2>
      <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#exampleModal" style="background-color:#6c757d; border-color:#343a40">הוסף עובד</button>
     <asp:GridView class="table" ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" DataKeyNames="ID" style="text-align:center; margin-top:10px;">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="ID" HeaderText="מספר רשומה" SortExpression="ID" InsertVisible="False" ReadOnly="True" />
            <asp:BoundField DataField="FirstName" HeaderText="שם" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="שם משפחה" SortExpression="LastName" />
            <asp:BoundField DataField="UserName" HeaderText="יוזר" SortExpression="UserName" />
            <asp:BoundField DataField="Password" HeaderText="סיסמא" SortExpression="Password" />
            <asp:BoundField DataField="Type" HeaderText="סוג עובד" SortExpression="Type" />
            <asp:BoundField DataField="Branch" HeaderText="סניף" SortExpression="Branch" />
            <asp:CheckBoxField DataField="Active" HeaderText="פעיל" SortExpression="Active" />
            <asp:BoundField DataField="Minimum" HeaderText="מינימום משמרות" SortExpression="Minimum" />
        </Columns>
         <FooterStyle BackColor="White" ForeColor="#333333" />
         <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="White" ForeColor="#333333" />
         <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
         <SortedAscendingCellStyle BackColor="#F7F7F7" />
         <SortedAscendingHeaderStyle BackColor="#487575" />
         <SortedDescendingCellStyle BackColor="#E5E5E5" />
         <SortedDescendingHeaderStyle BackColor="#275353" />
    </asp:GridView>
   
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
                        <h5 class="modal-title" id="exampleModalLabel">הוספת משתמש</h5>
                    </div>
                    <div class="modal-body">
                        <form>
                            <div class="form-group">
                                <table>
                                    
                                      <tr>
                                        <td>
                                            <label for="exampleFormControlInput1">שם פרטי</label>
                                        </td>
                                        <td>
                                            <input type="text" class="form-control" id="NameInput" placeholder="הזן שם פרטי" style="width: 50%; margin: 0; display: inline-block;" runat="server">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="exampleFormControlInput1">שם משפחה</label>
                                        </td>
                                        <td>
                                            <input type="text" class="form-control" id="LnameInput" placeholder="הזן שם משפחה" style="width: 50%; margin: 0; display: inline-block;" runat="server">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="exampleFormControlInput1">יוזר</label>
                                        </td>
                                        <td>
                                            <input type="text" class="form-control" id="UserName" placeholder="הזן שם משתמש" style="width: 50%; margin: 0; display: inline-block;" runat="server">
                                        </td>
                                    </tr>
                                          <tr>
                                        <td>
                                            <label for="exampleFormControlInput1">סיסמא</label>
                                        </td>
                                        <td>
                                            <input type="text" class="form-control" id="PasswordI" placeholder="הזן סיסמא" style="width: 50%; margin: 0; display: inline-block;" runat="server">
                                        </td>
                                    </tr>
                                          <tr>
                                        <td>
                                            <label for="exampleFormControlInput1">סוג</label>
                                        </td>
                                        <td>
                                            <input type="text" class="form-control" id="TypeInput" placeholder="הזן סוג עובד" style="width: 50%; margin: 0; display: inline-block;" runat="server">
                                        </td>
                                    </tr>
                                          <tr>
                                        <td>
                                            <label for="exampleFormControlInput1">מינימום משמרות</label>
                                        </td>
                                        <td>
                                            <input type="text" class="form-control" id="MinInput" placeholder="הזן את מספר המשמרות המינימלי" style="width: 50%; margin: 0; display: inline-block;" runat="server">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="exampleFormControlSelect1">בחר סניף</label>

                                        </td>
                                        <td>
                                            <asp:DropDownList ID="BDDL" runat="server" AutoPostBack="True" DataSourceID="messegSql" DataTextField="Name" DataValueField="ID" CssClass="custom-select" style="width: 100%; margin: 0; display: inline-block;"></asp:DropDownList>

                                        </td>
                                    </tr>
                                 
                                </table>
                            </div>
                        </form>
                        <div class="modal-footer">
                                            
                            <%--  <button type="button" class="btn btn-primary">שמירה</button>--%>
                            <asp:Button ID="SButton" class="btn btn-primary" runat="server" Text="שמור" OnClick="SaveaddEmpl" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">סגור</button>
                        </div>
                     
                </div>
        </div>
                </div>
    <asp:SqlDataSource ID="messegSql" runat="server" ConnectionString="<%$ ConnectionStrings:rikosheTDBConnectionString %>" SelectCommand="SELECT [Name],[ID] FROM [Branch]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:rikosheTDBConnectionString %>" SelectCommand="SELECT * FROM [Employee]" DeleteCommand="DELETE FROM [Employee] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Employee] ([FirstName], [LastName], [UserName], [Password], [Type], [Branch], [Active], [Minimum]) VALUES (@FirstName, @LastName, @UserName, @Password, @Type, @Branch, @Active, @Minimum)" UpdateCommand="UPDATE [Employee] SET [FirstName] = @FirstName, [LastName] = @LastName, [UserName] = @UserName, [Password] = @Password, [Type] = @Type, [Branch] = @Branch, [Active] = @Active, [Minimum] = @Minimum WHERE [ID] = @ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="FirstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="UserName" Type="Int32" />
            <asp:Parameter Name="Password" Type="String" />
            <asp:Parameter Name="Type" Type="Int32" />
            <asp:Parameter Name="Branch" Type="Int32" />
            <asp:Parameter Name="Active" Type="Boolean" />
            <asp:Parameter Name="Minimum" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="FirstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="UserName" Type="Int32" />
            <asp:Parameter Name="Password" Type="String" />
            <asp:Parameter Name="Type" Type="Int32" />
            <asp:Parameter Name="Branch" Type="Int32" />
            <asp:Parameter Name="Active" Type="Boolean" />
            <asp:Parameter Name="Minimum" Type="Int32" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
            </asp:SqlDataSource>
   
                          
                        
                        
   
             </div>
</asp:Content>


