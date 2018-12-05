$(document).ready(function() {

    // Basic Views
    // --------------------------------------------------

    $('#basic-fc').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,basicWeek,basicDay'
        },
        buttonIcons: {
            prev: ' ti-angle-left',
            next: ' ti-angle-right'
        },
        defaultDate: '2016-03-15',
        editable: true,
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
        }]
    });

    // Internationalization
    // --------------------------------------------------

    var currentLangCode = 'en';
    $.each($.fullCalendar.langs, function(langCode) {
        $('#lang-selector').append($('<option/>').attr('value', langCode).prop('selected', langCode == currentLangCode).text(langCode));
    });

    $('#lang-selector').on('change', function() {
        if (this.value) {
            currentLangCode = this.value;
            $('#internationalization-fc').fullCalendar('destroy');
            renderCalendar();
        }
    });

    function renderCalendar() {
        $('#internationalization-fc').fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay'
            },
            defaultDate: '2016-03-15',
            lang: currentLangCode,
            buttonIcons: false,
            weekNumbers: true,
            editable: true,
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
            }]
        });
    }
    renderCalendar();

    // Google Calendar
    // --------------------------------------------------

    $('#google-fc').fullCalendar({
        buttonIcons: {
            prev: ' ti-angle-left',
            next: ' ti-angle-right'
        },
        defaultDate: '2016-03-15',
        eventColor: '#1F364F',
        // THIS KEY WON'T WORK IN PRODUCTION!!!
        // To make your own Google API key, follow the directions here:
        // http://fullcalendar.io/docs/google_calendar/
        googleCalendarApiKey: 'AIzaSyDcnW6WejpTOCffshGDDb4neIrXVUA1EAE',
        events: 'usa__en@holiday.calendar.google.com',
        eventClick: function(event) {
            window.open(event.url, 'gcalevent', 'width=700,height=600');
            return false;
        }
    });

    // Selecting Time Ranges
    // --------------------------------------------------

    $('#time-ranges-fc').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        buttonIcons: {
            prev: ' ti-angle-left',
            next: ' ti-angle-right'
        },
        defaultDate: '2016-03-15',
        selectable: true,
        selectHelper: true,
        select: function(start, end) {
            var title = prompt('Event Title:');
            var eventData;
            if (title) {
                eventData = {
                    title: title,
                    start: start,
                    end: end
                };
                $('#time-ranges-fc').fullCalendar('renderEvent', eventData, true);
            }
            $('#time-ranges-fc').fullCalendar('unselect');
        },
        eventColor: '#1F364F',
        editable: true,
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
        }]
    });

    // Background Events
    // --------------------------------------------------

    $('#bg-events-fc').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        buttonIcons: {
            prev: ' ti-angle-left',
            next: ' ti-angle-right'
        },
        defaultDate: '2016-03-15',
        businessHours: true,
        editable: true,
        events: [{
            title: 'Business Lunch',
            start: '2016-03-03T13:00:00',
            constraint: 'businessHours',
            color: '#8E23E0'
        }, {
            title: 'Meeting',
            start: '2016-03-13T11:00:00',
            constraint: 'availableForMeeting',
            color: '#17A88B'
        }, {
            title: 'Conference',
            start: '2016-03-18',
            end: '2016-03-20',
            color: '#0667D6'
        }, {
            title: 'Party',
            start: '2016-03-29T20:00:00',
            color: '#8E23E0'
        }, {
            id: 'availableForMeeting',
            start: '2016-03-11T10:00:00',
            end: '2016-03-11T16:00:00',
            rendering: 'background'
        }, {
            id: 'availableForMeeting',
            start: '2016-03-13T10:00:00',
            end: '2016-03-13T16:00:00',
            rendering: 'background'
        }, {
            start: '2016-03-24',
            end: '2016-03-28',
            overlap: false,
            rendering: 'background',
            color: '#0667D6'
        }, {
            start: '2016-03-06',
            end: '2016-03-08',
            overlap: false,
            rendering: 'background',
            color: '#0667D6'
        }]
    });

    // External Events
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
        eventColor: '#1F364F',
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

});