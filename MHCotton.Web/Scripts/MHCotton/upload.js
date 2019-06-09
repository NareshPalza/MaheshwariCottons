var mc = mc || {};
mc.upload = mc.upload || {};
if (mc.upload) {
    mc.upload = function () {
        return {
            urls: {},
            load: function () {
                ko.applyBindings(mc.upload.viewModel, $('#uploadExcelDiv')[0]);
            },
            viewModel: {
                fileUploadText: ko.observable()
            },
            uploadExcel: function () {
                $.blockUI({ 'message': $('#spinner') });
                var formData = new FormData();
                var totalFiles = document.getElementById("FileUpload1").files.length;
                for (var i = 0; i < totalFiles; i++) {
                    var file = document.getElementById("FileUpload1").files[i];

                    formData.append("FileUpload1", file);
                }
                $.ajax({
                    type: "POST",
                    url: mc.upload.urls.uploadExcelUrl,
                    data: formData,
                    dataType: 'json',
                    contentType: false,
                    processData: false,
                    success: function (response) {
                        //Notify(result.Message, null, null, 'success');
                        $.unblockUI();
                    },
                    error: function (xhr, textStatus, error) {
                        //console.log(xhr.statusText);
                        //console.log(textStatus);
                        //console.log(error);
                        $.unblockUI();
                    }
                });
                return false;
            }
        }
    }();
}