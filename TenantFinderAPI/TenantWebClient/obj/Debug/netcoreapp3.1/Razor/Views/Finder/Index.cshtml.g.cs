#pragma checksum "C:\Users\Dell\source\repos\TenantFinderAPI\TenantWebClient\Views\Finder\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c28d1c51d80572211b9cfb95771e6fcecf027ec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Finder_Index), @"mvc.1.0.view", @"/Views/Finder/Index.cshtml")]
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
#line 1 "C:\Users\Dell\source\repos\TenantFinderAPI\TenantWebClient\Views\_ViewImports.cshtml"
using TenantWebClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dell\source\repos\TenantFinderAPI\TenantWebClient\Views\_ViewImports.cshtml"
using TenantWebClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c28d1c51d80572211b9cfb95771e6fcecf027ec", @"/Views/Finder/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8fee6728cae1f4edb691d5fd9b2356228909163d", @"/Views/_ViewImports.cshtml")]
    public class Views_Finder_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TenantFinderAPI.Models.Tenant>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Dell\source\repos\TenantFinderAPI\TenantWebClient\Views\Finder\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "../Home/_LayoutHome.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"



<table class=""table"">
    <thead>
        <tr>
            <th>
                Name
            </th>
            <th>
                Contact No
            </th>
            <th>
                Category
            </th>
            <th>
                Req. House
            </th>
            
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 30 "C:\Users\Dell\source\repos\TenantFinderAPI\TenantWebClient\Views\Finder\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 33 "C:\Users\Dell\source\repos\TenantFinderAPI\TenantWebClient\Views\Finder\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.tname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 36 "C:\Users\Dell\source\repos\TenantFinderAPI\TenantWebClient\Views\Finder\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 39 "C:\Users\Dell\source\repos\TenantFinderAPI\TenantWebClient\Views\Finder\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.catg));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 42 "C:\Users\Dell\source\repos\TenantFinderAPI\TenantWebClient\Views\Finder\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.reqhouse));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            \r\n        </tr>\r\n");
#nullable restore
#line 46 "C:\Users\Dell\source\repos\TenantFinderAPI\TenantWebClient\Views\Finder\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TenantFinderAPI.Models.Tenant>> Html { get; private set; }
    }
}
#pragma warning restore 1591