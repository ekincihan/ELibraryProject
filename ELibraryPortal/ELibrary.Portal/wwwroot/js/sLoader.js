function SpinLoader(process) {
    if (process) {
        $('.ecd').fadeIn(); // will first fade out the loading animation
    }
    else {
        $('.ecd').delay(210).fadeOut('slow');
    }
}