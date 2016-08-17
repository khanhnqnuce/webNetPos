$(document).ready(function () {
    var overlay = $('.sidebar-overlay');
    $('.sidebar-toggle').on('click', function () {
        var sidebar = $('#sidebar');
        sidebar.toggleClass('open');
        overlay.addClass('active');
        var mainContructor = $(".sidebar-overlay").width();
        $(".constructor").css("width", mainContructor + "px");
    });
    overlay.on('click', function () {
        $(this).removeClass('active');
        $('#sidebar').removeClass('open');
        $(".constructor").css("width", "100%");
    });
});

$("#iptLoginPassfil").keyup(function () {
    var passwordOld = $("#iptLoginPass").val();
    var passwordNew = $("#iptLoginPassfil").val();
    if (passwordOld == passwordNew) {
        $("#validate-status").html("");
        $('#btnChangePass').removeClass('disabled');
    } else {
        $("#validate-status").text("Mật khẩu nhập lại không đúng !");
        $('#btnChangePass').addClass('disabled');    }
});


$("#iptLoginPassfil").change(function () {
    var passwordOld = $("#iptLoginPass").val();
    var passwordNew = $("#iptLoginPassfil").val();
    if (passwordOld == passwordNew) {
        $("#validate-status").html("");
        $('#btnChangePass').removeClass('disabled');
    } else {
        $("#validate-status").text("Mật khẩu nhập lại không đúng !");
        $('#btnChangePass').addClass('disabled');
    }
});

$('.call-inline-pop').magnificPopup({
    removalDelay: 500, //delay removal by X to allow out-animation
    callbacks: {
        beforeOpen: function () {
            this.st.mainClass = this.st.el.attr('data-effect');
        }
    },
    midClick: true // allow opening popup on middle mouse click. Always set it to true if you don't provide alternative source.
});



//Validate Login Res
$("#loginForm").validate({
    rules: {
        txtUsername: {
            required: true
        },
        txtPassword: {
            required: true,
            minlength: 6,
        }
    },
    messages: {
        txtUsername: {
            required: "Nhập Tài khoản  của bạn !",
        },
        txtPassword: {
            required: "Nhập password của bạn !",
            minlength: "Password tối thiểu 6 ký tự",
        },
    },
    submitHandler: function () {
        $.get("/Ajax/LoginAndRegister/Login", $("#loginForm").serialize(), function (msg) {
            if (msg.Erros) {
                $("#error-message").html(msg.Message);
            } else {
                swal("Success !", msg.Message, "success");
                window.location = "/";
            }
        });

        return false;
    },
});

$("#formRegister1").validate({

    rules: {
        txtUsernamecd: {
            required: true,
            number: true
        },
        txtUsernamegt: {
            required: true,
            number: true
        }
    },
    messages: {
        txtUsernamecd: {
            required: "Nhập ID Người chỉ định !"
        },
        txtUsernamegt: {
            required: "Nhập ID Người Giới thiệu !"
        }
    },
    submitHandler: function () {
        window.location = "/dang-ky/" + $("#txtUsernamecd").val() + "/" + $("#txtUsernamegt").val() + "/trai";
    }
});


