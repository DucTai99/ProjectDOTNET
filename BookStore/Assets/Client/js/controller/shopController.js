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

    }
}
book.init();