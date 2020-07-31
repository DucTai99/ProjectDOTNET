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
                url: "listBookWithType",
                data: {
                    "id": id
                },
                success: function (response) {
                    change.html('');
                    change.html(response);
                }
            })
        })
    }
}
book.init();