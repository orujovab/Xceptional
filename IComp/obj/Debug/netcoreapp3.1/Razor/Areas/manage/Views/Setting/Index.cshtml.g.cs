#pragma checksum "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "66ad1fbccfa96644213a03b66b28a1d9ebca28ce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_manage_Views_Setting_Index), @"mvc.1.0.view", @"/Areas/manage/Views/Setting/Index.cshtml")]
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
#line 1 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\_ViewImports.cshtml"
using IComp.Service.DTOs.ProcessorDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\_ViewImports.cshtml"
using IComp.Service.DTOs.ProcessorSerieDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\_ViewImports.cshtml"
using IComp.Service.DTOs.VideoCardDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\_ViewImports.cshtml"
using IComp.Service.DTOs.MemoryDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\_ViewImports.cshtml"
using IComp.Service.DTOs.MemoryCapacityDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\_ViewImports.cshtml"
using IComp.Service.DTOs.VCSerieDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\_ViewImports.cshtml"
using IComp.Service.DTOs.HardDiscDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\_ViewImports.cshtml"
using IComp.Service.DTOs.HardDiscCapacityDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\_ViewImports.cshtml"
using IComp.Service.DTOs.BrandDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\_ViewImports.cshtml"
using IComp.Service.DTOs.CategoryDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\_ViewImports.cshtml"
using IComp.Service.DTOs.ProductDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\_ViewImports.cshtml"
using IComp.Service.DTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\_ViewImports.cshtml"
using IComp.Service.DTOs.MotherBoardDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\_ViewImports.cshtml"
using IComp.Service.DTOs.ProductPartsDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\_ViewImports.cshtml"
using IComp.Service.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\_ViewImports.cshtml"
using IComp.Areas.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\_ViewImports.cshtml"
using IComp.Core.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66ad1fbccfa96644213a03b66b28a1d9ebca28ce", @"/Areas/manage/Views/Setting/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12f30ab681f4ca286641d1eccb53e85a274f8bb7", @"/Areas/manage/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_manage_Views_Setting_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PaginatedListDto<Setting>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-page", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
  
    ViewData["Title"] = "Index";
    int counter = (Model.PageIndex - 1) * 3;


#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"container\">\n    <div class=\"row\">\n        <div class=\"col-lg-12 d-flex justify-content-between\">\n            <h3>Settings</h3>\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "66ad1fbccfa96644213a03b66b28a1d9ebca28ce9435", async() => {
                WriteLiteral("Create");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
        <div class=""col-lg-12"">
            <table class=""table"">
                <thead class=""thead-light"">
                    <tr>
                        <th scope=""col"">#</th>
                        <th scope=""col"">Key</th>
                        <th scope=""col"">Value</th>
                        <th scope=""col"">Image</th>
                        <th scope=""col""></th>
                        <th scope=""col""></th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 27 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                     foreach (var item in Model.Items)
                    {
                        counter++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\n                            <th scope=\"row\">");
#nullable restore
#line 31 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                                       Write(counter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\n                            <td>");
#nullable restore
#line 32 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                           Write(item.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 33 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                           Write(item.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n");
#nullable restore
#line 34 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                             if (item.Value.Contains(".png") || item.Value.Contains(".jpeg") || item.Value.Contains("jpg"))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "66ad1fbccfa96644213a03b66b28a1d9ebca28ce12858", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1386, "~/uploads/settings/", 1386, 19, true);
#nullable restore
#line 37 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
AddHtmlAttributeValue("", 1405, item.Value, 1405, 11, false);

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
            WriteLiteral("\n                                </td>\n");
#nullable restore
#line 39 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td></td>\n");
#nullable restore
#line 43 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "66ad1fbccfa96644213a03b66b28a1d9ebca28ce15113", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 45 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                                                       WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                            </td>\n                        </tr>\n");
#nullable restore
#line 48 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </tbody>\n            </table>\n\n            <nav aria-label=\"Page navigation example\">\n                <ul class=\"pagination\">\n");
#nullable restore
#line 55 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                     if (Model.HasPrev)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"page-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "66ad1fbccfa96644213a03b66b28a1d9ebca28ce18120", async() => {
#nullable restore
#line 57 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                                                                                                     Write("<<");

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\n                        <li class=\"page-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "66ad1fbccfa96644213a03b66b28a1d9ebca28ce20168", async() => {
#nullable restore
#line 58 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                                                                                                                          Write("<");

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 58 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                                                                                           WriteLiteral(Model.PageIndex - 1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\n");
#nullable restore
#line 59 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                     for (int i = 1; i <= Model.TotalPage; i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"page-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "66ad1fbccfa96644213a03b66b28a1d9ebca28ce23276", async() => {
#nullable restore
#line 62 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                                                                                                     Write(i);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 62 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                                                                                          WriteLiteral(i);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\n");
#nullable restore
#line 63 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                     if (Model.HasNext)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"page-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "66ad1fbccfa96644213a03b66b28a1d9ebca28ce26318", async() => {
#nullable restore
#line 66 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                                                                                                                          Write(">");

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 66 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                                                                                           WriteLiteral(Model.PageIndex + 1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\n                        <li class=\"page-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "66ad1fbccfa96644213a03b66b28a1d9ebca28ce28947", async() => {
#nullable restore
#line 67 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                                                                                                                    Write(">>");

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 67 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                                                                                          WriteLiteral(Model.TotalPage);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\n");
#nullable restore
#line 68 "C:\xampp\htdocs\XceptionalW\Icomp.az\IComp\IComp\Areas\manage\Views\Setting\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\n            </nav>\n        </div>\n    </div>\n</div>\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PaginatedListDto<Setting>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
