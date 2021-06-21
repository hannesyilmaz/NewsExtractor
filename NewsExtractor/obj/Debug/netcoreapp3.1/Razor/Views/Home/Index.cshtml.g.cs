#pragma checksum "C:\Users\Hanne\source\repos\NewsExtractor\NewsExtractor\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c5867ba3033323e87530fc232b991c07824b4485"
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
#line 1 "C:\Users\Hanne\source\repos\NewsExtractor\NewsExtractor\Views\_ViewImports.cshtml"
using NewsExtractor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Hanne\source\repos\NewsExtractor\NewsExtractor\Views\_ViewImports.cshtml"
using NewsExtractor.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5867ba3033323e87530fc232b991c07824b4485", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9db319784dd5ab7aa726fc9257a2d52ca0bffe6b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Hanne\source\repos\NewsExtractor\NewsExtractor\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Display News";
    string[] TableHeaders = new string[] {"Topic",
                                          "Title",
                                          "Summary",
                                          "Link"};

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"table\">\r\n    <table class=\"table table-bordered table-hover\">\r\n        <thead>\r\n            <tr>\r\n");
#nullable restore
#line 13 "C:\Users\Hanne\source\repos\NewsExtractor\NewsExtractor\Views\Home\Index.cshtml"
                   
                    foreach (var head in TableHeaders)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <th>\r\n                            ");
#nullable restore
#line 17 "C:\Users\Hanne\source\repos\NewsExtractor\NewsExtractor\Views\Home\Index.cshtml"
                       Write(head);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n");
#nullable restore
#line 19 "C:\Users\Hanne\source\repos\NewsExtractor\NewsExtractor\Views\Home\Index.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 24 "C:\Users\Hanne\source\repos\NewsExtractor\NewsExtractor\Views\Home\Index.cshtml"
              
                if (Model != null)
                {
                    foreach (var Data in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 30 "C:\Users\Hanne\source\repos\NewsExtractor\NewsExtractor\Views\Home\Index.cshtml"
                           Write(Data.Topic);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 31 "C:\Users\Hanne\source\repos\NewsExtractor\NewsExtractor\Views\Home\Index.cshtml"
                           Write(Data.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 32 "C:\Users\Hanne\source\repos\NewsExtractor\NewsExtractor\Views\Home\Index.cshtml"
                           Write(Data.Summary);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 33 "C:\Users\Hanne\source\repos\NewsExtractor\NewsExtractor\Views\Home\Index.cshtml"
                           Write(Data.Link);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 35 "C:\Users\Hanne\source\repos\NewsExtractor\NewsExtractor\Views\Home\Index.cshtml"
                    }

                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n\r\n    </table>\r\n\r\n\r\n\r\n\r\n\r\n</div>");
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
