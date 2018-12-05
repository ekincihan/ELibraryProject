$(document).ready(function() {

	$('#date-added, #date-modified').daterangepicker({
		singleDatePicker: true,
	});

	// Order List
	// --------------------------------------------------

	var table = $('#order-list').DataTable({
		pageLength: 10,
		colReorder: true,
		buttons: ['copy', 'excel', 'pdf', 'print'],
		searching: false,
		aLengthMenu: [
			[10, 20, 50, -1],
			[10, 20, 50, 'All']
		],
		order: [
			[1, 'asc']
		],
		columnDefs: [{
			orderable: false,
			targets: [0, 7]
		}]
	});
	$('#order-list_wrapper .col-sm-6:eq(1)').addClass('text-right');
	table.buttons().container().appendTo('#order-list_wrapper .col-sm-6:eq(1)');

});