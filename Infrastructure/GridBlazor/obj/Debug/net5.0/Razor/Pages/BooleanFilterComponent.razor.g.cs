#pragma checksum "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7526dee223f886a2e3602821acd56b302041a75c"
// <auto-generated/>
#pragma warning disable 1591
namespace GridBlazor.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Projects\VMS\Infrastructure\GridBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\VMS\Infrastructure\GridBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\VMS\Infrastructure\GridBlazor\_Imports.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\VMS\Infrastructure\GridBlazor\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
using GridBlazor.Resources;

#line default
#line hidden
#nullable disable
    public partial class BooleanFilterComponent<T> : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 5 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
 if (Visible)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "dropdown dropdown-menu grid-dropdown opened");
            __builder.AddAttribute(2, "style", "display:block;position:relative;" + (
#nullable restore
#line 7 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
                                                                                                  "margin-left:" + _offset.ToString() + "px;"

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "onkeyup", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.KeyboardEventArgs>(this, 
#nullable restore
#line 7 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
                                                                                                                                                                            FilterKeyup

#line default
#line hidden
#nullable disable
            ));
            __builder.AddEventStopPropagationAttribute(4, "onclick", true);
            __builder.AddEventStopPropagationAttribute(5, "onkeyup", true);
            __builder.AddElementReferenceCapture(6, (__value) => {
#nullable restore
#line 7 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
                                                                                                                                                      boolFilter = __value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.AddMarkupContent(7, "\n    ");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "grid-dropdown-arrow");
            __builder.AddAttribute(10, "style", 
#nullable restore
#line 8 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
                                              "margin-left:" + (-_offset).ToString() + "px;"

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\n    ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "grid-dropdown-inner");
            __builder.AddMarkupContent(14, "\n        ");
            __builder.OpenElement(15, "div");
            __builder.AddAttribute(16, "class", "grid-popup-widget");
            __builder.AddMarkupContent(17, "\n            ");
            __builder.OpenElement(18, "div");
            __builder.AddAttribute(19, "class", "grid-filter-body");
            __builder.AddMarkupContent(20, "\n                ");
            __builder.OpenElement(21, "label");
            __builder.OpenElement(22, "b");
#nullable restore
#line 12 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
__builder.AddContent(23, Strings.FilterValueLabel);

#line default
#line hidden
#nullable disable
            __builder.AddContent(24, ":");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\n                ");
            __builder.OpenElement(26, "ul");
            __builder.AddAttribute(27, "class", "menu-list");
            __builder.AddMarkupContent(28, "\n                    ");
            __builder.OpenElement(29, "li");
            __builder.AddMarkupContent(30, "\n                        ");
            __builder.OpenElement(31, "a");
            __builder.AddAttribute(32, "class", "grid-filter-choose" + (
#nullable restore
#line 15 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
                                                      _filterValue != null && _filterValue.ToLower() == "true" ? " choose-selected" : ""

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(33, "data-value", "true");
            __builder.AddAttribute(34, "href", "javascript:void(0);");
            __builder.AddAttribute(35, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 15 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
                                                                                                                                                                                                  ApplyTrueButtonClicked

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(36, "\n                            ");
#nullable restore
#line 16 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
__builder.AddContent(37, Strings.BoolTrueLabel);

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(38, "\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\n                    ");
            __builder.OpenElement(41, "li");
            __builder.AddMarkupContent(42, "\n                        ");
            __builder.OpenElement(43, "a");
            __builder.AddAttribute(44, "class", "grid-filter-choose" + (
#nullable restore
#line 20 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
                                                      _filterValue != null && _filterValue.ToLower() == "false" ? " choose-selected" : ""

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(45, "data-value", "false");
            __builder.AddAttribute(46, "href", "javascript:void(0);");
            __builder.AddAttribute(47, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 20 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
                                                                                                                                                                                                    ApplyFalseButtonClicked

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(48, "\n                            ");
#nullable restore
#line 21 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
__builder.AddContent(49, Strings.BoolFalseLabel);

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(50, "\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(51, "\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(52, "\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(53, "\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\n        ");
            __builder.OpenElement(56, "div");
            __builder.AddAttribute(57, "class", "grid-popup-additional");
            __builder.AddMarkupContent(58, "\n");
#nullable restore
#line 28 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
             if (_clearVisible)
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(59, "                ");
            __builder.OpenElement(60, "ul");
            __builder.AddAttribute(61, "class", "menu-list");
            __builder.AddMarkupContent(62, "\n                    ");
            __builder.OpenElement(63, "li");
            __builder.AddMarkupContent(64, "\n                        ");
            __builder.OpenElement(65, "a");
            __builder.AddAttribute(66, "class", "grid-filter-clear");
            __builder.AddAttribute(67, "href", "javascript:void(0);");
            __builder.AddAttribute(68, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 32 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
                                                                                          ClearButtonClicked

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(69, "\n                            ");
#nullable restore
#line 33 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
__builder.AddContent(70, Strings.ClearFilterLabel);

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(71, "\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(72, "\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(73, "\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(74, "\n");
#nullable restore
#line 37 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(75, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(76, "\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(77, "\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(78, "\n");
#nullable restore
#line 41 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
