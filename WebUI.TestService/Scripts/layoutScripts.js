
$(document).ready(function () {
    var title = $('title').text();

    var elems = $('#navbarCollapse').find('[id="' + title + '"]').attr('class', 'active');

});