#pragma checksum "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\Shared\_FastOrderPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7c558d8df63ab184de7616862c1136390c28af46"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__FastOrderPartial), @"mvc.1.0.view", @"/Views/Shared/_FastOrderPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c558d8df63ab184de7616862c1136390c28af46", @"/Views/Shared/_FastOrderPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d62eb347431375907ea01495c26217e23afbb2de", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__FastOrderPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FastCheckOutViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 80%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\Shared\_FastOrderPartial.cshtml"
  
    var counter = 0;
    decimal productTotalPrice = 0;
    var item = Model.Product;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"shopping-cart\">\n\n");
#nullable restore
#line 11 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\Shared\_FastOrderPartial.cshtml"
      
        productTotalPrice = item.Count * (item.DiscountPercent > 0 ? item.SalePrice * (1 - item.DiscountPercent / 100) : item.SalePrice);
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    <div class=\"product\">\n        <div class=\"product-image-basket\" style=\"width: 10%;\">\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "7c558d8df63ab184de7616862c1136390c28af467092", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 434, "~/uploads/products/", 434, 19, true);
#nullable restore
#line 17 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\Shared\_FastOrderPartial.cshtml"
AddHtmlAttributeValue("", 453, item.ProductImages.FirstOrDefault(x => x.PosterStatus == true)?.Image, 453, 70, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        </div>\n        <div class=\"product-details\">\n            <div class=\"product-title\">");
#nullable restore
#line 20 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\Shared\_FastOrderPartial.cshtml"
                                  Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
            <p class=""product-description"">
                The best dog bones of all time. Holy crap. Your dog
                will be begging for these things! I got curious once and ate one myself. I'm a
                fan.
            </p>
        </div>
        <div class=""product-price-basket"">price:  ₼");
#nullable restore
#line 27 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\Shared\_FastOrderPartial.cshtml"
                                               Write((item.DiscountPercent > 0 ?item.SalePrice*(1-item.DiscountPercent/100):item.SalePrice).ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n        <div class=\"product-quantity\">\n            <input type=\"number\" form=\"fastOrder\" name=\"ordercount\" value=\"1\" min=\"1\"");
            BeginWriteAttribute("max", " max=\"", 1183, "\"", 1200, 1);
#nullable restore
#line 29 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\Shared\_FastOrderPartial.cshtml"
WriteAttributeValue("", 1189, item.Count, 1189, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n            <input type=\"hidden\" form=\"fastOrder\" name=\"prodcount\"");
            BeginWriteAttribute("value", " value=\"", 1269, "\"", 1288, 1);
#nullable restore
#line 30 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\Shared\_FastOrderPartial.cshtml"
WriteAttributeValue("", 1277, item.Count, 1277, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1323, "\"", 1339, 1);
#nullable restore
#line 31 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\Shared\_FastOrderPartial.cshtml"
WriteAttributeValue("", 1331, item.Id, 1331, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n\n        </div>\n        \n        <div class=\"product-line-price\">");
#nullable restore
#line 35 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\Shared\_FastOrderPartial.cshtml"
                                    Write((item.DiscountPercent > 0 ?item.SalePrice*(1-item.DiscountPercent/100):item.SalePrice).ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n    </div>\n    <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1555, "\"", 1571, 1);
#nullable restore
#line 37 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\Shared\_FastOrderPartial.cshtml"
WriteAttributeValue("", 1563, counter, 1563, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"basket-count\" />\n\n\n    <div class=\"totals\">\n        <div class=\"totals-item totals-item-total\">\n            <label>Total</label>\n            <div class=\"totals-value\" id=\"cart-total\">");
#nullable restore
#line 43 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\Shared\_FastOrderPartial.cshtml"
                                                  Write((item.DiscountPercent > 0 ?item.SalePrice*(1-item.DiscountPercent/100):item.SalePrice).ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n        </div>\n    </div>\n\n\n\n</div>\n\n");
#nullable restore
#line 51 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\Shared\_FastOrderPartial.cshtml"
Write(await Html.PartialAsync("_FastOrderFormPartial", Model.Order));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<input form=\"fastOrder\" type=\"hidden\" name=\"productid\"");
            BeginWriteAttribute("value", " value=\"", 2029, "\"", 2045, 1);
#nullable restore
#line 52 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Views\Shared\_FastOrderPartial.cshtml"
WriteAttributeValue("", 2037, item.Id, 2037, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FastCheckOutViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
