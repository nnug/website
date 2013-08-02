using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI;

namespace NNUG.WebSite.Core.MvcHelper
{
    public static class WebSiteExtensions
    {
        public static void RenderBootstrapGridLayout<T>(this HtmlHelper html, List<T> items, int itemsPerRow, string partialViewName)
        {
            var writer = new HtmlTextWriter(html.ViewContext.Writer);
            int row = 0;
            while (row * itemsPerRow < items.Count)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "row");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                foreach (T item in items.Skip(row*itemsPerRow).Take(itemsPerRow))
                {
                    html.RenderPartial(partialViewName, item);
                }
                writer.RenderEndTag();
                row++;
            }
        }
    }
}