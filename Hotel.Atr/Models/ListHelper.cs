using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web.Mvc;

namespace Hotel.Atr.Models
{
    public static class ListHelper
    {
        //mvc
        //public static MvcHtmlString CreateList(string[] items)
        //{            
        //    TagBuilder ul = new TagBuilder("ul");
        //    foreach (string item in items)
        //    {
        //        TagBuilder li = new TagBuilder("li");
        //        li.SetInnerText(item);
        //        ul.InnerHtml += li;
        //    }
        //    return new MvcHtmlString(ul.ToString());
        //}

        //core
        //public static HtmlString CreateList(this IHtmlHelper html,
        //    string[] items)
        //{
        //    string ul = "<ul>";
        //    foreach (string item in items)
        //    {
        //        ul += "<li>" + item + "</li>";
        //    }
        //    ul += "</ul>";

        //    return new HtmlString(ul);
        //}        
    }
}
