'use strict';

$(document).ready(function() {

	// Toggle Demo Settings
	// --------------------------------------------------

	$('.setting-toggle').on('click', function() {
		$('.setting').toggleClass('closed');
	});

	// Demo Settings
	// --------------------------------------------------

	$('.body-bg').on('click', function() {
		var setBg = '../build/images/backgrounds/' + $(this).attr('data-bg');
		$('body').css('background-image', 'url(' + setBg + ')');
	});

});