#pragma checksum "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\FormTooltipComponent.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d2f52b68158eadba160ff9c1e696557248e49c3"
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
    public partial class FormTooltipComponent<T> : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "label");
            __builder.AddAttribute(1, "for", 
#nullable restore
#line 3 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\FormTooltipComponent.razor"
             Column.FieldName

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(2, "class", "col-form-label");
            __builder.AddAttribute(3, "onmouseover", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 3 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\FormTooltipComponent.razor"
                                                                    e => DisplayTooltip(Column.Name)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "onmouseout", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 3 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\FormTooltipComponent.razor"
                                                                                                                   e => HideTooltip(Column.Name)

#line default
#line hidden
#nullable disable
            ));
#nullable restore
#line 3 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\FormTooltipComponent.razor"
__builder.AddContent(5, Column.Title);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\n");
#nullable restore
#line 4 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\FormTooltipComponent.razor"
 if (_isTooltipVisible)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(7, "    ");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "grid-tooltip");
            __builder.AddMarkupContent(10, "\n        ");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "dropdown dropdown-menu grid-tooltip-dropdown opened");
            __builder.AddAttribute(13, "style", "display:block;" + (
#nullable restore
#line 7 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\FormTooltipComponent.razor"
                                                                                                GridComponent.Grid.Direction == GridShared.GridDirection.RTL ? _offset > 0 ? "margin-right:-" + _offset.ToString() + "px;" : "margin-right:90px;" : _offset > 0 ? "margin-left:-" + _offset.ToString() + "px;" : "margin-left:90px;"

#line default
#line hidden
#nullable disable
            ));
            __builder.AddElementReferenceCapture(14, (__value) => {
#nullable restore
#line 7 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\FormTooltipComponent.razor"
                                                                                                                                                                                                                                                                                                                                             tooltip = __value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.AddMarkupContent(15, "\n            ");
            __builder.OpenElement(16, "div");
            __builder.AddAttribute(17, "class", "grid-dropdown-arrow");
            __builder.AddAttribute(18, "style", 
#nullable restore
#line 8 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\FormTooltipComponent.razor"
                                                      GridComponent.Grid.Direction == GridShared.GridDirection.RTL ? _offset > 0 ? "margin-right:" + _offset.ToString() + "px" : "margin-right:-90px;" : _offset > 0 ? "margin-left:" + _offset.ToString() + "px" : "margin-left:-90px;"

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\n            ");
            __builder.OpenElement(20, "div");
            __builder.AddAttribute(21, "class", "grid-dropdown-inner");
            __builder.AddMarkupContent(22, "\n                ");
            __builder.OpenElement(23, "div");
            __builder.AddAttribute(24, "class", "grid-popup-widget");
            __builder.AddMarkupContent(25, "\n                    ");
            __builder.OpenElement(26, "div");
            __builder.AddAttribute(27, "class", "grid-tooltip-body");
            __builder.AddMarkupContent(28, "\n                        ");
            __builder.OpenElement(29, "label");
            __builder.OpenElement(30, "b");
#nullable restore
#line 12 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\FormTooltipComponent.razor"
__builder.AddContent(31, Column.TooltipValue);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\n");
#nullable restore
#line 18 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\FormTooltipComponent.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
