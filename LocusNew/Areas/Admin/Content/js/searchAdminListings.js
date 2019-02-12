$(document).delegate('#DeleteListingButton', 'click', function () {
    var ListingId = $(this).data('listingid');
    $('#ListingIdInput').val(ListingId);
});