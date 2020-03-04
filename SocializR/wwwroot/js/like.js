$(".like-button").on("click", function (e) {
    let $target = $(e.target);
    let postId = $target.data("post-id");

    let action = $target.data("like-state");
    if (action === "like") {
        $.ajax({
            type: "POST",
            url: Router.action('Like', 'Like'),
            data: { postId: postId },
            success: function (data) {
                $target.data("like-state", "unlike");
                changeLikeNumber(postId, data);
                $target.text("Unlike");
            }
        });
    }
    else if (action === "unlike") {
        $.ajax({
            type: "POST",
            url: Router.action('Like', 'Unlike'),
            data: { postId: postId },
            success: function (data) {
                $target.data("like-state", "like");
                changeLikeNumber(postId, data);
                $target.text("Like");
            }
        });
    }
    
});

function changeLikeNumber(postId, likeNumber) {
    let $likeNumber = $("#text-" + postId);

    $likeNumber.text(likeNumber + " Likes");
}