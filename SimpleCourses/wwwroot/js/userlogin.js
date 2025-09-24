$(function () {
    function onUserLoginClick() {
        var url = 'UserAuth/Login';

        var userInput = {
            __RequestVerificationToken: $("#UserLoginModal input[name='__RequestVerificationToken']").val(),
            Email: $('#UserLoginModal #Email').val(),
            Password: $('#UserLoginModal #Password').val(),
            RememberMe: $('#UserLoginModal #RememberMe').val()
        };

        $.ajax({
            type: "POST",
            url: url,
            data: userInput,
            success: function (data) { // callback method
                var parsed = $.parseHTML(data);

                var hasErrors = $(parsed).find("input[name='LoginInvalid']").val() == 'true';
                if (hasErrors) {
                    $('#UserLoginModal').html(data);
                    userLoginButton = $('#UserLoginModal #login').click(onUserLoginClick);

                    var form = $('#UserLoginForm');
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

    var userLoginButton = $('#UserLoginModal #login').click(onUserLoginClick);
});