﻿var dataTable;

function format(d) {

    return "<h5><strong>Created By:</strong>" + "      " + d.userId + '</h5>'
        + "<h5><strong> Created At:</strong >" + " " + d.dateCreated + '</h5>'
        + "<h5><strong> Resolved At:</strong>" + " " + d.dateResolved + '</h5>'
        + "<h5><strong> Subject:</strong>" + " " + d.subject + '</h5>'
        + "<h5><strong> Description:</strong>" + " " + d.message + '</h5>'
        + "<h5><strong>Device:</strong>" + " " + d.device + ": " + d.otherDevice + '</h5>'
        + "<h5><strong>Resolution:</strong>" + " " + d.resolution + '</h5>';

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
            "processing": true,
            "serverSide": true,
            "url": "/api/adminrequest/AssignPending",
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
            { "data": "department" },
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
            //{ "data": "dateCreated" },
            //{ "data": "respondedDate" },
            {
                "render": function (data, type, full) {

                    var resolvTime = `${full.responseDate}`;
                    // alert(resolvTime)
                    if (resolvTime === '00:00:00') {

                        return `<div style="color:red"></div>`

                    }
                    else {
                        return `<div style="color:red">${full.responseDate}</div>`
                    }
                }
            },
            { "data": "dateResolved" },
            {
                "render": function (data, type, full) {

                    var respTime = `${full.resolvedDate}`;
                    if (respTime === '00:00:00') {

                        return `<div style="color:red"></div>`

                    }
                    else {
                        return `<div style="color:red">${full.resolvedDate}</div>`
                    }
                }
            },
            //{ "data": "issue" },
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
            // { "data": "device"},
            //{ "data": "subject" },
            { "data": "itStaff" },
            { "data": "resolvedBy" },
            {
                "render": function (data, type, full) {

                    var isCancel = `${full.isCancel}`;
                    if (isCancel === 'True') {



                        return `<div style="color:red">Canceled</div>`

                    }

                    return `<div class="text-center" id="editDiv">
             <a href="/Admin/Requests/Edit/${full.id}" class='style='cursor:pointer;'>
            <i class='fa fa-edit text-success'></i></a>
           </div>`;
                }

            },
            {
                "data": "isCancel", "render": function (data) {

                    return `<div hidden>${data}</div>`
                }
            }

        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%",


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