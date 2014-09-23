$(document).ready(function () {
    $('.thumbnail').hover(function () {
        $(this).find('.slideDownCaption').css('opacity', '1');
    }, function () {
        $(this).find('.slideDownCaption').css('opacity', '0');
    });    
});