'use strict';

$(document).ready(function() {

    // User Profile
    // --------------------------------------------------

    $('#esp-user-profile').easyPieChart({
        barColor: '#0667D6',
        trackColor: 'rgba(0,0,0,0)',
        scaleColor: false,
        scaleLength: 0,
        lineCap: 'round',
        lineWidth: 3,
        size: 130,
        animate: {
            duration: 2000,
            enabled: true
        }
    });

    // Demo Settings
    // --------------------------------------------------

    $('.header-color').on('click', function() {
        var setColor = $(this).attr('data-color');
        var getColor = $('body').attr('data-header-color');
        $('body').removeClass(getColor).addClass(setColor).attr('data-header-color', setColor);
    });

    $('.sidebar-color').on('click', function() {
        var setColor = $(this).attr('data-color');
        var getColor = $('body').attr('data-sidebar-color');
        $('body').removeClass(getColor).addClass(setColor).attr('data-sidebar-color', setColor);
        if ($('body').hasClass('sidebar-dark')) {
            $('.main-sidebar').css('background-image', 'url(\'../build/images/backgrounds/10.jpg\')');
        } else if ($('body').hasClass('sidebar-light')) {
            $('.main-sidebar').css('background-image', 'url(\'../build/images/backgrounds/11.jpg\')');
        }
    });

    $('.sidebar-bg').on('click', function() {
        $('body').removeClass('sidebar-no-bg');
        $('#sidebar-bg').prop('checked', true);
        var setBg = '../build/images/backgrounds/' + $(this).attr('data-bg');
        $('.main-sidebar').css('background-image', 'url(' + setBg + ')');
    });

    $('#sidebar-bg').on('click', function() {
        if ($(this).prop('checked') === true) {
            $('body').removeClass('sidebar-no-bg');
            if ($('body').hasClass('sidebar-dark')) {
                $('.main-sidebar').css('background-image', 'url(\'../build/images/backgrounds/10.jpg\')');
            } else if ($('body').hasClass('sidebar-light')) {
                $('.main-sidebar').css('background-image', 'url(\'../build/images/backgrounds/11.jpg\')');
            }
        } else if ($(this).prop('checked') === false) {
            $('body').addClass('sidebar-no-bg')
            $('.main-sidebar').css('background-image', '');
        }
    });

});