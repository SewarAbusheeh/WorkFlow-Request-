#pragma checksum "E:\شاشه التوقف acdemy pro\source\repos\Newone\Newone\Views\Shared\Components\Article\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72ca42f93c5faab5a85543e497c2af5d37178f4f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Article_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Article/Default.cshtml")]
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
#line 1 "E:\شاشه التوقف acdemy pro\source\repos\Newone\Newone\Views\_ViewImports.cshtml"
using Newone;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\شاشه التوقف acdemy pro\source\repos\Newone\Newone\Views\_ViewImports.cshtml"
using Newone.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\شاشه التوقف acdemy pro\source\repos\Newone\Newone\Views\_ViewImports.cshtml"
using Newone.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72ca42f93c5faab5a85543e497c2af5d37178f4f", @"/Views/Shared/Components/Article/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bfc051361729c7f24178bdd4701253611cd7bec4", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Article_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Article>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <!-- Start from blog -->
    <section id=""mu-from-blog"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""mu-from-blog-area"">
                        <!-- start title -->
                        <div class=""mu-title"">
                            <h2>Our Article</h2>
                            <p>Read to Discover</p>
                        </div>
                        <!-- end title -->
                        <!-- start from blog content   -->
                        <div class=""mu-from-blog-content"">
                            <div class=""row"">
");
#nullable restore
#line 18 "E:\شاشه التوقف acdemy pro\source\repos\Newone\Newone\Views\Shared\Components\Article\Default.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <div class=""col-md-4 col-sm-4"">
                                        <article class=""mu-blog-single-item"">
                                            <figure class=""mu-blog-single-img"">
                                                <a href=""#"">
                                                    <img");
            BeginWriteAttribute("src", " src=\"", 1136, "\"", 1172, 2);
#nullable restore
#line 24 "E:\شاشه التوقف acdemy pro\source\repos\Newone\Newone\Views\Shared\Components\Article\Default.cshtml"
WriteAttributeValue("", 1142, Url.Content(item.ArticleImg), 1142, 29, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1171, "", 1172, 1, true);
            EndWriteAttribute();
            WriteLiteral(" alt=\"img\"></a>\r\n                                            <figcaption class=\"mu-blog-caption\">\r\n                                                    <h3><a >");
#nullable restore
#line 26 "E:\شاشه التوقف acdemy pro\source\repos\Newone\Newone\Views\Shared\Components\Article\Default.cshtml"
                                                       Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a></h3>
                                                    </figcaption>
                                            </figure>
                                            <div class=""mu-blog-meta"">
                                                <a href=""#"">");
#nullable restore
#line 30 "E:\شاشه التوقف acdemy pro\source\repos\Newone\Newone\Views\Shared\Components\Article\Default.cshtml"
                                                       Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                                                <a href=""#"">.....</a>
                                                <span><i class=""fa fa-comments-o""></i>87</span>
                                            </div>
                                            <div class=""mu-blog-description"">
                                                <p>");
#nullable restore
#line 35 "E:\شاشه التوقف acdemy pro\source\repos\Newone\Newone\Views\Shared\Components\Article\Default.cshtml"
                                              Write(item.Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                                <a class=""mu-read-more-btn"" href=""https://en.wikipedia.org/wiki/History_of_artificial_intelligence"">Read More</a>
                                            </div>
                                        </article>
                                    </div>
");
#nullable restore
#line 40 "E:\شاشه التوقف acdemy pro\source\repos\Newone\Newone\Views\Shared\Components\Article\Default.cshtml"
                               
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                       
                            </div>
                        </div>
                        <!-- end from blog content   -->
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- End from blog -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Article>> Html { get; private set; }
    }
}
#pragma warning restore 1591
