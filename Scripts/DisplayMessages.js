function DisplayErrorMessage(msg) {
    var ico = '<i class="fa fa-exclamation-triangle"></i>'
    $('#loginAlertBar').html(ico + ' ' + msg);
    $('#loginAlertBar').removeClass('alert-info');
    $('#loginAlertBar').addClass('alert-danger');
    $('#loginAlertBar').removeClass('hidden');
    return false;
}

function DisplayInfo(msg) {
    var ico = '<i class="fa fa-info-circle"></i>'
    $('#loginAlertBar').html(ico + ' ' + msg);
    $('#loginAlertBar').removeClass('hidden');
    return false;
}

function DisplayCustomMessage(obj, msg, type) {
    console.log(msg);
    var ico;

    if (type == 'Error') {
        ico = '<i class="fa fa-exclamation-triangle"></i>';
        $(obj).html(ico + ' ' + msg);
        $(obj).addClass('alert-danger');
    }
    else if (type == 'Success') {
        ico = '<i class="fa fa-check"></i>'
        $(obj).html(ico + ' ' + msg);
        $(obj).removeClass('alert-danger');
        $(obj).removeClass('alert-info');
        $(obj).addClass('alert-success');
    }
    else if (type == 'Info') {
        ico = '<i class="fa fa-info-circle"></i>';
        $(obj).html(ico + ' ' + msg);
        $(obj).removeClass('alert-danger');
        $(obj).addClass('alert-info');
    }
    else if (type == 'Warning') {
        ico = '<i class="fa fa-info-circle"></i>';
        $(obj).html(ico + ' ' + msg);
        $(obj).addClass('alert-warning');
    }

    $(obj).removeClass('hidden');

    return false;
}

function HideCustomErrorMessage(obj) {
    var ico = '<i class="fa fa-exclamation-triangle"></i>'
    $(obj).addClass('hidden');
    $(obj).removeClass('alert-warning');
    $(obj).removeClass('alert-success');
    $(obj).removeClass('alert-danger');
    return false;
}

function HideErrorMessage() {
    var ico = '<i class="fa fa-exclamation-triangle"></i>'
    $('#loginAlertBar').addClass('hidden');
    $('#loginAlertBar').removeClass('alert-warning');
    $('#loginAlertBar').removeClass('alert-success');
    $('#loginAlertBar').addClass('alert-danger');
    return false;
}

function DisplaySuccessMessage(msg) {
    var ico = '<i class="fa fa-check"></i>'
    if ($.trim(msg).length > 0) {
        $('#loginAlertBar').html(ico + ' ' + msg);
        $('#loginAlertBar').removeClass('hidden');
        $('#loginAlertBar').removeClass('alert-danger');
        $('#loginAlertBar').removeClass('alert-warning');
        $('#loginAlertBar').addClass('alert-success');
        alert(msg);
    }
    else {
        $('#loginAlertBar').addClass('hidden');
    }
    return false;
}

function DisplayWarningMessage(msg) {
    var ico = '<i class="fa fa-exclamation-triangle"></i>'
    if ($.trim(msg).length > 0) {
        $('#loginAlertBar').html(ico + ' ' + msg);
        $('#loginAlertBar').removeClass('hidden');
        $('#loginAlertBar').removeClass('alert-danger');
        $('#loginAlertBar').addClass('alert-warning');
    }
    else {
        $('#loginAlertBar').addClass('hidden');
    }
    return false;
}

function HideWarningMessage() {
    var ico = '<i class="fa fa-exclamation-triangle"></i>'
    $('#loginAlertBar').addClass('hidden');
    $('#loginAlertBar').removeClass('alert-danger');
    $('#loginAlertBar').addClass('alert-warning');
    return false;
}

function DisplayMultiLineErrorMessage(msg) {
    var str = msg;
    var ico = '<i class="fa fa-exclamation-triangle"></i>'
    var strarray = str.split('</br>');
    var msgstring = '';

    for (var i = 0; i < strarray.length - 1; i++) {
        msgstring += ico + ' ' + strarray[i] + "<br>";
    }

    $('#loginAlertBar').removeClass('alert-success');
    $('#loginAlertBar').addClass('alert-danger');
    $('#loginAlertBar').html(msgstring);
    $('#loginAlertBar').removeClass('hidden');
    return false;

}

function DisplayMultiLineCustomMessage(obj, msg, type) {

    var ico;

    var str = msg;
    var strarray = str.split('</br>');
    var msgstring = '';



    if (type == 'Error') {
        ico = '<i class="fa fa-exclamation-triangle"></i>';
        for (var i = 0; i < strarray.length - 1; i++) {
            msgstring += ico + ' ' + strarray[i] + "</br>";
        }
        $(obj).html(msgstring);
        $(obj).addClass('alert-danger');
    }
    else if (type == 'Success') {
        ico = '<i class="fa fa-check"></i>'
        for (var i = 0; i < strarray.length - 1; i++) {
            msgstring += ico + ' ' + strarray[i] + "</br>";
        }
        $(obj).html(msgstring);
        $(obj).removeClass('alert-danger');
        $(obj).addClass('alert-success');
    }
    else if (type == 'Info') {
        ico = '<i class="fa fa-info-circle"></i>';
        for (var i = 0; i < strarray.length - 1; i++) {
            msgstring += ico + ' ' + strarray[i] + "</br>";
        }
        $(obj).html(msgstring);
        $(obj).removeClass('alert-danger').addClass('alert-info');
    }
    else if (type == 'Warning') {
        ico = '<i class="fa fa-info-circle"></i>';
        for (var i = 0; i < strarray.length - 1; i++) {
            msgstring += ico + ' ' + strarray[i] + "</br>";
        }
        $(obj).html(msgstring);
        $(obj).addClass('alert-warning');
    }

    $(obj).removeClass('hidden');

    return false;

}

function PasswordStrengthValidation(obj) {
    $(obj).removeClass('hidden');
    return false;
}

function HidePasswordStrengthValidation(obj) {
    $(obj).addClass('hidden');
    return false;
}