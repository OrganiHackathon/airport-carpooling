
$(function () {
    var effectTime = 300; // ms

    $('#LocationFrom').change(function () {
        var value = $(this).val();
        if (value == 'Other address') {
            $('#OtherAddressFrom').show(effectTime);
        } else {
            $('#OtherAddressFrom').hide(effectTime);
        }
    });
    $('#LocationTo').change(function () {
        var value = $(this).val();
        if (value == 'Other address') {
            $('#OtherAddressTo').show(effectTime);
        } else {
            $('#OtherAddressTo').hide(effectTime);
        }
    });
    $('#Driver').change(function () {
        var value = $(this).is(':checked');
        if (value) {
            $('#DriverFields').show(effectTime);
        } else {
            $('#DriverFields').hide(effectTime);
        }
    });
    if ($('#LocationFrom').length > 0) {
        $('#LocationFrom').trigger('change');
        $('#LocationTo').trigger('change');
        $('#Driver').trigger('change');
    }
});