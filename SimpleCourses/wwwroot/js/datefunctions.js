function AddSubtractMonths(date, numMonths) {
    var month = date.getMonth(); // 0 = jan
    var milliSeconds = new Date(date).setMonth(month + numMonths);
    return new Date(milliSeconds);
}