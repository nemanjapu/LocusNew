$('#Address').on('blur', function () {
    var address = $(this).val();
    $('#pac-input').val(address);
    $('#MetaKeyWords').val($("#MetaKeyWords").val() + ", " + address);
});
$('#CityPart').on('blur', function () {
    var cityPart = $(this).val();
    $('#MetaKeyWords').val($("#MetaKeyWords").val() + ", " + cityPart);
});
$('.popover-dismiss').popover({
    trigger: 'focus'
});
$(function () {
    $("#Published").datepicker({
        dateFormat: 'dd.mm.yy'
    });
    $("#ContractFrom").datepicker({
        dateFormat: 'dd.mm.yy',
        changeMonth: true,
        changeYear: true
    });
    $("#ContractTo").datepicker({
        dateFormat: 'dd.mm.yy',
        changeMonth: true,
        changeYear: true
    });
});
$('.listing-summernote').summernote({
    height: 350,
    toolbar: [
        // [groupName, [list of button]]
        ['style', ['bold', 'italic', 'underline', 'clear']],
        ['font', ['strikethrough', 'superscript', 'subscript']],
        ['fontsize', ['fontsize']],
        ['color', ['color']],
        ['para', ['ul', 'ol', 'paragraph']],
        ['height', ['height']],
        ['codeview', ['codeview']],
        ['undo', ['undo']],
        ['redo', ['redo']]
    ]
});
toastr.options = {
    "closeButton": true,
    "newestOnTop": true,
    "progressBar": false,
    "positionClass": "toast-bottom-right"
};
$('#ImagesContainer').sortable({
    items: ".sortable-image:not(.upload-label)",
    delay: 150,
    opacity: 0.5,
    handle: ".draggableHandleImage",
    stop: function (event, ui) {
        var images = [];
        $(".sortable-image:not(.upload-label)").each(function (index) {
            images.push({
                'id': $(this).attr("id"),
                'SortOrder': index
            });
        });
        $.ajax({
            url: "/api/ListingImages/SetImagesOrder",
            method: "POST",
            data: { '': images }
        }).done(function () {
            toastr.success("Redoslijed slika uspješno izmijenjen.");
        }).fail(function () {
            toastr.error("Greška! Novi redoslijed nije spašen.");
        });
    }
});
$('#MultiRooms').change(function () {
    $('#MultiRoomsSingle').toggle(!this.checked);
    $('#MultiRoomsMulti').toggle(this.checked);
});
$('#MultiBedrooms').change(function () {
    $('#MultiBedroomsSingle').toggle(!this.checked);
    $('#MultiBedroomsMulti').toggle(this.checked);
});
$('#MultiBathrooms').change(function () {
    $('#MultiBathsSingle').toggle(!this.checked);
    $('#MultiBathsMulti').toggle(this.checked);
});
$('#MultiSquareMeters').change(function () {
    $('#MultiSqSingle').toggle(!this.checked);
    $('#MultiSqMulti').toggle(this.checked);
});
$('#MultiPrice').change(function () {
    $('#MultiPriceSingle').toggle(!this.checked);
    $('#MultiPriceMulti').toggle(this.checked);
});

//CITY PARTS JAVASCRIPT

function PopulateCityPartsDeleteList() {
    $.ajax({
        url: '/api/CityParts/GetCityParts',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            $("#CityPartsDeleteList").empty();
            for (var i = 0; i < data.length; i++) {
                $("#CityPartsDeleteList").append('<li id="CityPart' + data[i].Id + '" class="list-group-item d-flex justify-content-between align-items-center">' + data[i].Name + '<span class="deleteCityButton" data-deleteCityId = ' + data[i].Id + '><i class="fa fa-trash-o" aria-hidden="true"></i></span></li>');
            }
        },
        error: function (xhr, status) {
            alert(status);
        }
    });
}
function PopulateCityPartsDropdownList() {
    $.ajax({
        url: '/api/CityParts/GetCityParts',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            $("#CityPartId").empty();
            var isSelected = "";
            for (var i = 0; i < data.length; i++) {
                if (i === data.length - 1) {
                    isSelected = "selected";
                }
                $("#CityPartId").append('<option ' + isSelected +' value="' + data[i].Id + '">' + data[i].Name + '</option>');
            }
        },
        error: function (xhr, status) {
            alert(status);
        }
    });
}
$(document).on('click', '.deleteCityButton', function () {
    cityPartId = $(this).data("deletecityid");
    $.ajax({
        type: "post",
        url: "/api/CityParts/DeleteCityPart/" + cityPartId
    }).done(function () {
        var CityPartContToRemove = $("#CityPart" + cityPartId);
        CityPartContToRemove.remove();
        PopulateCityPartsDropdownList();
        toastr.success("Dio grada uspješno izbrisan.");
    }).fail(function () {
        toastr.error("Greška! Dio grada nije izbrisan.");
    });
});
function SaveNewCityPart() {
    if ($('#newCityPartName').val() === '') {
        toastr.error("Molimo unesite naziv dijela grada!");
        $('#newCityPartName').focus();
    }
    else {
        var NewCityPart = new Object();
        NewCityPart.Name = $('#newCityPartName').val();
        $.ajax({
            url: '/api/CityParts/AddNewCityPart',
            type: 'POST',
            dataType: 'json',
            data: NewCityPart,
            success: function () {
                toastr.success("Dio grada uspješno dodan.");
                $('#newCityPartName').val('');
                PopulateCityPartsDeleteList();
                PopulateCityPartsDropdownList();
                $('#CityPartId').select2('destroy');
                $('#CityPartId').select2();
            },
            error: function () {
                toastr.error("Greška! Dio grada nije dodan.");
            }
        }); 
    } 
}

