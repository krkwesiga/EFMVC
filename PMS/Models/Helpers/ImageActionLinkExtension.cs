using System;
using System.Text;
using System.Web.Mvc;

namespace PMS.Models.Helpers
{
  public static class ImageActionLinkExtension
  {
    public static MvcHtmlString ActionImage(this HtmlHelper helper, String controller, String action, Object parameters, String src, String alt = "", String title = "")
    {

      var tagBuilder = new TagBuilder("img");
      var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
      var url = urlHelper.Action(action, controller, parameters);
      var imgUrl = urlHelper.Content(src);
      var image = "";
      var html = new StringBuilder();

      // build the image tag.
      tagBuilder.MergeAttribute("src", imgUrl);
      tagBuilder.MergeAttribute("alt", alt);
      tagBuilder.MergeAttribute("title", title);
      image = tagBuilder.ToString(TagRenderMode.SelfClosing);

      html.Append("<a href=\"");
      html.Append(url);
      html.Append("\">");
      html.Append(image);
      html.Append("</a>");

      return MvcHtmlString.Create(html.ToString());
    }
  }
}