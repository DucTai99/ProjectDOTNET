var book = {
    init: function () {
        book.registerEvents();
    },
    registerEvents: function () {
        $('.type-id').off('click').on('click', function (event) {
            event.preventDefault();
            var id = $(this).data('id');
            var change = $("#change");
            $.ajax({
                type: "POST",
                url: "/Shop/listBookWithType",
                data: {
                    "id": id
                },
                success: function (response) {
                    change.html('');
                    change.html(response);
                }
            })
        });

        $('#searchWithPrice').on('click', function () {
            var firstPrice = $('#amount').val().substr(0, 2);
            var secondPrice = $('#amount').val().substr(6, 3);
            if ($('#amount').val().charAt(2) != "K") {
                firstPrice = $('#amount').val().substr(0, 3);
                var secondPrice = $('#amount').val().substr(7, 3);
            }
            if ($('#amount').val().charAt(8) == "K") {
                secondPrice = $('#amount').val().substr(6, 2);
            }
            var change = $("#change");
            $.ajax({
                type: "POST",
                url: "/Shop/listBookWithType",
                data: {
                    "id": -1,
                    "firstPrice": firstPrice,
                    "secondePrice": secondPrice
                },
                success: function (response) {
                    change.html('');
                    change.html(response);
                }
            })
        });

        $('#search-text').keyup(function (event) {
            event.preventDefault();
            var name = $(this).val().trim();
            var search = $("#search");
            $.ajax({
                type: "GET",
                url: "/Shop/listBookSearch",
                data: {
                    "name": name
                },
                success: function (response) {
                    if (name != "") {
                        search.html(response);
                        search.css({
                            "opacity": 1,
                            "visibility": "visible",
                            "transform": "scaleY(1)",
                        })
                    }
                    else {
                        search.html("");
                        search.css({
                            "opacity": 0,
                            "visibility": "hidden",
                            "transform": "scaleY(0)",
                        })
                    }
                }
            })
        });

        $('.add-item-to-cart').on('click', function (event) {
            event.preventDefault();
            var idBook = $(this).data('id');
            var shoppingCart = $('.shoping-cart');
            var addItemSuccess = $('#addItemSuccess');
            addItemSuccess.removeClass("fade");
            addItemSuccess.addClass("show");
            $.ajax({
                type: "POST",
                url: "/Shop/addItemToCart",
                data: {
                    "idBook": idBook
                },
                success: function (response) {
                    shoppingCart.html('');
                    shoppingCart.html(response);
                }
            })
        });

        $('.remove-item-from-cart').on('click', function (event) {
            event.preventDefault();
            var idBook = $(this).data('id');
            var shoppingCart = $('.shoping-cart');
            $.ajax({
                type: "POST",
                url: "/Shop/removeItemFormCart",
                data: {
                    "idBook": idBook
                },
                success: function (response) {
                    shoppingCart.html('');
                    shoppingCart.html(response);
                }
            })
        });

        $('.remove-item').on('click', function (event) {
            event.preventDefault();
            var idBook = $(this).data('id');
            var topBody = $('#topBody');
            $.ajax({
                type: "POST",
                url: "/Cart/removeItem",
                data: {
                    "idBook": idBook
                },
                success: function (response) {
                    topBody.html('');
                    topBody.html(response);
                }
            })
        });

        $(".right-shoping-cart").on('click', function (event) {
            event.preventDefault();
            var topBody = $('#topBody');
            $.ajax({
                type: "POST",
                url: "/Cart/removeAllItem",
                success: function (response) {
                    topBody.html('');
                    topBody.html(response);
                }
            });
        });

        $(".qtybutton").on("click", function () {
            var idBook = $(this).data('id');
            var $button = $(this);
            var oldValue = $button.parent().find("input").val();
            if ($button.text() == "+") {
                if (oldValue < 10) {
                    var newVal = parseFloat(oldValue) + 1;
                }
                else {
                    newVal = 10;
                }
            } else {
                // Don't allow decrementing below zero
                if (oldValue > 1) {
                    var newVal = parseFloat(oldValue) - 1;
                } else {
                    newVal = 1;
                }
            }
            $button.parent().find("input").val(newVal);
            $.ajax({
                type: "POST",
                url: "/Cart/changeNumItem",
                data: {
                    "idBook": idBook,
                    "number": newVal,
                },
                success: function (response) {
                    $('#topBody').html('');
                    $('#topBody').html(response);
                }
            })
        });

        $("#submit-code-sale").on('click', function () {
            var codeSale = $("#codeSale").val();
            $.ajax({
                type: "POST",
                url: "/Cart/useCodeSale",
                data: {
                    "codeSale": codeSale
                },
                success: function (response) {
                    $('#topBody').html('');
                    $('#topBody').html(response);
                }
            })
        });

        $('#btn-submit-comment').on('click', function (event) {
            event.preventDefault();
            var lableUserEmail = $('#lableUserEmail').text();
            if (lableUserEmail == "NoName") {
                var signIn = $('#signIn');
                signIn.css({ "display": "block" });
                signIn.on('click', function () {
                    signIn.css({ "display": "none" });
                });
                $("#close_modal").on('click', function () {
                    signIn.css({ "display": "none" });
                });
            }
            else {
                var idBook = $("#maSach").val();
                var content = $("#commentText").val();
                $.ajax({
                    type: "POST",
                    url: "/Shop/addComment",
                    data: {
                        "idBook": idBook,
                        "content" : content,
                    },
                    success: function (response) {
                        $("#CommentArea").html('');
                        $("#CommentArea").html(response);
                        $("#commentText").val("");
                    }
                })
            }
        });

        $(".add-item-to-wishlist").on('click', function (event) {
            event.preventDefault();
            var idBook = $(this).data('id');
            var addItemToWishList = $('#addItemToWishList');
            var needToSignIn = $('#needToSignIn');
            $.ajax({
                type: "POST",
                url: "/Shop/addItemToWishList",
                data: {
                    "idBook": idBook
                },
                success: function (response) {
                    if (response.error == "NoUser") {
                        needToSignIn.removeClass("fade");
                        needToSignIn.addClass("show");
                    }
                    else {
                        addItemToWishList.removeClass("fade");
                        addItemToWishList.addClass("show");
                        setTimeout(function () {
                            addItemToWishList.removeClass("show");
                            addItemToWishList.addClass("fade");
                        }, 700);
                    }
                }
            })
        });

        $("#changePass").on('click', function (event) {
            event.preventDefault();
            var currentPass = $('#current-pass');
            var newPass = $('#newPass');
            var cfPass = $('#cfPass');
            if (currentPass.val() == "" || newPass.val() == "" || cfPass == "") {
                $('#errorWrongNewPass').text("Cần nhâp đầy đủ");
                $('#errorWrongNewPass').show();
            }
            else if (newPass.val() != cfPass.val()) {
                var errorWrongNewPass = $('#errorWrongNewPass');
                errorWrongNewPass.text("Nhâp mât khẩu lai sai");
                errorWrongNewPass.show();
                cfPass.val("");
            }
            else {
                 $.ajax({
                    type: "POST",
                     url: "/Account/changePassWord",
                    data: {
                        "currentPass": currentPass.val(),
                        "newPass": newPass.val()
                    },
                     success: function (response) {
                         console.log(response);
                        if (response.error == "CurrentPassWordWrong") {
                            $('#errorWrongNewPass').text("Nhâp mât khẩu hiên tai sai ");
                            $('#errorWrongNewPass').show();
                            currentPass.val("");
                            cfPass.val("");
                            newPass.val("");
                        }
                        else {
                            $('#changePassWordSuccess').removeClass("fade");
                            $('#changePassWordSuccess').addClass("show");
                            setTimeout(function () {
                                $('#changePassWordSuccess').removeClass("show");
                                $('#changePassWordSuccess').addClass("fade");
                                $('#errorWrongNewPass').hide();
                                currentPass.val("");
                                cfPass.val("");
                                newPass.val("");
                            }, 1000);
                        }
                    }
                })
            }
        });
    }
}
book.init();