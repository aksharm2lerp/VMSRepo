#pragma checksum "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridCol.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "736945e771ad1ae7e6604cfd990010f8c7a18c2b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__GridCol), @"mvc.1.0.view", @"/Views/Shared/_GridCol.cshtml")]
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
#line 1 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridCol.cshtml"
using GridShared.Columns;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"736945e771ad1ae7e6604cfd990010f8c7a18c2b", @"/Views/Shared/_GridCol.cshtml")]
    #nullable restore
    public class Views_Shared__GridCol : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IGridColumn>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("\n");
#nullable restore
#line 5 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridCol.cshtml"
  
    const string HiddenStyle = "display:none;";
    string _cssStyles;

    if (Model.Hidden)
    {
        _cssStyles = HiddenStyle;
    }
    else
    {
        _cssStyles = "";
    }

    if (!string.IsNullOrWhiteSpace(Model.Width))
    {
        _cssStyles = string.Concat(_cssStyles, " width:", Model.Width, ";").Trim();
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<col");
            BeginWriteAttribute("style", " style=\"", 389, "\"", 408, 1);
#nullable restore
#line 24 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridCol.cshtml"
WriteAttributeValue("", 397, _cssStyles, 397, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IGridColumn> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
