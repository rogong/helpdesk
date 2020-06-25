#pragma checksum "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\RequestReports\ReportWithoutDepartment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "108b927d30c2857fa300c192683ac87718fb7fe1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_RequestReports_ReportWithoutDepartment), @"mvc.1.0.view", @"/Areas/Admin/Views/RequestReports/ReportWithoutDepartment.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\_ViewImports.cshtml"
using CallogApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\_ViewImports.cshtml"
using CallogApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"108b927d30c2857fa300c192683ac87718fb7fe1", @"/Areas/Admin/Views/RequestReports/ReportWithoutDepartment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5bea9ab759c8394bfef8f2618f3c227856ba4d9", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_RequestReports_ReportWithoutDepartment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CallogApp.Models.Request>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.dataTables.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral(@"

    <link rel=""stylesheet"" type=""text/css"" href=""https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.css"" />
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.css"" />
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css"" />
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.css"" />
    <link rel=""stylesheet"" href=""https://cdn.datatables.net/1.10.21/css/jquery.dataTables.min.css"" />
    <link rel=""stylesheet"" href=""https://cdn.datatables.net/buttons/1.6.1/css/buttons.dataTables.min.css"" />
    <link rel=""stylesheet"" href=""https://cdn.datatables.net/responsive/2.2.1/css/responsive.dataTables.min.css"" />
    <link rel=""stylesheet"" href=""https://datatables.net/media/css/site.css?_=6239e0117a45e8466919cf6525f8d1f2"" />
 
    <style>
        .limited {
            white-space: nowrap;
            witableh: 100%;
            overflow:");
                WriteLiteral(@" hidden;
            text-overflow: ellipsis;
        }

        td.details-control {
            background: url('/images/details_open.png') no-repeat center center;
            cursor: pointer;
        }

        tr.details td.details-control {
            background: url('/images/details_close.png') no-repeat center center;
        }

        div.polaroid {
            padding: 5px 5px 5px 5px;
            border: 1px solid #BFBFBF;
            background-color: white;
            box-shadow: 10px 10px 10px 10px #aaaaaa;
        }
    </style>

");
            }
            );
#nullable restore
#line 40 "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\RequestReports\ReportWithoutDepartment.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-md-4""></div>
    <div class=""col-md-4"">
        <h4>Report by only date range</h4>
    </div>
    <div class=""col-md-4""></div>
