var gulp = require('gulp');
var browserSync = require('browser-sync').create();
var jade = require('gulp-jade');
var less = require('gulp-less');
var uglify = require('gulp-uglify');
var cleanCSS = require('gulp-clean-css');

gulp.task('browser-sync', function() {
	browserSync.init({
		proxy: 'localhost/Umega'
	});
	gulp.watch(['assets/less/*.less', 'assets/less/**/*.less'], ['less']);
	gulp.watch(['assets/jade/*.jade', 'assets/jade/**/*.jade'], ['jade']);
	gulp.watch(['assets/js/*.js', 'assets/js/**/*.js'], ['js']);
});

gulp.task('jade', function() {
	gulp.src(['assets/jade/fourth-layout/documentation/*.jade', 'assets/jade/fourth-layout/extra-pages/*.jade'])
		.pipe(jade({
			pretty: true
		}))
		.pipe(gulp.dest('fourth-layout'))
		.pipe(browserSync.stream());
});

gulp.task('less', function() {
	gulp.src(['assets/less/first-layout/first-layout.less'])
		.pipe(less())
		.pipe(cleanCSS())
		.pipe(gulp.dest('build/css'))
		.pipe(browserSync.stream());
});

gulp.task('js', function() {
	gulp.src(['assets/js/first-layout/*.js'])
		.pipe(uglify())
		.pipe(gulp.dest('build/js/first-layout'))
		.pipe(browserSync.stream());
});

gulp.task('default', ['browser-sync'], function() {
	console.log('**** Umega - Responsive web app kit ****');
	console.log('* Start less compiler                  *');
	console.log('* Start jade compiler                  *');
	console.log('* Minify/compress css/js               *');
	console.log('* Automatically live reload            *');
	console.log('****************************************');
});