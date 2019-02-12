$(document).delegate('#DeleteImageButton', 'click', function (e) {
    e.preventDefault();
    var idToRemove = $(this).find('.ImageId').val();
    $.ajax({
        type: "post",
        url: "/api/ListingImages/DeleteListingImage/" + idToRemove,
    }).done(function () {
        var imgContToRemove = $("#" + idToRemove);
        imgContToRemove.remove();
        toastr.success("Slika uspješno izbrisana.")
    }).fail(function () {
        toastr.error("Greška! Slika nije izbrisana.")
    });
});