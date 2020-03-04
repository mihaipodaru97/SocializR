function post(id) {
    var text = $('#text').val();

    if (text.length > 10) {
        $.ajax({
            type: "POST",
            url: Router.action('Post', 'AddPost'),
            data: { id: id, text: text },
            success: function (){
                window.location.reload(true);
            }
        });
    }
    else {
        $('#error').show();
    }
}

function comment(event, postId) {
    if (event.keyCode === 13) {
        var text = event.target.value;
        $.ajax({
            type: "POST",
            url: Router.action('Comment', 'AddComment'),
            data: { PostId: postId, Body: text },
            success: function (data) {
                window.location.reload(true);
            },
            error: function (xhr, status, error) {
                window.location = Router.action('Feed', 'Index');
            }
        });
    }
}