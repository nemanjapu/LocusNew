$(document).ready(function () {
    $('.datatable-table').DataTable({
        "language": {
            "decimal": "",
            "emptyTable": "Nema zapisa u tabeli.",
            "info": "_START_ - _END_ od _TOTAL_ zapisa",
            "infoEmpty": "0 - 0 od 0 zapisa",
            "infoFiltered": "(filtrirano od ukupno _MAX_ zapisa)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Prikaži _MENU_ zapisa",
            "loadingRecords": "Loading...",
            "processing": "Processing...",
            "search": "Traži:",
            "zeroRecords": "Nema rezultata pretrage",
            "paginate": {
                "first": "Prva",
                "last": "Zadnja",
                "next": "Sljedeća",
                "previous": "Prethodna"
            },
            "aria": {
                "sortAscending": ": activate to sort column ascending",
                "sortDescending": ": activate to sort column descending"
            }
        }
    });
});