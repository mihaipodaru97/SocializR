$(function () {
    $('#CountyId').change(populateLocalities);
    $('#CountyId').trigger('change');
});

function populateLocalities() {
    var countyId = this.value;
    $.ajax({
        url: Router.action('Locality', 'GetLocalities'),
        data: { countyId: countyId },
        success: function (data) {
            var localityList = $('#LocalityId');
            localityList.empty();

            for (var i = 0; i < data.length; i++) {
                localityList.append(new Option(data[i].text, data[i].value));
            }
        },

        error: function (xhr, status, error) {
            window.location = Router.action('Account', 'AccesDenied');
        }

    });
}