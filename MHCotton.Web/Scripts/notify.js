Notify = function (text, callback, close_callback, style) {
    var time = '2000';
    var $container = $('#notifications');
    var icon = '<i class="fa fa-info-circle "></i>';
    if (typeof style == 'undefined') style = 'warning'
    //var html = $('<div class="alert alert-' + style + '  hide">' + icon +  " " + text + '</div>');
    var html = $('<div style="font-size:14px" class="alert alert-' + style + '  hide">' + " " + text + '&nbsp;  <span> <i class="fa fa-times-circle" aria-hidden="true"></i> </span></div>');
    var splitMessage = (text != undefined && text != null) ? text.split('~') : '';
    if (splitMessage.length > 1) {
        var buildText = "";
        for (var i = 0; i < splitMessage.length; i++) {
            buildText += "<li>" + splitMessage[i] + "</li>";
        }
        html = $('<div style="font-size:14px" class="alert alert-' + style + '  hide">' + " " + buildText + '&nbsp;  <span> <i class="fa fa-times-circle" aria-hidden="true"></i> </span></div>');
    }
    $container.html("");
    $container.prepend(html)
    html.removeClass('hide').hide().fadeIn('slow')
    function remove_notice() {
        html.stop().fadeOut('slow').remove()
    }
    var timer = setInterval(remove_notice, time);
    $(html).hover(function () {
        clearInterval(timer);
    }, function () {
        timer = setInterval(remove_notice, time);
    });
    html.on('click', function () {
        clearInterval(timer)
        callback && callback()
        remove_notice()
    });
}