$("#formRegister2").validate({

    rules: {
        FullName: {
            required: true,

        },
        PeoplesIdentity: {
            required: true,
            minlength: 8,
            maxlength: 12,
        },
        txtDate2: {
            required: true
        },
        txtMonth2: {
            required: true,
        },
        txtyear2: {
            required: true,
            number: true
        },
        PeoplesIdentityReward: {
            required: true,
            minlength: 8,
            maxlength: 12,
        },
        ProvincialAgencyID: {
            required: true,
        },

        Mobile: {
            required: true
        },

        txtDate: {
            required: true,
        },
        txtMonth: {
            required: true,
        },
        txtyear: {
            required: true,
            number: true
        },
        PlaceOfIssue: {
            required: true,
        },
        Address: {
            required: true,
        },
        txtResPass: {
            required: true,
            minlength: 6,
        },
        txtResPassConf: {
            required: true,
            minlength: 6,
        },
        //TaxCode: {
        //    required: true,
        //    minlength: 8,
        //    maxlength: 14,
        //},
        NameCompany: {
            required: true,
        },
        Email: {
            required: true,
            email: true
        },
        CityID: {
            required: true,
        },
        DistrictID: {
            required: true
        },
        NumberDate: {
            required: true
        }
    },
    messages: {
        txtHoten: {
            required: "Nhập họ tên !"
        },
        PeoplesIdentity: {
            required: "Nhập CMND hoặc CNMD không đúng !",
            minlength: "CMND ký tự phải lớn hơn 7 !",
            maxlength: "CMND ký tự phải nhỏ hơn 12 !"
        },
        PeoplesIdentityReward: {
            required: "Nhập CMND hoặc CNMD không đúng !",
            minlength: "CMND ký tự phải lớn hơn 7 !",
            maxlength: "CMND ký tự phải nhỏ hơn 12 !"
        },
        txtDate2: {
            required: "Nhập ngày !"
        },
        txtMonth2: {
            required: "Nhập tháng !"
        },
        txtyear2: {
            required: "Nhập năm !"
        },
        txtDate: {
            required: "Nhập ngày !"
        },
        txtMonth: {
            required: "Nhập tháng !"
        },
        txtyear: {
            required: "Nhập năm !"
        },

        ProvincialAgencyID: {
            required: "Nhập văn phòng !"
        },
        Mobile: {
            required: "Nhập Số điện thoại !"
        },
        Email: {
            required: "Nhập Email !",
            email: "Email không đúng định dạng !"
        },
        Address: {
            required: "Nhập địa chỉ !"
        },
        //TaxCode: {
        //    required: "Nhập Số tài khoản !"
        //},
        NameCompany: {
            required: "Nhập ngân hàng !"
        },

        txtResPass: {
            required: "Nhập mật khẩu !",
            minlength: "Mật khẩu ký tự phải lớn hơn 6 !",
        },
        txtResPassConf: {
            required: "Nhập lại mật khẩu !",
            minlength: "Mật khẩu ký tự phải lớn hơn 6 !",
        },
        PlaceOfIssue: {
            required: "Nhập lơi cấp !",
        },
        CityID: {
            required: "Chọn Tỉnh/ Thành phố !",
        },
        DistrictID: {
            required: "Chọn Quận/Huyện !"
        },
        NumberDate: {
            required: "Nhập số ngày sử dụng !"
        }

    },
    submitHandler: function () {
      if ($('#txtResPass').val() === $('#txtResPassConf').val()) {
            $.get("/Ajax/LoginAndRegister/Register", $("#formRegister2").serialize(), function (msg) {
                if (msg.Erros === false) {
                    swal("Success !", "Bạn đã đăng ký thành công.", "success");
                    window.location = "/";
                } else {
                    swal("Error !", msg.Message, "error");
                }
            });
        } else {
            swal("Error !", 'Password không trùng nhau', "error");
        }
    }

});


$("#formCustomerInfo").validate({
    rules: {
        FullName: {
            required: true,

        },
        PeoplesIdentity: {
            required: true,
            minlength: 8,
            maxlength: 12,
        },
        txtDate2: {
            required: true
        },
        txtMonth2: {
            required: true,
        },
        txtyear2: {
            required: true,
            number: true
        },
        PeoplesIdentityReward: {
            required: true,
            minlength: 8,
            maxlength: 12,
        },
        ProvincialAgencyID: {
            required: true,
        },

        Mobile: {
            required: true
        },

        txtDate: {
            required: true,
        },
        txtMonth: {
            required: true,
        },
        txtyear: {
            required: true,
            number: true
        },
        PlaceOfIssue: {
            required: true,
        },
        Address: {
            required: true,
        },
        txtResPass: {
            required: true,
            minlength: 6,
        },
        txtResPassConf: {
            required: true,
            minlength: 6,
        },
        TaxCode: {
            required: true,
            minlength: 8,
            maxlength: 14,
        },
        NameCompany: {
            required: true,
        },
        Email: {
            required: true,
            email: true
        },
        CityID: {
            required: true,
        },
        DistrictID: {
            required: true,
        },
        NumberDate: {
            required: true,
        }
    },
    messages: {
        txtHoten: {
            required: "Nhập họ tên !"
        },
        PeoplesIdentity: {
            required: "Nhập CMND hoặc CNMD không đúng !",
            minlength: "CMND ký tự phải lớn hơn 7 !",
            maxlength: "CMND ký tự phải nhỏ hơn 12 !"
        },
        PeoplesIdentityReward: {
            required: "Nhập CMND hoặc CNMD không đúng !",
            minlength: "CMND ký tự phải lớn hơn 7 !",
            maxlength: "CMND ký tự phải nhỏ hơn 12 !"
        },
        txtDate2: {
            required: "Nhập ngày !"
        },
        txtMonth2: {
            required: "Nhập tháng !"
        },
        txtyear2: {
            required: "Nhập năm !"
        },
        txtDate: {
            required: "Nhập ngày !"
        },
        txtMonth: {
            required: "Nhập tháng !"
        },
        txtyear: {
            required: "Nhập năm !"
        },
        Mobile: {
            required: "Nhập Số điện thoại !"
        },
        Email: {
            required: "Nhập Email !",
            email: "Email không đúng định dạng !"
        },
        Address: {
            required: "Nhập địa chỉ !"
        },
        TaxCode: {
            required: "Nhập Số tài khoản !"
        },
        NameCompany: {
            required: "Nhập ngân hàng !"
        },

        PlaceOfIssue: {
            required: "Nhập lơi cấp !",
        },
        CityID: {
            required: "Chọn Tỉnh/ Thành phố !",
        },
        DistrictID: {
            required: "Chọn Quận/Huyện !"
        },
        NumberDate: {
            required: "Nhập số ngày !"
        }

    },
    submitHandler: function () {
        
        $.get("/Ajax/CustomerInfo/Update", $("#formCustomerInfo").serialize(), function (msg) {
            if (msg.Erros === false) {
                swal("Success !", "Bạn đã cập nhật thành công.", "success");
                window.location = "/";
            } else {
                swal("Error !", msg.Message, "error");
            }
        });
    }

});

