<%@ Page Title="" Language="C#" MasterPageFile="~/MayaManagerMasterPage.master" AutoEventWireup="true" CodeFile="ShiftEditing.aspx.cs" Inherits="ShiftEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>יצירת משמרת</h2>
<script>
    function saveShiftAfterEditing(src, arg) {
        var shifts = "";
        var AllShifts = document.getElementsByClassName("btn btn-light");
        var tempArray;
        var NameArray = [];
        var finalShiftString = "";
        for (i = 0; i < AllShifts.length; i++) {
            if (AllShifts[i].id.length > 10) {
                if (i != 0) shifts += "/";
                var temp = AllShifts[i].id.substring(20);
                shifts += temp;
            }
            else { if (i != 0) shifts += "/" + AllShifts[i].id; else shifts += AllShifts[i].id; }
        }
        tempArray = shifts.split('/');
        //Create Array with employees names
        for (var i = 0; i < tempArray.length; i++) {
            var temp = tempArray[i].split('_');
            var tempEmp = temp[0];
            var a = NameArray.indexOf(tempEmp);
            if (a == '-1')
                NameArray.push(tempEmp);
        }
        for (var i = 0; i < NameArray.length; i++) {
            var temp = NameArray[i].split(',');
            var tempEmp = temp[0];
            if (i != 0) finalShiftString += "/";
            finalShiftString += tempEmp;
            var tempEmployee =""
            for (var j = 0; j < tempArray.length; j++) {
                if (j == 0) finalShiftString += "|";
                var tempShift = tempArray[j].split('_');
                if (tempEmp == tempShift[0]) {
                    if (tempEmployee.length>0) tempEmployee += ",";
                    tempEmployee += tempShift[1];
                }
            }
            finalShiftString += tempEmployee;
        }
            //alert(finalShiftString);
            document.cookie = "ListShiftAfterEditing=" + finalShiftString+";";
    }

    function employeePerfernce(src, arg) {
        var shiftEmp = src.toString();
        var list = shiftEmp.split("0");
        for (var i = 0; i < list.length; i++) {
            if (list[i] == 11) document.getElementById(11).parentElement.style.backgroundColor = "#A9F5BC";
            else if (list[i] == 21) document.getElementById(21).parentElement.style.backgroundColor = "#A9F5BC";
            else if (list[i] == 31) document.getElementById(31).parentElement.style.backgroundColor = "#A9F5BC";
            else if (list[i] == 41) document.getElementById(41).parentElement.style.backgroundColor = "#A9F5BC";
            else if (list[i] == 51) document.getElementById(51).parentElement.style.backgroundColor = "#A9F5BC";
            else if (list[i] == 61) document.getElementById(61).parentElement.style.backgroundColor = "#A9F5BC";
            else if (list[i] == 71) document.getElementById(71).parentElement.style.backgroundColor = "#A9F5BC";
            else if (list[i] == 12) document.getElementById(12).parentElement.style.backgroundColor = "#A9F5BC";
            else if (list[i] == 22) document.getElementById(22).parentElement.style.backgroundColor = "#A9F5BC";
            else if (list[i] == 32) document.getElementById(32).parentElement.style.backgroundColor = "#A9F5BC";
            else if (list[i] == 42) document.getElementById(42).parentElement.style.backgroundColor = "#A9F5BC";
            else if (list[i] == 52) document.getElementById(52).parentElement.style.backgroundColor = "#A9F5BC";
            else if (list[i] == 62) document.getElementById(62).parentElement.style.backgroundColor = "#A9F5BC";
            else if (list[i] == 72) document.getElementById(72).parentElement.style.backgroundColor = "#A9F5BC";
            else if (list[i] == 13) document.getElementById(13).parentElement.style.backgroundColor = "#A9F5BC";
            else if (list[i] == 23) document.getElementById(23).parentElement.style.backgroundColor = "#A9F5BC";
            else if (list[i] == 33) document.getElementById(33).parentElement.style.backgroundColor = "#A9F5BC";
            else if (list[i] == 43) document.getElementById(43).parentElement.style.backgroundColor = "#A9F5BC";
            else if (list[i] == 53) document.getElementById(53).parentElement.style.backgroundColor = "#A9F5BC";
            else if (list[i] == 63) document.getElementById(63).parentElement.style.backgroundColor = "#A9F5BC";
            else if (list[i] == 73) document.getElementById(73).parentElement.style.backgroundColor = "#A9F5BC";
        }
    }

    function clearShiftTable(src, arg) {
        document.getElementById(11).parentElement.style.backgroundColor = "#FFFFFF";
        document.getElementById(21).parentElement.style.backgroundColor = "#FFFFFF";
        document.getElementById(31).parentElement.style.backgroundColor = "#FFFFFF";
        document.getElementById(41).parentElement.style.backgroundColor = "#FFFFFF";
        document.getElementById(51).parentElement.style.backgroundColor = "#FFFFFF";
        document.getElementById(61).parentElement.style.backgroundColor = "#FFFFFF";
        document.getElementById(71).parentElement.style.backgroundColor = "#FFFFFF";
        document.getElementById(12).parentElement.style.backgroundColor = "#FFFFFF";
        document.getElementById(22).parentElement.style.backgroundColor = "#FFFFFF";
        document.getElementById(32).parentElement.style.backgroundColor = "#FFFFFF";
        document.getElementById(42).parentElement.style.backgroundColor = "#FFFFFF";
        document.getElementById(52).parentElement.style.backgroundColor = "#FFFFFF";
        document.getElementById(62).parentElement.style.backgroundColor = "#FFFFFF";
        document.getElementById(72).parentElement.style.backgroundColor = "#FFFFFF";
        document.getElementById(13).parentElement.style.backgroundColor = "#FFFFFF";
        document.getElementById(23).parentElement.style.backgroundColor = "#FFFFFF";
        document.getElementById(33).parentElement.style.backgroundColor = "#FFFFFF";
        document.getElementById(43).parentElement.style.backgroundColor = "#FFFFFF";
        document.getElementById(53).parentElement.style.backgroundColor = "#FFFFFF";
        document.getElementById(63).parentElement.style.backgroundColor = "#FFFFFF";
        document.getElementById(73).parentElement.style.backgroundColor = "#FFFFFF";
    }
