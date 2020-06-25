var dataTable;

function format(d) {

    return d.message;

}

$(document).ready(function () {

    $('.assign_all').click(function () {
        if ($(this).is(':checked')) {
            $("input[name='assign_id']").attr('checked', true);
        } else {
            $("input[name='assign_id']").attr('checked', false);
        }
    });


    $('#assignbtn').click(function () {

        if ($('#ITStaffId').val() === "1") {
            swal("Select a User");
            return;
        }
        $('#RequestId').val('');

        var assignVal = [];
        $.each($("input[name='assign_id']:checked"), function () {
            assignVal.push($(this).val());
        });


        if (assignVal == "") {
            swal("No checkbox was checked");
            return;
        } else {
            $('#RequestId').val(assignVal);

            $('#myForm').submit();
        }

    });

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
            "url": "/api/adminrequest/assignpending",
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
            { "data": "status" },
            { "data": "dateCreated"},
            { "data": "issue" },
            { "data": "device"},
            { "data": "subject"},
            { "data": "itStaff"},
            {
                'render': function (data, type, full, meta) {
                    return '<label> <input name="assign_id"  type="checkbox" value="' + full.Id + '"> </label>';
                }
            },
            

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