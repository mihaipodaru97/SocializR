$("#interest-button").on("click", function () {
    let interest = $('#interest-text').val();

    $.ajax({
        type: "POST",
        url: Router.action('Interest', 'AddInterest'),
        data: { interest: interest },
        success: function () {
            $('#interest-text').text('');
            $('#interest-label').text('Interesul a fost adaugat cu succes');
            $('#interest-label').removeClass("text-danger");
            $('#interest-label').addClass("text-success");
        },
        error: function (xhr, status, error) {
            $('#interest-label').text('Interesul exista deja in baza de date');
            $('#interest-label').removeClass("text-success");
            $('#interest-label').addClass("text-danger");
        }
    });
});

$("#county-button").on("click", function () {
    let county = $('#county-text').val();

    $.ajax({
        type: "POST",
        url: Router.action('County', 'AddCounty'),
        data: { county: county },
        success: function () {
            $('#county-text').text('');
            $('#county-label').text('Judetul a fost adaugat cu succes');
            $('#county-label').removeClass("text-danger");
            $('#county-label').addClass("text-success");
        },
        error: function (xhr, status, error) {
            $('#county-label').text('Judetul exista deja in baza de date');
            $('#county-label').removeClass("text-success");
            $('#county-label').addClass("text-danger");
        }
    });
});

$("#locality-button").on("click", function () {
    let locality = $('#locality-text').val();
    let countyId = $('#counties :selected').val();

    $.ajax({
        type: "POST",
        url: Router.action('Locality', 'AddLocality'),
        data: { locality: locality, countyId: parseInt(countyId) },
        success: function () {
            $('#locality-text').text('');
            $('#locality-label').text('Localitatea a fost adaugat cu succes');
            $('#locality-label').removeClass("text-danger");
            $('#locality-label').addClass("text-success");
        },
        error: function (xhr, status, error) {
            $('#locality-label').text('Localitatea exista deja in baza de date');
            $('#locality-label').removeClass("text-success");
            $('#locality-label').addClass("text-danger");
        }
    });
});
