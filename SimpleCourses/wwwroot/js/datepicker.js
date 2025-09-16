$(function () {
    function WireUpDatePicker() {
        var addMonths = 2;
        var currentDate = new Date();

        $('.datepicker').datepicker({
            dateFormat: 'yy-mm-dd',
            minDate: currentDate,
            maxDate: AddSubtractMonths(currentDate, addMonths)
        });
    }

    WireUpDatePicker();
});