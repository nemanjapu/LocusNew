document.getElementById("File1").onchange = function () {
    var reader = new FileReader();

    reader.onload = function (e) {
        document.getElementById("File1img").src = e.target.result;
    };
    reader.readAsDataURL(this.files[0]);
};

document.getElementById("File2").onchange = function () {
    var reader = new FileReader();

    reader.onload = function (e) {
        document.getElementById("File2img").src = e.target.result;
    };
    reader.readAsDataURL(this.files[0]);
};

document.getElementById("File3").onchange = function () {
    var reader = new FileReader();

    reader.onload = function (e) {
        document.getElementById("File3img").src = e.target.result;
    };
    reader.readAsDataURL(this.files[0]);
};

document.getElementById("File4").onchange = function () {
    var reader = new FileReader();

    reader.onload = function (e) {
        document.getElementById("File4img").src = e.target.result;
    };
    reader.readAsDataURL(this.files[0]);
};

document.getElementById("File5").onchange = function () {
    var reader = new FileReader();

    reader.onload = function (e) {
        document.getElementById("File5img").src = e.target.result;
    };
    reader.readAsDataURL(this.files[0]);
};

document.getElementById("File6").onchange = function () {
    var reader = new FileReader();

    reader.onload = function (e) {
        document.getElementById("File6img").src = e.target.result;
    };
    reader.readAsDataURL(this.files[0]);
};
$('#AboutUs').summernote({
    height: 210,
    toolbar: [
        ['style', ['bold', 'italic', 'underline', 'clear']],
        ['font', ['strikethrough', 'superscript', 'subscript']],
        ['fontsize', ['fontsize']],
        ['color', ['color']],
        ['para', ['ul', 'ol', 'paragraph']],
        ['height', ['height']],
        ['codeview', ['codeview']]
    ],

});
$('.global-settings-select').select2();
