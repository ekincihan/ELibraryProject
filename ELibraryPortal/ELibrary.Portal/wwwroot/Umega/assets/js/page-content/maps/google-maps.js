$(document).ready(function() {
	function initialize() {

		// Simple map
		// --------------------------------------------------
		var simpleMapProp = {
			center: new google.maps.LatLng(34.052234, -118.243685),
			zoom: 10,
			mapTypeId: google.maps.MapTypeId.ROADMAP
		};
		var simpleMap = new google.maps.Map(document.getElementById('simpleMap'), simpleMapProp);

		// Weather map
		// --------------------------------------------------
		var weatherMapProp = {
			zoom: 10,
			center: new google.maps.LatLng(34.052234, -118.243685)
		};
		var weatherMap = new google.maps.Map(document.getElementById('weatherMap'), weatherMapProp);
		var weatherLayer = new google.maps.weather.WeatherLayer({
			temperatureUnits: google.maps.weather.TemperatureUnit.FAHRENHEIT
		});
		weatherLayer.setMap(weatherMap);
		var cloudLayer = new google.maps.weather.CloudLayer();
		cloudLayer.setMap(weatherMap);

		// Traffic Map
		// --------------------------------------------------
		var trafficMapProp = {
			zoom: 10,
			center: new google.maps.LatLng(34.052234, -118.243685)
		};
		var trafficMap = new google.maps.Map(document.getElementById('trafficMap'), trafficMapProp);
		var trafficLayer = new google.maps.TrafficLayer();
		trafficLayer.setMap(trafficMap);

		// Transit Map
		// --------------------------------------------------
		var transitMapProp = {
			zoom: 10,
			center: new google.maps.LatLng(34.052234, -118.243685)
		};
		var transitMap = new google.maps.Map(document.getElementById('transitMap'), transitMapProp);
		var transitLayer = new google.maps.TransitLayer();
		transitLayer.setMap(transitMap);

		// Styled Map
		// --------------------------------------------------

		var styledProp = {
			center: new google.maps.LatLng(34.052234, -118.243685),
			zoom: 10,
			mapTypeId: google.maps.MapTypeId.ROADMAP,
			styles: [{
				'featureType': 'water',
				'elementType': 'geometry',
				'stylers': [{
					'color': '#004358'
				}]
			}, {
				'featureType': 'landscape',
				'elementType': 'geometry',
				'stylers': [{
					'color': '#1f8a70'
				}]
			}, {
				'featureType': 'poi',
				'elementType': 'geometry',
				'stylers': [{
					'color': '#1f8a70'
				}]
			}, {
				'featureType': 'road.highway',
				'elementType': 'geometry',
				'stylers': [{
					'color': '#fd7400'
				}]
			}, {
				'featureType': 'road.arterial',
				'elementType': 'geometry',
				'stylers': [{
					'color': '#1f8a70'
				}, {
					'lightness': -20
				}]
			}, {
				'featureType': 'road.local',
				'elementType': 'geometry',
				'stylers': [{
					'color': '#1f8a70'
				}, {
					'lightness': -17
				}]
			}, {
				'elementType': 'labels.text.stroke',
				'stylers': [{
					'color': '#ffffff'
				}, {
					'visibility': 'on'
				}, {
					'weight': 0.9
				}]
			}, {
				'elementType': 'labels.text.fill',
				'stylers': [{
					'visibility': 'on'
				}, {
					'color': '#ffffff'
				}]
			}, {
				'featureType': 'poi',
				'elementType': 'labels',
				'stylers': [{
					'visibility': 'simplified'
				}]
			}, {
				'elementType': 'labels.icon',
				'stylers': [{
					'visibility': 'off'
				}]
			}, {
				'featureType': 'transit',
				'elementType': 'geometry',
				'stylers': [{
					'color': '#1f8a70'
				}, {
					'lightness': -10
				}]
			}, {}, {
				'featureType': 'administrative',
				'elementType': 'geometry',
				'stylers': [{
					'color': '#1f8a70'
				}, {
					'weight': 0.7
				}]
			}]
		};
		var styledMap = new google.maps.Map(document.getElementById('styledMap'), styledProp);

		// Street View Map
		// --------------------------------------------------
		var panoMapProp = {
			position: new google.maps.LatLng(34.052234, -118.243685),
			addressControlOptions: {
				position: google.maps.ControlPosition.BOTTOM
			},
			linksControl: false,
			panControl: false,
			zoomControlOptions: {
				style: google.maps.ZoomControlStyle.SMALL
			},
			enableCloseButton: false
		};
		var panorama = new google.maps.StreetViewPanorama(document.getElementById('streetviewMap'), panoMapProp);
	}
	google.maps.event.addDomListener(window, 'load', initialize);
});