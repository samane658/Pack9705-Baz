(function () {

$(function () { 
    let $wrapper = $('#wrapper');
    $wrapper.css('text-align', 'center');
    let $location = $('#location');
    let locations = [
        { "text": "سالن ۱", "seats": [25, 25, 25, 30, 20, 20, 15, 10,20,20,20] },
        { "text": "سالن ۲", "seats": [25, 25, 25, 30, 20, 20,20,15,20, 15, 10] },
        { "text": "سالن ۳", "seats": [25, 25, 25, 30, 30,15,15, 5] },
    ];

    var selected_seats = [];

    for (let ix in locations) {
        $('<option>')
            .val(ix)
            .html(locations[ix].text)
            .appendTo($location);
    }

   


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


    $("#cReserve").click(function () {

        $(this).toggleClass('btn-success').toggleClass('btn-warning');
        let $InputName = $("#InputName").val();
        let $InputLastName = $("#InputLastName").val();


        let $saloon = $('#location').val();
        
           $.ajax({
                method: "Get",
                url: "/AjaxAction.aspx",
                data: { InputName: $InputName, InputLastName: $InputLastName, saloon: $saloon, seat: selected_seats[0] }
            })
      /*  $.ajax({
            method: "Post"
            ,url: "/AjaxAction.aspx"
            , contentType: 'application/json'
            , dataType: 'json'
            , data: { seat: selected_seats[0], InputName: $InputName, InputLastName: $InputLastName, saloon: $saloon }
   
        })*/
    });







    });
 
}) ();