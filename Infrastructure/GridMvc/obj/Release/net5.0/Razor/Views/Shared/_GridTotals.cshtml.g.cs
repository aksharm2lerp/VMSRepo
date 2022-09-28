#pragma checksum "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f94dbd51fc1b611368670d93cd252a7d69bcde7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__GridTotals), @"mvc.1.0.view", @"/Views/Shared/_GridTotals.cshtml")]
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
#line 1 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
using GridCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
using GridCore.Resources;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
using GridShared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
using GridShared.Columns;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f94dbd51fc1b611368670d93cd252a7d69bcde7", @"/Views/Shared/_GridTotals.cshtml")]
    #nullable restore
    public class Views_Shared__GridTotals : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ISGrid>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 7 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
 if (Model == null) { return; }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 9 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
  
    var firstColumn = (ITotalsColumn)Model.Columns.FirstOrDefault();
    bool hasSubGrid = Model.SubGridKeys != null && Model.SubGridKeys.Length > 0;
    bool requiredTotalsColumn = firstColumn != null
              && (firstColumn.IsSumEnabled || firstColumn.IsAverageEnabled
                  || firstColumn.IsMaxEnabled || firstColumn.IsMinEnabled);
    string cssStyles = "";
    if (Model.Direction == GridDirection.RTL)
        cssStyles = string.Concat(cssStyles, " text-align:right;direction:rtl;").Trim();

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 20 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
 if (Model.RenderOptions.RenderRowsOnly)
{
    return;
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr class=\"grid-row\"><td class=\"grid-cell\" style=\"height:25px;border:none;background-color:white\"></td></tr>\n");
#nullable restore
#line 27 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
    if (Model.IsSumEnabled)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr class=\"grid-totals-row\">\n");
#nullable restore
#line 30 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             if (hasSubGrid)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"grid-cell\" data-name=\"\"></td>\n");
#nullable restore
#line 33 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             if (requiredTotalsColumn)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 1107, "\"", 1125, 1);
#nullable restore
#line 36 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
WriteAttributeValue("", 1115, cssStyles, 1115, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><b>");
#nullable restore
#line 36 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                       Write(Strings.Sum);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></td>\n");
#nullable restore
#line 37 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             for (int i = 0; i < Model.Columns.Count(); i++)
            {
                var column = (ITotalsColumn)Model.Columns.ElementAt(i);
                if (i == 0 && !column.IsSumEnabled && !column.IsAverageEnabled
                   && !column.IsMaxEnabled && !column.IsMinEnabled)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 1519, "\"", 1537, 1);
#nullable restore
#line 44 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
WriteAttributeValue("", 1527, cssStyles, 1527, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><b>");
#nullable restore
#line 44 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                           Write(Strings.Sum);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></td>\n");
#nullable restore
#line 45 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                }
                else
                {
                    if (column.IsSumEnabled)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 1733, "\"", 1751, 1);
#nullable restore
#line 50 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
WriteAttributeValue("", 1741, cssStyles, 1741, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><b>");
#nullable restore
#line 50 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                               Write(column.SumString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></td>\n");
#nullable restore
#line 51 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                    }
                    else
                    {
                        if (((IGridColumn)column).Hidden)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"grid-cell\" style=\"display:none;\"></td>\n");
#nullable restore
#line 57 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 2144, "\"", 2162, 1);
#nullable restore
#line 60 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
WriteAttributeValue("", 2152, cssStyles, 2152, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></td>\n");
#nullable restore
#line 61 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                        }
                    }
                }

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\n");
#nullable restore
#line 67 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
    }
    if (Model.IsAverageEnabled)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr class=\"grid-totals-row\">\n");
