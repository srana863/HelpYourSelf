/// <reference path="site.common.js" />


var SS_ServerYear = 'ServerYear';
var SS_ServerDate = 'ServerDate';

function makePagination(tableId) {
    $('#' + tableId).dataTable({
        "paging": true,
        "ordering": true,
        "info": true
    });

    //$('#' + tableId + '_filter').empty().append('<label><input type="search" placeholder="Search" class="form-control" aria-controls="' + tableId + '"></label>');
}


// this function skips the first column in search
function makePaginationWithExport(tableId, column, title, message, orientation, fileName) {
    orientation = null ? "portrait" : orientation;

    $('#' + tableId).dataTable({
        "paging": true,
        "ordering": true,
        "info": true,
        "aoColumnDefs": [{ "bSearchable": false, "aTargets": [0] }],
        "columnDefs": [
        {
            "type": "html",
        }
        ],
        "dom": 'T<"clear">lfrtip',
        "tableTools": {
            "sSwfPath": "/Plugins/madmin/vendors/DataTables/extensions/TableTools/swf/copy_csv_xls_pdf.swf",
            "aButtons": [
                 {
                     "sExtends": "csv",
                     "sTitle": title,
                     "sFileName": fileName + '.csv',
                     "bHeader": true,
                     "mColumns": column,
                 },
                 {
                     "sExtends": "xls",
                     "sTitle": title,
                     "sFileName": fileName + '.xls',
                     "bHeader": true,
                     "mColumns": column,
                 },
                 {
                     "sExtends": "pdf",
                     "sPdfOrientation": orientation,
                     "sTitle": title,
                     "sPdfMessage": message,
                     "sFileName": fileName + '.pdf',
                     "bHeader": true,
                     "mColumns": column,
                 },
                {
                    "sExtends": "print",
                }
            ],
        },

    });

}

// this function skips search for the given columns in searchEscapeColumns
function makePaginationWithExportEscapeSearchForGivenColumns(tableId, column, searchEscapeColumns, title, message, orientation, fileName) {
    orientation = null ? "portrait" : orientation;

    $('#' + tableId).dataTable({
        "paging": true,
        "ordering": true,
        "info": true,
        "aoColumnDefs": [{ "bSearchable": false, "aTargets": searchEscapeColumns }],
        "columnDefs": [
        {
            "type": "html",
        }
        ],
        "dom": 'T<"clear">lfrtip',
        "tableTools": {
            "sSwfPath": "/Plugins/madmin/vendors/DataTables/extensions/TableTools/swf/copy_csv_xls_pdf.swf",
            "aButtons": [
                 {
                     "sExtends": "csv",
                     "sTitle": title,
                     "sFileName": fileName + '.csv',
                     "bHeader": true,
                     "mColumns": column,
                 },
                 {
                     "sExtends": "xls",
                     "sTitle": title,
                     "sFileName": fileName + '.xls',
                     "bHeader": true,
                     "mColumns": column,
                 },
                 {
                     "sExtends": "pdf",
                     "sPdfOrientation": orientation,
                     "sTitle": title,
                     "sPdfMessage": message,
                     "sFileName": fileName + '.pdf',
                     "bHeader": true,
                     "mColumns": column,
                 },
                {
                    "sExtends": "print",
                }
            ],
        },

    });

}

function makePaginationWithExportButton(tableId) {
    $('#' + tableId).dataTable({
        "paging": true,
        "ordering": true,
        "info": true,
        "dom": 'T<"clear">lfrtip',
        "tableTools": {
            "aButtons": [
                "copy",
                "csv",
                "xls",
                {
                    "sExtends": "pdf",
                    "sPdfOrientation": "landscape",
                    "sPdfMessage": "Test"
                },
                "print"
            ]
        }
    });
}

function showNotification(type, message) {
    if (type != '0') {
        if (type == '1' || type == 'success') {
            toastr.success(message);
        } else if (type == '2' || type == 'info') {
            toastr.info(message);
        } else if (type == '3' || type == 'warning') {
            toastr.warning(message);
        }
        else if (type == '-1' || type == 'error') {
            toastr.error(message);
        }
    }
}

