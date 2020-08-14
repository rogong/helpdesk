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
            "url": "/api/userrequest/pendingrequest",
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
                "defaultContent": '<i class = "glyphicon glyphicon-plus-sign bg-success text-white"> </i>',
            },
            {
                "render": function (data, type, full) {

                    var status = `${full.status}`;

                    if (status === 'Resolved') {
                        return `<div style="color:green" class="fa fa-check"><strong>${status}</strong></div>`;

                    }

                    return `<div style="color:red" class="fa fa-circle">${status}</div>`;
                }
                //"data": "status", "width": "20%"
            },
            { "data": "dateCreated" },
            //{ "data": "issue", "width": "20%" },
            {
                "render": function (data, type, full) {

                    var isIssue = `${full.issue}`;
                    if (isIssue === 'OTHER') {

                        return `<div>${full.otherIssue}</div>`

                    }
                    else {
                        return `<div>${full.issue}</div>`
                    }
                }

            },
            //{ "data": "device" },
            {
                "render": function (data, type, full) {

                    var device = `${full.device}`;
                    if (device === 'Other') {

                        return `<div">${full.otherDevice}</div>`

                    }
                    else {
                        return `<div">${full.device}</div>`
                    }
                }

            },
            { "data": "subject" },
            { "data": "itStaff" },
            {
                "render": function (data, type, full) {

                    var isCancel = `${full.isCancel}`;
                    if (isCancel === 'True') {
                        return `<div style="color:red">Canceled</div>`

                    }

                    var status = `${full.status}`;

                    if (status === 'Resolved') {
                        return `<span><strong>Closed</strong></span>`;
                    }
                    else {
                        return `<div class="text-center" id="editDiv">
             <a href="/User/UserRequest/Edit/${full.id}" class='style='cursor:pointer;'><i class='fa fa-edit text-success'></i></a>
            &nbsp<a class='btn text-danger style='cursor:pointer;font-size:14px' onclick=Cancel('/api/userrequest?id='+${full.id})><i class='fa fa-window-close text-danger'></i></a>
               </div>`;
                    }


                }
            },
            {
                "data": "isCancel", "render": function (data, type, row) {
                    return `<div id="isCancel" hidden>${data}</div>`
                }

            }

        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });

}

function Cancel(url) {
    swal({
        title: "Are you sure?",
        text: "Once canceled, you will not able to recover",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "Put",
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