function ss() {
    this.ajax = function (url, parm, sucsessFunction, errorFunction, completeFunction) {
        $.ajax({
            url: url,
            data: parm,
            async: false,
            datatype: "json",
            type: "POST",
            success: sucsessFunction,
            error: errorFunction,
            complete: completeFunction
        });
    };
    this.selectListBasedOnPropName = function (list, propName) {
        var nameList = [];
        console.log(JSON.stringify(list));
        for (var i = 0; i < list.length; i++) {
            if (list[i] != null)
                nameList.push(list[i][propName]);
        }
        console.log(JSON.stringify(nameList));
        return nameList;
    }
    this.selectListBasedOnPropValue = function (list, propName, propValue) {
        var result = [];
        for (var i = 0; i < list.length; i++) {
            if (list[i] != null && list[i][propName] == propValue) {
                result.push(list[i]);
            }
        }
        return result;
    }
    this.toHtml = function (str) {
        return str.replace(/&lt;/g, '<').replace(/&gt;/g, '>').replace(/&amp;/g, '&');
    }
    this.toDateTimeString = function (date) {
        return kendo.toString(kendo.parseDate(date, 'yyyy-MM-dd hh:mm:tt'), 'yyyy-MM-dd hh:mm:tt');
    }
    this.toTimeString = function (date) {
        return kendo.toString(kendo.parseDate(date, 'yyyy-MM-dd hh:mm:tt'), 'hh:mm:tt');
    }
    this.toDateString = function (date) {
        return kendo.toString(kendo.parseDate(date, 'yyyy-MM-dd hh:mm:tt'), 'yyyy-MM-dd');
    }
    this.toDropdown = function (control, readUrl, changeFunction) {
        control.kendoDropDownList({
            change: changeFunction,
            autoBind: true,
            dataTextField: "Name",
            dataValueField: "Id",
            dataSource: {
                transport: {
                    read: {
                        url: window.domainurl + readUrl,
                        dataType: "json",
                        contentType: "application/json",
                        type: "POST"
                    }
                }, requestEnd: function (e) {
                    if (e.type == 'read') {
                        return;
                    }
                }, schema: {
                    model: {
                        id: "Id",
                    }
                }
            }
        });
    }

    this.toAdvanceDropdown = function (control, readUrl, changeFunction, formdata) {
        control.kendoDropDownList({
            change: changeFunction,
            autoBind: true,
            dataTextField: "Name",
            dataValueField: "Id",
            dataSource: {
                transport: {
                    read: {
                        url: window.domainurl + readUrl,
                        data: formdata,
                        dataType: "json",
                        contentType: "application/json",
                        //type: "POST"
                    }
                }, requestEnd: function (e) {
                    if (e.type == 'read') {
                        return;
                    }
                }, schema: {
                    model: {
                        id: "Id",
                    }
                }
            }
        });
    }
    this.toNumeric = function (control, readUrl, selectFunction) {
        control.kendoNumericTextBox();
    }


    //$(document).ajaxStart(function () {
    //    $("#wait").css("display", "block");
    //});

    //$(document).ajaxComplete(function () {
    //    $("#wait").css("display", "none");
    //});
}
window._ss = new ss();
//End File