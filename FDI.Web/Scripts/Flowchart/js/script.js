//Sidebar effect
$(document).ready(function () {
    var overlay = $('.sidebar-overlay');
    $('.sidebar-toggle').on('click', function () {
        var sidebar = $('#sidebar');
        sidebar.toggleClass('open');
        overlay.addClass('active');     
        var mainContructor = $(".sidebar-overlay").width();
        $(".constructor").css("width", mainContructor+"px");
    });
    overlay.on('click', function () {
        $(this).removeClass('active');
        $('#sidebar').removeClass('open');
        $(".constructor").css("width", "100%");
    });
});

//Menu Sidebar Mobie effect
$(document).ready(function () {
    $('.nav-mobie li.has-sub>.a-open-down').on('click', function () {
        $(this).removeAttr('href');
        var element = $(this).parent('li');
        if (element.hasClass('open')) {
            element.removeClass('open');
            element.find('li').removeClass('open');
            element.find('ul').slideUp();
        }
        else {
            element.addClass('open');
            element.children('ul').slideDown();
            element.siblings('li').children('ul').slideUp();
            element.siblings('li').removeClass('open');
            element.siblings('li').find('li').removeClass('open');
            element.siblings('li').find('ul').slideUp();
        }
    });
});

// Javascript header mobie
$(document).ready(function () { 
//Slider main
    $("#slider-main").owlCarousel({
        navigation: true, // Show next and prev buttons
        slideSpeed: 300,
        paginationSpeed: 400,
        singleItem: true,
        lazyLoad: true,
        //transitionStyle: "fade",
        navigationText: ["<i class='fa fa-angle-left'></i>",
         "<i class='fa fa-angle-right'></i>"],
        pagination: false
    });
//Slider casure
    $("#sliderBottom").owlCarousel({
        items: 6,
        itemsCustom: false,
        itemsDesktop: [1105,5],
        itemsDesktopSmall: [1024, 5],
        itemsTablet: [768, 4],
        itemsTabletSmall: false,
        itemsMobile: [479, 2],
        navigation: true,
        autoPlay: 7000,
        stopOnHover: true,
        pagination: false,
        slideSpeed: 200,
        paginationSpeed: 800,
        rewindSpeed: 1000,
        lazyLoad: true,
        transitionStyle: false,
        navigationText: ["<i class='fa fa-angle-left'></i>",
         "<i class='fa fa-angle-right'></i>"]
    });

//NiceScroll
    //$(".my-div").niceScroll({
    //    touchbehavior: true,
    //    cursorcolor: "#ec1f24",
    //    cursoropacitymax: 1,
    //    cursorwidth: 3,
    //    cursorborder: "0px",
    //    cursorborderradius: "0px",
    //    background: "#f8f8f8",
    //    autohidemode: false
    //});

// Inline popups effect
    //$('.call-inline-pop').magnificPopup({
    //    removalDelay: 500, //delay removal by X to allow out-animation
    //    callbacks: {
    //        beforeOpen: function () {
    //            this.st.mainClass = this.st.el.attr('data-effect');
    //        }
    //    },
    //    midClick: true // allow opening popup on middle mouse click. Always set it to true if you don't provide alternative source.
    //});


});

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

