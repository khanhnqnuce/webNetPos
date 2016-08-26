var imageLoading = "<div class='col-sm-12 text-left m-t-sm' style='position: absolute;'><img src='/images/loading52.gif'/></div>";
var urlLists = '';
var urlForm = '';
var urlXuatExcel = '';


function run_waitMe(effect, obj, text) {
    $(obj).waitMe({
        effect: effect,
        text: text,
        bg: 'rgba(255,255,255,0.3)',
        color: '#000',
        sizeW: '',
        sizeH: '',
        source: 'img.svg'
    });
}

function loadAjax(urlContent, container) {
    $.ajax({
        url: encodeURI(urlContent),
        cache: false,
        type: "POST",
        success: function (data) {
            $(container).html(data);
        }
    });
}

function initAjaxLoad(urlListLoad, container, callback) {
    $.address.init().change(function (event) {
        var urlTransform = urlListLoad;
        var urlHistory = event.value;
        if (urlHistory.length > 0) {
            urlHistory = urlHistory.substring(1, urlHistory.length);
            if (urlTransform.indexOf('?') > 0)
                urlTransform = urlTransform + '&' + urlHistory;
            else
                urlTransform = urlTransform + '?' + urlHistory;
        }
        $(container).html(imageLoading);
        $.post(urlTransform, function (data) {
            $(container).html(data);
        }).complete(function () {
            if (callback && typeof (callback) === "function") {
                callback();
            }
        });
    });
}

function getValueMutilSelect(selectName) {
    var arrID = '';
    $.each($('select.mutil').multiSelect("getSelects"), function (key, value) {
        arrID += value + ",";
    });
    arrID = (arrID.length > 0) ? arrID.substring(0, arrID.length - 1) : arrID;
    return arrID;
}

function getValueFormMutilSelect(form) {
    var arrParam = '';
    var idMselect;

    $(form).find("input,textarea,hidden,select").not("input[type='checkbox'], input[type='radio']:checked, input[name='selectItem'], .ms-search input, .mutil").each(function () {
        idMselect = $(this).attr("name");
        if ($(this).val() != '' && $(this).val() != 'Từ khóa tìm kiếm')
            arrParam += "&" + idMselect + "=" + $(this).val();
    });
    $("[data-id='SearchIn'].multiSelectSearch").each(function () {
        idMselect = $(this).attr("data-id");
        if (getValueMutilSelect(idMselect) != '')
            arrParam += "&" + idMselect + "=" + getValueMutilSelect(idMselect);
    });
    if (arrParam != '')
        arrParam = arrParam.substring(1);
    return arrParam;
}

function changeHashValue(key, value, source) {
    value = encodeURIComponent(value);
    var currentLink = source.substring(1);
    var returnLink = '#';
    var exits = false;
    if (currentLink.indexOf('&') > 0) { // lớn hơn 1
        var tempLink = currentLink.split('&');
        for (idx = 0; idx < tempLink.length; idx++) {
            if (key == tempLink[idx].split('=')[0]) { //check Exits
                returnLink += key + '=' + value;
                exits = true;
            }
            else {
                returnLink += tempLink[idx];
            }
            if (idx < tempLink.length - 1)
                returnLink += '&';
        }
        if (!exits)
            returnLink += '&' + key + '=' + value;
    } else if (currentLink.indexOf('=') > 0) { //Chỉ 1
        if (currentLink.match(/Page/)) {
            returnLink = '#' + key + '=' + value;
        } else {
            returnLink = '#' + currentLink + '&' + key + '=' + value;
        }
    }
    else {
        returnLink = '#' + key + '=' + value;
    }
    return returnLink;
}

//Chuyển trang với value mới
function changeHashUrl(key, value) {
    var currentLink = $.address.value();
    return changeHashValue(key, value, currentLink);
}

