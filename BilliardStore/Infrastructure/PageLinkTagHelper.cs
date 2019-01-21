//The infrastructure folder holds cs files that are not related to the application's domain
//references PagingInfo.cs, 
//called by List.cshmtl
using Microsoft.AspNetCore.Mvc;

namespace BilliardStore.Infrastructure
{
    //inherits TagHelper class
    [Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    {
        private Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory urlHelperFactory;

        //constructor with an object of type IUrlHelperFactory passed in as a parameter
        public PageLinkTagHelper(Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        [Microsoft.AspNetCore.Mvc.ViewFeatures.ViewContext]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNotBound]
        public Microsoft.AspNetCore.Mvc.Rendering.ViewContext ViewContext { get; set; }

        public Models.ViewModels.PagingInfo PageModel { get; set; }

        public string PageAction { get; set; }

        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public System.Collections.Generic.Dictionary<string, object> PageUrlValues { get; set; } = new System.Collections.Generic.Dictionary<string, object>();

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
        {
            Microsoft.AspNetCore.Mvc.IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            Microsoft.AspNetCore.Mvc.Rendering.TagBuilder result = new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder("div");
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                Microsoft.AspNetCore.Mvc.Rendering.TagBuilder tag = new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder("a");
                PageUrlValues["productPage"] = i;
                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}


