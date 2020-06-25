var dataTable;

function format(d) {

    return d.message;

}

$(document).ready(function () {
    loadDataTable();

    var detailRows = [];

    $('#DT_load tbody').on('click', 'tr td.details-control', function () {
        var tr = $(this).closest('tr');
        var row = dataTable.row(tr);
        var idx = $.inArray(tr.attr('id'), detailRows);

        if (row.child.isShown()) {
            tr.removeClass('details');
            row.child.hide();

            // Remove from the 'open' array
            detailRows.splice(idx, 1);
        }
        else {
            tr.addClass('details');
            row.child(format(row.data())).show();

            // Add to the 'open' array
            if (idx === -1) {
                detailRows.push(tr.attr('id'));
            }
        }
    });

    // On each draw, loop over the `detailRows` array and show any child rows
    dataTable.on('draw', function () {
        $.each(detailRows, function (i, id) {
            $('#' + id + ' td.details-control').trigger('click');
        });
    });
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/adminrequest",
            "type": "GET",
            "datatype": "json"
        },
        dom: 'Bfrtip',
        buttons: [
            'print',
            // 'copyHtml5',
            'excelHtml5',
            // 'csvHtml5',
            'pdfHtml5'
        ],
        "columns": [
            {
                "class": "details-control",
                "orderable": false,
                "data": null,
                "defaultContent": '<i class = "glyphicon glyphicon-plus-sign bg-success text-white"> </ i>',
            },
            { "data": "status", "width": "20%" },
            { "data": "dateCreated", "width": "20%" },
            { "data": "issue", "width": "20%" },
            { "data": "device", "width": "20%" },
            { "data": "subject", "width": "20%" },
            { "data": "itStaff", "width": "20%" },
            {
                "data": "id", "render": function (data) {
                    return `<div class="text-center">
             <a href="/Admin/Requests/Edit/${data}" class='style='cursor:pointer;'><i class='fa fa-edit text-success'></i>Edit</a>
            &nbsp<a class='btn text-danger style='cursor:pointer;' onclick=Delete('/api/adminrequest?id='+${data})><i class='fa fa-trash text-danger'></i>Delete</a></div>`;
                }, "width": "40%"
            }

        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });

}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not able to recover",
        icon: "warning",
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}