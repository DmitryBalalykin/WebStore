using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DomainNew.ViewModel;

namespace WebStore.TagHelpers
{
    public class PagingTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory _urHelperFactory;

        [ViewContext,HtmlAttributeNotBound]
        public ViewContext viewContext { get; set; }

        public PageViewModel pageViewModel { get; set; }

        public string PageAction { get; set; }
        
        /// <summary>
        /// Параметр словарного типа
        /// </summary>
        [HtmlAttributeName(DictionaryAttributePrefix ="page-url-")]
        public Dictionary<string, object> pageUrlValues { get; set; } = new Dictionary<string, object>();

        public PagingTagHelper(IUrlHelperFactory urHelperFactory)
        {
            _urHelperFactory = urHelperFactory;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var url_helper = _urHelperFactory.GetUrlHelper(viewContext);

            var ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");

            for (var i = 1; i < pageViewModel.TotalPages; i++)
            {
                ul.InnerHtml.AppendHtml(CreateItem(i, url_helper));
            }

            output.Content.AppendHtml(ul);
        }

        private TagBuilder CreateItem (int pageNumber, IUrlHelper urlHelper)
        {
            var li = new TagBuilder("li");
            var a = new TagBuilder("a");

            if (pageNumber == pageViewModel.PageNumer)
            {
                a.MergeAttribute("data-page", pageViewModel.PageNumer.ToString());
                li.AddCssClass("active");
            }
            else
            {
                pageUrlValues["page"] = pageNumber;
                a.Attributes["href"] = "#";//urlHelper.Action(PageAction, pageUrlValues);
                foreach (var (key, value) in pageUrlValues.Where(p=> p.Value != null))
                {
                    a.MergeAttribute($"data-{key}", value.ToString());
                }
            }

            a.InnerHtml.AppendHtml(pageNumber.ToString());
            li.InnerHtml.AppendHtml(a);
            return li;
        }
    }
}
