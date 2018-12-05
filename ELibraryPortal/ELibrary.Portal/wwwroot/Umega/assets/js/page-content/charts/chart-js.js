$(document).ready(function() {

	// Line chart data
	// --------------------------------------------------

	var lineChartData = {
		labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul'],
		datasets: [{
			label: 'My First dataset',
			fillColor: '#1F364F',
			strokeColor: '#1F364F',
			pointColor: '#1F364F',
			pointStrokeColor: '#1F364F',
			pointHighlightFill: '#1F364F',
			pointHighlightStroke: '#1F364F',
			data: [65, 59, 80, 81, 56, 55, 40]
		}, {
			label: 'My Second dataset',
			fillColor: '#0667D6',
			strokeColor: '#0667D6',
			pointColor: '#0667D6',
			pointStrokeColor: '#0667D6',
			pointHighlightFill: '#0667D6',
			pointHighlightStroke: '#0667D6',
			data: [28, 48, 40, 19, 86, 27, 90]
		}]
	};

	// Bar chart data
	// --------------------------------------------------

	var barChartData = {
		labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul'],
		datasets: [{
			label: 'My First dataset',
			fillColor: '#0667D6',
			strokeColor: '#0667D6',
			highlightFill: '#0667D6',
			highlightStroke: '#0667D6',
			data: [65, 59, 80, 81, 56, 55, 40]
		}, {
			label: 'My Second dataset',
			fillColor: '#1F364F',
			strokeColor: '#1F364F',
			highlightFill: '#1F364F',
			highlightStroke: '#1F364F',
			data: [28, 48, 40, 19, 86, 27, 90]
		}]
	};

	// Rada chart data
	// --------------------------------------------------

	var radarChartData = {
		labels: ['Eating', 'Drinking', 'Sleeping', 'Designing', 'Coding', 'Cycling', 'Running'],
		datasets: [{
			label: 'My First dataset',
			fillColor: '#0667D6',
			strokeColor: '#0667D6',
			pointColor: '#0667D6',
			pointStrokeColor: '#0667D6',
			pointHighlightFill: '#0667D6',
			pointHighlightStroke: '#0667D6',
			data: [65, 59, 90, 81, 56, 55, 40]
		}, {
			label: 'My Second dataset',
			fillColor: '#1F364F',
			strokeColor: '#1F364F',
			pointColor: '#1F364F',
			pointStrokeColor: '#1F364F',
			pointHighlightFill: '#1F364F',
			pointHighlightStroke: '#1F364F',
			data: [28, 48, 40, 19, 96, 27, 100]
		}]
	};

	// Polar chart data
	// --------------------------------------------------

	var polarChartData = [{
		value: 300,
		color: '#1F364F',
		highlight: '#1F364F',
		label: 'Success'
	}, {
		value: 70,
		color: '#8E23E0',
		highlight: '#8E23E0',
		label: 'Info'
	}, {
		value: 100,
		color: '#0667D6',
		highlight: '#0667D6',
		label: 'Primary'
	}, {
		value: 60,
		color: '#17A88B',
		highlight: '#17A88B',
		label: 'Warning'
	}, {
		value: 120,
		color: '#E6E6E6',
		highlight: '#E6E6E6',
		label: 'Default'
	}];

	// Pie chart data
	// --------------------------------------------------

	var pieChartData = [{
		value: 300,
		color: '#1F364F',
		highlight: '#1F364F',
		label: 'Success'
	}, {
		value: 50,
		color: '#0667D6',
		highlight: '#0667D6',
		label: 'Primary'
	}, {
		value: 100,
		color: '#E6E6E6',
		highlight: '#E6E6E6',
		label: 'Danger'
	}];
	window.onload = function() {
		// Global chart configuration
		Chart.defaults.global.responsive = true;
		Chart.defaults.global.maintainAspectRatio = false;
		Chart.defaults.global.scaleFontFamily = '\'Poppins\', sans-serif';
		Chart.defaults.global.scaleFontSize = 11;
		Chart.defaults.global.scaleFontColor = '#9a9a9a';
		Chart.defaults.global.scaleLineColor = '#f1f1f1';
		Chart.defaults.global.tooltipTitleFontFamily = '\'Poppins\', sans-serif';
		Chart.defaults.global.tooltipTitleFontSize = 11;
		Chart.defaults.global.tooltipCornerRadius = 2;
		// Line chart
		var ctxLine = document.getElementById('linechart').getContext('2d');
		window.myLine = new Chart(ctxLine).Line(lineChartData, {
			scaleGridLineColor: '#f1f1f1',
			scaleOverride: true,
			scaleSteps: 5,
			scaleStepWidth: 20,
			scaleStartValue: 0,
			scaleLabel: '<%= value %>',
			multiTooltipTemplate: '<%= datasetLabel %>: <%= value %>',
			datasetFill: true
		});
		// Bar chart
		var ctxBar = document.getElementById('barchart').getContext('2d');
		window.myBar = new Chart(ctxBar).Bar(barChartData, {
			scaleOverride: true,
			scaleSteps: 5,
			scaleStepWidth: 20,
			scaleStartValue: 0,
			scaleLabel: '<%= value %>',
			multiTooltipTemplate: '<%= datasetLabel %>: <%= value %>',
			datasetFill: true
		});
		// Radar chart
		window.myRadar = new Chart(document.getElementById('radarchart').getContext('2d')).Radar(radarChartData, {
			pointLabelFontSize: 11,
			pointLabelFontFamily: '\'Poppins\', sans-serif'
		});
		// Polar chart
		var ctxPolar = document.getElementById('polarchart').getContext('2d');
		window.myPolarArea = new Chart(ctxPolar).PolarArea(polarChartData);
		// Pie chart
		var ctxPie = document.getElementById('piechart').getContext('2d');
		window.myPie = new Chart(ctxPie).Pie(pieChartData);
		// Doughnut chart
		var ctxDoughnut = document.getElementById('doughnutchart').getContext('2d');
		window.myDoughnut = new Chart(ctxDoughnut).Doughnut(pieChartData);
	};
});