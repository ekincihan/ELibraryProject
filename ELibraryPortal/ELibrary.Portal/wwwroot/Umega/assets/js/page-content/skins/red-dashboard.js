$(document).ready(function() {

    // Toastr
    // --------------------------------------------------

    toastr.options = {
        closeButton: true,
        progressBar: true,
        showMethod: 'fadeIn',
        hideMethod: 'fadeOut',
        timeOut: 5000
    };
    toastr.error('You have 6 notifications', 'Welcome to Umega');

    // jQuery Counter Up
    // --------------------------------------------------

    $('.counter').counterUp({
        delay: 10,
        time: 1000
    });

    // World Map
    // --------------------------------------------------

    var dataSale = {
        'AU': 12190,
        'AR': 3510,
        'BR': 2023,
        'CA': 1563,
        'CN': 5745,
        'FR': 2555,
        'DE': 3305,
        'JP': 5390,
        'RU': 2476,
        'US': 14624
    };
    var dataMapMarker = [{
        latLng: [41.90, 12.45],
        name: 'Vatican City',
        earnings: '500'
    }, {
        latLng: [43.73, 7.41],
        name: 'Monaco',
        earnings: '32'
    }, {
        latLng: [-0.52, 166.93],
        name: 'Nauru',
        earnings: '432'
    }, {
        latLng: [-8.51, 179.21],
        name: 'Tuvalu',
        earnings: '321'
    }, {
        latLng: [43.93, 12.46],
        name: 'San Marino',
        earnings: '510'
    }, {
        latLng: [47.14, 9.52],
        name: 'Liechtenstein',
        earnings: '130'
    }, {
        latLng: [7.11, 171.06],
        name: 'Marshall Islands',
        earnings: '234'
    }, {
        latLng: [17.3, -62.73],
        name: 'Saint Kitts and Nevis',
        earnings: '329'
    }, {
        latLng: [3.2, 73.22],
        name: 'Maldives',
        earnings: '120'
    }, {
        latLng: [35.88, 14.5],
        name: 'Malta',
        earnings: '435'
    }, {
        latLng: [12.05, -61.75],
        name: 'Grenada',
        earnings: '321'
    }, {
        latLng: [13.16, -61.23],
        name: 'Saint Vincent and the Grenadines',
        earnings: '110'
    }, {
        latLng: [13.16, -59.55],
        name: 'Barbados',
        earnings: '90'
    }, {
        latLng: [17.11, -61.85],
        name: 'Antigua and Barbuda',
        earnings: '230'
    }, {
        latLng: [-4.61, 55.45],
        name: 'Seychelles',
        earnings: '200'
    }, {
        latLng: [7.35, 134.46],
        name: 'Palau',
        earnings: '320'
    }, {
        latLng: [42.5, 1.51],
        name: 'Andorra',
        earnings: '123'
    }, {
        latLng: [14.01, -60.98],
        name: 'Saint Lucia',
        earnings: '500'
    }, {
        latLng: [6.91, 158.18],
        name: 'Federated States of Micronesia',
        earnings: '310'
    }, {
        latLng: [1.3, 103.8],
        name: 'Singapore',
        earnings: '23'
    }, {
        latLng: [1.46, 173.03],
        name: 'Kiribati',
        earnings: '58'
    }, {
        latLng: [-21.13, -175.2],
        name: 'Tonga',
        earnings: '90'
    }, {
        latLng: [15.3, -61.38],
        name: 'Dominica',
        earnings: '239'
    }, {
        latLng: [-20.2, 57.5],
        name: 'Mauritius',
        earnings: '100'
    }, {
        latLng: [26.02, 50.55],
        name: 'Bahrain',
        earnings: '225'
    }, {
        latLng: [0.33, 6.73],
        name: 'São Tomé and Príncipe',
        earnings: '150'
    }];
    $('#world-map').vectorMap({
        map: 'world_mill',
        backgroundColor: 'rgba(0,0,0,0)',
        zoomOnScroll: false,
        regionStyle: {
            initial: {
                fill: '#1F364F'
            }
        },
        markers: dataMapMarker,
        markerStyle: {
            initial: {
                fill: '#E5343D',
                stroke: '#E5343D',
                'fill-opacity': 1,
                'stroke-width': 10,
                'stroke-opacity': 0.2,
                r: 5
            },
            hover: {
                stroke: '#1F364F',
                'stroke-width': 2,
                cursor: 'pointer'
            }
        },
        onRegionTipShow: function(e, el, code) {
            if (dataSale.hasOwnProperty(code)) {
                el.html(el.html() + ' ($' + dataSale[code] + ')');
            }
        },
        onMarkerTipShow: function(e, el, code) {
            el.html(el.html() + ' ($' + dataMapMarker[code].earnings + ')');
        }
    });

    // New Orders
    // --------------------------------------------------

    var dataOrder = [
        [0, 57],
        [1, 58],
        [2, 93],
        [3, 11],
        [4, 40],
        [5, 93],
        [6, 29],
        [7, 19],
        [8, 87],
        [9, 14],
        [10, 130],
        [11, 91],
        [12, 80],
        [13, 49],
        [14, 59]
    ];
    var datasetOrder = [{
        label: 'Orders',
        data: dataOrder,
        color: '#FFB61E'
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
                fill: true,
                fillColor: '#FFB61E'
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

    // Total Revenue
    // --------------------------------------------------

    var dataRevenue = [
        [0, 755],
        [1, 1133],
        [2, 1234],
        [3, 1448],
        [4, 1198],
        [5, 918],
        [6, 583],
        [7, 842],
        [8, 540],
        [9, 665],
        [10, 1195],
        [11, 742],
        [12, 1040],
        [13, 682],
        [14, 1190]
    ];
    var datasetRevenue = [{
        label: 'Revenue',
        data: dataRevenue,
        color: '#E5343D'
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
                fill: true,
                fillColor: '#E5343D'
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

    // Visitor Chart
    // --------------------------------------------------

    var dataNewVisitor = [
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
    var dataReturningVisitor = [
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
    var xticksVisitor = [
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
    var datasetVisitor = [{
        label: 'New visitors',
        data: dataNewVisitor,
        color: '#E5343D',
        lines: {
            show: true,
            fill: 0.9,
            lineWidth: 0
        },
        curvedLines: {
            apply: true,
            monotonicFit: true
        }
    }, {
        data: dataNewVisitor,
        color: '#E5343D',
        lines: {
            show: true,
            lineWidth: 0
        }
    }, {
        label: 'Returning visitors',
        data: dataReturningVisitor,
        color: '#1F364F',
        lines: {
            show: true,
            fill: 0.9,
            lineWidth: 0
        },
        curvedLines: {
            apply: true,
            monotonicFit: true
        }
    }, {
        data: dataReturningVisitor,
        color: '#1F364F',
        lines: {
            show: true,
            lineWidth: 0
        }
    }];
    var optionsVisitor = {
        series: {
            curvedLines: {
                active: true
            },
            shadowSize: 0
        },
        grid: {
            borderWidth: 0,
            hoverable: true,
            labelMargin: 15
        },
        xaxis: {
            ticks: xticksVisitor,
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
            container: $('#flot-visitor-legend'),
            noColumns: 4,
            labelBoxBorderColor: '#FFF',
            margin: 0
        }
    };
    $.plot($('#flot-visitor'), datasetVisitor, optionsVisitor);
    $('#flot-visitor').bind('plothover', function(event, pos, item) {
        if (item) {
            $('.flotTip').text(item.datapoint[1].toFixed(0).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',') + ' visitors').css({
                top: item.pageY + 15,
                left: item.pageX + 10
            }).show();
        } else {
            $('.flotTip').hide();
        }
    });

    // Bootstrap Date Range Picker
    // --------------------------------------------------

    $('#daterangepicker').daterangepicker({
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
        endDate: moment(),
        applyClass: 'btn-raised btn-black',
        cancelClass: 'btn-raised btn-default'
    }, function(start, end, label) {
        $('#daterangepicker span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
    });
    $('#daterangepicker span').html(moment().subtract(29, 'days').format('MMMM D, YYYY') + ' - ' + moment().format('MMMM D, YYYY'));

    // Browser Chart
    // --------------------------------------------------

    Morris.Donut({
        element: 'morris-browser',
        data: [{
            label: 'Chrome',
            value: 40
        }, {
            label: 'Firefox',
            value: 35
        }, {
            label: 'IE',
            value: 25
        }],
        resize: true,
        colors: ['#1F364F', '#E5343D', '#E6E6E6'],
        formatter: function(x) {
            return x + '%';
        }
    });

    // New Comments
    // --------------------------------------------------

    $('#esp-comment').easyPieChart({
        barColor: '#FFB61E',
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
        }
    });

    table.buttons().container().appendTo('#order-table_wrapper .col-sm-6:eq(0)');

    // Upcoming Events
    // --------------------------------------------------

    $('.draggable li').each(function() {
        $(this).data('event', {
            title: $.trim($(this).text()),
            stick: true
        });
        $(this).draggable({
            zIndex: 999,
            revert: true,
            revertDuration: 0
        });
    });
    $('#fullcalendar').fullCalendar({
        header: {
            left: 'prev,next',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        buttonIcons: {
            prev: ' ti-angle-left',
            next: ' ti-angle-right'
        },
        defaultDate: '2016-03-15',
        editable: true,
        droppable: true,
        selectable: true,
        select: function(start, end, allDay) {
            $('#start').val(moment(start).format('YYYY/MM/DD hh:mm a'));
            $('#end').val(moment(end).format('YYYY/MM/DD hh:mm a'));
            $('#inputTitleEvent').val('');
            $('#addNewEvent').modal('show');
        },
        eventColor: '#E5343D',
        eventLimit: true,
        events: [{
            title: 'All Day Event',
            start: '2016-03-18',
            color: '#8E23E0'
        }, {
            title: 'Long Event',
            start: '2016-03-07',
            end: '2016-03-10',
            color: '#E5343D'
        }, {
            id: 999,
            title: 'Repeating Event',
            start: '2016-03-28T16:00:00',
            color: '#FFB61E'
        }, {
            id: 999,
            title: 'Repeating Event',
            start: '2016-03-16T16:00:00',
            color: '#FFB61E'
        }, {
            title: 'Conference',
            start: '2016-03-11',
            end: '2016-03-13',
            color: '#17A88B'
        }, {
            title: 'Meeting',
            start: '2016-03-12T10:30:00',
            end: '2016-03-12T12:30:00',
            color: '#0667D6'
        }, {
            title: 'Lunch',
            start: '2016-03-12T12:00:00',
            color: '#1F364F'
        }, {
            title: 'Meeting',
            start: '2016-03-12T14:30:00',
            color: '#E5343D'
        }, {
            title: 'Happy Hour',
            start: '2016-03-12T17:30:00',
            color: '#888888'
        }, {
            title: 'Dinner',
            start: '2016-03-12T20:00:00',
            color: '#0667D6'
        }, {
            title: 'Birthday Party',
            start: '2016-03-13T07:00:00',
            color: '#8E23E0'
        }, {
            title: 'Click for Google',
            url: 'http://google.com/',
            start: '2016-03-28',
            color: '#0667D6'
        }],
        drop: function() {
            if ($('#drop-remove').is(':checked')) {
                $(this).remove();
            }
        }
    });
    $('#btnAddNewEvent').on('click', function(e) {
        e.preventDefault();
        addNewEvent();
    });

    function addNewEvent() {
        $('#addNewEvent').modal('hide');
        $('#fullcalendar').fullCalendar('renderEvent', {
            title: $('#inputTitleEvent').val(),
            start: new Date($('#start').val()),
            end: new Date($('#end').val()),
            color: $('#inputBackgroundEvent').val()
        }, true);
    }

    // jQuery Minicolors
    // --------------------------------------------------

    $('#inputBackgroundEvent').minicolors({
        theme: 'bootstrap'
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