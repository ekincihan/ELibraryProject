$(document).ready(function() {
    // add slideDown animation to dropdown
    $('.dropdown').on('show.bs.dropdown', function(e) {
        $(this).find('.dropdown-menu').first().fadeIn(120);
    });
    // add slideUp animation to dropdown
    $('.dropdown').on('hide.bs.dropdown', function(e) {
        $(this).find('.dropdown-menu').first().fadeOut(120);
    });
    // add class to header
    $(window).scroll(function() {
        var scroll = $(window).scrollTop();
        if (scroll >= 70) {
            $("header").addClass("scrolled");
        } else {
            $("header").removeClass("scrolled");
        }
    });
});
