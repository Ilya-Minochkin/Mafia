#pragma checksum "F:\DEV\Mafia\Mafia\Mafia\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "47e11d69917e8667106bcb4866802f0fda64c172"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "F:\DEV\Mafia\Mafia\Mafia\Views\_ViewImports.cshtml"
using Mafia;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\DEV\Mafia\Mafia\Mafia\Views\_ViewImports.cshtml"
using Mafia.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47e11d69917e8667106bcb4866802f0fda64c172", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db6fc1755ebbc5458c68711af2494ecbd0aacf6e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DataLayer.Entities.Player>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "F:\DEV\Mafia\Mafia\Mafia\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Список игроков: </h1>\r\n");
#nullable restore
#line 8 "F:\DEV\Mafia\Mafia\Mafia\Views\Home\Index.cshtml"
      

        if (Model != null)
        {
            foreach (var player in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h1>");
#nullable restore
#line 14 "F:\DEV\Mafia\Mafia\Mafia\Views\Home\Index.cshtml"
               Write(player.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                <h1>");
#nullable restore
#line 15 "F:\DEV\Mafia\Mafia\Mafia\Views\Home\Index.cshtml"
               Write(player.NickName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                <br/>\r\n");
#nullable restore
#line 17 "F:\DEV\Mafia\Mafia\Mafia\Views\Home\Index.cshtml"
            }
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DataLayer.Entities.Player>> Html { get; private set; }
    }
}
#pragma warning restore 1591
