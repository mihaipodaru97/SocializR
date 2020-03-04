$(document).ready(function () {
    $('#select2list').select2();

    $('#select2list').select2({
        ajax: {
            url: Router.action('User', 'SearchUsers'),
            data: function (params) {
                var query = {
                    userName: params.term
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
        minimumInputLength: 3,
        placeholder: 'Search user'
    })
        .on('select2:select', function () {
            var id = $(this).val();
            location.href = Router.action('Profile', 'ViewProfile', { id: id });
   });
});