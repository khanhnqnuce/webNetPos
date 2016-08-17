var layoutName = "";
var pageId = 0;
var url = "";

$(function () {
    $("#btnAddModule").click(function () {
        $("#dialog-form").dialog({
            title: "Thêm module",
            resizable: false,
            width: 300,
            modal: true,
            buttons: {
                "Cập nhật": {
                    click: function () {
                        $("#saveModule").click();
                    },
                    text: 'Cập nhật',
                    "class": 'btn btn-sm btn-success'
                },
                "Hủy": {
                    click: function () {
                        $(this).dialog("close");
                    },
                    text: 'Hủy',
                    "class": 'btn btn-sm btn-danger'
                }
            },
            show: {
                effect: "fade",
                duration: 500
            }
        }).load("/Modules/EditModule?doAction=add&pageId=" + pageId + "&layout=" + layoutName).dialog("open");
    });

    $(".edit-module").click(function () {
        var id = $(this).data("id");
        $("#dialog-form").dialog({
            title: "Chỉnh sửa",
            resizable: false,
            width: 300,
            modal: true,
            buttons: {
                "Cập nhật": function () {
                    $("#saveModule").click();
                },
                "Hủy": function () {
                    $(this).dialog("close");
                },
            },
            show: {
                effect: "fade",
                duration: 500
            }
        }).load("/Modules/EditModule" + "?doAction=edit&ctrId=" + id + "&layout=" + layoutName).dialog("open");
    });

    $(".delete-module").click(function () {
        var id = $(this).data("id");
        $("#dialog-form").html("<p><b>Bạn có chắc chắn muốn xóa</b></p>");
        $("#dialog-form").dialog({
            title: "Thông báo",
            resizable: false,
            height: 'auto',
            width: 'auto',
            modal: true,
            buttons: {
                "Xóa": function () {
                    $.post("/Modules/SaveModule?doAction=delete", { ctrId: id }, function (data) {
                        window.location.reload();
                    });
                },
                "Hủy": function () {
                    $(this).dialog("close");
                },
            }
        }).dialog("open");;
    });

    $(".copy-module").click(function () {
        var id = $(this).data("id");
        $("#dialog-form").dialog({
            title: "Copy module",
            resizable: false,
            width: 300,
            modal: true,
            buttons: {
                "Save": {
                    click: function () {
                        $("#saveModuleCopy").click();
                    },
                    text: 'Save',
                    "class": 'btn btn-sm btn-success'
                },
                "Close": {
                    click: function () {
                        $(this).dialog("close");
                    },
                    text: 'Close',
                    "class": 'btn btn-sm btn-danger'
                }
            }
        }).load("/Modules/ModuleCopy?pageId=" + pageId + "&ctrId=" + id).dialog("open");
    });

    $(".setting-module").click(function () {
        var id = $(this).data("id");
        var url = $(this).data("url");
        $("#dialog-form").dialog({
            title: "Cấu hình module",
            resizable: false,
            height: 'auto',
            width: 'auto',
            modal: true,
            buttons: {
                "Lưu lại": function () {
                    $("#SaveSetting").click();
                },
                "Hủy": function () {
                    $(this).dialog("close");
                },
            }
        }).dialogExtend({
            closable: true,
            maximizable: true,
            minimizable: true,
            minimizeLocation: "right",
            collapsable: true,
            dblclick: "maximize"
        }).load("/" + url + "?setting=1&ctrId=" + id).dialog("open");
    });

    $("#btnSaveLayout").click(function () {
        $.post("/Modules/SaveModule" + "?doAction=layout", { LayoutNew: $("#LayoutNew").val(), pageId: pageId }, function () {
            window.location.reload();
        });
    });
   
    
    $("body").on("click", "#btnEditPage", function () {
        $.post("/Modules/editPage", { name: "edit" }, function () {
            window.location.reload();
        });
    });

    $("body").on("click", "#btnViewPage", function () {
        $.post("/Modules/editPage", { name: "view" }, function () {
            window.location.reload();
        });
    });

    //Thêm mới module html
    //$("body").on("click", "#btnAddModulHtml", function () {
    //    $("#dialog-form").dialog({
    //        title: "Thêm mới",
    //        resizable: false,
    //        height: 'auto',
    //        width: 'auto',
    //        modal: true,
    //        buttons: {
    //            "Cập nhật": function () {
    //                $("#saveModule").click();
    //            },
    //            "Hủy": function () {
    //                $(this).dialog("close");
    //            },
    //        }
    //    }).dialogExtend({
    //        closable: true,
    //        maximizable: true,
    //        minimizable: true,
    //        minimizeLocation: "right",
    //        collapsable: true,
    //        dblclick: "maximize"
    //    }).load("/Html/Html/Index?doAction=add").dialog("open");
    //});

    $("body").on("click", ".btn-edit-html", function () {
        var key = $(this).attr("data-key");
        $("#dialog-form").dialog({
            title: "Chỉnh sửa",
            resizable: false,
            height: 500,
            width: 900,
            modal: true,
            buttons: {
                "Cập nhật": {
                    click: function () {
                        $(".btn-save-html").click();
                    },
                    text: 'Cập nhật',
                    "class": 'btn btn-sm btn-success'
                },
                "Hủy": {
                    click: function () {
                        $(this).dialog("close");
                    },
                    text: 'Hủy',
                    "class": 'btn btn-sm btn-danger'
                }
            }
        }).dialogExtend({
            closable: true,
            maximizable: true,
            minimizable: true,
            minimizeLocation: "right",
            collapsable: true,
            dblclick: "maximize"
        }).load("/Html/Html/Edit?key=" + key).dialog("open");
    });

    $("body").on("click", ".btn-save-html", function () {
        var ctrId = $(this).attr("data-key");
        var htmlId = $(this).attr("data-id");
        updateEditor();
        $.post("/Html/Html/Save?key=" + htmlId + "&ctrId=" + ctrId, { Value: $('textarea[name="txt-' + ctrId + '"]').val() }, function (data) {
            if (!data.Erros) {
                window.location.reload();
            }
        });
    });

    $(".btn-show-pagesetting").click(function () {
        $("#top-header-setting").toggleClass("active");
    });
});