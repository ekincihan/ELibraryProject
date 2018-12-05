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
        lineWidth: 2,
        size: 104,
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
    });

});