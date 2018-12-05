$(document).ready(function() {

	// Order Status
	// --------------------------------------------------

	var dataOrdered = [
		[0, 150708],
		[1, 502507],
		[2, 220627],
		[3, 821182],
		[4, 233599],
		[5, 4087866],
		[6, 364625],
		[7, 3064625],
		[8, 236585],
		[9, 1040222],
		[10, 516876],
		[11, 292003]
	];
	var dataReturned = [
		[0, 650708],
		[1, 1102507],
		[2, 417012],
		[3, 495497],
		[4, 887603],
		[5, 564775],
		[6, 2580159],
		[7, 607998],
		[8, 1906411],
		[9, 346237],
		[10, 315699],
		[11, 202003]
	];
	var xticksOrder = [
		[0, 'Jan'],
		[1, 'Feb'],
		[2, 'Mar'],
		[3, 'Apr'],
		[4, 'May'],
		[5, 'Jun'],
		[6, 'Jul'],
		[7, 'Aug'],
		[8, 'Sep'],
		[9, 'Oct'],
		[10, 'Nov'],
		[11, 'Dec']
	];
	var datasetOrder = [{
		label: 'Ordered',
		data: dataOrdered,
		color: '#0667D6'
	}, {
		label: 'Returned',
		data: dataReturned,
		color: '#1F364F'
	}];
	var optionsOrder = {
		series: {
			lines: {
				show: true,
				lineWidth: 4
			},
			points: {
				show: true,
				lineWidth: 4,
				radius: 6
			},
			shadowSize: 0
		},
		grid: {
			borderWidth: 0,
			hoverable: true,
			labelMargin: 15
		},
		xaxis: {
			ticks: xticksOrder,
			tickLength: 0,
			font: {
				color: '#9a9a9a',
				size: 11
			}
		},
		yaxis: {
			tickLength: 0,
			tickSize: 1000000,
			font: {
				color: '#9a9a9a',
				size: 11
			},
			tickFormatter: function(val, axis) {
				if (val > 0) {
					return (val / 1000000).toFixed(axis.tickDecimals) + ' M';
				} else {
					return (val / 1000000).toFixed(axis.tickDecimals);
				}
			}
		},
		tooltip: {
			show: false
		},
		legend: {
			show: true,
			position: 'ne',
			noColumns: 4,
			labelBoxBorderColor: '#FFF',
			margin: 0
		}
	};
	$.plot($('#flot-order'), datasetOrder, optionsOrder);
	$('#flot-order').bind('plothover', function(event, pos, item) {
		if (item) {
			$('.flotTip').text(item.series.label + ': $' + item.datapoint[1].toFixed(0).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')).css({
				top: item.pageY + 15,
				left: item.pageX + 10
			}).show();
		} else {
			$('.flotTip').hide();
		}
	});

	// Monthly Sales
	// --------------------------------------------------

	var dataSales = [
		[0, 1021],
		[1, 1370],
		[2, 904],
		[3, 690],
		[4, 904],
		[5, 929],
		[6, 789],
		[7, 579],
		[8, 1039],
		[9, 1204],
		[10, 1120],
		[11, 809]
	];
	var datasetSales = [{
		label: 'Sales',
		data: dataSales,
		color: '#0667D6'
	}];
	var tickSales = [
		[0, 'Jan'],
		[1, 'Feb'],
		[2, 'Mar'],
		[3, 'Apr'],
		[4, 'May'],
		[5, 'Jun'],
		[6, 'Jul'],
		[7, 'Aug'],
		[8, 'Sep'],
		[9, 'Oct'],
		[10, 'Nov'],
		[11, 'Dec']
	];
	var optionsSales = {
		series: {
			bars: {
				show: true,
				fill: 0.2,
				align: 'center',
				barWidth: 0.5,
				lineWidth: 2
			}
		},
		grid: {
			borderWidth: 0,
			hoverable: true,
			tickColor: '#fff',
			labelMargin: 15
		},
		xaxis: {
			font: {
				color: '#9a9a9a',
				size: 11
			},
			ticks: tickSales
		},
		yaxis: {
			font: {
				color: '#9a9a9a',
				size: 11
			},
			tickFormatter: function(v, axis) {
				return v.toString().replace(/\B(?=(?:\d{3})+(?!\d))/g, ',');
			}
		},
		tooltip: {
			show: true,
			content: '%x: %y',
			defaultTheme: false
		},
		legend: {
			show: false
		}
	};
	$.plot($('#flot-sales'), datasetSales, optionsSales);

	// Browser Chart
	// --------------------------------------------------

	Morris.Donut({
		element: 'morris-category',
		data: [{
			label: 'Cosmetics',
			value: 40
		}, {
			label: 'Accessories',
			value: 35
		}, {
			label: 'Books',
			value: 25
		}],
		resize: true,
		colors: ['#1F364F', '#0667D6', '#E6E6E6'],
		formatter: function(x) {
			return x + '%';
		}
	});

	// Order Table
	// --------------------------------------------------

	var table = $('#order-table').DataTable({
		lengthChange: false,
		pageLength: 5,
		colReorder: true,
		buttons: ['copy', 'excel', 'pdf', 'print'],
		language: {
			search: '',
			searchPlaceholder: 'Search records'
		},
		columnDefs: [{
			orderable: false,
			targets: 6
		}]
	});

	table.buttons().container().appendTo('#order-table_wrapper .col-sm-6:eq(0)');

});