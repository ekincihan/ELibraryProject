$(document).ready(function() {

	// Clock Picker
	// --------------------------------------------------

	$('.clockpicker').clockpicker();

	// Clockface
	// --------------------------------------------------

	$('.clock-face').clockface();

	$('#t2').clockface({
		format: 'HH:mm',
		trigger: 'manual'
	});

	$('#toggle-clockface').click(function(e) {
		e.stopPropagation();
		$('#t2').clockface('toggle');
	});

	$('#t3').clockface({
		format: 'H:mm'
	}).clockface('show', '14:30');

});