#nullable restore
#line 71 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             if (hasSubGrid)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"grid-cell\" data-name=\"\"></td>\n");
#nullable restore
#line 74 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             if (requiredTotalsColumn)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 2550, "\"", 2568, 1);
#nullable restore
#line 77 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
WriteAttributeValue("", 2558, cssStyles, 2558, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><b>");
#nullable restore
#line 77 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                       Write(Strings.Average);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></td>\n");
#nullable restore
#line 78 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 79 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             for (int i = 0; i < Model.Columns.Count(); i++)
            {
                var column = (ITotalsColumn)Model.Columns.ElementAt(i);
                if (i == 0 && !column.IsSumEnabled && !column.IsAverageEnabled
                   && !column.IsMaxEnabled && !column.IsMinEnabled)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 2966, "\"", 2984, 1);
#nullable restore
#line 85 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
WriteAttributeValue("", 2974, cssStyles, 2974, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><b>");
#nullable restore
#line 85 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                           Write(Strings.Average);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></td>\n");
#nullable restore
#line 86 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                }
                else
                {
                    if (column.IsAverageEnabled)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 3188, "\"", 3206, 1);
#nullable restore
#line 91 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
WriteAttributeValue("", 3196, cssStyles, 3196, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><b>");
#nullable restore
#line 91 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                               Write(column.AverageString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></td>\n");
#nullable restore
#line 92 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                    }
                    else
                    {
                        if (((IGridColumn)column).Hidden)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"grid-cell\" style=\"display:none;\"></td>\n");
#nullable restore
#line 98 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 3603, "\"", 3621, 1);
#nullable restore
#line 101 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
WriteAttributeValue("", 3611, cssStyles, 3611, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></td>\n");
#nullable restore
#line 102 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                        }
                    }
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\n");
#nullable restore
#line 107 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
    }
    if (Model.IsMaxEnabled)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr class=\"grid-totals-row\">\n");
#nullable restore
#line 111 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             if (hasSubGrid)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"grid-cell\" data-name=\"\"></td>\n");
#nullable restore
#line 114 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 115 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             if (requiredTotalsColumn)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 4004, "\"", 4022, 1);
#nullable restore
#line 117 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
WriteAttributeValue("", 4012, cssStyles, 4012, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><b>");
#nullable restore
#line 117 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                       Write(Strings.Max);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></td>\n");
#nullable restore
#line 118 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 119 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             for (int i = 0; i < Model.Columns.Count(); i++)
            {
                var column = (ITotalsColumn)Model.Columns.ElementAt(i);
                if (i == 0 && !column.IsSumEnabled && !column.IsAverageEnabled
                   && !column.IsMaxEnabled && !column.IsMinEnabled)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 4416, "\"", 4434, 1);
#nullable restore
#line 125 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
WriteAttributeValue("", 4424, cssStyles, 4424, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><b>");
#nullable restore
#line 125 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                           Write(Strings.Max);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></td>\n");
#nullable restore
#line 126 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                }
                else
                {
                    if (column.IsMaxEnabled)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 4630, "\"", 4648, 1);
#nullable restore
#line 131 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
WriteAttributeValue("", 4638, cssStyles, 4638, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><b>");
#nullable restore
#line 131 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                               Write(column.MaxString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></td>\n");
#nullable restore
#line 132 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                    }
                    else
                    {
                        if (((IGridColumn)column).Hidden)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"grid-cell\" style=\"display:none;\"></td>\n");
#nullable restore
#line 138 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 5041, "\"", 5059, 1);
#nullable restore
#line 141 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
WriteAttributeValue("", 5049, cssStyles, 5049, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></td>\n");
#nullable restore
#line 142 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                        }
                    }
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\n");
#nullable restore
#line 147 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
    }
    if (Model.IsMinEnabled)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr class=\"grid-totals-row\">\n");
#nullable restore
#line 151 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             if (hasSubGrid)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"grid-cell\" data-name=\"\"></td>\n");
#nullable restore
#line 154 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 155 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             if (requiredTotalsColumn)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 5442, "\"", 5460, 1);
#nullable restore
#line 157 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
WriteAttributeValue("", 5450, cssStyles, 5450, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><b>");
#nullable restore
#line 157 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                       Write(Strings.Min);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></td>\n");
#nullable restore
#line 158 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 159 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             for (int i = 0; i < Model.Columns.Count(); i++)
            {
                var column = (ITotalsColumn)Model.Columns.ElementAt(i);
                if (i == 0 && !column.IsSumEnabled && !column.IsAverageEnabled
                   && !column.IsMaxEnabled && !column.IsMinEnabled)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 5854, "\"", 5872, 1);
#nullable restore
#line 165 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
WriteAttributeValue("", 5862, cssStyles, 5862, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><b>");
#nullable restore
#line 165 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                           Write(Strings.Min);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></td>\n");
#nullable restore
#line 166 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                }
                else
                {
                    if (column.IsMinEnabled)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 6068, "\"", 6086, 1);
#nullable restore
#line 171 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
WriteAttributeValue("", 6076, cssStyles, 6076, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><b>");
#nullable restore
#line 171 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                               Write(column.MinString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></td>\n");
#nullable restore
#line 172 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                    }
                    else
                    {
                        if (((IGridColumn)column).Hidden)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"grid-cell\" style=\"display:none;\"></td>\n");
#nullable restore
#line 178 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 6479, "\"", 6497, 1);
#nullable restore
#line 181 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
WriteAttributeValue("", 6487, cssStyles, 6487, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></td>\n");
#nullable restore
#line 182 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                        }
                    }
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\n");
#nullable restore
#line 187 "D:\AksharItSolution\VMS\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
    }
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ISGrid> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
