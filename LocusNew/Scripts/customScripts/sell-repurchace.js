$('#form0').submit(function () {
    if ($("#form0").valid()) {
        $(this).find(':submit').attr('disabled', 'disabled');
        $('#FormSubmitBtn').html('<i class="fa fa-spinner fa-spin"></i>')
    }
});