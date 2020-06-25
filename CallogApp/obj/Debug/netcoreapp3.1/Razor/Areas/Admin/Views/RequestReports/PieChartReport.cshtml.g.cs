#pragma checksum "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\RequestReports\PieChartReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98e4eb8df5043f15ed625245d4e42c3b1cf55b08"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_RequestReports_PieChartReport), @"mvc.1.0.view", @"/Areas/Admin/Views/RequestReports/PieChartReport.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98e4eb8df5043f15ed625245d4e42c3b1cf55b08", @"/Areas/Admin/Views/RequestReports/PieChartReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5bea9ab759c8394bfef8f2618f3c227856ba4d9", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_RequestReports_PieChartReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CallogApp.Models.Request>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral(@"

    <link rel=""stylesheet"" type=""text/css"" href=""https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.css"" />
    <style>
        .limited {
            white-space: nowrap;
            witableh: 100%;
            overflow: hidden;
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
#line 32 "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\RequestReports\PieChartReport.cshtml"
  
    ViewData["Title"] = "Pie Chart Report";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-md-4""></div>
    <div class=""col-md-4"">
        <h4>Pie Report</h4>
    </div>
    <div class=""col-md-4""></div>
</div>
<div class=""row"">

 

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
                    <button type=""button"" onclick=""submitSearch()"" class=""btn btn-primary"">Find</button>
                </div>
            </div>


        </div>

   

        <table class=""columns"">
            <t");
            WriteLiteral("r>\r\n                <td><div id=\"piechart_3d\" style=\"border: 1px solid #ccc\"></div></td>\r\n");
            WriteLiteral("            </tr>\r\n        </table>\r\n\r\n  \r\n\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"



    <script type=""text/javascript"">

        var network, printer, mail, dataprocessing, datasystem,other, procurement,krmachine,software,logs;


        function submitSearch() {


            var start = $('#daterange').data('daterangepicker').startDate;
            var end = $('#daterange').data('daterangepicker').endDate;

            var thePost = ""?startDate="" + start.format('YYYY-MM-DD') + ""&endDate="" + end.format('YYYY-MM-DD');

            $.ajax({
                ""processing"": true,
                ""serverSide"": true,
                ""url"": ""/api/piechartreport/network"" + thePost,
                ""type"": ""GET"",
                ""datatype"": ""json"",

                success: function (data) {

                    network = parseInt(data);
                    

                }, error: function (xhr, ajaxOptions, thrownError) {
                    console.log(xhr.responseText);
                }

            });


            $.ajax({
                ""processing");
                WriteLiteral(@""": true,
                ""serverSide"": true,
                ""url"": ""/api/piechartreport/Printer"" + thePost,
                ""type"": ""GET"",
                ""datatype"": ""json"",

                success: function (data) {
                    printer = parseInt(data);
                }, error: function (xhr, ajaxOptions, thrownError) {
                    console.log(xhr.responseText);
                }

            });


            $.ajax({
                ""processing"": true,
                ""serverSide"": true,
                ""url"": ""/api/piechartreport/Mail"" + thePost,
                ""type"": ""GET"",
                ""datatype"": ""json"",

                success: function (data) {
                   mail = parseInt(data)
                }, error: function (xhr, ajaxOptions, thrownError) {
                    console.log(xhr.responseText);
                }

            });



            $.ajax({
                ""processing"": true,
                ""serverSide"": true,
         ");
                WriteLiteral(@"       ""url"": ""/api/piechartreport/dataprocessing"" + thePost,
                ""type"": ""GET"",
                ""datatype"": ""json"",

                success: function (data) {
                    dataprocessing = parseInt(data);
                }, error: function (xhr, ajaxOptions, thrownError) {
                    console.log(xhr.responseText);
                }

            });


            $.ajax({
                ""processing"": true,
                ""serverSide"": true,
                ""url"": ""/api/piechartreport/datasystem"" + thePost,
                ""type"": ""GET"",
                ""datatype"": ""json"",

                success: function (data) {
                    datasystem = parseInt(data)
                }, error: function (xhr, ajaxOptions, thrownError) {
                    console.log(xhr.responseText);
                }

            });

            $.ajax({
                ""processing"": true,
                ""serverSide"": true,
                ""url"": ""/api/piechartrepor");
                WriteLiteral(@"t/other"" + thePost,
                ""type"": ""GET"",
                ""datatype"": ""json"",

                success: function (data) {
                    other = parseInt(data)
                }, error: function (xhr, ajaxOptions, thrownError) {
                    console.log(xhr.responseText);
                }

            });

            $.ajax({
                ""processing"": true,
                ""serverSide"": true,
                ""url"": ""/api/piechartreport/procurement"" + thePost,
                ""type"": ""GET"",
                ""datatype"": ""json"",

                success: function (data) {
                    procurement = parseInt(data)
                }, error: function (xhr, ajaxOptions, thrownError) {
                    console.log(xhr.responseText);
                }

            });

             $.ajax({
                ""processing"": true,
                ""serverSide"": true,
                ""url"": ""/api/piechartreport/software"" + thePost,
                ""type"": ""GE");
                WriteLiteral(@"T"",
                ""datatype"": ""json"",

                success: function (data) {
                    software = parseInt(data)
                }, error: function (xhr, ajaxOptions, thrownError) {
                    console.log(xhr.responseText);
                }

             });


            $.ajax({
                ""processing"": true,
                ""serverSide"": true,
                ""url"": ""/api/piechartreport/logs"" + thePost,
                ""type"": ""GET"",
                ""datatype"": ""json"",

                success: function (data) {
                    logs = parseInt(data)
                }, error: function (xhr, ajaxOptions, thrownError) {
                    console.log(xhr.responseText);
                }

            });


            $.ajax({
                ""processing"": true,
                ""serverSide"": true,
                ""url"": ""/api/piechartreport/krmachine"" + thePost,
                ""type"": ""GET"",
                ""datatype"": ""json"",

          ");
                WriteLiteral(@"      success: function (data) {
                    krmachine = parseInt(data)
                }, error: function (xhr, ajaxOptions, thrownError) {
                    console.log(xhr.responseText);
                }

            });

     

               // Load Charts and the corechart package.
      google.charts.load('current', {'packages':['corechart']});

      // Draw the pie chart for Sarah's pizza when Charts is loaded.
      google.charts.setOnLoadCallback(drawSarahChart);

      // Draw the pie chart for the Anthony's pizza when Charts is loaded.
      google.charts.setOnLoadCallback(drawAnthonyChart);

      // Callback that draws the pie chart for Sarah's pizza.
      function drawSarahChart() {

        // Create the data table for Sarah's pizza.
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Topping');
          data.addColumn('number', 'Slices');
        data.addRows([

                
                ['Network', netwo");
                WriteLiteral(@"rk],
                ['Printer', printer],
                ['Mail', mail],
                ['Data Processing', dataprocessing],
                ['Computer', datasystem],
                ['Procurement', procurement],
                ['Other', other],
                ['Software', software],
                ['KR Machine', krmachine],
                ['Logs', logs],
                
        ]);

        // Set options for Sarah's pie chart.
        var options = {title:'Pie Chart',
                       width:900,
                       height:500};

        // Instantiate and draw the chart for Sarah's pizza.
        var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));
        chart.draw(data, options);
      }

      // Callback that draws the pie chart for Anthony's pizza.
      function drawAnthonyChart() {

        // Create the data table for Anthony's pizza.
        var data = new google.visualization.DataTable();
        data.addColumn('string");
                WriteLiteral(@"', 'Topping');
          data.addColumn('number', 'Slices');
        data.addRows([

                
                ['Network', network],
                ['Printer', printer],
                ['Mail', mail],
                ['Data Processing', dataprocessing],
                ['Computer', datasystem],
                ['Procurement', procurement],
                ['Other', other],
                ['Software', software],
                ['KR Machine', krmachine],
                ['Logs', logs],
        ]);

        // Set options for Anthony's pie chart.
        var options = {title:'Line Chart',
                       width:900,
                       height:500};

        // Instantiate and draw the chart for Anthony's pizza.
        var chart = new google.visualization.LineChart(document.getElementById('curve_chart'));
        chart.draw(data, options);
      }



        }




        $(function () {

            var start = moment().subtract(29, 'days');
            v");
                WriteLiteral(@"ar end = moment();

            function cb(start, end) {
                $('#daterange span').html(start.format('YYYY-MM-DD') + ' / ' + end.format('YYYY-MM-DD'));
            }

            $('#daterange').daterangepicker({
                startDate: start,
                endDate: end,
                ranges: {
                    'Today': [moment(), moment()],
                    'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                    'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                    'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                    'This Month': [moment().startOf('month'), moment().endOf('month')],
                    'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
                }
            }, cb);

            cb(start, end);

        });




    </script>


    <script type=""text/javascript"" src=""https://cdn.jsdelivr.");
                WriteLiteral(@"net/momentjs/latest/moment.min.js""></script>
    <script type=""text/javascript"" src=""https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.min.js""></script>
    <script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>

   
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