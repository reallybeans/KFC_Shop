#pragma checksum "C:\Users\leean\Documents\Main\C#\KFC_Food-main\KFC_Food\Views\ShoppingCart\CheckOutForm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0842e82e6e4e40833b48b9871244b73e1d05b9ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ShoppingCart_CheckOutForm), @"mvc.1.0.view", @"/Views/ShoppingCart/CheckOutForm.cshtml")]
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
#line 1 "C:\Users\leean\Documents\Main\C#\KFC_Food-main\KFC_Food\Views\_ViewImports.cshtml"
using KFC_Food;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\leean\Documents\Main\C#\KFC_Food-main\KFC_Food\Views\_ViewImports.cshtml"
using KFC_Food.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0842e82e6e4e40833b48b9871244b73e1d05b9ea", @"/Views/ShoppingCart/CheckOutForm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8bca3037c5018a171bb72bfbac39b3a331a478fe", @"/Views/_ViewImports.cshtml")]
    public class Views_ShoppingCart_CheckOutForm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 2 "C:\Users\leean\Documents\Main\C#\KFC_Food-main\KFC_Food\Views\ShoppingCart\CheckOutForm.cshtml"
  
    ViewData["Title"] = "CheckOutForm";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0842e82e6e4e40833b48b9871244b73e1d05b9ea3441", async() => {
                WriteLiteral(@"
    <style>
        .form {
            margin-top: 100px;
            text-align: center;
            border-style: outset;
            border-radius: 30px;
        }
        .form h1 {
                margin-top: 20px;
         }
        #los {
            margin-top: 15px;
            width: 500px;
            margin-left: 300px;
        }
        #button{
            margin-bottom:20px;
            margin-left:270px;
        }
        #link{
            height:20px;
        }
    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n\n\n<div class=\"form\">\n");
#nullable restore
#line 36 "C:\Users\leean\Documents\Main\C#\KFC_Food-main\KFC_Food\Views\ShoppingCart\CheckOutForm.cshtml"
     using (Html.BeginForm("Checkout", "ShoppingCart"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <h1>Check Out Form</h1>
        <div id=""los"" class=""input-group mb-3"">
            <div class=""input-group-prepend"">
                <span class=""input-group-text"" id=""basic-addon1"">Address:</span>
            </div>
            <input type=""text""");
            BeginWriteAttribute("required", " required=\"", 946, "\"", 957, 0);
            EndWriteAttribute();
            WriteLiteral(@" name=""address"" class=""form-control"" placeholder=""Address"" aria-label=""Address"" aria-describedby=""basic-addon1"">
        </div>
        <div id=""los"" class=""input-group mb-3"">
            <div class=""input-group-prepend"">
                <span class=""input-group-text"" id=""basic-addon1"">Phone (123-456-7890):</span>
            </div>
            <input type=""tel""");
            BeginWriteAttribute("required", " required=\"", 1322, "\"", 1333, 0);
            EndWriteAttribute();
            WriteLiteral(" name=\"phone\" class=\"form-control\" placeholder=\"Phone\" aria-label=\"Phone\" aria-describedby=\"basic-addon1\"\n                   pattern=\"[0-9]{3}-[0-9]{3}-[0-9]{4}\"> <br />\n\n\n        </div>\n");
            WriteLiteral("        <a id=\"link\" class=\"badge badge-warning\"");
            BeginWriteAttribute("href", " href=\"", 1570, "\"", 1604, 1);
#nullable restore
#line 55 "C:\Users\leean\Documents\Main\C#\KFC_Food-main\KFC_Food\Views\ShoppingCart\CheckOutForm.cshtml"
WriteAttributeValue("", 1577, Url.Action("Index","Home"), 1577, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Continue Shopping</a>\n        <input id=\"button\" class=\"btn btn-outline-success\" type=\"submit\" value=\"Checkout\" />\n");
#nullable restore
#line 57 "C:\Users\leean\Documents\Main\C#\KFC_Food-main\KFC_Food\Views\ShoppingCart\CheckOutForm.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
