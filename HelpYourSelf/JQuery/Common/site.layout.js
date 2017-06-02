//$(document)
//    .ajaxStart(function () { showLoaderGlobal(); })
//    .ajaxStop(function () { hideLoaderGlobal(); });


$('.decimal').on('keyup', function (e) {
    var ex = /^[0-9]+\.?[0-9]*$/;
    if (ex.test(this.value) == false) {
        this.value = this.value.substring(0, this.value.length - 1);
    }

});
$('.number').on('keyup', function (e) {
    var ex = /^[0-9]*$/;
    if (ex.test(this.value) == false) {
        this.value = this.value.substring(0, this.value.length - 1);
    }
});

$('.datepicker-not-allow-futuredate').prop('readonly', true);
$('.datepicker-not-allow-futuredate').datepicker({
    format: 'dd-M-yyyy',
    autoclose: true,
    todayBtn: 'linked',
    todayHightlight: true,
    endDate: "current"
});

$('.datepicker-allow-futuredate').prop('readonly', true);
$('.datepicker-allow-futuredate').datepicker({
    format: 'dd-M-yyyy',
    autoclose: true,
    todayBtn: 'linked',
    todayHightlight: true
});

$('.readonly-input').prop('readonly', true);
$('.disabled-input').prop('disabled', true);

$(function () {
    $('.datepicker').prop('readonly', true);
    $('.datepicker').datepicker({
        format: 'dd-M-yyyy',
        autoclose: true,
        todayBtn: 'linked',
        todayHightlight: true
    });
    var today = new Date();
    today.setDate(today.getDate());
});


//function searchSupplier(controlId, identityCode, nextCallFunction) {
//    $('#SearchSupplierName').modal('show');
//    loadSearchSupplier(controlId, identityCode, nextCallFunction);
//}

//function loadSearchSupplier(controlId, identityCode, nextCallFunction) {
//    var url = '/Common/LoadSearchSupplier';
//    $('#Div-SupplierList').empty().load(url);
//    $('#SearchSupplierName #nextId').val(controlId);
//    $('#SearchSupplierName #identityCode').val(identityCode);
//    $('#SearchSupplierName #nextMethod').val(nextCallFunction);
//}
