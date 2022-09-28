#pragma checksum "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5326d9d98dfa446b6078551c84d46a52cf047549"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__GridHeader), @"mvc.1.0.view", @"/Views/Shared/_GridHeader.cshtml")]
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
#line 1 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
using GridCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
using GridCore.Filtering;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
using GridCore.Pagination;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
using GridCore.Resources;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
using GridCore.Sorting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
using GridShared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
using GridShared.Columns;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
using GridShared.Filtering;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
using GridShared.Sorting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
using GridShared.Utility;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
using Microsoft.Extensions.Primitives;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
using System.Text.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5326d9d98dfa446b6078551c84d46a52cf047549", @"/Views/Shared/_GridHeader.cshtml")]
    #nullable restore
    public class Views_Shared__GridHeader : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IGridColumn>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("\n");
#nullable restore
#line 17 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
  
    const string ThClass = "grid-header";
    const string ThStyle = "display:none;";

    const string FilteredButtonCssClass = "filtered";
    const string FilterButtonCss = "grid-filter-btn";

    List<ColumnFilterValue> _filterSettings;
    string _url;
    string _cssStyles;
    string _cssClass;
    string _cssFilterClass;
    string _cssSortingClass;
    bool _isColumnFiltered;
    StringValues _clearInitFilter;


    _filterSettings = new List<ColumnFilterValue>();
    IGridSettingsProvider _settings = ((ISGrid)(Model.ParentGrid)).Settings;
    if (_settings.FilterSettings.IsInitState(Model) && Model.InitialFilterSettings != ColumnFilterValue.Null)
    {
        _filterSettings.Add(Model.InitialFilterSettings);
    }
    else
    {
        _filterSettings.AddRange(_settings.FilterSettings.FilteredColumns.GetByColumn(Model));
    }

    _isColumnFiltered = _filterSettings.Any(r => r.FilterType != GridFilterType.Condition);

    //determine current url:
    var queryBuilder = new CustomQueryStringBuilder(_settings.FilterSettings.Query);

    var exceptQueryParameters = new List<string>
{
        QueryStringFilterSettings.DefaultTypeQueryParameter,
        QueryStringFilterSettings.DefaultClearInitFilterQueryParameter
    };

    string pagerParameterName = GetPagerQueryParameterName(((ISGrid)(Model.ParentGrid)).Pager);
    if (!string.IsNullOrEmpty(pagerParameterName))
    {
        exceptQueryParameters.Add(pagerParameterName);
    }

    _url = queryBuilder.GetQueryStringExcept(exceptQueryParameters);

    _clearInitFilter = _settings.FilterSettings.Query.Get(QueryStringFilterSettings.DefaultClearInitFilterQueryParameter);

    if (Model.Hidden)
    {
        _cssStyles = ((GridStyledColumn)Model).GetCssStylesString() + " " + ThStyle;
    }
    else
    {
        _cssStyles = ((GridStyledColumn)Model).GetCssStylesString();
    }
    _cssClass = ((GridStyledColumn)Model).GetCssClassesString() + " " + ThClass;

    // tables with fixed layout don't need to set up column width on the header
    if (Model.ParentGrid.TableLayout == TableLayout.Auto)
    {
        if (!string.IsNullOrWhiteSpace(Model.Width))
        {
            _cssStyles = string.Concat(_cssStyles, " width:", Model.Width, "; border-width: 0.5px;").Trim();
        }
    }

    if (Model.ParentGrid.Direction == GridDirection.RTL)
        _cssStyles = string.Concat(_cssStyles, " text-align:right;direction:rtl; ").Trim();

    List<string> cssFilterClasses = new List<string>();
    cssFilterClasses.Add(FilterButtonCss);
    if (_isColumnFiltered)
    {
        cssFilterClasses.Add(FilteredButtonCssClass);
    }
    _cssFilterClass = string.Join(" ", cssFilterClasses);

    List<string> cssSortingClass = new List<string>();
    cssSortingClass.Add("grid-header-title");

    if (Model.IsSorted)
    {
        cssSortingClass.Add("sorted");
        cssSortingClass.Add(Model.Direction == GridSortDirection.Ascending ? "sorted-asc" : "sorted-desc");
    }
    _cssSortingClass = string.Join(" ", cssSortingClass);

    string _href = Context.Request.PathBase + Context.Request.Path + GetSortUrl(Model.Name, Model.Direction);

    string GetPagerQueryParameterName(IGridPager pager)
    {
        var defaultPager = pager as GridPager;
        if (defaultPager == null)
            return string.Empty;
        return defaultPager.ParameterName;
    }

    string GetSortUrl(string columnName, GridSortDirection? direction)
    {
        //determine current url:
        var builder = new CustomQueryStringBuilder(_settings.SortSettings.Query);
        string url = builder.GetQueryStringExcept(new[]
        {
            GridPager.DefaultPageQueryParameter,
            ((QueryStringSortSettings)_settings.SortSettings).ColumnQueryParameterName,
            ((QueryStringSortSettings)_settings.SortSettings).DirectionQueryParameterName
        });

        if (Model.IsSorted)
        {
            if (Model.Direction == GridSortDirection.Ascending)
            {
                if (string.IsNullOrEmpty(url))
                {
                    url = "?";
                }
                else
                {
                    url += "&";
                }

                return string.Format("{0}{1}={2}&{3}={4}", url,
                    ((QueryStringSortSettings)_settings.SortSettings).ColumnQueryParameterName, columnName,
                    ((QueryStringSortSettings)_settings.SortSettings).DirectionQueryParameterName,
                    ((int)GridSortDirection.Descending).ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                if (Model.InitialDirection.HasValue)
                {
                    if (string.IsNullOrEmpty(url))
                    {
                        url = "?";
                    }
                    else
                    {
                        url += "&";
                    }

                    return string.Format("{0}{1}={2}&{3}={4}", url,
                        ((QueryStringSortSettings)_settings.SortSettings).ColumnQueryParameterName, columnName,
                        ((QueryStringSortSettings)_settings.SortSettings).DirectionQueryParameterName,
                        ((int)GridSortDirection.Ascending).ToString(CultureInfo.InvariantCulture));
                }
                else if (string.IsNullOrEmpty(url))
                {
                    url = "?";
                }
                return url;
            }
        }
        else
        {
            if (string.IsNullOrEmpty(url))
            {
                url = "?";
            }
            else
            {
                url += "&";
            }

            return string.Format("{0}{1}={2}&{3}={4}", url,
                ((QueryStringSortSettings)_settings.SortSettings).ColumnQueryParameterName, columnName,
                ((QueryStringSortSettings)_settings.SortSettings).DirectionQueryParameterName,
                ((int)GridSortDirection.Ascending).ToString(CultureInfo.InvariantCulture));
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<th");
            BeginWriteAttribute("class", " class=\"", 6402, "\"", 6420, 1);
#nullable restore
#line 189 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
WriteAttributeValue("", 6410, _cssClass, 6410, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("style", " style=\"", 6421, "\"", 6440, 1);
#nullable restore
#line 189 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
WriteAttributeValue("", 6429, _cssStyles, 6429, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n    <div class=\"grid-header-group\">\n");
#nullable restore
#line 191 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
         if (Model.ParentGrid.ExtSortingEnabled)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div");
            BeginWriteAttribute("class", " class=\"", 6554, "\"", 6602, 2);
            WriteAttributeValue("", 6562, "grid-extsort-draggable", 6562, 22, true);
#nullable restore
#line 193 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
WriteAttributeValue(" ", 6584, _cssSortingClass, 6585, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" draggable=\"true\" data-column=\"");
#nullable restore
#line 193 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                                                                                           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\n");
#nullable restore
#line 194 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                 if (Model.SortEnabled)
                {
                    if (Model.IsSorted)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 6794, "\"", 6807, 1);
#nullable restore
#line 198 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
WriteAttributeValue("", 6801, _href, 6801, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-column=\"");
#nullable restore
#line 198 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                                                 Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-sorted=\"");
#nullable restore
#line 198 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                                                                            Write(Model.Direction == GridSortDirection.Ascending ? "asc" : "desc");

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 198 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                                                                                                                                               Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n");
#nullable restore
#line 199 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 7028, "\"", 7041, 1);
#nullable restore
#line 202 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
WriteAttributeValue("", 7035, _href, 7035, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-column=\"");
#nullable restore
#line 202 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                                                 Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 202 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                                                              Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n");
#nullable restore
#line 203 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                    }
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span data-column=\"");
#nullable restore
#line 207 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                                  Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 207 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                                               Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n");
#nullable restore
#line 208 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 209 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                 if (Model.IsSorted)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"grid-sort-arrow\"></span>\n");
#nullable restore
#line 212 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\n");
#nullable restore
#line 214 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div");
            BeginWriteAttribute("class", " class=\"", 7454, "\"", 7479, 1);
#nullable restore
#line 217 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
WriteAttributeValue("", 7462, _cssSortingClass, 7462, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n");
#nullable restore
#line 218 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                 if (Model.SortEnabled)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=\"", 7562, "\"", 7575, 1);
#nullable restore
#line 220 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
WriteAttributeValue("", 7569, _href, 7569, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 220 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                                Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n");
#nullable restore
#line 221 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span>");
#nullable restore
#line 224 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                     Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n");
#nullable restore
#line 225 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 226 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                 if (Model.IsSorted)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"grid-sort-arrow\"></span>\n");
#nullable restore
#line 229 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\n");
#nullable restore
#line 231 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 232 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
         if (Model.FilterEnabled)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"grid-filter\" data-type=\"");
#nullable restore
#line 234 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                                           Write(Model.FilterWidgetTypeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-isnullable=\"");
#nullable restore
#line 234 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                                                                                         Write(Model.Filter.IsNullable);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-name=\"");
#nullable restore
#line 234 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                                                                                                                              Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-widgetdata=\"");
#nullable restore
#line 234 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                                                                                                                                                            Write(JsonSerializer.Serialize(Model.FilterWidgetData));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-filterdata=\"");
#nullable restore
#line 234 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                                                                                                                                                                                                                                Write(JsonSerializer.Serialize(_filterSettings));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-url=\"");
#nullable restore
#line 234 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                                                                                                                                                                                                                                                                                      Write(_url);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-clearinitfilter=\"");
#nullable restore
#line 234 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
                                                                                                                                                                                                                                                                                                                   Write(_clearInitFilter.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\n                <span");
            BeginWriteAttribute("class", " class=\"", 8283, "\"", 8307, 1);
#nullable restore
#line 235 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
WriteAttributeValue("", 8291, _cssFilterClass, 8291, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 8308, "\"", 8348, 1);
#nullable restore
#line 235 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
WriteAttributeValue("", 8316, Strings.FilterButtonTooltipText, 8316, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></span>\n            </div>\n");
#nullable restore
#line 237 "C:\Projects\VMS\Infrastructure\GridMvc\Views\Shared\_GridHeader.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n</th>\n\n\n");
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