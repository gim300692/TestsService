$.datetimepicker.setLocale('ru');
$('#datetimepicker').datetimepicker();

$('#datetimepicker2').datetimepicker({
    datepicker: false,
    format: 'H:i',
    lang: 'ru',
    minDate: '-1970/01/01'
});