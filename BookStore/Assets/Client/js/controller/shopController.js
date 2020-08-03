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
            var secondPrice = $('#amount').val().substr(6,3);
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





        



    }
}
book.init();