function changeAlbumName(id) {
    var name = $('#albumName').val();
    $.ajax({
        type: "POST",
        url: Router.action('Album', 'EditAlbumName'),
        data: { albumId: id, name: name },
        success: function () {
            $('#albumName').text(name);
        }
    });
}

$(".edit-button").on("click", function (e) {
    let $target = $(e.target);
    let photoId = $target.data("photo-id");
    let description = $('#text-' + photoId).val();
    let albumId = $("#albumId").data("album-id");

    $.ajax({
        type: "POST",
        url: Router.action('Photo', 'ChangePhotoDescription'),
        data: { photoId: photoId, albumId: albumId, description: description },
        success: function (data) {
            $('#text' + photoId).text(description);
        }
    });
});

$(".delete-button").on("click", function (e) {
    let $target = $(e.target);
    let photoId = $target.data("photo-id");

    $.ajax({
        type: "POST",
        url: Router.action('Photo', 'DeletePhoto'),
        data: { photoId: photoId },
        success: function (data) {
            window.location.reload(true);
        }
    });
});

$(".image").on("mouseover", function (e) {
    e.target.style.width = '400px';
    e.target.style.height = '400px';
});

$(".image").on("mouseout", function (e) {
    e.target.style.width = '150px';
    e.target.style.height = '150px';
});