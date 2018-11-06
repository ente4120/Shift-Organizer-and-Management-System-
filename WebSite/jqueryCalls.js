ProductInfo = new Object();
CatlogInfo = new Object();

//   <!------דף מוצרים - 2.1------>

$(document).on('pagebeforeshow', '#product', function () {
    getProduct(renderProducts);
});

function renderProducts(results) {
    results = $.parseJSON(results.d);
    $.each(results, function (i, row) {
        if (row.ProdImgUrl === null)
        { imageFullPath = "images/no-img.jpg"; }
        else
        { imageFullPath = row.ProdImgUrl; }
        dynamicLi = '<li> <a href="#productDetails" data-id="' + row.ProdID + '"><img style = "width:65px"  src="' + imageFullPath + '"/><h3>' + row.ProdName + '</h3><p>מותג: ' + row.ProdBrand + '</p><p> קטגוריה: ' + row.ProdCategory + '</p></a></li>';
        $('#product-list').append(dynamicLi);
        $('#product-list').listview('refresh');
    });
}


$(document).on('vclick', '#product-list li a', function () {
    ProductInfo.id = $(this).attr('data-id');
    $.mobile.changePage("#productDetails", { transition: "slide", changeHash: false });
});

//   <!------דף מידע מוצר - 2.1.2------>

$(document).on('pagebeforeshow', '#productDetails', function () {
    $('#prodName').text('');
    $("#prodImgUrl").text('');
    $('#prodBrand').text('');
    $('#prodCategory').text('');
    $('#prodPrice').text('');
    $('#prodDiscription').text('');
    getProductInfo(ProductInfo, renderFullProduct);
});

function renderFullProduct(results) {
    results = $.parseJSON(results.d);
    $('#prodName').append(results.ProdName);
    $("#prodImgUrl").attr('src', results.ProdImgUrl);
    $('#prodBrand').append('מותג:' + results.ProdBrand);
    $('#prodPrice').append('מחיר:' + results.ProdPrice);
    $('#prodDiscription').append('תיאור:' + results.ProdDiscription);
}

//   <!------דף הודעות - 3------>

$(document).on('pagebeforeshow', '#message', function () {
    getMessage(renderMessage);
});

function renderMessage(results) {
    $('#Message-list').empty();
    results = $.parseJSON(results.d);
    $.each(results, function (i, row) {
        $('#Message-list').append('<div data-role="collapsible"><h3> ' + row.MsTitle + '     -      ' + row.MsWriter + '</h3 ><p>תאריך:' + row.MsDate + '</br>סניף: ' + row.MsBranch + ' </br>' + row.MsContent + '</p></div>');
    });
    $('#Message-list').collapsibleset().trigger('create');
}

//   <!------דף העברות - 5------>

$(document).on('pagebeforeshow', '#transfer', function () {
    getTransfer(renderTransfer);
});

function renderTransfer(results) {
    $('#transferTable').empty();
    results = $.parseJSON(results.d);
    $.each(results, function (i, row) {
        $('#transferTable').append('<tr><td>' + row.TraId + '</td><td>' + row.TraDate + '</td><td>' + row.TraProd + '</td><td>' + row.TraFrom + '</td><td>' + row.TraTo + '</td><td>' + row.TraAmount + '</td><td>' + row.TraWriter + '</tr>');
    });
    $('#transferTable').trigger("create");
    $('#transferTable').table("refresh");


}


//   <!------דף קטלוגים - 2.2------>
$(document).on('pagebeforeshow', '#catalog', function () {
    getGuide(renderGuide);
});

function renderGuide(results) {
    $('#catalog-list').empty();
    results = $.parseJSON(results.d);
    $.each(results, function (i, row) {
        dynamicLi = '<li> <a href="#catalogDetails" data-id="' + row.GuId + '"><h3>' + row.GuName + '</h3><p> ' + row.GuWriter + '</p><p> ' + row.GuDiscription + '</p></a></li>';
        $('#catalog-list').append(dynamicLi);
        $('#catalog-list').listview('refresh');
    });
}