function registerGridView(selector) {
    //Đổi màu row
    $(selector + " .gridView tr").each(function (index) {
        if (index % 2 == 0)
            $(this).addClass("odd");
    });

    //Sắp xếp các cột
    //TúNT      22/11/2013      Update sort dont' lose param search, page
    $(selector + " .gridView th a").each(function (idx) {
        var link = $(this).attr("href");
        link = link.substring(1, link.length);
        var newLink = '';
        var currentLink = $.address.value();
        //Trường hợp ghi đè mọi thuộc tính khác trên grid với có số trang, thông tin tìm kiếm
        if (currentLink.indexOf('&') > 1) {
            var re = /(?:\x26)?(Field\x3D[^\x26]+)\x26/;
            if (currentLink.match(/\x26(Field\x3D[^\x26]+)\x26/))
                newLink = currentLink.replace(re, link + '&');
            if (currentLink.match(/(?:\x26)?(Field\x3D[^\x26]+)\x26/))
                newLink = currentLink.replace(re, '&' + link + '&');
            if (newLink.match(/^\x2F/))
                newLink = newLink.substring(1, newLink.length);
            if (newLink.match(/^\x26/))
                newLink = newLink.substring(1, newLink.length);
            $(this).attr("href", '#' + newLink);
        }
        //Trường hợp đã sort
        if ($.address.value().indexOf(link) > 0) {
            if ($.address.value().indexOf('FieldOption=1') > 0) { //Tăng dần
                newLink = newLink.replace('/', '');
                var tempLink = newLink;
                $(this).addClass('desc');
                var re2 = /\x26(FieldOption\x3D\d+)/;
                newLink = newLink.replace(re2, '&FieldOption=0');
                if (newLink == tempLink) {
                    var re4 = /\x26(x26FieldOption\x3D[^\x26]+)\x26/;
                    newLink = newLink.replace(re4, '&FieldOption=0');
                }
                newLink = newLink.replace('/', '');
                if (newLink.match(/^\x26/))
                    newLink = newLink.substring(1, newLink.length);
                $(this).attr("href", '#' + newLink);
            }
            else { //Giảm dần
                $(this).addClass('asc');
                var tempLink = newLink;
                var re5 = /\x26(FieldOption\x3D\d+)/;
                newLink = newLink.replace('/', '');
                newLink = newLink.replace(re5, '&FieldOption=1');
                if (newLink == tempLink) {
                    var re6 = /\x26(x26FieldOption\x3D[^\x26]+)\x26/;
                    newLink = newLink.replace(re6, 'FieldOption=1');
                }
                if (newLink == '')
                    newLink = link + '&FieldOption=1';
                newLink = newLink.replace('/', '');
                $(this).attr("href", '#' + newLink);
            }
        }
    });

    //khi người dùng click trên 1 row
    $(selector + " .gridView tr").not("first").click(function () {
        $(selector + " .gridView tr").removeClass("hightlight");
        $(this).addClass("hightlight");
    });

    //checkall
    $(selector + ' .checkAll').click(function () {
        var selectQuery = selector + " input.check[type='checkbox']";
        if ($(this).val() != '')
            selectQuery = selector + " #" + $(this).val() + " input.check[type='checkbox']";
        $(selectQuery).attr('checked', $(this).is(':checked'));
    });

    //checkall popup
    $(selector + ' .checkAllTopHome').click(function () {
        var selectQuery = selector + " input.check[type='checkbox']";
        if ($(this).val() != '')
            selectQuery = selector + " #" + $(this).val() + " input.check[type='checkbox']";
        $(selectQuery).attr('checked', $(this).is(':checked'));
    });

    //Nhảy trang
    $(selector + " .bottom-pager input").change(function () {
        var cPage = trim12($(this).val());
        var maxPage = $(selector + " .bottom-pager input[type=hidden]").val();
        if (cPage.length == 0)
            createMessage("Thông báo", "Yêu cầu nhập trang cần chuyển đến");
        else if (isNaN(cPage))
            createMessage("Thông báo", "trang chuyển đến phải là kiểu số");
        else if (parseInt(cPage) > maxPage)
            createMessage("Thông báo", "trang không được lớn hơn " + maxPage + "");
        else if (parseInt(cPage) <= 0) {
            createMessage("Thông báo", "trang phải lớn hơn 0");
        }
        else {
            window.location.href = changeHashUrl('Page', cPage);;
        }
    });

    //Thay đổi số bản ghi trên trang
    $(selector + " .bottom-pager select").change(function () {
        var urlFWs = $.address.value();
        urlFWs = changeHashValue("Page", 1, urlFWs); //Replace  &Page=.. => Page=1
        urlFWs = changeHashValue("RowPerPage", $(this).val(), urlFWs); //Replace  &TenDonVi=.. => TenDonVi=donViNhan
        window.location.href = urlFWs;
    });

}

function escapeHTML(str) {
    var div = document.createElement('div');
    var text = document.createTextNode(str);
    div.appendChild(text);
    return div.innerHTML;
}

function trim12(str) {
    var str = str.replace(/^\s\s*/, ''),
		ws = /\s/,
		i = str.length;
    while (ws.test(str.charAt(--i)));
    return str.slice(0, i + 1);
}

function createCloseMessage(title, message, urlFw) {
    urlFw = urlFw.replace(/<\/?\w(?:[^"'>]|"[^"]*"|'[^']*')*>/g, "");

    $.notify(message, 'success');
    window.location.href = urlFw;
}

function createAutoTag(tagControls, urlRouters) {
    $("#" + tagControls + "_Input").keypress(function (e) {
        if (e.keyCode == 13) {
            valuesAdd = trim12($(this).val());
            if (valuesAdd == '')
                createMessage('Đã có lỗi xảy ra.', 'Bạn phải nhập vào từ khóa tìm kiếm');
            else {
                addValues(tagControls, valuesAdd, urlRouters + "&do=Add", '');
            }
            return false;
        }
    });

    $('#' + tagControls + "_Input").autocomplete({
        serviceUrl: urlRouters,
        minChars: 1,
        delimiter: /(;)\s*/, // regex or character
        maxHeight: 400,
        width: 500,
        zIndex: 9999,
        deferRequestBy: 0, //miliseconds
    });
}

function getParameters(name, valueDefault) {
    var page = valueDefault;
    var url = window.location.href;
    if (url.indexOf('?') > 0) {
        url = url.replace("#", "&");
    } else {
        url = url.replace("#", "?");
    }
    var obj = $.url(url).param();
    if (obj[name] != null) {
        page = obj[name];
    }
    return page;
}
