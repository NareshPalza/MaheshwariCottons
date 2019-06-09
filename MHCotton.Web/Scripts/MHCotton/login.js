var mc = mc || {};
mc.login = mc.login || {};
if (mc.login) {
    mc.login = function () {
        return {
            urls: {},
            load: function () {
                ko.applyBindings(mc.login.viewModel, $('#loginHtml')[0]);
            },
            viewModel: {
                LoginID: ko.observable(),
                Password: ko.observable()
            },
            loginSubmit: function () {
                $.blockUI({ 'message': $('#spinner') });
                //$.blockUI({ 'message': '<img src="Content/Loader/FinalSpinner.gif"></img>' });
                var jsonData = ko.toJS(mc.login.viewModel);
                $.ajax({
                    url: mc.login.urls.GetLoginSubmitUrl,
                    data: jsonData,
                    method: 'post',
                    success: function (result) {
                        if (!result.isSuccess)
                            Notify(result.Message, null, null, 'danger');
                        else
                            window.location.href = result.url;
                        $.unblockUI();
                    },
                    error: function () {

                    }
                });
            },
            forgotPassword: function () {
                debugger;
                $('#forgotPasswordModal').modal('toggle');
            },
            getPassword: function () {
                $.blockUI({ 'message': $('#spinner') });
                $('#forgotPasswordModal').modal('toggle');
                debugger;
                //$.blockUI({ 'message': '<img src="Content/Loader/FinalSpinner.gif"></img>' });
                $.ajax({
                    url: mc.login.urls.GetForgotPasswordUrl,
                    data: { loginID: mc.login.viewModel.LoginID()},
                    method: 'post',
                    success: function (result) {
                        if (result.isSuccess)
                            Notify(result.Message, null, null, 'success');
                        else
                            Notify(result.Message, null, null, 'error');
                        $.unblockUI();
                    },
                    error: function () {
                    }
                });
            }
        }
    }();
}