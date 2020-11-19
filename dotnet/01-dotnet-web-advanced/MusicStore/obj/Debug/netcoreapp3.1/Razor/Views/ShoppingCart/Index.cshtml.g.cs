#pragma checksum "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Views\ShoppingCart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "332e216e7a18fc1824295be076ab4136b49ffebe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ShoppingCart_Index), @"mvc.1.0.view", @"/Views/ShoppingCart/Index.cshtml")]
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
#line 1 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Views\_ViewImports.cshtml"
using MusicStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Views\_ViewImports.cshtml"
using MusicStore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Options;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"332e216e7a18fc1824295be076ab4136b49ffebe", @"/Views/ShoppingCart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6a258c2a84527e9a80203b6d1583ebbc8da49df", @"/Views/_ViewImports.cshtml")]
    public class Views_ShoppingCart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MusicStore.ViewModels.ShoppingCartViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Checkout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddressAndPayment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Store", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Views\ShoppingCart\Index.cshtml"
  
    ViewBag.Title = "Shopping Cart";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            WriteLiteral("\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(function () {
            // Document.ready -> link up remove event handler
            $("".RemoveLink"").click(function () {
                // Get the id from the link
                var recordToDelete = $(this).attr(""data-id"");
                var PostToUrl = $(this).attr(""data-url"");
                if (recordToDelete != '') {

                    // Perform the ajax post
                    $.ajax(PostToUrl, {
                        type: ""post"",
                        data: {
                            ""id"": recordToDelete
                        },
                        dataType: ""json"",
                        headers: {
                            ""RequestVerificationToken"": '");
#nullable restore
#line 33 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Views\ShoppingCart\Index.cshtml"
                                                    Write(GetAntiXsrfRequestToken());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"'
                        }
                    }).done(function (data) {
                        // Successful requests get here
                        // Update the page elements
                        if (data.itemCount == 0) {
                            $('#row-' + data.deleteId).fadeOut('slow');
                        } else {
                            $('#item-count-' + data.deleteId).text(data.itemCount);
                        }

                        $('#cart-total').text(data.cartTotal);
                        $('#update-message').text(data.message);
                        $('#cart-status').text(data.cartCount);
                    });
                }
            });

        });
    </script>
");
            }
            );
            WriteLiteral("\n<h3>\n    <em>Review</em> your cart:\n</h3>\n<p class=\"button\">\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "332e216e7a18fc1824295be076ab4136b49ffebe7246", async() => {
                WriteLiteral("Checkout >>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</p>
<div id=""update-message"">
</div>
<table id=""cart-summary"" class=""table table-bordered table-responsive table-hover table-striped"">
    <tr>
        <th>
            Album Name
        </th>
        <th>
            Price (each)
        </th>
        <th>
            Quantity
        </th>
        <th></th>
    </tr>
");
#nullable restore
#line 76 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Views\ShoppingCart\Index.cshtml"
     foreach (var item in Model.CartItems)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr");
            BeginWriteAttribute("id", " id=\"", 2329, "\"", 2354, 2);
            WriteAttributeValue("", 2334, "row-", 2334, 4, true);
#nullable restore
#line 78 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Views\ShoppingCart\Index.cshtml"
WriteAttributeValue("", 2338, item.CartItemId, 2338, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n            <td>\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "332e216e7a18fc1824295be076ab4136b49ffebe9742", async() => {
#nullable restore
#line 80 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Views\ShoppingCart\Index.cshtml"
                                                                                       Write(item.Album.Title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 80 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Views\ShoppingCart\Index.cshtml"
                                                                 WriteLiteral(item.AlbumId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 83 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Views\ShoppingCart\Index.cshtml"
           Write(item.Album.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td");
            BeginWriteAttribute("id", " id=\"", 2590, "\"", 2622, 2);
            WriteAttributeValue("", 2595, "item-count-", 2595, 11, true);
#nullable restore
#line 85 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Views\ShoppingCart\Index.cshtml"
WriteAttributeValue("", 2606, item.CartItemId, 2606, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                ");
#nullable restore
#line 86 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Views\ShoppingCart\Index.cshtml"
           Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                <a href=\"#\" class=\"RemoveLink\" data-id=\"");
#nullable restore
#line 89 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Views\ShoppingCart\Index.cshtml"
                                                   Write(item.CartItemId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\n                   data-url=\'");
#nullable restore
#line 90 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Views\ShoppingCart\Index.cshtml"
                        Write(Url.Content("~/ShoppingCart/RemoveFromCart"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\'>\n                    Remove from cart\n                </a>\n            </td>\n        </tr>\n");
#nullable restore
#line 95 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Views\ShoppingCart\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\n        <td>\n            Total\n        </td>\n        <td></td>\n        <td></td>\n        <td id=\"cart-total\">\n            ");
#nullable restore
#line 103 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Views\ShoppingCart\Index.cshtml"
       Write(Model.CartTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </td>\n    </tr>\n</table>");
        }
        #pragma warning restore 1998
#nullable restore
#line 8 "E:\Projects\elca-reski\ASP.NET MVC Core Final Excersise\01-dotnet-web-advanced\MusicStore\Views\ShoppingCart\Index.cshtml"
 
    public string GetAntiXsrfRequestToken()
    {
        return Xsrf.GetAndStoreTokens(Context).RequestToken;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Antiforgery.IAntiforgery Xsrf { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MusicStore.ViewModels.ShoppingCartViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
