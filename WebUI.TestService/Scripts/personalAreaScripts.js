$(document).ready(function () {

        $('body').on('click', '.editTest', function () {
            var id = $(this).closest('.panel-heading').attr('id');
            $(this).val(id);
        })


        $('body').on('click', '#go', function () {
            var testId = $("#testId").val();
            $("#testIdModal").val(testId);
        })


        $('#go').click(function (event) { 
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
})