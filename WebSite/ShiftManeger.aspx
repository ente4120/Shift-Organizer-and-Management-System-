<%@ Page Title="" Language="C#" MasterPageFile="~/MayaManagerMasterPage.master" AutoEventWireup="true" CodeFile="ShiftManeger.aspx.cs" Inherits="ShiftManeger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script>
    window.onload = function ShiftSettings(src, arg) {
        var tempListShift = "<%= Session["ListShift"]%>";
        var tempListPossibles = "<%= Session["ListPossibles"]%>";
        var arrayListShift = tempListShift.split(',');
        var arrayListPossibles = tempListPossibles.split(',');
        arrayListShift[0] = arrayListShift[0].substring(1, 3);
        arrayListShift[arrayListShift.length - 1] = arrayListShift[arrayListShift.length - 1].substring(0, 2);
        arrayListPossibles[0] = arrayListPossibles[0].substring(1, 2);
        arrayListPossibles[arrayListPossibles.length - 1] = arrayListPossibles[arrayListPossibles.length - 1].substring(0, 1);
        for (var i = 0; i < arrayListShift.length; i++) {
            document.getElementById(arrayListShift[i]).getElementsByTagName("option")[arrayListPossibles[i]].selected="selected";
        }
    }

    function saveSettings(src, arg) {
        var saveID = "";
        var saveAmount = "";
        var t = 0;
         //var temp = document.getElementsByTagName("select");
        for (var i = 1; i < 8; i++) {
             for (var y = 1; y < 4; y++) {
                 temp = i * 10 + y;
                 temp2 = document.getElementById(temp);
                if (temp2.options[temp2.selectedIndex].text > 0) {
                    if (t==0) {
                     saveID = temp;
                        saveAmount = temp2.options[temp2.selectedIndex].text;
                        t++;
                    }
                    else {
                        saveID = saveID+ "," + temp;
                        saveAmount = saveAmount + "," + temp2.options[temp2.selectedIndex].text;
                    }
                 }
             }
         }
        document.cookie = "ListShift=" + saveID+";";
        document.cookie = "ListPossibles=" + saveAmount+";";
    }
</script>


     <h2>בקשת משמרות</h2>
   
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
      <td><select class="custom-select" id="11" onmouseout="saveSettings()">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>
    
      <td><select class="custom-select" id="21" onmouseout="saveSettings()">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>
      
      <td><select class="custom-select" id="31" onmouseout="saveSettings()">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>
       
      <td><select class="custom-select" id="41" onmouseout="saveSettings()">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>
      
      <td><select class="custom-select" id="51" onmouseout="saveSettings()">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>
       
      <td><select class="custom-select" id="61" onmouseout="saveSettings()">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>
     
      <td><select class="custom-select" id="71" onmouseout="saveSettings()">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>
  </tr>
  <tr>
   <th scope="row">אמצע</th> 
      <td><select class="custom-select" id="12" onmouseout="saveSettings()">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>
      <td><select class="custom-select" id="22" onmouseout="saveSettings()">
        <option selected value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>
      
      <td><select class="custom-select" id="32" onmouseout="saveSettings()">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>
       
      <td><select class="custom-select" id="42" onmouseout="saveSettings()">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>
      
      <td><select class="custom-select" id="52" onmouseout="saveSettings()">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>
   
      <td><select class="custom-select" id="62" onmouseout="saveSettings()">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>

      <td><select class="custom-select" id="72" onmouseout="saveSettings()">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>
    
  </tr>
  <tr>
    <th scope="row">ערב</th>
      <td><select class="custom-select" id="13" onmouseout="saveSettings()">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>
       
      <td><select class="custom-select" id="23" onmouseout="saveSettings()">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>
       
      <td><select class="custom-select" id="33" onmouseout="saveSettings()">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>
       
      <td><select class="custom-select" id="43" onmouseout="saveSettings()">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>
      
      <td><select class="custom-select" id="53" onmouseout="saveSettings()">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>
       
      <td><select class="custom-select" id="63" onmouseout="saveSettings()">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>

      <td><select class="custom-select" id="73" onmouseout="saveSettings()">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="3">4</option>
        </select></td>
  </tr>
</table>
    <asp:Button ID="Button1" class="btn btn-lg" runat="server" Text="שמור" style="height:40px;background-color:#ADFF2F;" OnClick="SaveTheShift"/>
    <input class="btn btn-lg btn-sm" type="submit" value="אפס" style="height:40px;background-color:#ADFF2F;">
    <a ID="Button2" class="btn btn-lg" href="Shifts.aspx"  runat="server" style="height:40px;background-color:#ADFF2F; color:black;">חזרה</a>
</asp:Content>

