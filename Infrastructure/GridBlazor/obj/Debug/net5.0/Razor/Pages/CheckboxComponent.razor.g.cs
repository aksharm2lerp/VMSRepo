#pragma checksum "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\CheckboxComponent.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8d264ed553136b2adaff037d337227f94cf252b6"
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
    public partial class CheckboxComponent<T> : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 3 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\CheckboxComponent.razor"
 if (_readonly)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(0, "    ");
            __builder.OpenElement(1, "input");
            __builder.AddAttribute(2, "type", "checkbox");
            __builder.AddAttribute(3, "checked", 
#nullable restore
#line 5 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\CheckboxComponent.razor"
                                     _value

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(4, "disabled", "disabled");
            __builder.AddAttribute(5, "readonly", "readonly");
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\n");
#nullable restore
#line 6 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\CheckboxComponent.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(7, "    ");
            __builder.OpenElement(8, "input");
            __builder.AddAttribute(9, "type", "checkbox");
            __builder.AddAttribute(10, "checked", 
#nullable restore
#line 9 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\CheckboxComponent.razor"
                                     _value

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(11, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 9 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\CheckboxComponent.razor"
                                                        ChangeHandler

#line default
#line hidden
#nullable disable
            ));
            __builder.AddEventStopPropagationAttribute(12, "onclick", true);
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\n");
#nullable restore
#line 10 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\CheckboxComponent.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
