﻿(function () {

$(function () { 
    let $wrapper = $('#wrapper');
    $wrapper.css('text-align', 'center');
    let $location = $('#location');
    let locations = [
        { "text": "سالن ۱", "seats": [25, 25, 25, 30, 20, 20, 15, 10,20,20,20] },
        { "text": "سالن ۲", "seats": [25, 25, 25, 30, 20, 20,20,15,20, 15, 10] },
        { "text": "سالن ۳", "seats": [25, 25, 25, 30, 30,15,15, 5] },
    ];

    let selected_seats = [];

    for (let ix in locations) {
        $('<option>')
            .val(ix)
            .html(locations[ix].text)
            .appendTo($location);
    }

    $("#cReserve").click(function () {

        $(this).toggleClass('btn-success').toggleClass('btn-warning');
        let $InputName = $("#InputName").val();
        let $InputLastName = $("#InputLastName").val();


        let $saloon = $('#location').val();
        var $seat = selected_seats[0];
        alert(seat);
        var seatstring ;
        for (var i = 0; i < selected_seats.length; i++) {
            var x = selected_seats[i];
            seatstring = x;
        }
        alert(seatstring);

        $.ajax({
            method: "Get",
            url: "/AjaxAction.aspx",
            data: { InputName: $InputName, InputLastName: $InputLastName, saloon: $saloon, seat: $seat }
        })
    });


    $location.on('change', function () {
        let selectedIndex = $location.val();
        
        


        if (selectedIndex !== -1) {
            $wrapper.html('');

            let seats = locations[selectedIndex].seats;
            for (let ix in seats) {

                let seat_buttons = $('<div>').addClass('col-md-11');
                for (var i = 0; i < seats[ix]; i++) {
                    seat_buttons.append(
                        $('<button>')
                            .addClass('btn btn-success btn-xs')
                            .html(i + 1)
                            .on('click', function () {

                                selected_seats.push(+$(this).html());
                                

                                $(this).toggleClass('btn-success').toggleClass('btn-warning');

                            })
                    );
                }


                $('<div>')
                    .addClass('row')
                    .append($('<div>').addClass('col-md-1').html(+ix + 1))
                    .append(seat_buttons).appendTo($wrapper);
            }
        }

    });


    });
 
}) ();