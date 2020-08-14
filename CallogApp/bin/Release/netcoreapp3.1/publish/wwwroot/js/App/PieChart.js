

            $.ajax({

                "url": "/api/piechart/" + thePost,
                "type": "GET",
                "datatype": "json",

                success: function (data) {

                    var x = $('#totalPending').text();

                    if (x === ' ') { $('#totalPending').append(data) }



                }, error: function (xhr, ajaxOptions, thrownError) {
                    swal(ajaxOptions, xhr.responseText);
                }

            });



            $.ajax({

                "url": "/api/piechart" + thePost,
                "type": "GET",
                "datatype": "json",

                success: function (data) {

                    var x = $('#totalRequests').text();

                    if (x === ' ') { $('#totalRequests').append(data); }

                }, error: function (xhr, ajaxOptions, thrownError) {
                    swal(ajaxOptions, xhr.responseText);
                }

            });

            $.ajax({

                "url": "/api/piechart" + thePost,
                "type": "GET",
                "datatype": "json",

                success: function (data) {

                    var x = $('#totalResolved').text();

                    if (x === ' ') { $('#totalResolved').append(data); }

                }, error: function (xhr, ajaxOptions, thrownError) {
                    swal(ajaxOptions, xhr.responseText);
                }

            });

            $.ajax({

                "url": "/api/piechart" + thePost,
                "type": "GET",
                "datatype": "json",

                success: function (data) {

                    var x = $('#avgResponseTime').text();

                    if (x === ' ') { $('#avgResponseTime').append(data + 'min(s)'); }

                }, error: function (xhr, ajaxOptions, thrownError) {
                    swal('No records found.');
                }

            });

            $.ajax({

                "url": "/api/piechart" + thePost,
                "type": "GET",
                "datatype": "json",

                success: function (data) {
                    // $('#avgResponseTimeHour').empty();
                    var x = $('#avgResponseTimeHour').text();

                    if (x === ' ') { $('#avgResponseTimeHour').append(data + 'hr(s)'); }

                }, error: function (xhr, ajaxOptions, thrownError) {
                    swal('No records found.');
                }

            });

            $.ajax({

                "url": "/api/piechart" + thePost,
                "type": "GET",
                "datatype": "json",

                success: function (data) {
                    // $('#avgResolutionTime').empty();
                    var x = $('#avgResolutionTime').text();

                    if (x === ' ') { $('#avgResolutionTime').append(data + 'min(s)'); }


                }, error: function (xhr, ajaxOptions, thrownError) {
                    swal('No records found.');
                }

            });

            $.ajax({

                "url": "/api/piechart" + thePost,
                "type": "GET",
                "datatype": "json",

                success: function (data) {
                    var x = $('#avgResolutionTimeHour').text();
                 
                }, error: function (xhr, ajaxOptions, thrownError) {
                    swal('No records found.');
                }

            });

           
