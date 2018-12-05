$(document).ready(function() {

	// jQuery Minicolors
	// --------------------------------------------------

	$('#hue-minicolors').minicolors({
		theme: 'bootstrap'
	});

	$('#saturation-minicolors').minicolors({
		control: 'saturation',
		theme: 'bootstrap'
	});

	$('#brightness-minicolors').minicolors({
		control: 'brightness',
		theme: 'bootstrap'
	});

	$('#wheel-minicolors').minicolors({
		control: 'wheel',
		theme: 'bootstrap'
	});

	$('#text-minicolors').minicolors({
		theme: 'bootstrap'
	});

	$('#hidden-minicolors').minicolors({
		theme: 'bootstrap'
	});

	$('#inline-minicolors').minicolors({
		inline: true,
		theme: 'bootstrap'
	});

	$('#bottom-left-minicolors').minicolors({
		theme: 'bootstrap'
	});

	$('#bottom-right-minicolors').minicolors({
		position: 'bottom right',
		theme: 'bootstrap'
	});

	$('#top-left-minicolors').minicolors({
		position: 'top left',
		theme: 'bootstrap'
	});

	$('#top-right-minicolors').minicolors({
		position: 'top right',
		theme: 'bootstrap'
	});

	$('#rgb-minicolors').minicolors({
		format: 'rgb',
		theme: 'bootstrap'
	});

	$('#rgba-minicolors').minicolors({
		format: 'rgb',
		opacity: 0.8,
		theme: 'bootstrap'
	});

	$('#opacity-minicolors').minicolors({
		opacity: true,
		theme: 'bootstrap'
	});

	$('#keywords-minicolors').minicolors({
		keywords: 'transparent',
		theme: 'bootstrap'
	});

	$('#default-value-minicolors').minicolors({
		defaultValue: '#3498db',
		theme: 'bootstrap'
	});

	$('#letter-case-minicolors').minicolors({
		letterCase: 'uppercase',
		theme: 'bootstrap'
	});

	$('#input-group-minicolors').minicolors({
		theme: 'bootstrap'
	});

	$('#more-input-group-minicolors').minicolors({
		theme: 'bootstrap'
	});

	// Bootstrap Color Picker Sliders
	// --------------------------------------------------

	$('#hsvflat').ColorPickerSliders({
		color: 'rgb(155, 89, 182)',
		flat: true,
		sliders: false,
		swatches: false,
		hsvpanel: true
	});

	$('#top').ColorPickerSliders({
		placement: 'top',
		size: 'sm',
		swatches: false,
		order: {
			hsl: 1
		}
	});

	$('#left').ColorPickerSliders({
		placement: 'left',
		size: 'sm',
		swatches: false,
		order: {
			hsl: 1
		}
	});

	$('#bottom').ColorPickerSliders({
		placement: 'bottom',
		size: 'sm',
		swatches: false,
		order: {
			hsl: 1
		}
	});

	$('#right').ColorPickerSliders({
		placement: 'right',
		size: 'sm',
		swatches: false,
		order: {
			hsl: 1
		}
	});

	$('#hslflat').ColorPickerSliders({
		color: 'rgb(26, 188, 156)',
		flat: true,
		order: {
			hsl: 1,
			cie: 2,
			preview: 3
		}
	});

	$('#small').ColorPickerSliders({
		size: 'sm',
		swatches: false,
		order: {
			hsl: 1
		}
	});

	$('#smallhsv').ColorPickerSliders({
		size: 'sm',
		swatches: false,
		sliders: false,
		hsvpanel: true
	});

	$('#default').ColorPickerSliders({
		swatches: false,
		order: {
			rgb: 1
		}
	});

	$('#large').ColorPickerSliders({
		size: 'lg',
		swatches: false,
		order: {
			cie: 1
		}
	});

	$('#swatchesonly').ColorPickerSliders({
		color: '#f1c40f',
		swatches: ['#1abc9c', '#2ecc71', '#3498db', '#9b59b6', '#e67e22', '#e74c3c', '#f1c40f', '#34495e'],
		customswatches: false,
		order: {}
	});

	$('#hslswatches').ColorPickerSliders({
		order: {
			hsl: 1,
			opacity: 2
		}
	});

});