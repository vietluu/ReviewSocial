#pragma checksum "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "40ec0b94f4c7a52de4245090091af9f3efebb14c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Post_Index), @"mvc.1.0.view", @"/Views/Post/Index.cshtml")]
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
#line 1 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\_ViewImports.cshtml"
using ReviewSocial;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\_ViewImports.cshtml"
using ReviewSocial.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40ec0b94f4c7a52de4245090091af9f3efebb14c", @"/Views/Post/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e106a7012b7907678136e7a9277aa3c8fb21fa7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Post_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tuple<IEnumerable<Category>, IEnumerable<Post>>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("sidebar__link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
  
    ViewData["Title"] = "Trang chủ";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container p-2\">\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-9 col-md-12 activity p-2 newsfeed\">\r\n");
#nullable restore
#line 27 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
           if(Model.Item2 != null){
             

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
              foreach (var item in Model.Item2.Reverse())
           {
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"panel panel-default mb-3 bg-white p-2 rounded-sm\">\r\n                <div class=\"panel-heading\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 1477, "\"", 1522, 2);
#nullable restore
#line 33 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
WriteAttributeValue("", 1483, Url.Content("~/img/"), 1483, 22, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
WriteAttributeValue("", 1505, item.User.Avatar, 1505, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"40\" height=\"40\" class=\"img-rounded img-circle cover-image\">\r\n                    <div class=\"pull-right text-right\">\r\n");
            WriteLiteral("                        <div class=\"dropdown\">\r\n");
            WriteLiteral(@"                            <button class=""btn btn-secondary bg-transparent text-dark border-0"" type=""button"" data-toggle=""dropdown"" aria-expanded=""false"">
                                <i class=""fa fa-ellipsis-h""></i>
                            </button>
                            <div class=""dropdown-menu"" style=""margin-left: -155px;"">
");
#nullable restore
#line 42 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
                                if(item.UserId == Convert.ToInt32(Accessor.HttpContext.Session.GetString("id"))){
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a class=\"dropdown-item\" data-toggle=\"modal\" data-target=\"#exampleModals\" ><i class=\"fa fa-pencil\" aria-hidden=\"true\"  readonly ></i> Chỉnh sửa bài viết</a>\r\n                                <a class=\"dropdown-item\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2690, "\"", 2720, 3);
            WriteAttributeValue("", 2700, "deleteItem(", 2700, 11, true);
#nullable restore
#line 45 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
WriteAttributeValue("", 2711, item.Id, 2711, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2719, ")", 2719, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-trash\" aria-hidden=\"true\"></i> Xóa bài</a>\r\n                                <a class=\"dropdown-item\" href=\"#\"><i class=\"fa fa-window-close\" aria-hidden=\"true\"></i> Ẩn bài viết</a>\r\n");
#nullable restore
#line 47 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
                                
                               }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n");
            WriteLiteral("                        </div>\r\n                    </div>\r\n                    <div><strong>");
#nullable restore
#line 111 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
                            Write(item?.User?.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                        <div>\r\n                        <p style=\"font-family:\'Times New Roman\', Times, serif\">");
#nullable restore
#line 113 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
                                                                          Write(DateTime.Parse(item.CreatedDate.ToString()).ToString("dd/MM/yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                    </div>\r\n                </div>\r\n                <div class=\"panel-body d-flex flex-column\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40ec0b94f4c7a52de4245090091af9f3efebb14c10434", async() => {
#nullable restore
#line 118 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
                                                                                                         Write(item.Title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 118 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
                                                                       WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 119 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
                         if (@item.Thumbnail.Trim() != "")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"text-center\">\r\n                                <img");
            BeginWriteAttribute("src", " src=\"", 6895, "\"", 6934, 3);
#nullable restore
#line 122 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
WriteAttributeValue("", 6901, Url.Content("~"), 6901, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6918, "/", 6918, 1, true);
#nullable restore
#line 122 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
WriteAttributeValue("", 6919, item.Thumbnail, 6919, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("  class=\"img-responsive w-50 h-50\">\r\n\r\n                            </div>\r\n");
#nullable restore
#line 125 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""card-body"">
                    </div>
                    <div class=""actions"">
                        <div class=""btn-group"">
                            <button type=""button"" class=""btn btn-link""><i class=""fa fa-thumbs-o-up""></i> Like</button>
                            <button type=""button"" class=""btn btn-link""><i class=""fa fa-comments""></i>                        
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40ec0b94f4c7a52de4245090091af9f3efebb14c14891", async() => {
                WriteLiteral("Comment");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 132 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
                                                                           WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</button>\r\n                        </div>\r\n                    \r\n\r\n                        <div class=\"pull-right\"> <span class=\"stats-text\">");
#nullable restore
#line 137 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
                                                                     Write(item.Comments.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Comment  </span><strong>");
#nullable restore
#line 137 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
                                                                                                                  Write(item.View);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> People View this</div>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 142 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
           }

#line default
#line hidden
#nullable disable
#nullable restore
#line 142 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
            
          }
          else{

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h3> khong co bai viet nao </h3>\r\n");
#nullable restore
#line 146 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
          }

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n");
            WriteLiteral(@"
        </div>

        <div class=""col-lg-3 d-md-12 activity d-sm-none d-lg-block p-2"">
            <div class=""category bg-white rounded-3"">
                <h3 class=""title text-center"">
                    Danh mục
                </h3>
                <div class=""sidebar__box flex-column d-flex align-items-center justify-content-center"">
");
#nullable restore
#line 257 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
                     foreach (var item in Model.Item1){

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"sidebar__item\">\r\n                        <i class=\"fa fa-newspaper-o\"></i>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40ec0b94f4c7a52de4245090091af9f3efebb14c19679", async() => {
                WriteLiteral("\r\n                                ");
#nullable restore
#line 261 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
                           Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-category", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 260 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
                                                                       WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["category"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-category", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["category"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 264 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                   
                  
                </div>

            </div>
        </div>
    </div>
</div>

<!-- Modal -->
<div class=""modal fade"" id=""exampleModal"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40ec0b94f4c7a52de4245090091af9f3efebb14c22950", async() => {
                WriteLiteral(@"
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLabel"">Tạo bài viết</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <div class=""form-group row mb-3"">
                        <label for=""title"" class=""col-sm-2 col-form-label"">Tiêu đề:</label>
                        <div class=""col-sm-10"">
                            <input type=""text"" name=""title"" class=""form-control"" id=""title""");
                BeginWriteAttribute("value", " value=\"", 15592, "\"", 15600, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Tiêu đề"">
                        </div>
                    </div>
                    <div class=""form-group row mb-3"">
                        <label for=""title"" class=""col-sm-2 col-form-label"">Danh mục:</label>
                        <div class=""col-sm-10"">
                            <select class=""form-control"" id=""exampleFormControlSelect1"">
");
#nullable restore
#line 301 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
                                 foreach (var item in Model.Item1 )
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                   ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40ec0b94f4c7a52de4245090091af9f3efebb14c24790", async() => {
#nullable restore
#line 303 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
                                                       Write(item.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 303 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
                                      WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" \r\n");
#nullable restore
#line 304 "D:\bgi\ReviewSocial\ReviewSocial\ReviewSocial\Views\Post\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            </select>
                        </div>
                    </div>
                    <div class=""form-group row mb-3"">
                        <label for=""inputPassword"" class=""col-sm-2 col-form-label"">Nội dung:</label>
                        <div class=""col-sm-10"">
                            <textarea name=""content"" id=""content-home"" class=""form-control w-100"" rows=""10""></textarea>
                            
                        </div>
                    </div>
                    <div class=""form-group row mb-3"">
                        <label for=""exampleFormControlFile1"" class=""col-sm-2 col-form-label"">Ảnh bài viết:</label>
                        <div class=""col-sm-10"" id=""imagePreview""></div>
                        <div class=""col-sm-10"">
                            <input type=""file"" name=""file"" accept=""image/*"" class=""form-control-file"" id=""file"">
                        </div>
                    </div>
                </div>
                <");
                WriteLiteral(@"div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                    <button type=""button"" onclick=""submitForm()"" class=""btn btn-primary"">Save changes</button>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral(@"            <script>
                 const deleteItem = (itemId) => {
                    
                    if (confirm(""Bạn có muốn xóa bai viet này?"")) {
                 
                    ajaxCustom(`/Home/Delete/${itemId}`,'delete',null,(value)=>{window.location.reload()},(value)=>{
                        alert('xoa khong thanh cong')
                    })
                 
                        }


                 };
                const submitForm = () => {
                    var editor = CKEDITOR.instances['content-home'];
                    const title = document.getElementById(""title"").value;
                    const option = document.getElementById(""exampleFormControlSelect1"").value;
                    const file = document.getElementById(""file"").files[0]

                    var formData = new FormData();

                    formData.append('file', file);
                    formData.append('Title', title);
                    formData.append('Content', edit");
            WriteLiteral(@"or.getData());
                    formData.append('CategoryId', option);
                    ajaxCustom(""Home/Create"",""post"",formData,(value)=>{window.location.reload()},(value)=>{alert('them khong thanh cong')})
                }
            </script>
        </div>
    </div>
</div>


");
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor Accessor { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tuple<IEnumerable<Category>, IEnumerable<Post>>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
