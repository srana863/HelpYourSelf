
function loadAllTutorialCategoryCombo(controlId, isDefaultRecordRequired) {
    var url = '/Common/GetAllTutorialCategory';
    var data = {
    };
    loadCombo(controlId, url, data, isDefaultRecordRequired);
}

function loadCombo(controlId, url, parameter, isDefaultRecordRequired) {
    $.ajax({
        url: url,
        type: 'get',
        async: false,
        data: parameter,
        success: function (res) {
            var data = res;

            $("#" + controlId).empty();
            $("#" + controlId).get(0).options.length = 0;
            if (isDefaultRecordRequired) {
                $("#" + controlId).get(0).options[0] = new Option("---- Select -----", "");
            }
            if (data != null) {
                $.each(data, function (index, item) {
                    $("#" + controlId).get(0).options[$("#" + controlId).get(0).options.length] = new Option(item.Text, item.Value);
                });
            }
        },
        error: function () {
        }
    });
}

