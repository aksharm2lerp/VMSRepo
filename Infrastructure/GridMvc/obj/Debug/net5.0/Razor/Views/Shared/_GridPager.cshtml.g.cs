#pragma checksum "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d78403fe145e5e864167ee1aa21d39a6a66fa6b6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__GridPager), @"mvc.1.0.view", @"/Views/Shared/_GridPager.cshtml")]
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
#line 1 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
using GridCore.Pagination;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
using GridCore.Resources;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d78403fe145e5e864167ee1aa21d39a6a66fa6b6", @"/Views/Shared/_GridPager.cshtml")]
    #nullable restore
    public class Views_Shared__GridPager : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GridPager>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
 if (Model == null || Model.PageCount <= 1)
{
    return;
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 9 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
  
    string _changePageSizeUrl = (string) ViewData["changePageSizeUrl"];
    string _goToUrl = (string) ViewData["goToUrl"];
    bool _enablePaging = (bool) ViewData["enablePaging"];
    int _pageSize = Model.ChangePageSize && Model.QueryPageSize > 0 ? Model.QueryPageSize : Model.PageSize;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"grid-pager-sizer\">\n    <nav class=\"grid-pager\" data-currentpage=\"");
#nullable restore
#line 17 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
                                         Write(Model.CurrentPage);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\n        <ul class=\"pagination\">\n");
#nullable restore
#line 19 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
             if (Model.CurrentPage > 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"page-item\">\n                    <a class=\"page-link grid-page-link\"");
            BeginWriteAttribute("href", " href=\"", 705, "\"", 802, 3);
#nullable restore
#line 22 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 712, Context.Request.PathBase, 712, 25, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 737, Context.Request.Path, 737, 21, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 758, Model.GetLinkForPage(Model.CurrentPage - 1), 758, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">«</a>\n                </li>\n");
#nullable restore
#line 24 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 26 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
             if (Model.StartDisplayedPage > 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"page-item\">\n                    <a class=\"page-link grid-page-link\"");
            BeginWriteAttribute("href", " href=\"", 1002, "\"", 1079, 3);
#nullable restore
#line 29 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 1009, Context.Request.PathBase, 1009, 25, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 1034, Context.Request.Path, 1034, 21, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 1055, Model.GetLinkForPage(1), 1055, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">1</a>\n                </li>\n");
#nullable restore
#line 31 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
                if (Model.StartDisplayedPage > 2)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item\"><a class=\"page-link grid-page-link\"");
            BeginWriteAttribute("href", " href=\"", 1254, "\"", 1358, 3);
#nullable restore
#line 33 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 1261, Context.Request.PathBase, 1261, 25, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 1286, Context.Request.Path, 1286, 21, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 1307, Model.GetLinkForPage(Model.StartDisplayedPage - 1), 1307, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">...</a></li>\n");
#nullable restore
#line 34 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
             for (int i = Model.StartDisplayedPage; i <= Model.EndDisplayedPage; i++)
            {
                if (i == Model.CurrentPage)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item active\"><span type=\"button\" class=\"page-link grid-page-link\">");
#nullable restore
#line 40 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
                                                                                                 Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\n");
#nullable restore
#line 41 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item\"><a class=\"page-link grid-page-link\"");
            BeginWriteAttribute("href", " href=\"", 1818, "\"", 1895, 3);
#nullable restore
#line 44 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 1825, Context.Request.PathBase, 1825, 25, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 1850, Context.Request.Path, 1850, 21, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 1871, Model.GetLinkForPage(i), 1871, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 44 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
                                                                                                                                                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\n");
#nullable restore
#line 45 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
             if (Model.EndDisplayedPage < Model.PageCount)
            {
                if (Model.EndDisplayedPage < Model.PageCount - 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item\"><a class=\"page-link grid-page-link\"");
            BeginWriteAttribute("href", " href=\"", 2175, "\"", 2277, 3);
#nullable restore
#line 51 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 2182, Context.Request.PathBase, 2182, 25, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 2207, Context.Request.Path, 2207, 21, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 2228, Model.GetLinkForPage(Model.EndDisplayedPage + 1), 2228, 49, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">...</a></li>\n");
#nullable restore
#line 52 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li><a class=\"page-link grid-page-link\"");
            BeginWriteAttribute("href", " href=\"", 2365, "\"", 2456, 3);
#nullable restore
#line 53 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 2372, Context.Request.PathBase, 2372, 25, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 2397, Context.Request.Path, 2397, 21, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 2418, Model.GetLinkForPage(Model.PageCount), 2418, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 53 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
                                                                                                                                               Write(Model.PageCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\n");
#nullable restore
#line 54 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
             if (Model.CurrentPage < Model.PageCount)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"page-item\"><a class=\"page-link grid-page-link\"");
            BeginWriteAttribute("href", " href=\"", 2639, "\"", 2736, 3);
#nullable restore
#line 57 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 2646, Context.Request.PathBase, 2646, 25, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 2671, Context.Request.Path, 2671, 21, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 2692, Model.GetLinkForPage(Model.CurrentPage + 1), 2692, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">»</a></li>\n");
#nullable restore
#line 58 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\n    </nav>\n\n");
            WriteLiteral("\n");
#nullable restore
#line 69 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
     if (_enablePaging && Model.ChangePageSize)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"grid-change-page-size form-group\" data-change-page-size-url=\"");
#nullable restore
#line 71 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
                                                                            Write(_changePageSizeUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\n            <label class=\"control-label\"><b>");
#nullable restore
#line 72 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
                                       Write(Strings.Show);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></label>\n            <div>\n                <input class=\"to-txt grid-change-page-size-input\"");
            BeginWriteAttribute("value", " value=\"", 3370, "\"", 3388, 1);
#nullable restore
#line 74 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
WriteAttributeValue("", 3378, _pageSize, 3378, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n            </div>\n            <label class=\"control-label\"><b>");
#nullable restore
#line 76 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
                                       Write(Strings.Items);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></label>\n        </div>\n");
#nullable restore
#line 78 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridPager.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GridPager> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591