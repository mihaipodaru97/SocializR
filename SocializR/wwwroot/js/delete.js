$("#delete").on("click", function (e) {
    let $target = $(e.target);
    let userId = $target.data("user-id");

    $.ajax({
        type: "POST",
        url: Router.action('Account', 'Delete'),
        data: { id: userId },
        success: function (data) {
            window.location = Router.action('Feed', 'Index');
        }
    });
});