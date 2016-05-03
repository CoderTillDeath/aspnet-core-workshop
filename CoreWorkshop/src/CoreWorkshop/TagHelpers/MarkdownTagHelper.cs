using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.AspNet.Razor.TagHelpers;

namespace CoreWorkshop.TagHelpers
{
    // You may need to install the Microsoft.AspNet.Razor.Runtime package into your project
    [HtmlTargetElement("markdown")]  // Manually set tag name
    [HtmlTargetElement("p", Attributes = "markdown")]
    public class MarkdownTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            output.Content.SetHtmlContent(CommonMark.CommonMarkConverter.Convert(childContent.GetContent()));
            output.TagName = null;
        }
    }
}