//CITY PARTS JAVASCRIPT

//PROPERTY TYPES JAVASCRIPT
function PopulateListingTypesDeleteList() {
    $.ajax({
        url: '/api/PropertyTypes/GetPropertyTypes',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            $("#ListingTypesDeleteList").empty();
            for (var i = 0; i < data.length; i++) {
                $("#ListingTypesDeleteList").append('<li id="ListingType' + data[i].Id + '" class="list-group-item d-flex justify-content-between align-items-center">' + data[i].Name + '<span class="deleteListingTypeButton" data-deletelistingtypeid = ' + data[i].Id + '><i class="fa fa-trash-o" aria-hidden="true"></i></span></li>');
            }
        },
        error: function (xhr, status) {
            alert(status);
        }
    });
}
function PopulateListingTypesDropdownList() {
    $.ajax({
        url: '/api/PropertyTypes/GetPropertyTypes',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            $("#PropertyTypeId").empty();
            var isSelected = "";
            for (var i = 0; i < data.length; i++) {
                if (i === data.length - 1) {
                    isSelected = "selected";
                }
                $("#PropertyTypeId").append('<option ' + isSelected +' value="' + data[i].Id + '">' + data[i].Name + '</option>');
            }
        },
        error: function (xhr, status) {
            alert(status);
        }
    });
}
$(document).on('click', '.deleteListingTypeButton', function () {
    listingTypeId = $(this).data("deletelistingtypeid");
    $.ajax({
        type: "post",
        url: "/api/PropertyTypes/DeletePropertyType/" + listingTypeId
    }).done(function () {
        var ListingTypesContToRemove = $("#ListingType" + listingTypeId);
        ListingTypesContToRemove.remove();
        PopulateListingTypesDropdownList();
        toastr.success("Tip nekretnine uspješno izbrisan.");
    }).fail(function () {
        toastr.error("Greška! Tip nekretnine nije izbrisan.");
    });
});
function SaveNewListingType() {
    if ($('#newListingTypeName').val() === '') {
        toastr.error("Molimo unesite naziv tipa nekretnine!");
        $('#newListingTypeName').focus();
    }
    else {
        var NewCityPart = new Object();
        NewCityPart.Name = $('#newListingTypeName').val();
        $.ajax({
            url: '/api/PropertyTypes/AddNewPropertyType',
            type: 'POST',
            dataType: 'json',
            data: NewCityPart,
            success: function () {
                toastr.success("Tip nekretnine uspješno dodan.");
                $('#newListingTypeName').val('');
                PopulateListingTypesDeleteList();
                PopulateListingTypesDropdownList();
                $('#PropertyTypeId').select2('destroy');
                $('#PropertyTypeId').select2();
            },
            error: function () {
                toastr.error("Greška! Tip nekretnine nije dodan.");
            }
        });
    }
}
//PROPERTY TYPES JAVASCRIPT

window.onload = function () {
    PopulateCityPartsDeleteList();
    PopulateListingTypesDeleteList();
};

//HOUSE OWNERS JAVASCRIPT

function PopulateHouseOwnersDropdownList() {
    $.ajax({
        url: '/api/PropertyOwners/GetHouseOwners',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            $("#PropertyOwnerId").empty();
            var isSelected = "";
            for (var i = 0; i < data.length; i++) {
                if (i === data.length - 1) {
                    isSelected = "selected";
                }
                $("#PropertyOwnerId").append('<option ' + isSelected +' value="' + data[i].Id + '">' + data[i].FullName + '</option>');
            }
        },
        error: function (xhr, status) {
            alert(status);
        }
    });
}

$('#saveNewHouseOwnerForm').validate();

$("#saveNewHouseOwnerForm").submit(function (e) {
    e.preventDefault();
    if ($('#saveNewHouseOwnerForm').valid()) {
        var HouseOwner = new Object();
        HouseOwner.FirstName = $('#NewHouseOwnerFirstName').val();
        HouseOwner.LastName = $('#NewHouseOwnerLastName').val();
        HouseOwner.Email = $('#NewHouseOwnerEmail').val();
        HouseOwner.Phone = $('#NewHouseOwnerPhone').val();
        HouseOwner.Address = $('#NewHouseOwnerAddress').val();
        HouseOwner.IdNumber = $('#NewHouseOwnerIdNumber').val();
        $.ajax({
            url: '/api/PropertyOwners/AddNewHouseOwner',
            type: 'POST',
            dataType: 'json',
            data: HouseOwner,
            success: function () {
                toastr.success("Novi vlasnik uspješno dodan.");
                PopulateHouseOwnersDropdownList();
                $('#PropertyOwnerId').select2('destroy');
                $('#PropertyOwnerId').select2();
            },
            error: function () {
                toastr.error("Greška! Novi vlasnik nije dodan.");
            }
        });
        $('#newHouseOwner').modal('toggle');
    }
    else {
        return false;
    }
});

//HOUSE OWNERS JAVASCRIPT