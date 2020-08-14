#pragma checksum "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\Home\ITDashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf10da8039f0493801f7542757343d94d81c44a9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_ITDashboard), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/ITDashboard.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf10da8039f0493801f7542757343d94d81c44a9", @"/Areas/Admin/Views/Home/ITDashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5bea9ab759c8394bfef8f2618f3c227856ba4d9", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Home_ITDashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color:white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "requests", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "pendingrequest", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "myassignedtask", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\Home\ITDashboard.cshtml"
  
    ViewData["Title"] = "IT Dashboard";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<ol class=""breadcrumb"">
    <li class=""breadcrumb-item""><a href=""index.html"">Home</a> <i class=""fa fa-angle-right""></i></li>
</ol>
<!--four-grids here-->
<div class=""four-grids"">
    <div class=""col-md-3 four-grid"">
        <div class=""four-agileits"">
            <div class=""icon"">
                <i class=""glyphicon glyphicon-list"" aria-hidden=""true""></i>
            </div>
            <div class=""four-text"">

                <h3 class=""text-light"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf10da8039f0493801f7542757343d94d81c44a95451", async() => {
                WriteLiteral("All Pending Requests");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h3>\r\n                <h4> ");
#nullable restore
#line 20 "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\Home\ITDashboard.cshtml"
                Write(ViewBag.pendingRequestsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>

            </div>

        </div>
    </div>

    <div class=""col-md-3 four-grid"">
        <div class=""four-w3ls"">
            <div class=""icon"">
                <i class=""glyphicon glyphicon-link"" aria-hidden=""true""></i>
            </div>
            <div class=""four-text"">
                <h3 class=""text-light"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf10da8039f0493801f7542757343d94d81c44a97726", async() => {
                WriteLiteral(" Assigned Pending Requests");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h3>\r\n               \r\n                <h4> ");
#nullable restore
#line 35 "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\Home\ITDashboard.cshtml"
                Write(ViewBag.myPendingRequest);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>

            </div>

        </div>
    </div>
    <div class=""col-md-3 four-grid"">
        <div class=""four-wthree"">
            <div class=""icon"">
                <i class=""glyphicon glyphicon-time"" aria-hidden=""true""></i>
            </div>
            <div class=""four-text"">
                <h3 class=""text-light"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf10da8039f0493801f7542757343d94d81c44a910044", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("Today Requests\r\n                </h3>\r\n                <h4>\r\n                   \r\n                        ");
#nullable restore
#line 52 "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\Home\ITDashboard.cshtml"
                   Write(ViewBag.todayRequests);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    
                </h4>

            </div>

        </div>
    </div>
    <div class=""clearfix""></div>

    <table class=""columns"">
        <tr>
            <td><div id=""piechart_3d"" style=""border: 1px solid #ccc""></div></td>
       
        </tr>
    </table>
</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>
    <script type=""text/javascript"">


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
        data.addColumn('number', 'Requests');
        data.addRows([

                ['Network', ");
#nullable restore
#line 92 "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\Home\ITDashboard.cshtml"
                       Write(ViewBag.networkIssueCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'Printer\', ");
#nullable restore
#line 93 "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\Home\ITDashboard.cshtml"
                       Write(ViewBag.printerIssueCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'Mail\', ");
#nullable restore
#line 94 "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\Home\ITDashboard.cshtml"
                    Write(ViewBag.mailCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'Data Processing\', ");
#nullable restore
#line 95 "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\Home\ITDashboard.cshtml"
                               Write(ViewBag.dataProcessingCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'Computer\', ");
#nullable restore
#line 96 "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\Home\ITDashboard.cshtml"
                        Write(ViewBag.dataSystemCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'Procurement\', ");
#nullable restore
#line 97 "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\Home\ITDashboard.cshtml"
                           Write(ViewBag.dataProcurementCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'Other\', ");
#nullable restore
#line 98 "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\Home\ITDashboard.cshtml"
                     Write(ViewBag.dataOtherCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'Software\', ");
#nullable restore
#line 99 "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\Home\ITDashboard.cshtml"
                        Write(ViewBag.softwareCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'KR Machine\', ");
#nullable restore
#line 100 "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\Home\ITDashboard.cshtml"
                          Write(ViewBag.dataKRCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'Logs\', ");
#nullable restore
#line 101 "C:\Projects\HelpDesk\CallogApp\Areas\Admin\Views\Home\ITDashboard.cshtml"
                    Write(ViewBag.logsCount);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"],

        ]);

        // Set options for Sarah's pie chart.
        var options = {title:'Today Requests in Pie Chart',
                       width:900,
                       height:400};

        // Instantiate and draw the chart for Sarah's pizza.
        var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));
        chart.draw(data, options);
      }

");
                WriteLiteral("\r\n\r\n    </script>\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
