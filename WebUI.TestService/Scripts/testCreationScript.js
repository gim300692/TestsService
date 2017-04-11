$(document).ready(function () {

    var answers = 0;
    var questions = 0;
    var questionId = 0;

    var createAnwser = $(function () {
        $('body').on('click', '.addAnswer', function () {
            answers++;
            questionId = $(this).closest('div.questionItem').attr('id');
            var AddAnswerToHtml =
            "<div class='input-group anwserItem'>" +
                 "<span class='input-group-addon'>" +
                    "<input type='checkbox' name='Answers[" + answers + "].IsCorrect' />" +
                 "</span>" +
                 "<input type='text' name='Answers[" + answers + "].AnswerContent' class = 'form-control', placeholder='Введите вариант ответа'/>" +
                 "<input type='hidden' name='Answers[" + answers + "].QuestionId' value=' " + questionId + "' />" +
            "</div>";


            $(this).closest('div.answersBlock').append(AddAnswerToHtml);
        })
    })

        $('body').on('click', ".addQuestion", function () {

            questions++;

            var AddQuestionToHtml =
            "<div class='panel panel-default'>" +
                "<div class='panel-heading'>" +
                    "<h3 class='panel-title'>Вопрос №" + (questions + 1) + "</h3>" +
                "</div>" +
                "<div class='questionBlock panel-body'>" +
                    "<div class='questionItem'" + 'id=' + questions + ">" +
                        "<div class='input-group'>" +
                            "<span class='input-group-addon'>Содержание вопроса</span>" +
                            "<textarea cols='20' class = 'form-control' placeholder = 'Содержание вопроса' name='Questions[" + questions + "].QuestionContent' rows='2' />" +
                            "<input type='hidden' name='Questions[" + questions + "].Id' value=' " + questions + "' />" +
                            "<input type='hidden' name='Questions[" + questions + "].Index' value=' " + (questions + 1) + "' />" +
                        "</div>" +
                        "<div class='answersBlock' data-correct-max='1'>" +
                            "<div class='btn-group-sm'>" +
                                "<button type='button' class='btn btn-default addAnswer'>Добавить вариант ответа</button>" +
                            "</div>" +
                        "</div>" +
                    "</div>" +
                    "<div class='btn-group'>" +
                        "<button type='button' class='btn btn-default saveQuestion'>Сохранить вопрос</button>" +
                    "</div>" +
                "</div>" +
            "</div>";

            $('#questionAndAnswerBlock').append(AddQuestionToHtml);
        })


        $('body').on('click', "[type='checkbox']", function () {
            var $block = $(this).parents('[data-correct-max]');
            if ($block.find(':checked').length > $block.data('correct-max')) {
                this.checked = false;
            }
        })

        $('body').on('click', "[type='checkbox']", function () {
            if ($(this).prop('checked')) {
                $(this).val("true");
            }
            else
                $(this).val("false");
        })


        if ($('body').on('click', ".saveQuestion", function () {

            var cb = $(this).parent().siblings('.questionItem').find(':checkbox:checked')

        if (cb.length < 1) {
            //$(this).parent().siblings('.questionItem').append('<p>Должен быть выбран хотя бы один вариант ответа!</p>') Криво! Переделать!
        }
        else {
            var id = $(this).parent().siblings('.questionItem').attr('id');

            if ($("[class = 'questionItem']" + "[id = " + id + "]").is(":visible")) {
                $("[class = 'questionItem']" + "[id = " + id + "]").slideToggle("slow");
                 $(this).text("Корректировать вопрос");
        }
        else {
                $(this).text("Сохранить вопрос");
                $("[class = 'questionItem']" + "[id = " + id + "]").slideToggle("slow");
        }
        }


        }
            ));

})
