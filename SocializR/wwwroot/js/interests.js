$(document).ready(function () {
    $('#select2interests').select2();

    $('#select2interests').select2({
        ajax: {
            url: Router.action('Interest', 'GetAllInterests'),
            data: function (params) {
                var query = {
                    interestName: params.term
                };

                return query;
            },
            dataType: 'json',
            processResults: function (data) {
                return {
                    results: data.map(function (i) {
                        return {
                            text: i.text,
                            id: i.value
                        };
                    })
                };
            }
        },
        minimumInputLength: 3
    });
});