$(document).on('vclick', '#catalog-list li a', function () {
    ProductInfo.id = $(this).attr('data-id');
    $.mobile.changePage("#catalogDetails", { transition: "slide", changeHash: false });
});


//   <!------דף קטלוגים - 2.2.2------>


$(document).on('pagebeforeshow', '#catalogDetails', function () {
    $('#prodName').text('');
    getCatlogInfo(CatlogInfo, renderFullGuide);
});

function renderFullGuide(results) {
    results = $.parseJSON(results.d);
    dynamicLi = '<object width="400" height="500" type="application/pdf" data="' + results.GuPath + '?#zoom=85&scrollbar=0&toolbar=0&navpanes=0" id="pdf_content"><p>אין קובץ</p></object>';
    $('#catName').append(results.GuName);
    $('#catPdf').append(dynamicLi);

}

//<!------התחברות למערכת - 5------>

function renderLoginUser(results) {
    results = results.d;
    if (results != "0") {
        arr = results.split('|');
        userFullName = arr[0] + " " + arr[1];
        userID = arr[2];
        userTYPE = arr[3];
        document.cookie = "userFullName:" + userFullName + ";";
        document.cookie = "userID:" + userID + ";";
        document.cookie = "userTYPE:" + userTYPE + ";";      
        $.mobile.navigate("#index");

    }
}

//<!------החלפת משמרות - 6------>

