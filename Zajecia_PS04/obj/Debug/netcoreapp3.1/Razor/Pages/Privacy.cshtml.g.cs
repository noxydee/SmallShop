#pragma checksum "C:\Users\tomek\source\repos\Zajecia_FizzBuzz\Zajecia_PS04\Pages\Privacy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ca4eb043e33c417e65b3fc1c02c0582604a78e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Zajecia_PS04.Pages.Pages_Privacy), @"mvc.1.0.razor-page", @"/Pages/Privacy.cshtml")]
namespace Zajecia_PS04.Pages
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
#line 1 "C:\Users\tomek\source\repos\Zajecia_FizzBuzz\Zajecia_PS04\Pages\_ViewImports.cshtml"
using Zajecia_PS04.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tomek\source\repos\Zajecia_FizzBuzz\Zajecia_PS04\Pages\_ViewImports.cshtml"
using Zajecia_PS04.DAL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\tomek\source\repos\Zajecia_FizzBuzz\Zajecia_PS04\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\tomek\source\repos\Zajecia_FizzBuzz\Zajecia_PS04\Pages\_ViewImports.cshtml"
using Zajecia_PS04;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\tomek\source\repos\Zajecia_FizzBuzz\Zajecia_PS04\Pages\_ViewImports.cshtml"
using React.AspNet;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ca4eb043e33c417e65b3fc1c02c0582604a78e7", @"/Pages/Privacy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2a2efa9ddaac01fdc3fe86b00bc60c681f73965", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Privacy : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\tomek\source\repos\Zajecia_FizzBuzz\Zajecia_PS04\Pages\Privacy.cshtml"
  
    ViewData["Title"] = "Privacy Policy";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>");
#nullable restore
#line 6 "C:\Users\tomek\source\repos\Zajecia_FizzBuzz\Zajecia_PS04\Pages\Privacy.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n<p>Use this page to detail your site\'s privacy policy.</p>\r\n<h1>");
#nullable restore
#line 9 "C:\Users\tomek\source\repos\Zajecia_FizzBuzz\Zajecia_PS04\Pages\Privacy.cshtml"
Write(ViewData["filterMessage1"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PrivacyModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<PrivacyModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<PrivacyModel>)PageContext?.ViewData;
        public PrivacyModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591