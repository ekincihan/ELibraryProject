$(document).ready(function() {

	// Datetime Picker
	// --------------------------------------------------

	$('#minimum-dtpicker').datetimepicker({
		locale: 'en-gb'
	});

	$('#custom-dtpicker').datetimepicker({
		locale: 'en-gb',
		format: 'LT'
	});

	$('#view-mode-dtpicker').datetimepicker({
		locale: 'en-gb',
		viewMode: 'years'
	});

	$('#min-view-mode-dtpicker').datetimepicker({
		locale: 'en-gb',
		viewMode: 'years',
		format: 'MM/YYYY'
	});

	// Bootstrap Date Range Picker
	// --------------------------------------------------

	$('#date-range-picker').daterangepicker();

	$('#date-time-picker').daterangepicker({
		timePicker: true,
		timePickerIncrement: 30,
		locale: {
			format: 'MM/DD/YYYY h:mm A'
		}
	});

	$('#single-date-picker').daterangepicker({
		singleDatePicker: true,
		showDropdowns: true
	}, function(start, end, label) {
		var years = moment().diff(start, 'years');
		alert('You are ' + years + ' years old.');
	});

	$('#predefined-ranges-picker').daterangepicker({
		ranges: {
			'Today': [moment(), moment()],
			'Yesterday': [moment().subtract('days', 1), moment().subtract('days', 1)],
			'Last 7 Days': [moment().subtract('days', 6), moment()],
			'Last 30 Days': [moment().subtract('days', 29), moment()],
			'This Month': [moment().startOf('month'), moment().endOf('month')],
			'Last Month': [moment().subtract('month', 1).startOf('month'), moment().subtract('month', 1).endOf('month')]
		},
		opens: 'left',
		startDate: moment().subtract(29, 'days'),
		endDate: moment()
	}, function(start, end, label) {
		$('#predefined-ranges-picker span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
	});
	$('#predefined-ranges-picker span').html(moment().subtract(29, 'days').format('MMMM D, YYYY') + ' - ' + moment().format('MMMM D, YYYY'));

	// jQuery Steps
	// --------------------------------------------------

	$('#form-horizontal').steps({
		headerTag: 'h3',
		bodyTag: 'fieldset',
		transitionEffect: 'slide'
	});

	$('#form-vertical').steps({
		headerTag: 'h3',
		bodyTag: 'fieldset',
		transitionEffect: 'slide',
		stepsOrientation: 'vertical'
	});

	$('#form-tabs').steps({
		headerTag: 'h3',
		bodyTag: 'fieldset',
		transitionEffect: 'slideLeft',
		enableFinishButton: false,
		enablePagination: false,
		enableAllSteps: true,
		titleTemplate: '#title#',
		cssClass: 'tabcontrol'
	});

	// Data Tables
	// --------------------------------------------------

	$('#example-6').DataTable({
		select: {
			style: 'os'
		}
	});

});