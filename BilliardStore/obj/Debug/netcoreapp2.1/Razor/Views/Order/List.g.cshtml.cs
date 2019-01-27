#pragma checksum "C:\Projects\BilliardStore\BilliardStore\Views\Order\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "69e2f14ce3f63ef7ad6df9a5d9111b2efc102af8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_List), @"mvc.1.0.view", @"/Views/Order/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Order/List.cshtml", typeof(AspNetCore.Views_Order_List))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"69e2f14ce3f63ef7ad6df9a5d9111b2efc102af8", @"/Views/Order/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e51f2cec11fc3db9ab68994b90503e8584bc1caa", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MarkShipped", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projects\BilliardStore\BilliardStore\Views\Order\List.cshtml"
 if (Model.Count() > 0)
{

#line default
#line hidden
            BeginContext(55, 137, true);
            WriteLiteral("    <table class=\"table table-bordered table-striped\">\r\n        <tr><th>Name</th><th>Zip</th><th colspan=\"2\">Details</th><th></th></tr>\r\n");
            EndContext();
#line 6 "C:\Projects\BilliardStore\BilliardStore\Views\Order\List.cshtml"
         foreach (Order o in Model)
        {

#line default
#line hidden
            BeginContext(240, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(279, 6, false);
#line 9 "C:\Projects\BilliardStore\BilliardStore\Views\Order\List.cshtml"
               Write(o.Name);

#line default
#line hidden
            EndContext();
            BeginContext(285, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(313, 12, false);
#line 10 "C:\Projects\BilliardStore\BilliardStore\Views\Order\List.cshtml"
               Write(o.PostalCode);

#line default
#line hidden
            EndContext();
            BeginContext(325, 118, true);
            WriteLiteral("</td>\r\n                <th>Product</th>\r\n                <th>Quantity</th>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(443, 304, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aae709af09de4dada129e737d6f82095", async() => {
                BeginContext(488, 61, true);
                WriteLiteral("\r\n                        <input type=\"hidden\" name=\"orderId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 549, "\"", 567, 1);
#line 15 "C:\Projects\BilliardStore\BilliardStore\Views\Order\List.cshtml"
WriteAttributeValue("", 557, o.OrderID, 557, 10, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(568, 172, true);
                WriteLiteral(" />\r\n                        <button type=\"submit\" class=\"btn btn-sm btn-danger\">\r\n                            Ship\r\n                        </button>\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(747, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 22 "C:\Projects\BilliardStore\BilliardStore\Views\Order\List.cshtml"
             foreach (CartLine line in o.Lines)
            {

#line default
#line hidden
            BeginContext(855, 89, true);
            WriteLiteral("                <tr>\r\n                    <td colspan=\"2\"></td>\r\n                    <td>");
            EndContext();
            BeginContext(945, 17, false);
#line 26 "C:\Projects\BilliardStore\BilliardStore\Views\Order\List.cshtml"
                   Write(line.Product.Name);

#line default
#line hidden
            EndContext();
            BeginContext(962, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(994, 13, false);
#line 27 "C:\Projects\BilliardStore\BilliardStore\Views\Order\List.cshtml"
                   Write(line.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(1007, 61, true);
            WriteLiteral("</td>\r\n                    <td></td>\r\n                </tr>\r\n");
            EndContext();
#line 30 "C:\Projects\BilliardStore\BilliardStore\Views\Order\List.cshtml"
            }

#line default
#line hidden
#line 30 "C:\Projects\BilliardStore\BilliardStore\Views\Order\List.cshtml"
             
        }

#line default
#line hidden
            BeginContext(1094, 14, true);
            WriteLiteral("    </table>\r\n");
            EndContext();
#line 33 "C:\Projects\BilliardStore\BilliardStore\Views\Order\List.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(1120, 56, true);
            WriteLiteral("    <div class=\"text-center\">No Unshipped Orders</div>\r\n");
            EndContext();
#line 37 "C:\Projects\BilliardStore\BilliardStore\Views\Order\List.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
