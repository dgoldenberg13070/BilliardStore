#pragma checksum "C:\Projects\BilliardStore\BilliardStore\Views\Order\Completed.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48a46f1327e5b8af5b2281dd605636f8e29b50d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Completed), @"mvc.1.0.view", @"/Views/Order/Completed.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Order/Completed.cshtml", typeof(AspNetCore.Views_Order_Completed))]
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
#line 6 "C:\Projects\BilliardStore\BilliardStore\Views\_ViewImports.cshtml"
using BilliardStore.Models;

#line default
#line hidden
#line 7 "C:\Projects\BilliardStore\BilliardStore\Views\_ViewImports.cshtml"
using BilliardStore.Models.ViewModels;

#line default
#line hidden
#line 8 "C:\Projects\BilliardStore\BilliardStore\Views\_ViewImports.cshtml"
using BilliardStore.Infrastructure;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48a46f1327e5b8af5b2281dd605636f8e29b50d9", @"/Views/Order/Completed.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e51f2cec11fc3db9ab68994b90503e8584bc1caa", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Completed : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Order>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projects\BilliardStore\BilliardStore\Views\Order\Completed.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(55, 139, true);
            WriteLiteral("<h2>Thanks!</h2>\r\n<p>Thanks for placing your order.</p>\r\n<p>We\'ll ship your goods as soon as possible.</p>\r\n<br />\r\n<h2>Details for Order #");
            EndContext();
            BeginContext(195, 20, false);
#line 9 "C:\Projects\BilliardStore\BilliardStore\Views\Order\Completed.cshtml"
                  Write(Model.TrackingNumber);

#line default
#line hidden
            EndContext();
            BeginContext(215, 46, true);
            WriteLiteral("</h2>\r\n<dl>\r\n    <dt>Order Date</dt>\r\n    <dd>");
            EndContext();
            BeginContext(262, 39, false);
#line 12 "C:\Projects\BilliardStore\BilliardStore\Views\Order\Completed.cshtml"
   Write(Model.PlacementDate.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(301, 7, true);
            WriteLiteral("</dd>\r\n");
            EndContext();
            BeginContext(589, 13, true);
            WriteLiteral("</dl>\r\n<ul>\r\n");
            EndContext();
#line 19 "C:\Projects\BilliardStore\BilliardStore\Views\Order\Completed.cshtml"
     foreach (var item in Model.Lines)
    {

#line default
#line hidden
            BeginContext(649, 12, true);
            WriteLiteral("        <li>");
            EndContext();
            BeginContext(662, 16, false);
#line 21 "C:\Projects\BilliardStore\BilliardStore\Views\Order\Completed.cshtml"
       Write(item.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(678, 12, true);
            WriteLiteral(" (quantity: ");
            EndContext();
            BeginContext(691, 13, false);
#line 21 "C:\Projects\BilliardStore\BilliardStore\Views\Order\Completed.cshtml"
                                    Write(item.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(704, 8, true);
            WriteLiteral(")</li>\r\n");
            EndContext();
#line 22 "C:\Projects\BilliardStore\BilliardStore\Views\Order\Completed.cshtml"
    }

#line default
#line hidden
            BeginContext(719, 9, true);
            WriteLiteral("</ul>\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Order> Html { get; private set; }
    }
}
#pragma warning restore 1591
