var admin = {
    init: function () {
        admin.registerEvents();
    },
    registerEvents: function () {
        $('.book').off('click').on('click', function (event) {
            event.preventDefault();
            $('#body').scrollTop(100);

            var idBook = $(this).data('id');
            var bookDetail = $("#bookDetail");

            $.ajax({
                type: "POST",
                url: "/Admin/AdminHome/bookDetail",
                data: {
                    "idBook": idBook
                },
                success: function (response) {

                    $('html, body').animate({
                        scrollTop: bookDetail.offset().top
                    }, 1000)
                   
                    bookDetail.html('');
                    bookDetail.html(response);
                }
            })
        });
    }
}
admin.init();