function rendershiftsUser(results) {
    results = results.d;
    arr = results.split('/');
    arrN = arr[0].split(',');
    arrW = arr[1].split(',');
    var select = document.getElementById("myShiftsDDL");
    for (var i = 0; i < arrN.length; i++) {
        var option = document.createElement('option');
        if (arrN[i] == "11") { option.text = option.value = "ראשון בוקר (שבוע הבא)"; option.value = arrN[i] + "n"; }
        else if (arrN[i] == "12") { option.text = "ראשון אמצע (שבוע הבא)"; option.value = arrN[i] + "n"; }
        else if (arrN[i] == "13") { option.text = "ראשון ערב (שבוע הבא)"; option.value = arrN[i] + "n"; }
        else if (arrN[i] == "21") { option.text = "שני בוקר (שבוע הבא)"; option.value = arrN[i] + "n"; }
        else if (arrN[i] == "22") { option.text = "שני אמצע (שבוע הבא)"; option.value = arrN[i] + "n"; }
        else if (arrN[i] == "23") { option.text = "שני ערב (שבוע הבא)"; option.value = arrN[i] + "n"; }
        else if (arrN[i] == "31") { option.text = "שלישי בוקר (שבוע הבא)"; option.value = arrN[i] + "n"; }
        else if (arrN[i] == "32") { option.text = "שלישי אמצע (שבוע הבא)"; option.value = arrN[i] + "n"; }
        else if (arrN[i] == "33") { option.text = "שלישי ערב (שבוע הבא)"; option.value = arrN[i] + "n"; }
        else if (arrN[i] == "41") { option.text = "רביעי בוקר (שבוע הבא)"; option.value = arrN[i] + "n"; }
        else if (arrN[i] == "42") { option.text = "רביעי אמצע (שבוע הבא)"; option.value = arrN[i] + "n"; }
        else if (arrN[i] == "43") { option.text = "רביעי ערב (שבוע הבא)"; option.value = arrN[i] + "n"; }
        else if (arrN[i] == "51") { option.text = "חמישי בוקר (שבוע הבא)"; option.value = arrN[i] + "n"; }
        else if (arrN[i] == "52") { option.text = "חמישי אמצע (שבוע הבא)"; option.value = arrN[i] + "n"; }
        else if (arrN[i] == "53") { option.text = "חמישי ערב (שבוע הבא)"; option.value = arrN[i] + "n"; }
        else if (arrN[i] == "61") { option.text = "שישי בוקר (שבוע הבא)"; option.value = arrN[i] + "n"; }
        else if (arrN[i] == "62") { option.text = "שישי אמצע (שבוע הבא)"; option.value = arrN[i] + "n"; }
        else if (arrN[i] == "63") { option.text = "שישי ערב (שבוע הבא)"; option.value = arrN[i] + "n"; }
        else if (arrN[i] == "71") { option.text = "שבת בוקר (שבוע הבא)"; option.value = arrN[i] + "n"; }
        else if (arrN[i] == "72") { option.text = "שבת אמצע (שבוע הבא)"; option.value = arrN[i] + "n"; }
        else if (arrN[i] == "73") { option.text = "שבת ערב (שבוע הבא)"; option.value = arrN[i] + "n"; }
        select.add(option, 0);
    }
    for (var i = 0; i < arrN.length; i++) {
        var option = document.createElement('option');
        if (arrN[i] == "11") { option.text = "ראשון בוקר (השבוע)"; option.value = arrN[i] + "w"; }
        else if (arrN[i] == "12") { option.text = "ראשון אמצע (השבוע)"; option.value = arrN[i] + "w"; }
        else if (arrN[i] == "13") { option.text = "ראשון ערב (השבוע)"; option.value = arrN[i] + "w"; }
        else if (arrN[i] == "21") { option.text = "שני בוקר (השבוע)"; option.value = arrN[i] + "w"; }
        else if (arrN[i] == "22") { option.text = "שני אמצע (השבוע)"; option.value = arrN[i] + "w"; }
        else if (arrN[i] == "23") { option.text = "שני ערב (השבוע)"; option.value = arrN[i] + "w"; }
        else if (arrN[i] == "31") { option.text = "שלישי בוקר (השבוע)"; option.value = arrN[i] + "w"; }
        else if (arrN[i] == "32") { option.text = "שלישי אמצע (השבוע)"; option.value = arrN[i] + "w"; }
        else if (arrN[i] == "33") { option.text = "שלישי ערב (השבוע)"; option.value = arrN[i] + "w"; }
        else if (arrN[i] == "41") { option.text = "רביעי בוקר (השבוע)"; option.value = arrN[i] + "w"; }
        else if (arrN[i] == "42") { option.text = "רביעי אמצע (השבוע)"; option.value = arrN[i] + "w"; }
        else if (arrN[i] == "43") { option.text = "רביעי ערב (השבוע)"; option.value = arrN[i] + "w"; }
        else if (arrN[i] == "51") { option.text = "חמישי בוקר (השבוע)"; option.value = arrN[i] + "w"; }
        else if (arrN[i] == "52") { option.text = "חמישי אמצע (השבוע)"; option.value = arrN[i] + "w"; }
        else if (arrN[i] == "53") { option.text = "חמישי ערב (השבוע)"; option.value = arrN[i] + "w"; }
        else if (arrN[i] == "61") { option.text = "שישי בוקר (השבוע)"; option.value = arrN[i] + "w"; }
        else if (arrN[i] == "62") { option.text = "שישי אמצע (השבוע)"; option.value = arrN[i] + "w"; }
        else if (arrN[i] == "63") { option.text = "שישי ערב (השבוע)"; option.value = arrN[i] + "w"; }
        else if (arrN[i] == "71") { option.text = "שבת בוקר (השבוע)"; option.value = arrN[i] + "w"; }
        else if (arrN[i] == "72") { option.text = "שבת אמצע (השבוע)"; option.value = arrN[i] + "w"; }
        else if (arrN[i] == "73") { option.text = "שבת ערב (השבוע)"; option.value = arrN[i] + "w"; }
        select.add(option, 0);
    } 
}

