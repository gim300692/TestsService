$(document).ready(function () {

    $('.timer').startTimer({
        onComplete: function () {
            $('#mainForm').submit();
        }
    });

    $('#nextQuestion').on('click', function () {
        var $block = $('input:checked').attr('id');
        $('#CurrentAnswer').val($block);
    });

    $('body').on('click', "[type='checkbox']", function () {
        if ($('#questionAnswers').find(':checked').length > 1) {
            this.checked = false;
        }
    });


    $('#ajaxBlock').on('DOMSubtreeModified', function () {

        var ans = $('[name="correctAnswersCount"]').val();
        $('[name="CorrectAnswersCount"]').val(ans);

        if ($('#qIndex').text() == $('#qQuantity').text()) {
            $('#nextQuestion').text("Завершить тест");
        };

        if ($('#finish').is(':visible')) {
            $('#nextQuestion').hide();

            var corr = $('#total').val();
            $('[name="CorrectAnswersCount"]').val(corr);

            $('#finishTest').show();
        };
    });


});
