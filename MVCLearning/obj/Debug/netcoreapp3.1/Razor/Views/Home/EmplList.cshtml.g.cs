#pragma checksum "C:\Users\Asus\Desktop\c#\MVCStart\MVCLearning\Views\Home\EmplList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80493d11aa6cf1361677e21630a207b4dec4892a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_EmplList), @"mvc.1.0.view", @"/Views/Home/EmplList.cshtml")]
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
#line 1 "C:\Users\Asus\Desktop\c#\MVCStart\MVCLearning\Views\_ViewImports.cshtml"
using MVCLearning.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Asus\Desktop\c#\MVCStart\MVCLearning\Views\_ViewImports.cshtml"
using MVCLearning.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80493d11aa6cf1361677e21630a207b4dec4892a", @"/Views/Home/EmplList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52e4ba340f123aa204f0529a4148edda58c2ebfe", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_EmplList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Employee>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Asus\Desktop\c#\MVCStart\MVCLearning\Views\Home\EmplList.cshtml"
  
    ViewBag.Title = "Find an employee";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card-deck\">\r\n");
#nullable restore
#line 8 "C:\Users\Asus\Desktop\c#\MVCStart\MVCLearning\Views\Home\EmplList.cshtml"
     foreach(var empl in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card m-3\">\r\n            <div class=\"card-header\">\r\n                <h3>");
#nullable restore
#line 12 "C:\Users\Asus\Desktop\c#\MVCStart\MVCLearning\Views\Home\EmplList.cshtml"
               Write(empl.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
            </div>
            <div class=""card-footer text-center"">
                <a href=""#"" class=""btn btn-primary"">View</a>
                <a href=""#"" class=""btn btn-primary"">Edit</a>
                <a href=""#"" class=""btn btn-danger"">Delete</a>
            </div>
        </div>
");
#nullable restore
#line 20 "C:\Users\Asus\Desktop\c#\MVCStart\MVCLearning\Views\Home\EmplList.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Employee>> Html { get; private set; }
    }
}
#pragma warning restore 1591
