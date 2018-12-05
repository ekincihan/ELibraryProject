$(document).ready(function() {

	// Bootstrap Maxlength
	// --------------------------------------------------

	$('#default-ml').maxlength();
	$('#threshold-ml').maxlength({
		threshold: 20
	});
	$('#few-ml').maxlength({
		alwaysShow: true,
		threshold: 10,
		warningClass: 'label label-info',
		limitReachedClass: 'label label-warning'
	});
	$('#all-ml').maxlength({
		alwaysShow: true,
		threshold: 10,
		warningClass: 'label label-success',
		limitReachedClass: 'label label-danger',
		separator: ' of ',
		preText: 'You have ',
		postText: ' chars remaining.',
		validate: true
	});
	$('#textarea-ml').maxlength({
		alwaysShow: true
	});
	$('#position-ml').maxlength({
		alwaysShow: true,
		placement: 'centered-right'
	});

	// Bootstrap TouchSpin
	// --------------------------------------------------

	$('#postfix-ts').TouchSpin({
		min: 0,
		max: 100,
		step: 0.1,
		decimals: 2,
		boostat: 5,
		maxboostedstep: 10,
		postfix: '%',
		buttondown_class: 'btn btn-outline btn-default',
		buttonup_class: 'btn btn-outline btn-default'
	});

	$('#prefix-ts').TouchSpin({
		min: -1000000000,
		max: 1000000000,
		stepinterval: 50,
		maxboostedstep: 10000000,
		prefix: '$',
		buttondown_class: 'btn btn-outline btn-default',
		buttonup_class: 'btn btn-outline btn-default'
	});

	$('#vertical-ts').TouchSpin({
		verticalbuttons: true,
		buttondown_class: 'btn btn-outline btn-default',
		buttonup_class: 'btn btn-outline btn-default'
	});

	$('#icon-ts').TouchSpin({
		verticalbuttons: true,
		verticalupclass: 'ti-plus',
		verticaldownclass: 'ti-minus',
		buttondown_class: 'btn btn-outline btn-default',
		buttonup_class: 'btn btn-outline btn-default'
	});

	$('#empty-ts').TouchSpin({
		buttondown_class: 'btn btn-outline btn-default',
		buttonup_class: 'btn btn-outline btn-default'
	});

	$('#initval-ts').TouchSpin({
		initval: 40,
		buttondown_class: 'btn btn-outline btn-default',
		buttonup_class: 'btn btn-outline btn-default'
	});

	$('#explicitly-ts').TouchSpin({
		initval: 40,
		buttondown_class: 'btn btn-outline btn-default',
		buttonup_class: 'btn btn-outline btn-default'
	});

	$('#small-ts').TouchSpin({
		postfix: 'a button',
		buttondown_class: 'btn btn-outline btn-default',
		buttonup_class: 'btn btn-outline btn-default'
	});

	$('#large-ts').TouchSpin({
		postfix: 'a button',
		buttondown_class: 'btn btn-outline btn-default',
		buttonup_class: 'btn btn-outline btn-default'
	});

	$('#group-ts').TouchSpin({
		buttondown_class: 'btn btn-outline btn-default',
		buttonup_class: 'btn btn-outline btn-default'
	});

	new BootstrapMenu('#basic-menu', {
		actions: [{
			name: 'Action',
			iconClass: 'fa-pencil',
			onClick: function() {
				toastr.info('\'Action\' clicked!', 'Welcome to BootstrapMenu');
			}
		}, {
			name: 'Another action',
			iconClass: 'fa-lock',
			onClick: function() {
				toastr.info('\'Another action\' clicked!', 'Welcome to BootstrapMenu');
			}
		}, {
			name: 'A third action',
			iconClass: 'fa-trash-o',
			onClick: function() {
				toastr.info('\'A third action\' clicked!', 'Welcome to BootstrapMenu');
			}
		}]
	});

	// Bootstrap Tags Input
	// --------------------------------------------------

	var citynames = new Bloodhound({
		datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
		queryTokenizer: Bloodhound.tokenizers.whitespace,
		prefetch: {
			url: '../assets/data/citynames.json',
			filter: function(list) {
				return $.map(list, function(cityname) {
					return {
						name: cityname
					};
				});
			}
		}
	});
	citynames.initialize();

	$('#typeahead-ti').tagsinput({
		typeaheadjs: {
			name: 'citynames',
			displayKey: 'name',
			valueKey: 'name',
			source: citynames.ttAdapter()
		}
	});

	var cities = new Bloodhound({
		datumTokenizer: Bloodhound.tokenizers.obj.whitespace('text'),
		queryTokenizer: Bloodhound.tokenizers.whitespace,
		prefetch: '../assets/data/cities.json'
	});
	cities.initialize();

	var elt = $('#categorizing-ti');
	elt.tagsinput({
		tagClass: function(item) {
			switch (item.continent) {
				case 'Europe':
					return 'label label-primary';
				case 'America':
					return 'label label-danger label-important';
				case 'Australia':
					return 'label label-success';
				case 'Africa':
					return 'label label-default';
				case 'Asia':
					return 'label label-warning';
				default:
					return 'label label-default';
			}
		},
		itemValue: 'value',
		itemText: 'text',
		typeaheadjs: {
			name: 'cities',
			displayKey: 'text',
			source: cities.ttAdapter()
		}
	});
	elt.tagsinput('add', {
		'value': 1,
		'text': 'Amsterdam',
		'continent': 'Europe'
	});
	elt.tagsinput('add', {
		'value': 4,
		'text': 'Washington',
		'continent': 'America'
	});
	elt.tagsinput('add', {
		'value': 7,
		'text': 'Sydney',
		'continent': 'Australia'
	});
	elt.tagsinput('add', {
		'value': 10,
		'text': 'Beijing',
		'continent': 'Asia'
	});
	elt.tagsinput('add', {
		'value': 13,
		'text': 'Cairo',
		'continent': 'Africa'
	});
});