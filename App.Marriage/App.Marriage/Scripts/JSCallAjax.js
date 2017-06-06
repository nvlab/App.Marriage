
function CallContoller(url, Parametrs,Method) {

  
    var param = "";
    if (Parametrs != null) {
        if (Parametrs.length > 0) {
            for (var i = 0; i < Parametrs.length; i++) {
                if (i == 0) {
                    param += "/?" + Parametrs[i][0] + "=" + Parametrs[i][1]
                } else {
                    param += "&" + Parametrs[i][0] + "=" + Parametrs[i][1]
                }

            }
        }
    }

    $.ajax({
        type: 'POST',
        url: url + param,
        async: true,
        dataType: "json",
        success: function (data) {
            Method(data);
        }
       
    }).done(function (data) {
        Method(data);
    });

};



function CallContollerWithResponse(url, Parametrs, Action) {

    var param = "";
    if (Parametrs != null) {
        if (Parametrs.length > 0) {
            for (var i = 0; i < Parametrs.length; i++) {
                if (i == 0) {
                    param += "/?" + Parametrs[i][0] + "=" + Parametrs[i][1]
                } else {
                    param += "&" + Parametrs[i][0] + "=" + Parametrs[i][1]
                }

            }
        }
    }

    $.ajax({
        type: 'POST',
        url: url + param,
        async: true,
        success: function (data) {
            FuntionSucessWorkFlow(Action,data);
        }
    });

};


function CallContollerWithReturnValue(url, Parametrs) {

    var param = "";
    if (Parametrs != null) {
        if (Parametrs.length > 0) {
            for (var i = 0; i < Parametrs.length; i++) {
                if (i == 0) {
                    param += "/?" + Parametrs[i][0] + "=" + Parametrs[i][1]
                } else {
                    param += "&" + Parametrs[i][0] + "=" + Parametrs[i][1]
                }

            }
        }
    }

    $.ajax({
        type: 'POST',
        url: url + param,
        async: false,
        success: function (data) {
            return data;
        }
    });

};

function CallContollerWithReturnScaleValue(url, Parameter,Seq) {
    var Url = url + "/?Id=" + Parameter;
    $.ajax({
        type: 'POST',
        url: Url,
        async: false,
        success: function (data) {
            ChangeData(data, Seq);
        }
    });
};

function getFormattedDate(date) {
    if (date != null) {
        var year = date.getFullYear();
        var month = (1 + date.getMonth()).toString();
        month = month.length > 1 ? month : '0' + month;
        var day = date.getDate().toString();
        day = day.length > 1 ? day : '0' + day;
        return day + "/" + month + "/" + year;
    }
    return null;
};

function open_in_new_tab(url) {
    var win = window.open(url, '_blank');
    win.focus();
};