function showDialog(type, message) {
    $("#lblMessage").text(message);
    $("#dialog-message").dialog({
        modal: true,
        draggable: false,
        resizeable: false,
        position: ['center', 'middle'],
        //width: 400,
        buttons: {
            "Ok": function () {
                $(this).dialog("close");
            }
        }
    });
    //$(".ui-dialog-titlebar").hide();
}

function showMessage(msgType, msg, lstErrors, url) {

    if (msgType != '0') {
        if (msgType == '1' || msgType == 'success') {
            toastr.success(msg);
        } else if (msgType == '2' || msgType == 'info') {
            toastr.info(msg);
        } else if (msgType == '3' || msgType == 'warning') {
            toastr.warning(msg);
        } else if (msgType == '-1' || msgType == 'error') {
            toastr.error(msg);
        }
    }
}

function hideMsgDivs() {
    $('#ErrorsList').empty();
    $('#SuccessMsgDiv').css('display', 'none');
    $('#ErrorMsgDiv').css('display', 'none');
}

function getFormatedDate(date) {
    var day = date.getDate();
    var month = date.getMonth() + 1;
    var year = date.getFullYear();
    return day + '-' + month + '-' + year;

}

function getFormatedDateWithMonthName(date) {
    var day = date.getDate();
    var month = date.getMonth() + 1;
    var year = date.getFullYear();
    return day + '-' + getMonthNameInShort(month) + '-' + year;

}

function formatJsonDate(jsonDate) {
    var d = new Date(parseInt(jsonDate.slice(6, -2)));
    var date = d.getDate() + '-' + (1 + d.getMonth()) + '-' + d.getFullYear();
    return date;
}

function formatJsonDateToStringDate(jsonDate) {
    if (jsonDate) {
        var d = new Date(parseInt(jsonDate.slice(6, -2)));
        var day = d.getDate().toString();
        if (day.length == 1) {
            day = "0" + day;
        }
        var date = day + '-' + getMonthNameInShort(1 + d.getMonth()) + '-' + d.getFullYear();
        return date;
    }

    return null;

}

function formatJsonMonthYear(jsonDate) {

    if (jsonDate != null) {
        var d = new Date(parseInt(jsonDate.slice(6, -2)));
        var month = getMonthName(1 + d.getMonth());
        var year = d.getFullYear();
        var date = month + ', ' + year;
        return date;
    }
    return null;
}

function getMonthNameInShort(monthNumber) {
    var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
    return months[monthNumber - 1];
}

function convertStringToDate(stringDate) {
    var months = ["jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "dec"];
    var data = stringDate.split('-');
    var day = data[0];
    var month = months.indexOf(data[1].toLowerCase());
    var year = data[2];
    return new Date(year, month, day).getTime();
}

function createDate(year, intMonth) {
    return new Date(year, intMonth - 1, 01).getTime();
}

function getMonthName(monthNumber) {
    var months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    return months[monthNumber - 1];
}

function getMonthNumber(monthName) {
    var month1 = ["jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "dec"];
    var month2 = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    if (monthName.length >= 3) {
        return month1.indexOf(monthName.toLowerCase());
    } else {
        return month2.indexOf(monthName.toLowerCase());
    }

}

function showGlobalLoader() {
    var width = window.outerWidth;
    var height = window.outerHeight;
    var w = (width / 2) - 450;
    var h = (height / 2) - 100;
    var div = '<div id="ICustomLoader" style="height:' + height + 'px; width:' + width + 'px;background-color:rgba(0,0,0,0.5);z-index:10;top:0;bottom:0;right:0;left:0; position:fixed;">' +
        '<div style="margin-left:' + w + 'px; margin-top:' + h + 'px ; "><p style="color:lightgray; font-size:20px;text-align: center;line-height: 75px;"><img src="/Images/loading17.gif"/></p></div>' +
        '</div>';
    $('body').append(div);
    $('#ICustomLoader').on("contextmenu", function (e) {
        e.preventDefault();
    });
}//rgba(0,0,0,.6)

function hideGlobalLoader() {
    $('#ICustomLoader').remove();
}

function showLoader() {
}

function hideLoader() {
}


function decimal(e, ths) {

    var keynum;
    if (window.event) {
        keynum = e.keyCode;
    }
    else
        if (e.which) {
            keynum = e.which;
        }
    var tv = ths.value;
    if (tv == "" && e.which == 45) return true;
    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        if (e.which != 46 && e.which != 190) {
            showNotification(2, 'Decimal value only.');
            return false;
        }
        var charExists = (tv.indexOf('.') >= 0) ? false : true;
        if (!charExists) return false;
    }
}

function integer(e, ths) {
    var keynum;
    if (window.event) {
        keynum = e.keyCode;
    }
    else
        if (e.which) {
            keynum = e.which;
        }
    var tv = ths.value;
    if (tv == "" && e.which == 45) return true;
    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        if (e.which != 190) {
            showNotification(2, 'Integer value only.');
            return false;
        }
    }
}

