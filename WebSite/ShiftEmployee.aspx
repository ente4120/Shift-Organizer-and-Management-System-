<%@ Page Title="" Language="C#" MasterPageFile="~/MayaManagerMasterPage.master" AutoEventWireup="true" CodeFile="ShiftEmployee.aspx.cs" Inherits="ShiftEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>בקשת משמרות</h2>
<script>
    //Script for loading the shift setting
    window.onload = function ShiftSettings(src, arg) {
        var temp = "<%= Session["ListShift"]%>";
        for (var i = 1; i < 8; i++) {
            for (var y = 1; y < 4; y++) {
                var temp2 = i * 10 + y;
                var btnID = "button" + temp2;
                var check = temp.indexOf(temp2);
                if (check < 0)
                    document.getElementById(temp2).parentElement.style.display = "none";
            }
        }
    }

    function saveSettings(src, arg) {
        var temp = document.getElementsByTagName("button");
        var save="";
        for (var i = 0, len = temp.length; i < len; i++) {
            if (temp[i].className == "btn btn-outline-success a") {
                if (save=="") {
                    save = temp[i].id;
                }
                else {
                    save = save + "," + temp[i].id;
                }
            }
        }
        document.cookie = "userShifts=" + save+";";
    }
</script>

<table class="table text-center" style="background-color: rgba(255, 255, 255, 0.86);">
  <tr>
    <th scope="col"></th>
    <th scope="col">ראשון</th>
    <th scope="col">שני</th>
    <th scope="col">שלישי</th>
    <th scope="col">רביעי</th>
    <th scope="col">חמישי</th>
    <th scope="col">שישי</th>
    <th scope="col">שבת</th>
  </tr>
  <tr>
    <th scope="row">בוקר</th>
    <td><button type="button" id="11" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>  
    <td><button type="button" id="21" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>
    <td><button type="button" id="31" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>
    <td><button type="button" id="41" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>
    <td><button type="button" id="51" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>
    <td><button type="button" id="61" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>
    <td><button type="button" id="71" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>
  </tr>
  <tr>
    <th scope="row">אמצע</th> 
    <td><button type="button" id="12" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>  
    <td><button type="button" id="22" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>
    <td><button type="button" id="32" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>
    <td><button type="button" id="42" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>
    <td><button type="button" id="52" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>
    <td><button type="button" id="62" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>
    <td><button type="button" id="72" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>
  </tr>
  <tr>
    <th scope="row">ערב</th>
    <td><button type="button" id="13" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>  
    <td><button type="button" id="23" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>
    <td><button type="button" id="33" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>
    <td><button type="button" id="43" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>
    <td><button type="button" id="53" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>
    <td><button type="button" id="63" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>
    <td><button type="button" id="73" class="btn btn-outline-danger" onmouseout="saveSettings()">לחץ</button></td>
  </tr>
</table>
    <asp:Button ID="Button1" class="btn btn-lg" runat="server" Text="שמור" style="height:40px;background-color:#ADFF2F;" OnClick="SaveTheShift"/>
    <button class="btn btn-lg" type="submit" value="אפס" style="height:40px;background-color:#ADFF2F;">אפס</button>
    <a ID="Button2" class="btn btn-lg" href="Shifts.aspx"  runat="server" style="height:40px;background-color:#ADFF2F; color:black;">חזרה</a>

</asp:Content>

