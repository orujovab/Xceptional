#pragma checksum "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\Order\TrackOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "827a7965d18e633e39d0ea2656bdc99b4af16094"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_TrackOrder), @"mvc.1.0.view", @"/Views/Order/TrackOrder.cshtml")]
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
#line 1 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.ProcessorDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.ProcessorSerieDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.VideoCardDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.MemoryDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.MemoryCapacityDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.VCSerieDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.HardDiscDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.HardDiscCapacityDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.BrandDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.CategoryDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.ProductDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.AppUserDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.ProductPartsDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Core.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"827a7965d18e633e39d0ea2656bdc99b4af16094", @"/Views/Order/TrackOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d62eb347431375907ea01495c26217e23afbb2de", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Order_TrackOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "trackorder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "order", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\Order\TrackOrder.cshtml"
  
    ViewData["Title"] = "TrackOrder";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""track"" style=""
display: flex;
    justify-content: center;
    height: 74vh;
    align-items: center;
background: #36D1DC;  /* fallback for old browsers */
background: -webkit-linear-gradient(to right, #5B86E5, #36D1DC);  /* Chrome 10-25, Safari 5.1-6 */
background: linear-gradient(to right, #5B86E5, #36D1DC); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */

"">
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "827a7965d18e633e39d0ea2656bdc99b4af160947538", async() => {
                WriteLiteral("\n        <input type=\"text\" name=\"trackid\" style=\"    width: 400px;\n    height: 45px;\"/>\n        <button type=\"submit\" style=\"    width: 100px;\n    height: 43px;\n    border: none;\">Submit</button>\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</div>\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591