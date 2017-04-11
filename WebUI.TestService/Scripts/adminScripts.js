$(document).ready(function () {



    $('body').on('click', '.testLink', function () {

        var id = $(this).siblings('input').val();

        $('#testsSection').find("[name = 'testId']").val(id);

        $(this).closest('div.transition').css('left', '-100%');

        $('#getQuestions').submit();
    });





        $('body').on('click', '.questionLink', function () {

            var id = $(this).siblings('input').val();

            $('#questionsSection').find("[name = 'questionId']").val(id);

            $(this).closest('div.transition').css('left', '-200%');

            $('#getAnswers').submit();
        });




        $('body').on('click', '#backToTests', function () {

            $(this).closest('div.transition').css('left', '0%');
        });




        $('body').on('click', '#backToQuestions', function () {

            $(this).closest('div.transition').css('left', '-100%');
        });




        $('body').on('click', '.editButton', function () {

            var id = $(this).parent().siblings('.idVariable').attr('id');


            var form = $(this).closest('.section').find('.editForm');

            form.children('input').val(id);

            $(form).submit();

        });



        $('body').on('click', '.deleteButton', function () {

            var id = $(this).parent().siblings('.idVariable').attr('id');

            var form = $(this).closest('.section').find('.deleteForm');

            var name = form.children('input').attr('name');

            $("#testIdModal").attr('name', name)
            $("#testIdModal").val(id);

        });



    $('body').on('click', '.deleteButton', function (event) { 
        event.preventDefault(); 
        $('#overlay').fadeIn(400, 
            function () { 
                $('#modal_form')
                    .css('display', 'block') 
                    .animate({ opacity: 1, top: '50%' }, 200);
            });
    });


    $('.modal_close, #overlay').click(function () { 
        $('#modal_form')
            .animate({ opacity: 0, top: '45%' }, 200,  
                function () { 
                    $(this).css('display', 'none'); 
                    $('#overlay').fadeOut(400); 
                }
            );
    });


});