</div>
<div class=""row"">

    <div class=""col-md-12"">

        <div class=""form-horizontal"">




            <div class=""form-group"" style=""width:70%;"">
                <label class=""control-label col-sm-2""> Date Range:</label>

                <div id=""daterange"" class=""col-sm-8"" style=""background: #fff; cursor: pointer;
            padding: 5px 10px; border: 1px solid #ccc;"">
                    <i class=""fa fa-calendar""></i>&nbsp;
                    <span></span> <i class=""fa fa-caret-down""></i>
                </div>

               

                <div class=""control-label col-sm-2"" style=""background: #fff; 
            padding: 5px 10px;"">  
                <button type=""button"" onclick=""submitSearch()"" class=""btn btn-primary"">Find</button></div>
            </div>

           
        </div>

    </");
            WriteLiteral(@"div>



</div>



<div class=""row"">
    <div class=""unit w-2-3 polaroid"">
        <div class=""hero-callout"">
            <div id=""example_wrapper"" class=""dataTables_wrapper"">
                <table id=""request"" class=""table table-bordered table-striped"" style=""font-size:13px"">
                    <thead>
                        <tr>
                            <th></th>
                            <th>Dept.</th>
                            <th>Status</th>
                            <th>Received At </th>
                            <th>Responded At </th>
                            <th>Resp. Time </th>
                            <th>Resoln. Time </th>
                            <th>Issue </th>
                            <th>Subject </th>
                            <th>Asigned To</th>
                            <th>Resolved By</th>
                            <th>Action</th>
                            <th></th>


                        </tr>
                    </thead>
 ");
            WriteLiteral("                   <tbody>\r\n                    </tbody>\r\n                    <tfoot>\r\n\r\n                    </tfoot>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "108b927d30c2857fa300c192683ac87718fb7fe18226", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script src=""https://cdn.datatables.net/buttons/1.6.1/js/dataTables.buttons.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js""></script>
    <script src=""https://cdn.datatables.net/buttons/1.6.1/js/buttons.html5.min.js""></script>
    <script src=""https://cdn.datatables.net/buttons/1.6.1/js/buttons.print.min.js""></script>


    <script type=""text/javascript"">

        function format(d) {

            return d.message;

        }
            $(document).ready(function () {

                var table = $(""#request"").DataTable({

                    select: true,
                    dom: 'Bfrtip',
                    ""columns"": [
            {
                ""class"": ""details-control"",
                ""orderable"": false,
                ""data"":");
                WriteLiteral(@" null,
                ""defaultContent"": '<i class = ""glyphicon glyphicon-plus-sign bg-success text-white""> </i>',
            },
            { ""data"": ""department""},
            {
                ""render"": function (data, type, full) {

                    var status = `${full.status}`;

                    if (status === 'Resolved') {
                        return `<div style=""color:green"" class=""fa fa-check""><strong>${status}</strong></div>`;
                    }

                    return `<div style=""color:red"" class=""fa fa-circle"">${status}</div>`;
                }
                //""data"": ""status"", ""width"": ""20%""
            },
            { ""data"": ""dateCreated"" },
            { ""data"": ""respondedDate"" },
            { ""data"": ""responseDate"" },
            { ""data"": ""resolvedDate"" },
            { ""data"": ""issue"" },
           // { ""data"": ""device""},
            { ""data"": ""subject""},
            { ""data"": ""itStaff"" },
            { ""data"": ""resolvedBy""},
            {
 ");
                WriteLiteral(@"               ""render"": function (data, type, full) {

                    var isCancel = `${full.isCancel}`;
                    if (isCancel === 'True') {



                        return `<div style=""color:red"">Canceled</div>`

                    }

                    return `<div class=""text-center"" id=""editDiv"">
             <a href=""/Admin/Requests/Edit/${full.id}"" class='style='cursor:pointer;'>
            <i class='fa fa-edit text-success'></i></a>
           </div>`;
                }

            },
            {
                ""data"": ""isCancel"", ""render"": function (data) {
                   
                    return `<div hidden>${data }</div>`
                }
            }

        ],
                });

                var detailRows = [];

                $('#request tbody').on('click', 'tr td.details-control', function () {
                    var tr = $(this).closest('tr');
                    var row = table.row(tr);
                    var idx = ");
                WriteLiteral(@"$.inArray(tr.attr('id'), detailRows);

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
                table.on('draw', function () {
                    $.each(detailRows, function (i, id) {
                        $('#' + id + ' td.details-control').trigger('click');
                    });
                });
            ");
                WriteLiteral(@"});

            function RefreshTable(tableId, theData) {
                table = $(tableId).dataTable();
                oSettings = table.fnSettings();
                table.fnClearTable(this);
                for (var x = 0; x < theData.length; x++) {
                    table.oApi._fnAddData(oSettings, theData[x]);
                }
                oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
                table.fnDraw();


            }


            function submitSearch() {

               
                var start = $('#daterange').data('daterangepicker').startDate;
                var end = $('#daterange').data('daterangepicker').endDate;

                var thePost = ""?startDate="" + start.format('YYYY-MM-DD') + ""&endDate="" + end.format('YYYY-MM-DD');

                $.ajax({
                    ""processing"": true,
                    ""serverSide"": true,
                    ""url"": ""/api/requestreports/daterange"" + thePost,
                    ""type"": ""GET");
                WriteLiteral(@""",
                    ""datatype"": ""json"",

                    success: function (data) {
                        console.log(data);
                        RefreshTable(""#request"", data);
                    }, error: function (xhr, ajaxOptions, thrownError) {
                        swal(ajaxOptions, xhr.responseText);
                    }

                });


            }




            $(function () {

                var start = moment().subtract(29, 'days');
                var end = moment();

                function cb(start, end) {
                    $('#daterange span').html(start.format('YYYY-MM-DD') + ' / ' + end.format('YYYY-MM-DD'));
                }

                $('#daterange').daterangepicker({
                    startDate: start,
                    endDate: end,
                    ranges: {
                        'Today': [moment(), moment()],
                        'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
  ");
                WriteLiteral(@"                      'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                        'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                        'This Month': [moment().startOf('month'), moment().endOf('month')],
                        'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
                    }
                }, cb);

                cb(start, end);

            });




    </script>


    <script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js""></script>
    <script type=""text/javascript"" src=""https://unpkg.com/sweetalert/dist/sweetalert.min.js""></script>

    <script type=""text/javascript"" src=""https://cdn.datatables.net/select/1.2.7/js/dataTables.select.min.js""></script>
    <script type=""text/javascript"" src=""https://cdn.jsdelivr.net/momentjs/latest/moment.min.js""></script>
    <script type=""text/javascript"" src=""https:");
                WriteLiteral(@"//cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.min.js""></script>
    <script src=""https://cdn.datatables.net/responsive/2.2.1/js/dataTables.responsive.min.js""></script>

    <script>


            $(document).ready(function () {
                $('#example')
                    .addClass('nowrap')
                    .dataTable({
                        responsive: true,
                        columnDefs: [
                            { targets: [-1, -3], className: 'dt-body-right' }
                        ]
                    });
            });


    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CallogApp.Models.Request> Html { get; private set; }
    }
}
#pragma warning restore 1591
