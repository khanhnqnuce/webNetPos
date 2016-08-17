var url = "";
$(document).ready(function () {
    
    $("#menu .menutop").click(function (e) {
        e.preventDefault();
        url = $(this).attr("data-layout");
        window.location.href = $(this).attr("href");
    });
});

function initAjaxLoad(callback) {
    $.address.init().change(function (event) {
        alert(window.location.href);
       if (url == "") return;
        
        url = "Home/" + url;
        $.post(url, function (data) {
            debugger;
            $("#container").html(data);
        }).complete(function () {
            if (callback && typeof (callback) === "function") {
                callback();
            }
        });
    });
}