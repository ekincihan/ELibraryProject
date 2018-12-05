// Product List
// --------------------------------------------------

var table = $('#product-list').DataTable({
	pageLength: 10,
	colReorder: true,
	buttons: ['copy', 'excel', 'pdf', 'print'],
	searching: false,
	aLengthMenu: [
		[10, 20, 50, -1],
		[10, 20, 50, 'All']
	],
	order: [
		[2, 'asc']
	],
	columnDefs: [{
		orderable: false,
		targets: [0, 1, 7]
	}]
});
$('#product-list_wrapper .col-sm-6:eq(1)').addClass('text-right');
table.buttons().container().appendTo('#product-list_wrapper .col-sm-6:eq(1)');