$("#formChangePass").validate({
    rules: {
        iptLoginUser: {
            required: true,
            minlength: 6,
        },
        iptLoginPass: {
            required: true,
            minlength: 6,
        },
        iptLoginPassfil: {
            required: true,
            minlength: 6,
        },
    },
    messages: {
        iptLoginUser: {
            required: "Nhập mật khẩu cũ !"
        },
        iptLoginPass: {
            required: "Nhập mật khẩu mới !",
            minlength: "Mật khẩu phải lớn hơn 7 !",
            maxlength: "Mật khẩu phải nhỏ hơn 12 !"
        },
        iptLoginPassfil: {
            required: "Nhập lại mật khẩu mới !",
            minlength: "Mật khẩu phải lớn hơn 7 !",
            maxlength: "Mật khẩu phải nhỏ hơn 12 !"
        },

    },
    submitHandler: function () {
        
        if (!($("#btnChangePass").hasClass("disabled")) && ($("#iptLoginPass").val() == $("#iptLoginPassfil").val()))
            $.get("/Ajax/CustomerInfo/UpdatePass", $("#formChangePass").serialize(), function (msg) {
                if (msg.Erros === false) {
                    setTimeout(function () {
                        swal("Success !", msg.Message, "success");
                        window.location = "/";
                    }, 1000);
                } else {
                    setTimeout(function () {
                       swal("Error !", msg.Message, "error");
                    }, 1000);
                }
            });
        else {
            setTimeout(function () {
                swal("Error !", "Mật khẩu không trùng nhau", "error");
            }, 1000);
        }
    }
});

//End Validate Login Res
//End Validate Login Res

// Javascript header mobie

//Scroll Top
(function () {
    $(window).scroll(function () {
        if ($(this).scrollTop() > 200) {
            $('#scrollTop').fadeIn(200);
        } else {
            $('#scrollTop').fadeOut(200);
        }
    });
    $('#scrollTop').click(function (event) {
        event.preventDefault();
        $('html, body').animate({ scrollTop: 0 }, 300);
    });

})();



function getValueMutilSelect(selectName) {
    var arrId = '';
    $.each($('select.mutil').multiSelect("getSelects"), function (key, value) {
        arrId += value + ",";
    });
    arrId = (arrId.length > 0) ? arrId.substring(0, arrId.length - 1) : arrId;
    return arrId;
}

var imageLoading = "<div class='col-sm-12 text-left m-t-sm' style='position: absolute;'><img src='/images/loading52.gif'/></div>";

function initAjaxLoad(urlListLoad, container, callback) {
    //alert(container);

    var urlTransform = urlListLoad;
    //alert(urlTransform);
    $(container).html(imageLoading);
    $.post(urlTransform, function (data) {
        //alert(data);
        $(container).html(data);
    }).complete(function () {
        if (callback && typeof (callback) === "function") {
            callback();
        }
    });

}
function loadGraph(id) {
    window.location = '/cay-tam-phan/' + id;
}

function dangky(gioithieu, nhanh) {
    window.location = "/dang-ky/" + gioithieu + "/" + gioithieu + '/' + nhanh;
};


function thoat() {
    window.location = "/thoat";
};

$("#gridAdd").submit(function (e) {
    e.preventDefault();
    $.get("/Ajax/HistoryVourcher/AddVourcher", function (msg) {
       
        if (msg.Erros === false) {
            swal("Success !", msg.Message, "success");
            setTimeout(function() {
                
                window.location = '/danh-sach-vourcher';
            }, 1000);
            
        } else {
            swal("Error !", msg.Message, "error");
            setTimeout(function() {
                window.location = '/danh-sach-vourcher';
            }, 1000);
        }
    });
});