#pragma checksum "C:\Projects\HelpDesk\CallogApp\Areas\User\Views\UserComment\GetAllCommentsByRequest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac5500217cae25c2ea0e6e89a8b9446d7f93054f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_UserComment_GetAllCommentsByRequest), @"mvc.1.0.view", @"/Areas/User/Views/UserComment/GetAllCommentsByRequest.cshtml")]
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
#line 1 "C:\Projects\HelpDesk\CallogApp\Areas\User\_ViewImports.cshtml"
using CallogApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\HelpDesk\CallogApp\Areas\User\_ViewImports.cshtml"
using CallogApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\HelpDesk\CallogApp\Areas\User\Views\UserComment\GetAllCommentsByRequest.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\HelpDesk\CallogApp\Areas\User\Views\UserComment\GetAllCommentsByRequest.cshtml"
using CallogApp.Utility;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac5500217cae25c2ea0e6e89a8b9446d7f93054f", @"/Areas/User/Views/UserComment/GetAllCommentsByRequest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5bea9ab759c8394bfef8f2618f3c227856ba4d9", @"/Areas/User/_ViewImports.cshtml")]
    public class Areas_User_Views_UserComment_GetAllCommentsByRequest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Comment>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Projects\HelpDesk\CallogApp\Areas\User\Views\UserComment\GetAllCommentsByRequest.cshtml"
  
    ViewData["Title"] = "GetAllCommentsByRequest";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>All Comments for ticket id ");
#nullable restore
#line 13 "C:\Projects\HelpDesk\CallogApp\Areas\User\Views\UserComment\GetAllCommentsByRequest.cshtml"
                          Write(Context.Request.RouteValues["id"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h2>\r\n\r\n");
#nullable restore
#line 15 "C:\Projects\HelpDesk\CallogApp\Areas\User\Views\UserComment\GetAllCommentsByRequest.cshtml"
 if (!User.IsInRole("Super Admin") && !User.IsInRole("Admin"))
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac5500217cae25c2ea0e6e89a8b9446d7f93054f5186", async() => {
                WriteLiteral("\r\n            <i class=\"fa fa-plus-circle\">Create New</i>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 19 "C:\Projects\HelpDesk\CallogApp\Areas\User\Views\UserComment\GetAllCommentsByRequest.cshtml"
                                 WriteLiteral(Context.Request.RouteValues["id"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </p>\r\n");
#nullable restore
#line 23 "C:\Projects\HelpDesk\CallogApp\Areas\User\Views\UserComment\GetAllCommentsByRequest.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 25 "C:\Projects\HelpDesk\CallogApp\Areas\User\Views\UserComment\GetAllCommentsByRequest.cshtml"
 if (Model.Any())
{

    

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Projects\HelpDesk\CallogApp\Areas\User\Views\UserComment\GetAllCommentsByRequest.cshtml"
     foreach (var comment in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card\" style=\"width: 30rem;\">\r\n            <div class=\"card-body\">\r\n                <p class=\"card-text\">");
#nullable restore
#line 32 "C:\Projects\HelpDesk\CallogApp\Areas\User\Views\UserComment\GetAllCommentsByRequest.cshtml"
                                Write(Html.Raw(comment.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral(".</p>\r\n                <h6>");
#nullable restore
#line 33 "C:\Projects\HelpDesk\CallogApp\Areas\User\Views\UserComment\GetAllCommentsByRequest.cshtml"
               Write(comment.CreatedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 36 "C:\Projects\HelpDesk\CallogApp\Areas\User\Views\UserComment\GetAllCommentsByRequest.cshtml"

    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Projects\HelpDesk\CallogApp\Areas\User\Views\UserComment\GetAllCommentsByRequest.cshtml"
     

}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card-header\">\r\n        No comments yet\r\n\r\n    </div>\r\n");
#nullable restore
#line 46 "C:\Projects\HelpDesk\CallogApp\Areas\User\Views\UserComment\GetAllCommentsByRequest.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<IdentityUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Comment>> Html { get; private set; }
    }
}
#pragma warning restore 1591
