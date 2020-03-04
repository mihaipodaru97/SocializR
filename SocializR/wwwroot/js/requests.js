function addFriend(id) {
    $.ajax({
        type: "POST",
        url: Router.action('Friend', 'AddFriendRequest'),
        data: { id: id },
        success: function () {
            window.location.reload(true);
        }
    });
}

function cancelRequest(id) {
    $.ajax({
        type: "POST",
        url: Router.action('Friend', 'CancelRequest'),
        data: { id: id },
        success: function () {
            window.location.reload(true);
        }
    });
}

function acceptRequest(id) {
    $.ajax({
        type: "POST",
        url: Router.action('Friend', 'AcceptRequest'),
        data: { id: id },
        success: function () {
            window.location.reload(true);
        }
    });
}


$(".unfriend-button").on("click", function (e) {
    let $target = $(e.target);
    let id = $target.data("friend-id");

    $.ajax({
        type: "POST",
        url: Router.action('Friend', 'Unfriend'),
        data: { id: id },
        success: function () {
            $('#friend-' + id).remove();
        }
    });
});