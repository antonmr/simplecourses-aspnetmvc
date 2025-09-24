$(function () {
    function onUserRegisterClick() {
        var url = 'UserAuth/RegisterUser';

        var userInput = {
            __RequestVerificationToken: $("#UserRegistrationForm input[name='__RequestVerificationToken']").val(),
            Email: $('#UserRegistrationForm #Email').val(),
            Password: $('#UserRegistrationForm #Password').val(),
            ConfirmPassword: $('#UserRegistrationForm #ConfirmPassword').val(),
            FirstName: $('#UserRegistrationForm #FirstName').val(),
            LastName: $('#UserRegistrationForm #LastName').val(),
            Address1: $('#UserRegistrationForm #Address1').val(),
            Address2: $('#UserRegistrationForm #Address2').val(),
            PostCode: $('#UserRegistrationForm #PostCode').val(),
            PhoneNumber: $('#UserRegistrationForm #PhoneNumber').val(),
            AcceptUserAgreement: $('#UserRegistrationForm #AcceptUserAgreement').prop('checked'),
        };

        $.ajax({
            type: "POST",
            url: url,
            data: userInput,
            success: function (data) { // callback method
                var parsed = $.parseHTML(data);

                var hasErrors = $(parsed).find("input[name='RegistrationInvalid']").val() == 'true';
                if (hasErrors) {
                    $('#UserRegistrationModal').html(data);
                    userRegisterButton = $('#UserRegistrationModal #register').click(onUserRegisterClick);

                    var form = $('#UserRegistrationForm');
                    $(form).removeData("validator");
                    $(form).removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse(form);
                } else {
                    location.href = "Home/Index";
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    }

    var userRegisterButton = $('#UserRegistrationModal #register').click(onUserRegisterClick);
});