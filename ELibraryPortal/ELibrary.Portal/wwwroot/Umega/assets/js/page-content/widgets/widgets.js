$(document).ready(function() {

	// jQuery Counter Up
	// --------------------------------------------------

	$('.counter').counterUp({
		delay: 10,
		time: 1000
	});

	// Sparklines
	// --------------------------------------------------

	$('#sp-line').sparkline([10, 20, 14, 30, 14, 20, 30, 15, 20, 0, 16, 5], {
		type: 'line',
		width: '110',
		height: '40',
		lineColor: '#FFF',
		fillColor: false,
		lineWidth: '2',
		spotColor: '#FFF',
		minSpotColor: '#FFF',
		maxSpotColor: '#FFF',
		highlightLineColor: '#FFF',
		highlightSpotColor: '#FFF',
		spotRadius: 4
	});

	$('#sp-bar').sparkline([50, 60, 70, 20, 0, 40, 20, 40, 10, 80, 50, 40], {
		type: 'bar',
		height: '40',
		barWidth: '8',
		barSpacing: 1,
		barColor: '#FFF'
	});

	// New Comments
	// --------------------------------------------------

	var dataComment = [
		[0, 10],
		[1, 100],
		[2, 300],
		[3, 310],
		[4, 600],
		[5, 360],
		[6, 150],
		[7, 130]
	];
	var datasetComment = [{
		label: 'Comments',
		data: dataComment,
		color: '#0667D6',
		points: {
			fillColor: '#0667D6'
		}
	}];
	var optionsComment = {
		series: {
			lines: {
				show: true,
				lineWidth: 1
			},
			points: {
				show: true,
				lineWidth: 0,
				fill: true
			},
			shadowSize: 0
		},
		grid: {
			hoverable: true,
			borderWidth: 0
		},
		xaxis: {
			ticks: 0
		},
		yaxis: {
			ticks: 0
		},
		tooltip: {
			show: true,
			content: '%s: %y',
			defaultTheme: false
		},
		legend: {
			show: false
		}
	};
	$.plot($('#flot-comment'), datasetComment, optionsComment);

	// New Orders
	// --------------------------------------------------

	var dataOrder = [
		[0, 50],
		[1, 90],
		[2, 300],
		[3, 500],
		[4, 300],
		[5, 560],
		[6, 200],
		[7, 130]
	];
	var datasetOrder = [{
		label: 'Orders',
		data: dataOrder,
		color: '#E5343D',
		points: {
			fillColor: '#E5343D'
		}
	}];
	var optionsOrder = {
		series: {
			lines: {
				show: true,
				lineWidth: 1
			},
			points: {
				show: true,
				lineWidth: 0,
				fill: true
			},
			shadowSize: 0
		},
		grid: {
			hoverable: true,
			borderWidth: 0
		},
		xaxis: {
			ticks: 0
		},
		yaxis: {
			ticks: 0
		},
		tooltip: {
			show: true,
			content: '%s: %y',
			defaultTheme: false
		},
		legend: {
			show: false
		}
	};
	$.plot($('#flot-order'), datasetOrder, optionsOrder);

	// Task Completed
	// --------------------------------------------------

	var dataTask = [
		[0, 10],
		[1, 25],
		[2, 30],
		[3, 70],
		[4, 43],
		[5, 54],
		[6, 60],
		[7, 50]
	];
	var datasetTask = [{
		label: 'Task',
		data: dataTask,
		color: '#17A88B',
		points: {
			fillColor: '#17A88B'
		}
	}];
	var optionsTask = {
		series: {
			lines: {
				show: true,
				lineWidth: 1
			},
			points: {
				show: true,
				lineWidth: 0,
				fill: true
			},
			shadowSize: 0
		},
		grid: {
			hoverable: true,
			borderWidth: 0
		},
		xaxis: {
			ticks: 0
		},
		yaxis: {
			ticks: 0
		},
		tooltip: {
			show: true,
			content: '%s: %y',
			defaultTheme: false
		},
		legend: {
			show: false
		}
	};
	$.plot($('#flot-task'), datasetTask, optionsTask);

	// Total Revenue
	// --------------------------------------------------

	var dataRevenue = [
		[0, 2000],
		[1, 1000],
		[2, 3000],
		[3, 3500],
		[4, 4000],
		[5, 3600],
		[6, 1500],
		[7, 1300]
	];
	var datasetRevenue = [{
		label: 'Revenue',
		data: dataRevenue,
		color: '#8E23E0',
		points: {
			fillColor: '#8E23E0'
		}
	}];
	var optionsRevenue = {
		series: {
			lines: {
				show: true,
				lineWidth: 1
			},
			points: {
				show: true,
				lineWidth: 0,
				fill: true
			},
			shadowSize: 0
		},
		grid: {
			hoverable: true,
			borderWidth: 0
		},
		xaxis: {
			ticks: 0
		},
		yaxis: {
			ticks: 0
		},
		tooltip: {
			show: true,
			content: '%s: $%y',
			defaultTheme: false
		},
		legend: {
			show: false
		}
	};
	$.plot($('#flot-revenue'), datasetRevenue, optionsRevenue);

	// New Comments
	// --------------------------------------------------

	$('#esp-comment').easyPieChart({
		barColor: '#8E23E0',
		trackColor: '#E6E6E6',
		scaleColor: false,
		scaleLength: 0,
		lineCap: 'round',
		lineWidth: 10,
		size: 140,
		animate: {
			duration: 2000,
			enabled: true
		}
	});

	// New Photos
	// --------------------------------------------------

	$('#esp-photo').easyPieChart({
		barColor: '#0667D6',
		trackColor: '#E6E6E6',
		scaleColor: false,
		scaleLength: 0,
		lineCap: 'round',
		lineWidth: 10,
		size: 140,
		animate: {
			duration: 2000,
			enabled: true
		}
	});

	// New Users
	// --------------------------------------------------

	$('#esp-user').easyPieChart({
		barColor: '#17A88B',
		trackColor: '#E6E6E6',
		scaleColor: false,
		scaleLength: 0,
		lineCap: 'round',
		lineWidth: 10,
		size: 140,
		animate: {
			duration: 2000,
			enabled: true
		}
	});

	// New Feedbacks
	// --------------------------------------------------

	$('#esp-feedback').easyPieChart({
		barColor: '#E5343D',
		trackColor: '#E6E6E6',
		scaleColor: false,
		scaleLength: 0,
		lineCap: 'round',
		lineWidth: 10,
		size: 140,
		animate: {
			duration: 2000,
			enabled: true
		}
	});

	// Slick Carousel
	// --------------------------------------------------

	$('#social').slick({
		arrows: false,
		autoplay: true,
		autoplaySpeed: 2000,
		cssEase: 'ease'
	});

	// Weather
	// --------------------------------------------------

	var dataWeather = [
		[0, 75],
		[1, 69],
		[2, 64],
		[3, 65],
		[4, 78],
		[5, 77],
		[6, 75],
		[7, 68],
		[8, 64],
		[9, 62],
		[10, 67],
		[11, 75],
		[12, 73],
		[13, 68],
		[14, 75],
		[15, 72],
		[16, 73],
		[17, 62],
		[18, 76],
		[19, 74],
		[20, 64],
		[21, 77],
		[22, 80],
		[23, 71]
	];
	var datasetWeather = [{
		label: 'F',
		data: dataWeather,
		color: '#fff'
	}];
	var optionsWeather = {
		series: {
			lines: {
				show: true,
				lineWidth: 2
			},
			points: {
				show: true,
				lineWidth: 4
			},
			shadowSize: 0
		},
		grid: {
			hoverable: true,
			borderWidth: 0
		},
		xaxis: {
			ticks: 0
		},
		yaxis: {
			ticks: 0
		},
		tooltip: {
			show: true,
			content: '%y %s',
			defaultTheme: false
		},
		legend: {
			show: false
		}
	};
	$.plot($('#flot-weather'), datasetWeather, optionsWeather);

});