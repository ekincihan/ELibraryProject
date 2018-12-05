$(document).ready(function() {

	$('#date-added').daterangepicker({
		singleDatePicker: true,
	});

	// Order List
	// --------------------------------------------------

	var table = $('#customer-list').DataTable({
		pageLength: 10,
		colReorder: true,
		buttons: ['copy', 'excel', 'pdf', 'print'],
		searching: false,
		aLengthMenu: [
			[10, 20, 50, -1],
			[10, 20, 50, 'All']
		],
		order: [
			[5, 'desc']
		],
		columnDefs: [{
			orderable: false,
			targets: [0, 6]
		}]
	});
	$('#customer-list_wrapper .col-sm-6:eq(1)').addClass('text-right');
	table.buttons().container().appendTo('#customer-list_wrapper .col-sm-6:eq(1)');

});