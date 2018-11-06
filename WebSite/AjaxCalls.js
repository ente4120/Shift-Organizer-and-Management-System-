//   <!------דף מוצרים - 2.1------>
function getProduct(renderProducts) {
    // serialize the object to JSON string
    $.ajax({ // ajax call starts
        url: 'WebService.asmx/getProducts',   // server side web service method
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: function (results) {
            renderProducts(results);
        },                // data.d id the Variable data contains the data we get from serverside
        error: function (request, error) {
            alert('Network error has occurred please try again! - getProduct');
        }
    }); // end of ajax call
}

//   <!------דף מידע מוצר - 2.1.2------>

function getProductInfo(ProductInfo, renderFullProduct) {
    // serialize the object to JSON string
    var dataString = JSON.stringify(ProductInfo);

    $.ajax({ // ajax call starts
        url: 'WebService.asmx/getFullProduct',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: function (results) {
            renderFullProduct(results);
        },                // data.d id the Variable data contains the data we get from serverside
        error: function (request, error) {
            alert('Network error has occurred please try again! - **getFullProduct**');
        }
    }); // end of ajax call
}

//   <!------דף הודעות - 3------>
function getMessage(renderMessage) {
    $.ajax({
        url: 'WebService.asmx/getMessage',
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            renderMessage(results);
        },
        error: function (request, error) {
            alert('Network error has occurred please try again --- cant get message!');
        }
    });
}

//   <!------דף העברות - 5------>
function getTransfer(renderTransfer) {
    $.ajax({
        url: 'WebService.asmx/getTransfer',
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            renderTransfer(results);
        },
        error: function (request, error) {
            alert('Network error has occurred please try again --- cant get transfer!');
        }
    });

    function getShiftSettings(renderShiftSettings) {
        // serialize the object to JSON string
        $.ajax({ // ajax call starts
            url: 'WebService.asmx/getShiftSettings',   // server side web service method
            type: 'POST',                              // can be also GET
            dataType: 'json',                          // expecting JSON datatype from the server
            contentType: 'application/json; charset = utf-8', // sent to the server
            success: function (results) {
                renderShiftSettings(results);
            },                // data.d id the Variable data contains the data we get from serverside
            error: function (request, error) {
                alert('Network error has occurred please try again! - getProduct');
            }
        }); // end of ajax call
    }
}

function getGuide(renderGuide) {
    // serialize the object to JSON string
    $.ajax({ // ajax call starts
        url: 'WebService.asmx/getGuide',   // server side web service method
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: function (results) {
            renderGuide(results);
        },                // data.d id the Variable data contains the data we get from serverside
        error: function (request, error) {
            alert('Network error has occurred please try again! - getGuide');
        }
    }); // end of ajax call
}

//   <!------דף קטלוגים - 2.2.2------>


function getCatlogInfo(CatlogInfo, renderGuide) {
    // serialize the object to JSON string
    var dataString = JSON.stringify(ProductInfo);

    $.ajax({ // ajax call starts
        url: 'WebService.asmx/getFullGuide',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: function (results) {
            renderFullGuide(results);
        },                // data.d id the Variable data contains the data we get from serverside
        error: function (request, error) {
            alert('Network error has occurred please try again! - **getFullProduct**');
        }
    }); // end of ajax call
}


//   <!------דף  הגשת משמרות - 4.1------>

function myAjaxFunc(request, successCB, errorCB) {
    // serialize the object to JSON string
    var dataString = JSON.stringify(request);
    $.ajax({ // ajax call starts             
        url: 'WebService.asmx/insertshift',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successCB,// data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }); // end of ajax call
}


function successCB(resutls) {
    result = $.parseJSON(resutls.d);
    tmpStr = "";
    for (var i = 0; i < result.length; i++) {
        if (resultString == "") {
            resultString = result[i].value;
            $('#divResult').html(resultString);
        }
        else {
            resultString = resultString + "," + result[i].value;
            $('#divResult').html(resultString);
        }
    }

    document.getElementById("divResult").innerHTML = tmpStr;

    // Get the snackbar DIV
    var x = document.getElementById("snackbar");

    // Add the "show" class to DIV
    x.className = "show";

    // After 3 seconds, remove the show class from DIV
    setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);

}

function errorCB(resutls) {
    alert("Cannot Insert to db");
}

function loginUserAJAX(request, renderLoginUser, errorLogin) {
    // serialize the object to JSON string
    var dataString = JSON.stringify(request);
    $.ajax({ // ajax call starts
        url: 'WebService.asmx/loginUser',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: renderLoginUser,            // data.d id the Variable data contains the data we get from serverside
        error: errorLogin    
    }); // end of ajax call
}

    function errorLogin(resutls) {
        alert('שם משתמש או סיסמא לא נכונים');
    }

function getUserShifts(request, rendershiftsUser, errorshiftsUse) {
    // serialize the object to JSON string
    var dataString = JSON.stringify(request);
    $.ajax({ // ajax call starts
        url: 'WebService.asmx/getShiftsAfterEditing',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: rendershiftsUser,            // data.d id the Variable data contains the data we get from serverside
        error: errorshiftsUse
    }); // end of ajax call
}

function getUsersShifts(rendershiftsUsers, errorshiftsUse) {
    $.ajax({ // ajax call starts
        url: 'WebService.asmx/getsChanges',   // server side web service method
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: rendershiftsUsers,            // data.d id the Variable data contains the data we get from serverside
        error: errorshiftsUse
    }); // end of ajax call
}

function loginUserAJAX(request, renderLoginUser, errorLogin) {
    // serialize the object to JSON string
    var dataString = JSON.stringify(request);
    $.ajax({ // ajax call starts
        url: 'WebService.asmx/loginUser',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: renderLoginUser,            // data.d id the Variable data contains the data we get from serverside
        error: errorLogin
    }); // end of ajax call
}

function insertSwitchAJAX(request, renderSwitch, errorInsert) {
    // serialize the object to JSON string
    var dataString = JSON.stringify(request);
    $.ajax({ // ajax call starts
        url: 'WebService.asmx/insertSwitch',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: renderSwitch,            // data.d id the Variable data contains the data we get from serverside
        error: errorInsert
    }); // end of ajax call
}

function UpdateSwitchAJAX(request, renderSwitch, errorInsert) {
    // serialize the object to JSON string
    var dataString = JSON.stringify(request);
    $.ajax({ // ajax call starts
        url: 'WebService.asmx/UpdateSwitch',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: renderSwitch,            // data.d id the Variable data contains the data we get from serverside
        error: errorInsert
    }); // end of ajax call
}

function ApproveSwitchAJAX(request, renderSwitch, errorInsert) {
    // serialize the object to JSON string
    var dataString = JSON.stringify(request);
    $.ajax({ // ajax call starts
        url: 'WebService.asmx/ApproveSwitch',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: renderSwitch,            // data.d id the Variable data contains the data we get from serverside
        error: errorInsert
    }); // end of ajax call
}

function errorshiftsUse(resutls) {
    alert('משמרות לא נטענו');
}

function errorInsert(resutls) {
    alert('הנתונים לא נשמרו');
}

function getShiftSettinghAJAX(request, renderSetting, errorSetting) {
    // serialize the object to JSON string
    //var dataString = JSON.stringify(request);
    $.ajax({ // ajax call starts
        url: 'WebService.asmx/getShiftSetting',   // server side web service method
        //data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: renderSetting,            // data.d id the Variable data contains the data we get from serverside
        error: errorInsert
    }); // end of ajax call
}

function errorSetting(resutls) {
    alert('הגדרות נכשלו');
}