#pragma checksum "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\GridDeleteButtonsComponent.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c41c6cdbf1e37b4b453332c13e134cd70d225cb5"
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
#line 1 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\GridDeleteButtonsComponent.razor"
using GridBlazor.Resources;

#line default
#line hidden
#nullable disable
    public partial class GridDeleteButtonsComponent<T> : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 3 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\GridDeleteButtonsComponent.razor"
 if (GridDeleteComponent._buttonsVisibility == 0)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(0, "    ");
            __builder.OpenElement(1, "button");
            __builder.AddAttribute(2, "type", "button");
            __builder.AddAttribute(3, "class", "btn btn-primary btn-md");
            __builder.AddAttribute(4, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 5 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\GridDeleteButtonsComponent.razor"
                                                                   () => GridDeleteComponent.DeleteItem()

#line default
#line hidden
#nullable disable
            ));
#nullable restore
#line 5 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\GridDeleteButtonsComponent.razor"
__builder.AddContent(5, Strings.Delete);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\n    ");
            __builder.OpenElement(7, "button");
            __builder.AddAttribute(8, "type", "button");
            __builder.AddAttribute(9, "class", "btn btn-primary btn-md");
            __builder.AddAttribute(10, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 6 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\GridDeleteButtonsComponent.razor"
                                                                   () => GridDeleteComponent.BackButtonClicked()

#line default
#line hidden
#nullable disable
            ));
#nullable restore
#line 6 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\GridDeleteButtonsComponent.razor"
__builder.AddContent(11, Strings.Back);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\n");
#nullable restore
#line 7 "C:\Projects\VMS\Infrastructure\GridBlazor\Pages\GridDeleteButtonsComponent.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
