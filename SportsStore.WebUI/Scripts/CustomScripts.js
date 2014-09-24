$(document).ready(function () {
    console.log('triggered');
    $(".clampString").dotdotdot({
        /*	The HTML to add as ellipsis. */
        ellipsis: '... ',

        /*	How to cut off the text/html: 'word'/'letter'/'children' */
        wrap: 'word',

        ///*	Wrap-option fallback to 'letter' for long words */
        //fallbackToLetter: true,

        ///*	jQuery-selector for the element to keep and put after the ellipsis. */
        //after: null,

        ///*	Whether to update the ellipsis: true/'window' */
        //watch: false,

        ///*	Optionally set a max-height, if null, the height will be measured. */
        //height: null,

        ///*	Deviation for the height-option. */
        //tolerance: 0,

        ///*	Callback function that is fired after the ellipsis is added,
		//	receives two parameters: isTruncated(boolean), orgContent(string). */
        //callback: function (isTruncated, orgContent) { },

        //lastCharacter: {

        //    /*	Remove these characters from the end of the truncated text. */
        //    remove: [' ', ',', ';', '.', '!', '?'],

        //    /*	Don't add an ellipsis if this array contains 
		//		the last character of the truncated text. */
        //    noEllipsis: []
        //}
    });

    //Please make sure the below two lines are the last lines of code of this file
    //These lines of code are to avoid resizing of the grid divs on the final page
    $('.thumbnail').css('height', '390px');
    $('.thumbnail').css('width', '230px');
    $('.clampString').css('height','50px');
});