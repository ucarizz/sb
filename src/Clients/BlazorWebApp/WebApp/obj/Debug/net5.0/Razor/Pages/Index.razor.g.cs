#pragma checksum "/Users/muratucar/Projects/ucar/src/Clients/BlazorWebApp/WebApp/Pages/Index.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "d95fb6f6bf5dff8ff8d5416bc246c5ecefe5eaa73761d693fb7647763f8dadb3"
// <auto-generated/>
#pragma warning disable 1591
namespace WebApp.Pages
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/muratucar/Projects/ucar/src/Clients/BlazorWebApp/WebApp/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/muratucar/Projects/ucar/src/Clients/BlazorWebApp/WebApp/_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/muratucar/Projects/ucar/src/Clients/BlazorWebApp/WebApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/muratucar/Projects/ucar/src/Clients/BlazorWebApp/WebApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/muratucar/Projects/ucar/src/Clients/BlazorWebApp/WebApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/muratucar/Projects/ucar/src/Clients/BlazorWebApp/WebApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/muratucar/Projects/ucar/src/Clients/BlazorWebApp/WebApp/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/muratucar/Projects/ucar/src/Clients/BlazorWebApp/WebApp/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/muratucar/Projects/ucar/src/Clients/BlazorWebApp/WebApp/_Imports.razor"
using WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/muratucar/Projects/ucar/src/Clients/BlazorWebApp/WebApp/_Imports.razor"
using WebApp.Shared;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Hello, world!</h1>\n\nWelcome to your new app.\n\n");
            __builder.OpenComponent<global::WebApp.Shared.SurveyPrompt>(1);
            __builder.AddAttribute(2, "Title", (object)("How is Blazor working for you?"));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
