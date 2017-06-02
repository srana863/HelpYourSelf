var iValidation = function () {

    var ValidateInput = function(el) {

        var hasError = false;
        var value = el.val();


        //= = = Required Field = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

        var requiredAttr = el.attr('required');
        if (typeof requiredAttr !== typeof undefined && requiredAttr !== false) {
            if (IsNullOrEmpty(value)) {
                AddMessage(el, 'This field is required.');
                hasError = true;
            } else {

                RemoveMessage(el);
                hasError = false;
            }
        }

        //= = = Minimum Length = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

        if (hasError == false) {

            var minLength = el.attr('data-min-length') ? el.data('min-length') : -1;
            var maxLength = el.attr('data-max-length') ? el.data('max-length') : -1;
            if (minLength > 0 || maxLength > 0) {
                var valueLength = value.length;

                if (minLength > 0 && maxLength > 0 && (valueLength < minLength || valueLength > maxLength)) {
                    AddMessage(el, 'Input length must be between ' + minLength + ' and ' + maxLength + ' charecters.');
                    hasError = true;
                } else if (minLength > 0 && valueLength < minLength) {
                    AddMessage(el, 'Input length must be at least ' + minLength + ' charecters.');
                    hasError = true;
                } else if (maxLength > 0 && valueLength > maxLength) {
                    AddMessage(el, 'Input length must be at most ' + maxLength + ' charecters.');
                    hasError = true;
                } else {
                    RemoveMessage(el);
                    hasError = false;
                }
            } else {
                RemoveMessage(el);
                hasError = false;
            }
        }


        //= = = Number / decimal / Email Type Validator = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

        if (hasError == false) {
            if (el.attr('data-f-type')) {
                var type = el.data('f-type');

                if (type == 'number' && !IsNullOrEmpty(value)) {
                    var numberRegex = /^\d+$/;
                    if (numberRegex.test(value)) {
                        RemoveMessage(el);
                        hasError = false;
                    } else {
                        AddMessage(el, 'Number only.');
                        hasError = true;
                    }
                } else if (type == 'decimal' && !IsNullOrEmpty(value)) {
                    var decimalRegex = /^\d+(\.\d{1,2})?$/i;
                    if (decimalRegex.test(value)) {
                        RemoveMessage(el);
                        hasError = false;
                    } else {
                        AddMessage(el, 'Decimal only.');
                        hasError = true;
                    }
                } else if (type == 'email' && !IsNullOrEmpty(value)) {
                    var emailRegex = new RegExp(/^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i);
                    if (emailRegex.test(value)) {
                        RemoveMessage(el);
                    } else {
                        AddMessage(el, 'Invalid email format.');
                        hasError = true;
                    }
                }
            }
        }

        //= = = Range Validator = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

        if (hasError == false) {

            var minValue = el.attr('data-min-range') ? el.data('min-range') : -1;
            var maxValue = el.attr('data-max-range') ? el.data('max-range') : -1;
            if (minValue > 0 || maxValue > 0) {
                if (el.attr('data-f-type')) {
                    var type = el.data('f-type');
                    if (type == 'number' || type == 'decimal') {
                        var newValue = 0;
                        if (type == 'number') {
                            newValue = parseInt(value);
                            minValue = parseInt(minValue);
                            maxValue = parseInt(maxValue);
                        } else {
                            newValue = parseFloat(value);
                            minValue = parseFloat(minValue);
                            maxValue = parseFloat(maxValue);
                        }

                        if (minValue > 0 && maxValue > 0 && (newValue < minValue || newValue > maxValue)) {
                            AddMessage(el, 'Value must be between ' + minValue + ' and ' + maxValue);
                            hasError = true;
                        } else if (minValue > 0 && newValue < minValue) {
                            AddMessage(el, 'Value must be at least ' + minValue);
                            hasError = true;
                        } else if (maxValue > 0 && newValue > maxValue) {
                            AddMessage(el, 'Value must be at most ' + maxValue);
                            hasError = true;
                        } else {
                            RemoveMessage(el);
                            hasError = false;
                        }
                    }
                }
            } else {
                RemoveMessage(el);
                hasError = false;
            }
        }

        return hasError;
    };

    var ValidateDate = function(el) {
        var hasError = false;
        RemoveMessage(el);
        try {
            var date = GetDate(el);

            if (el.hasClass('date-compare')) {
                var el2 = $('#' + el.data('c-control'));
                try {
                    var date2 = GetDate(el2);
                    var cType = el.data('c-type'); // max or min
                    if (cType == 'min') {
                        if (date > date2) {
                            AddMessage(el, "Should be less");
                            hasError = true;
                        } else {
                            RemoveMessage(el);
                            RemoveMessage(el2);
                            hasError = false;
                        }
                    } else {
                        if (date < date2) {
                            AddMessage(el, "Should be grater");
                            hasError = true;
                        } else {
                            RemoveMessage(el);
                            RemoveMessage(el2);
                            hasError = false;
                        }
                    }

                } catch (err) {

                }
            }
        } catch (err) {
            var value = el.val();
            var requiredAttr = el.attr('required');
            if (typeof requiredAttr !== typeof undefined && requiredAttr !== false) {
                if (IsNullOrEmpty(value)) {
                    AddMessage(el, 'This field is required.');
                    hasError = true;
                } else {
                    AddMessage(el, 'Invalid date');
                    hasError = true;
                    return hasError;
                }
            } else {
                if (!IsNullOrEmpty(value)) {
                    AddMessage(el, 'Invalid date');
                    hasError = true;
                }
            }
        }

        return hasError;
    };

    var ValidateSelect = function (el, isOnchange) {

        var id = el.attr('id');
        var selectedIndex = document.getElementById(id).selectedIndex;

        var hasError = false;
        var requiredAttr = el.attr('required');
        if (typeof requiredAttr !== typeof undefined && requiredAttr !== false) {
            if (selectedIndex < 0) {
                AddMessage(el, 'This field is required.');
                hasError = true;
            }
            else {

                RemoveMessage(el);
                hasError = false;
            }
        }

        if (hasError == false && el.attr('data-v-index')) {
            var errorIndex = parseInt(el.data('v-index'));

            if (selectedIndex == errorIndex) {
                AddMessage(el, 'Please choose another option.');
                hasError = true;
            }
            else {

                RemoveMessage(el);
                hasError = false;
            }
        }

        if (isOnchange) {
            if (el.attr('data-v-change')) {

                var functionToCall = '';

                var control = el.data('v-change');
                var controls = control.split(',');
                for (var i = 0; i < controls.length; i++) {
                    if (controls[i][0] == '#') {
                        var el = $(controls[i]);
                        if (el.is('input:text')) {
                            functionToCall = hasError == false ? 'ValidateInput' : 'RemoveMessage';
                            SelectOperation(el, functionToCall);
                        }
                        else if (el.is('select')) {

                            functionToCall = hasError == false ? 'ValidateSelect' : 'RemoveMessage';
                            SelectOperation(el, functionToCall);
                        }
                    }
                    else if (controls[i][0] == '.') {
                        $(controls[i]).each(function () {
                            var el = $(this);
                            if (el.is('input:text')) {
                                functionToCall = hasError == false ? 'ValidateInput' : 'RemoveMessage';
                                SelectOperation(el, functionToCall);
                            }
                            else if (el.is('select')) {
                                functionToCall = hasError == false ? 'ValidateSelect' : 'RemoveMessage';
                                SelectOperation(el, functionToCall);
                            }
                        });
                    }
                }
            }
        }

        return hasError;
    }

    var SelectOperation = function(el, functionToCall) {
        switch (functionToCall) {
        case "ValidateInput":
            ValidateInput(el);
            break;
        case "ValidateSelect":
            ValidateSelect(el);
            break;
        case "RemoveMessage":
            RemoveMessage(el);
            break;
        }
    };

    var RemoveValidation = function(controlId) {
        if (controlId[0] != '#') {
            controlId = '#' + controlId;
        }
        $(controlId + ' .validation').each(function() {
            RemoveMessage($(this));
        });
    };

    var IsNullOrEmpty = function (str) {
        if (!str)
            return true;
        return str === null || str.match(/^ *$/) !== null;
    };

    var AddMessage = function(el, msg) {
        el.removeClass('has-error').addClass('has-error');
        el.next('.msg').remove();
        $('<label class="msg msg-error">' + msg + '</label>').insertAfter(el);
    };

    var RemoveMessage = function(el) {
        if (el.hasClass('has-error')) {
            el.removeClass('has-error');
        }
        el.next('.msg').remove();
    };

    var GetDate = function(el) {

        var format = el.data('d-format');
        var sDate = el.val();

        var fullMonths = ['january', 'february', 'march', 'april', 'may', 'june', 'july', 'august', 'september', 'october', 'november', 'december'];
        var shortMonths = ['jan', 'feb', 'mar', 'apr', 'may', 'jun', 'jul', 'aug', 'sep', 'oct', 'nov', 'dec'];

        sDate = sDate.replace(/-/g, '/');
        format = format.replace(/-/g, '/').toLowerCase();
        formats = format.split('/');
        dates = sDate.split('/');

        var dayIndex = -1;
        var monthIndex = -1;
        var yearIndex = -1;

        for (var i = 0; i < formats.length; i++) {
            if (formats[i].indexOf('d') > -1) {
                dayIndex = i;
            }
            if (formats[i].indexOf('m') > -1) {
                monthIndex = i;
            }
            if (formats[i].indexOf('y') > -1) {
                yearIndex = i;
            }
        }

        var month = 0;
        var day = parseInt(dates[dayIndex]);

        if (dates[monthIndex].trim().length <= 2) {
            month = parseInt(dates[monthIndex].trim());
        } else {
            month = dates[monthIndex].trim().length > 3 ? fullMonths.indexOf(dates[monthIndex].trim()) + 1 : shortMonths.indexOf(dates[monthIndex].trim()) + 1;
        }
        var year = parseInt(dates[yearIndex]);

        if (day <= 0 || day > 31 || month <= 0 || month > 12 || year <= 1753 || year > 2120) {
            throw "Invalid date value";
        }

        var date = new Date(year, month - 1, day, 0, 0, 0, 0);
        return date;
    };

    var Validate = function(controlId) {
        var hasError = false;
        if (controlId[0] != '#') {
            controlId = '#' + controlId;
        }
        $(controlId + ' input[type="text"].validation').each(function() {
            var error = ValidateInput($(this));
            if (error == true) {
                hasError = error;
            }

        });

        $(controlId + ' select.validation').each(function() {
            var error = ValidateSelect($(this), false);
            if (error == true) {
                hasError = error;
            }
        });
        $(controlId + ' .date.validation').each(function() {
            var error = ValidateDate($(this), false);
            if (error == true) {
                hasError = error;
            }
        });

        return !hasError;
    };

    var initializeEvents = function() {

        $(document).on('keyup', 'input[type="text"].validation', function() {
            ValidateInput($(this));
        });

        $(document).on('change', '.date.validation', function() {
            ValidateDate($(this));
        });


        $(document).on('change', 'select.validation', function() {
            ValidateSelect($(this), true);
        });

    };

    return {
        init: function () {            
            initializeEvents();
        },
        Validate: Validate,
        RemoveValidation: RemoveValidation
    };
}();