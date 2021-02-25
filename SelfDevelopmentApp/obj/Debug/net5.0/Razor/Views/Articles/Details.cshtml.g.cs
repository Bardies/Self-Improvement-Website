#pragma checksum "H:\ITI\PD\ASP_MVC\Project\Project repo\Self-Improvement-Website\SelfDevelopmentApp\Views\Articles\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d850f9187a7711dfabb07cfb34ee9355e43b37f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Articles_Details), @"mvc.1.0.view", @"/Views/Articles/Details.cshtml")]
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
#line 1 "H:\ITI\PD\ASP_MVC\Project\Project repo\Self-Improvement-Website\SelfDevelopmentApp\Views\_ViewImports.cshtml"
using SelfDevelopmentApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "H:\ITI\PD\ASP_MVC\Project\Project repo\Self-Improvement-Website\SelfDevelopmentApp\Views\_ViewImports.cshtml"
using SelfDevelopmentApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "H:\ITI\PD\ASP_MVC\Project\Project repo\Self-Improvement-Website\SelfDevelopmentApp\Views\Articles\Details.cshtml"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "H:\ITI\PD\ASP_MVC\Project\Project repo\Self-Improvement-Website\SelfDevelopmentApp\Views\Articles\Details.cshtml"
using System.Text;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d850f9187a7711dfabb07cfb34ee9355e43b37f", @"/Views/Articles/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b321fcea14cc124bed00babd86e45c9fc84965bd", @"/Views/_ViewImports.cshtml")]
    public class Views_Articles_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SelfDevelopmentApp.Models.Article>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Articles", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "H:\ITI\PD\ASP_MVC\Project\Project repo\Self-Improvement-Website\SelfDevelopmentApp\Views\Articles\Details.cshtml"
  
    Layout = "_blog";
    ViewData["Title"] = "Details";

    IEnumerable<SelfDevelopmentApp.Models.Article> RelatedArticles = ViewBag.RelatedArticles;

    var base64 = Convert.ToBase64String(Model.Image);
    var imgsrc = string.Format("data:image/jpg;base64,{0}", base64);
    var articleText = "";
    //string filePath = string.Format("data:text/txt;base64,{0}", base64);
    using (MemoryStream stream = new MemoryStream((byte[])Model.Text, false))
    using (StreamReader reader = new StreamReader(stream, Encoding.Default, true))
    {
        articleText += reader.ReadToEnd();
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<!-- ======= Breadcrumbs ======= -->\r\n<section id=\"breadcrumbs\" class=\"breadcrumbs\">\r\n    <div class=\"container\">\r\n\r\n        <ol>\r\n            <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d850f9187a7711dfabb07cfb34ee9355e43b37f6120", async() => {
                WriteLiteral("Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n            <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d850f9187a7711dfabb07cfb34ee9355e43b37f7700", async() => {
                WriteLiteral("Articles");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
        </ol>

    </div>
</section><!-- End Breadcrumbs -->
<!-- ======= Blog Single Section ======= -->
<section id=""blog"" class=""blog"">
    <div class=""container"" data-aos=""fade-up"">

        <div class=""row"">

            <div class=""col-lg-8 entries"">

                <article class=""entry entry-single"">

                    <div class=""entry-img"">
                        <img");
            BeginWriteAttribute("src", " src=\'", 1413, "\'", 1426, 1);
#nullable restore
#line 44 "H:\ITI\PD\ASP_MVC\Project\Project repo\Self-Improvement-Website\SelfDevelopmentApp\Views\Articles\Details.cshtml"
WriteAttributeValue("", 1419, imgsrc, 1419, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1427, "\"", 1433, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\">\r\n                    </div>\r\n\r\n                    <h2 class=\"entry-title\">\r\n                        <!--Tilte-->\r\n                        ");
#nullable restore
#line 49 "H:\ITI\PD\ASP_MVC\Project\Project repo\Self-Improvement-Website\SelfDevelopmentApp\Views\Articles\Details.cshtml"
                   Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("   |  ");
#nullable restore
#line 49 "H:\ITI\PD\ASP_MVC\Project\Project repo\Self-Improvement-Website\SelfDevelopmentApp\Views\Articles\Details.cshtml"
                                     Write(Model.Topic.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h2>\r\n\r\n                    <div class=\"entry-meta\">\r\n                        <!--Author-->\r\n                        ");
#nullable restore
#line 54 "H:\ITI\PD\ASP_MVC\Project\Project repo\Self-Improvement-Website\SelfDevelopmentApp\Views\Articles\Details.cshtml"
                   Write(Model.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n\r\n                    <div class=\"entry-content\">\r\n\r\n                        ");
#nullable restore
#line 59 "H:\ITI\PD\ASP_MVC\Project\Project repo\Self-Improvement-Website\SelfDevelopmentApp\Views\Articles\Details.cshtml"
                   Write(articleText);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                    </div>
                    </article>
            </div><!-- End blog entries list -->

            <div class=""col-lg-4"">

                <div class=""sidebar"">

                    <h3 class=""sidebar-title"">Search</h3>
                    <div class=""sidebar-item search-form"">
");
#nullable restore
#line 71 "H:\ITI\PD\ASP_MVC\Project\Project repo\Self-Improvement-Website\SelfDevelopmentApp\Views\Articles\Details.cshtml"
                         using (Html.BeginForm("Index", "Articles", FormMethod.Post))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input type=\"text\" name=\"name\" required>\r\n                            <button type=\"submit\"><i class=\"bi bi-search\"></i></button>\r\n");
#nullable restore
#line 75 "H:\ITI\PD\ASP_MVC\Project\Project repo\Self-Improvement-Website\SelfDevelopmentApp\Views\Articles\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div><!-- End sidebar search formn-->\r\n\r\n");
#nullable restore
#line 78 "H:\ITI\PD\ASP_MVC\Project\Project repo\Self-Improvement-Website\SelfDevelopmentApp\Views\Articles\Details.cshtml"
                     if (RelatedArticles.ToList().Count > 1)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h3 class=\"sidebar-title\">Related articles</h3>\r\n                    <div class=\"sidebar-item categories\">\r\n                        <ul>\r\n");
#nullable restore
#line 83 "H:\ITI\PD\ASP_MVC\Project\Project repo\Self-Improvement-Website\SelfDevelopmentApp\Views\Articles\Details.cshtml"
                             foreach (var item in RelatedArticles.ToList().TakeWhile(a => a.Title != null).Take(4))
                            {
                                if (item.ID != Model.ID)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d850f9187a7711dfabb07cfb34ee9355e43b37f13842", async() => {
#nullable restore
#line 87 "H:\ITI\PD\ASP_MVC\Project\Project repo\Self-Improvement-Website\SelfDevelopmentApp\Views\Articles\Details.cshtml"
                                                                                                                     Write(item.Title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 87 "H:\ITI\PD\ASP_MVC\Project\Project repo\Self-Improvement-Website\SelfDevelopmentApp\Views\Articles\Details.cshtml"
                                                                                                    WriteLiteral(item.ID);

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
            WriteLiteral("</li>\r\n");
#nullable restore
#line 88 "H:\ITI\PD\ASP_MVC\Project\Project repo\Self-Improvement-Website\SelfDevelopmentApp\Views\Articles\Details.cshtml"
                                }
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </ul>\r\n                    </div><!-- End sidebar categories-->\r\n");
#nullable restore
#line 93 "H:\ITI\PD\ASP_MVC\Project\Project repo\Self-Improvement-Website\SelfDevelopmentApp\Views\Articles\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <!--<h3 class=""sidebar-title"">Recent Posts</h3>
                    <div class=""sidebar-item recent-posts"">
                        <div class=""post-item clearfix"">
                            <img src=""~/assets/img/blog/blog-recent-1.jpg"" alt="""">
                            <h4><a asp-area="""" asp-controller=""Home"" asp-action=""BlogSingle"">Nihil blanditiis at in nihil autem</a></h4>
                            <time datetime=""2020-01-01"">Jan 1, 2020</time>
                        </div>

                        <div class=""post-item clearfix"">
                            <img src=""~/assets/img/blog/blog-recent-2.jpg"" alt="""">
                            <h4><a asp-area="""" asp-controller=""Home"" asp-action=""BlogSingle"">Quidem autem et impedit</a></h4>
                            <time datetime=""2020-01-01"">Jan 1, 2020</time>
                        </div>

                        <div class=""post-item clearfix"">
                            <img src=""~/assets/img/blog/blog-recent");
            WriteLiteral(@"-3.jpg"" alt="""">
                            <h4><a asp-area="""" asp-controller=""Home"" asp-action=""BlogSingle"">Id quia et et ut maxime similique occaecati ut</a></h4>
                            <time datetime=""2020-01-01"">Jan 1, 2020</time>
                        </div>

                        <div class=""post-item clearfix"">
                            <img src=""~/assets/img/blog/blog-recent-4.jpg"" alt="""">
                            <h4><a asp-area="""" asp-controller=""Home"" asp-action=""BlogSingle"">Laborum corporis quo dara net para</a></h4>
                            <time datetime=""2020-01-01"">Jan 1, 2020</time>
                        </div>

                        <div class=""post-item clearfix"">
                            <img src=""~/assets/img/blog/blog-recent-5.jpg"" alt="""">
                            <h4><a asp-area="""" asp-controller=""Home"" asp-action=""BlogSingle"">Et dolores corrupti quae illo quod dolor</a></h4>
                            <time datetime=""2020-01-01"">Jan 1, 2020</ti");
            WriteLiteral(@"me>
                        </div>

                    </div>--><!-- End sidebar recent posts-->

                    <!--<h3 class=""sidebar-title"">Tags</h3>
                    <div class=""sidebar-item tags"">
                        <ul>
                            <li><a href=""#"">App</a></li>
                            <li><a href=""#"">IT</a></li>
                            <li><a href=""#"">Business</a></li>
                            <li><a href=""#"">Mac</a></li>
                            <li><a href=""#"">Design</a></li>
                            <li><a href=""#"">Office</a></li>
                            <li><a href=""#"">Creative</a></li>
                            <li><a href=""#"">Studio</a></li>
                            <li><a href=""#"">Smart</a></li>
                            <li><a href=""#"">Tips</a></li>
                            <li><a href=""#"">Marketing</a></li>
                        </ul>
                    </div>--><!-- End sidebar tags-->

                </div><");
            WriteLiteral("!-- End sidebar -->\r\n\r\n            </div><!-- End blog sidebar -->\r\n\r\n        </div>\r\n\r\n    </div>\r\n</section><!-- End Blog Single Section -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SelfDevelopmentApp.Models.Article> Html { get; private set; }
    }
}
#pragma warning restore 1591
