
$(function () {
    $('.SelectFlightLink').click(function () {
        var link = $(this);
        var flightnr = link.attr('data-flightnr');
        var arrival = link.attr('data-arrival');
        var departure = link.attr('data-departure');
        var arrdep = link.attr('data-arrdep');
        $('#FlightNumber').val(flightnr);
        $('#Arrival').val(arrival);
        $('#Departure').val(departure);
        $('#ArrDep').val(arrdep);
        $('#SelectFlightForm').submit();
        return false;
    });

});