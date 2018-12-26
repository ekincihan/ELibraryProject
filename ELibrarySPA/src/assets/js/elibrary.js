$(document).ready(function() {
    // add class to header
    $(window).scroll(function() {
        var scroll = $(window).scrollTop();
        if (scroll >= 35) {
            $("header").addClass("scrolled");
        } else {
            $("header").removeClass("scrolled");
        }
    });
    // popover callback
    $(function () {
        $('[data-toggle="popover"]').popover()
    });
});
