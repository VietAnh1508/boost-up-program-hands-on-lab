#pragma checksum "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Areas\Admin\Views\StoreManager\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b573994c4a13e441b4ac1cf7a02cf00803e3e8da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_StoreManager_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/StoreManager/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b573994c4a13e441b4ac1cf7a02cf00803e3e8da", @"/Areas/Admin/Views/StoreManager/Details.cshtml")]
    public class Areas_Admin_Views_StoreManager_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MusicStore.Models.Album>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Areas\Admin\Views\StoreManager\Details.cshtml"
  
    ViewBag.Title = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>Details</h2>\n\n<div>\n    <h4>Album</h4>\n    <hr />\n    <dl class=\"dl-horizontal\">\n        <dt>\n            ");
#nullable restore
#line 14 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Areas\Admin\Views\StoreManager\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Artist.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n\n        <dd>\n            ");
#nullable restore
#line 18 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Areas\Admin\Views\StoreManager\Details.cshtml"
       Write(Html.DisplayFor(model => model.Artist.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n\n        <dt>\n            ");
#nullable restore
#line 22 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Areas\Admin\Views\StoreManager\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Genre.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n\n        <dd>\n            ");
#nullable restore
#line 26 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Areas\Admin\Views\StoreManager\Details.cshtml"
       Write(Html.DisplayFor(model => model.Genre.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n\n        <dt>\n            ");
#nullable restore
#line 30 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Areas\Admin\Views\StoreManager\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n\n        <dd>\n            ");
#nullable restore
#line 34 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Areas\Admin\Views\StoreManager\Details.cshtml"
       Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n\n        <dt>\n            ");
#nullable restore
#line 38 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Areas\Admin\Views\StoreManager\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n\n        <dd>\n            ");
#nullable restore
#line 42 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Areas\Admin\Views\StoreManager\Details.cshtml"
       Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n\n        <dt>\n            ");
#nullable restore
#line 46 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Areas\Admin\Views\StoreManager\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AlbumArtUrl));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n\n        <dd>\n            ");
#nullable restore
#line 50 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Areas\Admin\Views\StoreManager\Details.cshtml"
       Write(Html.DisplayFor(model => model.AlbumArtUrl));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n\n    </dl>\n</div>\n<p>\n    ");
#nullable restore
#line 56 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Areas\Admin\Views\StoreManager\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.AlbumId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\n    ");
#nullable restore
#line 57 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Areas\Admin\Views\StoreManager\Details.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MusicStore.Models.Album> Html { get; private set; }
    }
}
#pragma warning restore 1591
