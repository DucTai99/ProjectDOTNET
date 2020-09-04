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
        $('.user-email').off('click').on('click', function (event) {
            event.preventDefault();
            $('#body').scrollTop(100);

            var email = $(this).data('id');
            var userDetail = $("#userDetail");

            $.ajax({
                type: "POST",
                url: "/Admin/AdminHome/accountArea",
                data: {
                    "email": email
                },
                success: function (response) {
                    $('html, body').animate({
                        scrollTop: userDetail.offset().top
                    }, 1000)
                    userDetail.html('');
                    userDetail.html(response);
                }
            })
        });
        $('.delete-user').off('click').on('click', function (event) {
            event.preventDefault();
            var email = $(this).data('email');
            $.ajax({
                type: "POST",
                url: "/Admin/AdminHome/deleteUser",
                data: {
                    "email": email,
                },
                success: function (response) {
                    $("#dataTableUser").html('');
                    $("#dataTableUser").html(response);
                }
            })
        });
    }
}
admin.init();