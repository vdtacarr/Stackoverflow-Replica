#pragma checksum "C:\Users\07018332\source\repos\foo\foo\Views\Home\SaveQuestion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d8598d3eed2b426575c482526afd764afe72bd3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_SaveQuestion), @"mvc.1.0.view", @"/Views/Home/SaveQuestion.cshtml")]
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
#line 1 "C:\Users\07018332\source\repos\foo\foo\Views\_ViewImports.cshtml"
using Stackoverflow.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\07018332\source\repos\foo\foo\Views\_ViewImports.cshtml"
using Stackoverflow.Jwt;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\07018332\source\repos\foo\foo\Views\_ViewImports.cshtml"
using Stackoverflow.Model.Dtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\07018332\source\repos\foo\foo\Views\_ViewImports.cshtml"
using foo;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d8598d3eed2b426575c482526afd764afe72bd3", @"/Views/Home/SaveQuestion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc97f7c8c3cd98dfc3e2f379dda72019dd0edbe5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_SaveQuestion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form_question"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\07018332\source\repos\foo\foo\Views\Home\SaveQuestion.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    button {
        margin-top: 10px;
    }

    a {
        background-color: antiquewhite;
    }

        a:hover {
            background-color: darkolivegreen;
            width: 75px;
            height: 20px;
        }

    .form-group {
        width: 700px;
    }

    .form_question {
        background-color: darkgrey;
        border-style: dotted;
        border-radius: 20px;
    }
</style>


");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d8598d3eed2b426575c482526afd764afe72bd34516", async() => {
                WriteLiteral(@"
    Title : <input class=""form-group m-1 title"" placeholder=""Title field"" required /><br />

    <div class=""form-group"">
        <label for=""comment"">Comment:</label>
        <textarea class=""form-control m-1"" rows=""5"" id=""comment"" placeholder=""Content field"" required></textarea>
        <div class=""valid-feedback"">Valid.</div>
        <div class=""invalid-feedback"">Check this question box to continue.</div>
    </div>
    Slug : <br /><input class=""m-1 slug"" placeholder=""Slug field"" /><br />

    <button class=""btn btn-primary m-2 send_btn"" type=""submit"">Save</button>

    <a");
                BeginWriteAttribute("href", " href=\"", 1099, "\"", 1134, 1);
#nullable restore
#line 44 "C:\Users\07018332\source\repos\foo\foo\Views\Home\SaveQuestion.cshtml"
WriteAttributeValue("", 1106, Url.Action("ListQuestions"), 1106, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Questions Page</a>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script>
        var comment = """";
        var title = """";
        var slug = """";
        $("".send_btn"").click(function (e) {
            e.preventDefault();

            comment = $(""#comment"").val();
            title = $("".title"").val();
            slug = $("".slug"").val();
            var _data = JSON.stringify({
                ""Content"": comment,
                ""Title"": title,
                ""Slug"": slug
            });
            $.ajax({
                type: ""POST"",
                url: '/home/questionsend',
                contentType: 'application/json',
                data: _data,
                success: function (data) {
                    if (data == ""1"") {
                        window.location = ""/home/questions"";
                    }
                },
                error: function (x, q, w) {
                    window.location = ""/home/login"";                },
            });
        });

    </script>
");
            }
            );
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