$(document).on('keypress', '.decimal-only', function (e) {
    var keynum;
    if (window.event) {
        keynum = e.keyCode;
    }
    else
        if (e.which) {
            keynum = e.which;
        }
    var tv = $(this).value;
    if (tv == "" && e.which == 45) return true;
    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57) && e.which != 109) {
        if (e.which != 46 && e.which != 190 && e.which != 109) {
            showNotification(2, 'Decimal value only.');
            return false;
        }
        var charExists = (tv.indexOf('.') >= 0) ? false : true;
        if (!charExists) return false;

        var subExists = (tv.indexOf('-') >= 0) ? false : true;
        if (!subExists) return false;
    }

});

$(document).on('keypress', '.number-only', function (e) {

    var keynum;
    if (window.event) {
        keynum = e.keyCode;
    }
    else
        if (e.which) {
            keynum = e.which;
        }
    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        if (e.which != 190) {
            showNotification(2, 'Integer value only.');
            return false;
        }
    }

});

function validateYearInfo(year) {
    var filter = new RegExp("([1-2][0-9][0-9][0-9])");
    if (filter.test(year)) {
        return true;
    } else {
        return false;
    }
}

function isValidForm(formId) {

    $('#' + formId).data('bootstrapValidator').validate();
    return $('#' + formId).data('bootstrapValidator').isValid() ? true : false;
};

function getFormData(className) {
    var data = {};
    $('.' + className).each(function () {
        var name = $(this).attr('name');
        if (name != 'undifined') {
            if ($(this).is('input[type="text"]') || $(this).is('input[type="hidden"]') || $(this).is('select') || $(this).is('textarea')) {
                console.log(name);
                if ($(this).val()) {
                    data[name] = $(this).val().trim();
                }

            }
            else if ($(this).is('input[type="checkbox"]')) {
                var id = $(this).attr('id');
                if (document.getElementById(id).checked) {
                    data[id] = true;
                } else {
                    data[id] = false;
                }
            }

        }
    });
    return data;
};

function setFormData(data, exclues) {
    if (exclues == null) {
        exclues = [];
    }
    for (var key in data) {
        if (exclues.indexOf(key) == -1) {
            if ($('#' + key).is('input[type="text"]') || $('#' + key).is('input[type="hidden"]') || $('#' + key).is('select') || $('#' + key).is('textarea')) {
                $('#' + key).val(data[key]);
            }
            else if ($('#' + key).is('input[type="checkbox"]')) {

                if (data[key] == "True" || data[key] == "False") {
                    $('#' + key).prop('checked', JSON.parse(data[key].toLowerCase()));
                } else {
                    $('#' + key).prop('checked', data[key]);
                }

            }
        }
    }
};

