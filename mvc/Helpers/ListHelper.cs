using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace mvc.Helpers
{
    public static class ListHelper
    {
        public static MvcHtmlString CreateList(this HtmlHelper html, string[] items, object htmlAttributest = null)
        {
            TagBuilder ul = new TagBuilder("ul");

            foreach (var item in items)
            {
                TagBuilder li = new TagBuilder("li");
                li.SetInnerText(item);
                ul.InnerHtml += li.ToString();
            }

            ul.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributest));

            return new MvcHtmlString(ul.ToString());
        }
    }
}