function rendershiftsUsers(results) {
    results = results.d;
    arr = results.split(',');
    var select = document.getElementById("otherShiftsDDL");
    var select2 = document.getElementById("shiftToConfig");
    for (var i = 0; i < arr.length; i++) {
        arrInfo = arr[i].split('|');
        whenTemp = arrInfo[2];
        when = "";
        if (whenTemp == "w") when = " (השבוע)";
        else when = " (שבוע הבא)";
        var option = document.createElement('option');
        if (arrInfo[0] == "11") { option.text = option.value = "ראשון בוקר " + arrInfo[1] + when, option.value =  "11" + whenTemp; }
        else if (arrInfo[0] == "12") { option.text = "ראשון אמצע " + arrInfo[1] + when, option.value =  "12" + whenTemp; }
        else if (arrInfo[0] == "13") { option.text = "ראשון ערב " + arrInfo[1] + when, option.value =  "13" + whenTemp; }
        else if (arrInfo[0] == "21") { option.text = "שני בוקר " + arrInfo[1] + when, option.value =  "21" + whenTemp; }
        else if (arrInfo[0] == "22") { option.text = "שני אמצע " + arrInfo[1] + when, option.value =  "22" + whenTemp; }
        else if (arrInfo[0] == "23") { option.text = "שני ערב " + arrInfo[1] + when, option.value =  "22" + whenTemp; }
        else if (arrInfo[0] == "31") { option.text = "שלישי בוקר " + arrInfo[1] + when, option.value =  "32" + whenTemp; }
        else if (arrInfo[0] == "32") { option.text = "שלישי אמצע " + arrInfo[1] + when, option.value =  "32" + whenTemp; }
        else if (arrInfo[0] == "33") { option.text = "שלישי ערב " + arrInfo[1] + when, option.value =  "32" + whenTemp; }
        else if (arrInfo[0] == "41") { option.text = "רביעי בוקר " + arrInfo[1] + when, option.value =  "42" + whenTemp; }
        else if (arrInfo[0] == "42") { option.text = "רביעי אמצע " + arrInfo[1] + when, option.value =  "42" + whenTemp; }
        else if (arrInfo[0] == "43") { option.text = "רביעי ערב " + arrInfo[1] + when, option.value =  "42" + whenTemp; }
        else if (arrInfo[0] == "51") { option.text = "חמישי בוקר " + arrInfo[1] + when, option.value =  "51" + whenTemp; }
        else if (arrInfo[0] == "52") { option.text = "חמישי אמצע " + arrInfo[1] + when, option.value =  "52" + whenTemp; }
        else if (arrInfo[0] == "53") { option.text = "חמישי ערב " + arrInfo[1] + when, option.value =  "53" + whenTemp; }
        else if (arrInfo[0] == "61") { option.text = "שישי בוקר " + arrInfo[1] + when, option.value =  "61" + whenTemp; }
        else if (arrInfo[0] == "73") { option.text = "צאת שבת " + arrInfo[1] + when, option.value =  "73" + whenTemp; }
        if (arrInfo[3] == "0") select.add(option, 0);
        else select2.add(option, 0);
    }

}
function renderSwitch(results) {
    results = results.d;
    if (results > 0) {
        document.getElementById("myShiftsDDL").innerHTML = "";
        document.getElementById("otherShiftsDDL").innerHTML="";
        document.getElementById("shiftToConfig").innerHTML = "";
        var request = { emp: userID };
        getUserShifts(request, rendershiftsUser, errorshiftsUse);
        getUsersShifts(rendershiftsUsers, errorshiftsUse);
    }
}

$(document).on('pagebeforeshow', '#shiftSwitch', function () {
    var request = { emp: userID };
    getUserShifts(request, rendershiftsUser, errorshiftsUse);
    getUsersShifts(rendershiftsUsers, errorshiftsUse);
});

function renderSetting(results) {
    //results = $.parseJSON(results.d);
    var temp1 = results.d.split(',');
    for (var i = 1; i < 8; i++) {
        for (var y = 1; y < 4; y++) {
            var temp2 = i * 10 + y;
            var check = temp1.indexOf(temp2.toString());
            if (check < 0)
                document.getElementById(temp2.toString()).style.display = "none";
        }
    }
}