var mc = mc || {};
mc.register = mc.register || {};
if (mc.register) {
    mc.register = function () {
        return {
            urls: {},
            viewModel: {
                FirstName: ko.observable(),
                MiddleName: ko.observable(),
                LastName: ko.observable(),
                LoginID: ko.observable(),
                Password: ko.observable(),
                EmailID: ko.observable()
            },
            load: function () {
                ko.applyBindings(mc.register.viewModel, $('#registerHtml')[0]);
            },
            saveUser: function () {
                $.blockUI({ 'message': $('#spinner') });
                var jsonData = ko.toJS(mc.register.viewModel);
                $.ajax({
                    url: mc.register.urls.saveUserUrl,
                    data: jsonData,
                    method: 'post',
                    success: function (result) {
                        if(result.isSuccess)
                            Notify(result.Message, null, null, "success");
                        else
                            Notify(result.Message, null, null, "warning");
                        mc.register.cancelData();
                        $.unblockUI();
                    },
                    error: function () {

                    }
                })
            },
            cancelData: function () {
                mc.register.viewModel.FirstName(null);
                mc.register.viewModel.MiddleName(null);
                mc.register.viewModel.LastName(null);
                mc.register.viewModel.LoginID(null);
                mc.register.viewModel.Password(null);
                mc.register.viewModel.EmailID(null);
            }
        }
    }();
}