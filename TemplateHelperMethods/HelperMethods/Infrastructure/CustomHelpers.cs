using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelperMethods.Infrastructure
{
    public static class CustomHelpers
    {
        public static MvcHtmlString ListArrayItems(this HtmlHelper html, string[] list)
        {
            TagBuilder tag = new TagBuilder("ul");

            foreach(string str in list)
            {
                TagBuilder itemTag = new TagBuilder("li");
                itemTag.SetInnerText(str);
                tag.InnerHtml += itemTag.ToString();
            }

            return new MvcHtmlString(tag.ToString());
        }

        public static MvcHtmlString DisplayMessage(this HtmlHelper html, string msg)
        {
            // Still not encoding markup or scripts
            //string result = String.Format("This is the message: <p>{0}</p>", msg);
            //return new MvcHtmlString(result);

            // encode all included markup or scripts into string
            //return String.Format("This is the message: <p>{0}</p>", msg);

            // encode what we want first, after that return MvcHtmlString as normal
            string encodeMessage = html.Encode(msg);
            string result = String.Format("This is the message: <p>{0}</p>", encodeMessage);

            return new MvcHtmlString(result);
        }
    }
}