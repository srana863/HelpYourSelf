var Tutorial = function () {
    var tutorialMetaViewModel = [];
    var clearForm = function () {
        clearFormField();
    };
    var saveTutorial = function () {
        if (iValidation.Validate('frmTutorial')) {
            var tutorial = getFormData('form-element');
            var value = CKEDITOR.instances['Description'].getData();
            var newVal = JSON.stringify($('.select2').select2('data'));
            console.log(newVal);
            TutorialMetaViewModel.push(newVal);
            tutorial.TutorialMetaViewModel = tutorialMetaViewModel;
            tutorial.Description = value;
            var url = "/Tutorial/SaveTutorial";
            ajaxRequestWithList(url, 'POST', JSON.stringify(tutorial), function (res) {
                showNotification(res.MessageType, res.Message);
                if (res.MessageType === 1) {
                    clearForm();
                }
            });
        }
    };
    var editTutorial = function (tutorialId) {
        var data = {
            tutorialId: tutorialId
        };
        var url = "/Tutorial/GetTutorial";
        ajaxRequest(url, 'GET', data, false, true, function (res) {
            if (res) {
                setFormData(res, null);
            }
        });
    };
    var loadTutorialCategory = function() {
        loadAllTutorialCategoryCombo('Meta', false);
    };
    var deleteTutorial = function (tutorialId) {
        $.confirm({
            title: 'Delete Message',
            text: 'Do you want to delete this tutorial',
            confirm: function () {
                var url = "/Tutorial/DeleteTutorial";
                ajaxRequest(url, 'POST', { tutorialId: tutorialId }, true, false, function (res) {
                    showNotification(res.MessageType, res.Message);
                });
            },
            cancel: function () {
                return false;
            },
            confirmButton: "Yes",
            cancelButton: "No"
        });
    };
    var userWiseTutorialList = function () {
        var url = "/Tutorial/GetAllTutorialByUserId";
        $("#userWiseTutorialList").load(url);

    };
    var initialEvent = function () {
        $("#btnSave").click(saveTutorial);
        $(document).on('click', '.tutorialEdit', function () {
            var tutorialId = $(this).data('id');
            editTutorial(tutorialId);
        });
        $(document).on('click', '.tutorialDelete', function () {
            var tutorialId = $(this).data('id');
            deleteTutorial(tutorialId);
        });
    };
    var init = function () {
        CKEDITOR.replace("Description");
        initialEvent();
        loadTutorialCategory();
        userWiseTutorialList();
    };
    return {
        init: init
    };
}();