</script>
<div class="row"> 
    <div class="col-lg-10">
        <table id="edtntbl" class="table text-center" style="background-color: rgba(255, 255, 255, 0.86);" onmouseout="saveShiftAfterEditing()">
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
            <td><asp:PlaceHolder ID="PlaceHolder11" runat="server"></asp:PlaceHolder><div id="11" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:90px;"></div></td>  
            <td><asp:PlaceHolder ID="PlaceHolder21" runat="server"></asp:PlaceHolder><div id="21" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:50px;"></div></td>
            <td><asp:PlaceHolder ID="PlaceHolder31" runat="server"></asp:PlaceHolder><div id="31" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:50px;"></div></td>
            <td><asp:PlaceHolder ID="PlaceHolder41" runat="server"></asp:PlaceHolder><div id="41" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:50px;"></div></td>
            <td><asp:PlaceHolder ID="PlaceHolder51" runat="server"></asp:PlaceHolder><div id="51" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:50px;"></div></td>
            <td><asp:PlaceHolder ID="PlaceHolder61" runat="server"></asp:PlaceHolder><div id="61" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:50px;"></div></td>
            <td><asp:PlaceHolder ID="PlaceHolder71" runat="server"></asp:PlaceHolder><div id="71" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:50px;"></div></td>
          </tr>
          <tr>
            <th scope="row">אמצע</th> 
            <td><asp:PlaceHolder ID="PlaceHolder12" runat="server"></asp:PlaceHolder><div id="12" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:50px;"></div></td>  
            <td><asp:PlaceHolder ID="PlaceHolder22" runat="server"></asp:PlaceHolder><div id="22" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:50px;"></div></td>
            <td><asp:PlaceHolder ID="PlaceHolder32" runat="server"></asp:PlaceHolder><div id="32" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:50px;"></div></td>
            <td><asp:PlaceHolder ID="PlaceHolder42" runat="server"></asp:PlaceHolder><div id="42" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:50px;"></div></td>
            <td><asp:PlaceHolder ID="PlaceHolder52" runat="server"></asp:PlaceHolder><div id="52" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:50px;"></div></td>
            <td><asp:PlaceHolder ID="PlaceHolder62" runat="server"></asp:PlaceHolder><div id="62" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:50px;"></div></td>
            <td><asp:PlaceHolder ID="PlaceHolder72" runat="server"></asp:PlaceHolder><div id="72" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:50px;"></div></td>
          </tr>
          <tr>
            <th scope="row">ערב</th>
            <td><asp:PlaceHolder id="PlaceHolder13" runat="server"></asp:PlaceHolder><div id="13" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:50px;"></div></td>  
            <td><asp:PlaceHolder id="PlaceHolder23" runat="server"></asp:PlaceHolder><div id="23" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:50px;"></div></td>
            <td><asp:PlaceHolder id="PlaceHolder33" runat="server"></asp:PlaceHolder><div id="33" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:50px;"></div></td>
            <td><asp:PlaceHolder id="PlaceHolder43" runat="server"></asp:PlaceHolder><div id="43" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:50px;"></div></td>
            <td><asp:PlaceHolder id="PlaceHolder53" runat="server"></asp:PlaceHolder><div id="53" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:50px;"></div></td>
            <td><asp:PlaceHolder id="PlaceHolder63" runat="server"></asp:PlaceHolder><div id="63" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:50px;"></div></td>
            <td><asp:PlaceHolder id="PlaceHolder73" runat="server"></asp:PlaceHolder><div id="73" ondrop = "dropcopy(event)" ondragover = "allowDrop(event)" style = "height:50px;"></div></td>
          </tr>
        </table>
    </div>
    <div class="col-lg-2 card">
        <div class="card-body">
            <div class="card-title"><h6>רשימת עובדים</h6></div>
            <asp:PlaceHolder runat="server" ID="EmployeeList"></asp:PlaceHolder>
        </div>
    </div>
</div>
    <asp:Button ID="Button4" class="btn" runat="server" Text="שמירה" style="height:40px;background-color:#ADFF2F; color:black;" OnClick="SaveShift"/>
    <asp:Button ID="Button1" class="btn" runat="server" Text="הפעל אלגוריתם" style="height:40px;background-color:#ADFF2F; color:black;" OnClick="LoadAlgorithm"/>
<%--    <asp:Button ID="Button5" class="btn" runat="server" Text="XML" style="height:40px;background-color:#ADFF2F; color:black;" OnClick="XmlReader"/>--%>
    <asp:Button ID="Button3" class="btn" runat="server" Text="איפוס" style="height:40px;background-color:#ADFF2F; color:black;" OnClick="Clear"/>
    <a ID="Button2" class="btn btn-lg" href="Shifts.aspx"  runat="server" style="height:40px;background-color:#ADFF2F; color:black;">חזרה</a>
<%--    <button ID="A1" class="btn btn-lg"  runat="server" style="height:40px;background-color:#ADFF2F; color:black;" onclick="saveShiftAfterEditing()">שמירה</button>--%>
</asp:Content>