function clearFormField(excludes) {
    if (excludes) {
        $('input[type=text],input[type=hidden],select,textarea').each(function () {

            var id = $(this).attr('id');
            if (id && excludes.indexOf(id) < 0) {
                if (!($(this).hasClass('non-cleared'))) {
                    $(this).val('');
                }
            }
            else {
                if (!($(this).hasClass('non-cleared'))) {
                    $(this).val('');
                }
            }
        });
    }
    else {
        $('input[type=text],input[type=hidden],select,textarea').each(function () {
            if (!($(this).hasClass('non-cleared'))) {
                $(this).val('');
            }
        });
        $('input[type=checkbox]').attr('checked', false);
    }
}

function ajaxRequest(url, type, data, async, cache, successCallBack) {
    showGlobalLoader();
    type == null ? 'post' : 'get',
    async == null ? true : false;
    cache == null ? false : true;
    $.ajax({
        url: url,
        type: type,
        data: data,
        async: async,
        cache: cache,
        success: successCallBack,
        error: function (xhr) {
        }
    });
    hideGlobalLoader();
};

function ajaxRequestWithList(url, type, data, successCallBack) {
    showGlobalLoader();
    type == null ? 'post' : 'get';
    var contentType = 'application/json;charset=utf-8';
    $.ajax({
        url: url,
        contentType: contentType,
        type: type,
        data: data,
        success: successCallBack,
        error: function (xhr) {
        }
    });
    hideGlobalLoader();
};

function validateYear(e) {

    e = '#' + e;
    var year = parseInt($(e).val());

    if (!isNaN(year)) {
        if (year < 99) {
            year = year >= 70 ? 1900 + year : 2000 + year;
        }
        else if (year <= 970) {
            year = 2000 + year;
        }
        else if (year <= 999) {
            year = 1000 + year;
        }
        else if (year <= 1970) {
            year = 0;
        }

    }
    else {
        year = 0;
    }

    $(e).val(year);
    if (year < 1970) {
        $(e).val('');
    }
    return year;
}

function validateIndividualFieldManually(frmName, controlName, status) {
    if (!status) {
        $('#' + frmName).data('bootstrapValidator').updateStatus(controlName, 'NOT-VALIDATE').validateField(controlName);
    } else {
        $('#' + frmName).data('bootstrapValidator').updateStatus(controlName, 'VALID').validateField(controlName);
    }
};


function validateDatepickerFields(event) {
    var currentControlId = $(this).prop('id');
    if ($(this).closest('div').find('small').length > 0) {
        if ($('#' + $(this).closest('form').prop('id')).find('small').length === 0) {

        } else {
            //this is for textbox without calendar
            if ($('#' + $(this).closest('form').prop('id')).find('small').attr('data-bv-validator').length > 0) {
                var formId = $(this).closest('form').prop('id');
                $('#' + formId).bootstrapValidator('revalidateField', currentControlId);
            }
        }
    } else {
        if ($(this).parent('div').parent('div').find('small').length > 0) {
            if ($('#' + $(this).closest('form').prop('id')).find('small').length === 0) {

            }
            else {
                //this is for textbox with calendar
                if ($('#' + $(this).closest('form').prop('id')).find('small').attr('data-bv-validator').length > 0) {
                    $('#' + $('#' + (currentControlId)).closest('form').prop('id')).bootstrapValidator('revalidateField', currentControlId);
                }
            }
        }
    }
}


$('.datepicker-not-allow-futuredate,.datepicker-allow-futuredate,.datepicker').on("changeDate", validateDatepickerFields);

$('.datepicker-not-allow-futuredate,.datepicker-allow-futuredate,.datepicker').on('hide', function (e) {
    var stickyDate = $(this).data('stickyDate');

    if (!e.date && stickyDate) {
        $(this).datepicker('setDate', stickyDate);
        $(this).data('stickyDate', null);
    }
});


$('.datepicker-not-allow-futuredate,.datepicker-allow-futuredate,.datepicker').on('show', function (e) {
    if (e.date) {
        $(this).data('stickyDate', e.date);
    } else {
        $(this).data('stickyDate', null);
    }
});

