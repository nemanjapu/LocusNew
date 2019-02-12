$(document).ready(function () {
    $("#cityPart").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/search/citiesautocomplete',
                datatype: "json",
                data: {
                    term: request.term
                },
                success: function (data) {
                    response($.map(data, function (val, item) {
                        return {
                            label: val.Name,
                            value: val.Name,
                            Id: val.Id
                        };
                    }));
                }
            });
        },
        select: function (event, ui) {
            $("#cityPartId").val(ui.item.Id);
        },
        minLength: 0
    });
    $("#SearchForm").one("submit", function (e) {
        e.preventDefault();
        if (!$("#cityPart").val()) {
            $("#cityPartId").val("0");
        }
        $(this).submit();
    });
    $("#toggleSearch").on("click", function () {
        $(".search-cont").slideToggle();
    });
});