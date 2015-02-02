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
    $('.clampString').css('height', '50px');
    //Star rating code
    $('#stars').on('starrr:change', function (e, value) {
        $('#count').html(value);
    });

    $('#stars-existing').on('starrr:change', function (e, value) {
        $('#count-existing').html(value);
    });
    //Code for Country State City Cascading drop down list
    
        debugger;
        //Dropdownlist SelectedChange event
        $("#CountryID").change(function () {
            $("#StateID").empty();
            $.ajax({
                type: 'POST',
                url: '/Cart/GetStates',
                dataType: 'json',
                data: { CountryID: $("#CountryID").val() },
                success: function (states) {
                    $.each(states, function (i, state) {
                        $("#StateID").append('<option value="' + state.Value + '">' + state.Text + '</option>');
                    });
                },
                error: function (ex) {
                    alert('Failed to retreive states.' + ex);
                }
            });
            return false;
        })
        $("#StateID").change(function () {
            $("#CityID").empty();
            $.ajax({
                type: 'POST',
                url: '/Cart/GetCities',
                dataType: 'json',
                data: { StateID: $("#StateID").val() },
                success: function (cities) {
                    $.each(cities, function (i, city) {
                        $("#CityID").append('<option value="' + city.Value + '">' + city.Text + '</option>');
                    });
                },
                error: function (ex) {
                    alert('Failed to retreive states.' + ex);
                }
            });
            return false;
        })
    
});
//Code below for star rating
var __slice = [].slice;

(function ($, window) {
    var Starrr;

    Starrr = (function () {
        Starrr.prototype.defaults = {
            rating: void 0,
            numStars: 5,
            change: function (e, value) { }
        };

        function Starrr($el, options) {
            var i, _, _ref,
                _this = this;

            this.options = $.extend({}, this.defaults, options);
            this.$el = $el;
            _ref = this.defaults;
            for (i in _ref) {
                _ = _ref[i];
                if (this.$el.data(i) != null) {
                    this.options[i] = this.$el.data(i);
                }
            }
            this.createStars();
            this.syncRating();
            this.$el.on('mouseover.starrr', 'i', function (e) {
                return _this.syncRating(_this.$el.find('i').index(e.currentTarget) + 1);
            });
            this.$el.on('mouseout.starrr', function () {
                return _this.syncRating();
            });
            this.$el.on('click.starrr', 'i', function (e) {
                return _this.setRating(_this.$el.find('i').index(e.currentTarget) + 1);
            });
            this.$el.on('starrr:change', this.options.change);
        }

        Starrr.prototype.createStars = function () {
            var _i, _ref, _results;

            _results = [];
            for (_i = 1, _ref = this.options.numStars; 1 <= _ref ? _i <= _ref : _i >= _ref; 1 <= _ref ? _i++ : _i--) {
                _results.push(this.$el.append("<i class='fa fa-star-o'></i>"));
            }
            return _results;
        };

        Starrr.prototype.setRating = function (rating) {
            if (this.options.rating === rating) {
                rating = void 0;
            }
            this.options.rating = rating;
            this.syncRating();
            return this.$el.trigger('starrr:change', rating);
        };

        Starrr.prototype.syncRating = function (rating) {
            var i, _i, _j, _ref;

            rating || (rating = this.options.rating);
            if (rating) {
                for (i = _i = 0, _ref = rating - 1; 0 <= _ref ? _i <= _ref : _i >= _ref; i = 0 <= _ref ? ++_i : --_i) {
                    this.$el.find('i').eq(i).removeClass('fa-star-o').addClass('fa-star');
                }
            }
            if (rating && rating < 5) {
                for (i = _j = rating; rating <= 4 ? _j <= 4 : _j >= 4; i = rating <= 4 ? ++_j : --_j) {
                    this.$el.find('i').eq(i).removeClass('fa-star').addClass('fa-star-o');
                }
            }
            if (!rating) {
                return this.$el.find('i').removeClass('fa-star').addClass('fa-star-o');
            }
        };

        return Starrr;

    })();
    return $.fn.extend({
        starrr: function () {
            var args, option;

            option = arguments[0], args = 2 <= arguments.length ? __slice.call(arguments, 1) : [];
            return this.each(function () {
                var data;

                data = $(this).data('star-rating');
                if (!data) {
                    $(this).data('star-rating', (data = new Starrr($(this), option)));
                }
                if (typeof option === 'string') {
                    return data[option].apply(data, args);
                }
            });
        }
    });
})(window.jQuery, window);

$(function () {
    return $(".starrr").starrr();
});
//Code for star rating ends
//Code for Product Quick View page starts
(function ($) {
    $('#thumbcarousel').carousel(0);
    var $thumbItems = $('#thumbcarousel .item');
    $('#carousel').on('slide.bs.carousel', function (event) {
        var $slide = $(event.relatedTarget);
        var thumbIndex = $slide.data('thumb');
        var curThumbIndex = $thumbItems.index($thumbItems.filter('.active').get(0));
        if (curThumbIndex > thumbIndex) {
            $('#thumbcarousel').one('slid.bs.carousel', function (event) {
                $('#thumbcarousel').carousel(thumbIndex);
            });
            if (curThumbIndex === ($thumbItems.length - 1)) {
                $('#thumbcarousel').carousel('next');
            } else {
                $('#thumbcarousel').carousel(numThumbItems - 1);
            }
        } else {
            $('#thumbcarousel').carousel(thumbIndex);
        }
    });
})(jQuery);






