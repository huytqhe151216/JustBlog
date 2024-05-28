using FA.JustBlock.Core.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;

namespace FA.JustBlog
{
    public static class CustomHTMLHelpers
    {
        public static IHtmlContent TagLink(
                           this IHtmlHelper helper,
                           Tag tag)
        {
            ArgumentNullException.ThrowIfNull(helper);

            string linkText = tag.Name ?? "";
            string actionName = "ListPostByTag";
            string controllerName = "Post";
            object routeValues = new { tag = tag.Name };
            object htmlAttributes = new { @class = "badge bg-dark text-decoration-underline m-1" };
            return helper.ActionLink(
                linkText,
                actionName,
                controllerName,
                protocol: null,
                hostname: null,
                fragment: null,
                routeValues: routeValues,
                htmlAttributes: htmlAttributes);
        }
        public static IHtmlContent CategoryLink(
                         this IHtmlHelper helper,
                         Category category)
        {
            ArgumentNullException.ThrowIfNull(helper);
            string linkText = category.Name ?? "";
            string actionName = "ListPost";
            string controllerName = "Post";
            object routeValues = new { categoryName = category.Name };
            object htmlAttributes = new { @class = "badge bg-dark text-decoration-underline m-1" };
            return helper.ActionLink(
                linkText,
                actionName,
                controllerName,
                protocol: null,
                hostname: null,
                fragment: null,
                routeValues: routeValues,
                htmlAttributes: htmlAttributes);
        }
        
        public static IHtmlContent PostLink(
            this IHtmlHelper helper,
            Post post)
        {
            ArgumentNullException.ThrowIfNull(helper);
            var urlHelperFactory = helper.ViewContext.HttpContext.RequestServices.GetService(typeof(IUrlHelperFactory)) as IUrlHelperFactory;
            var urlHelper = urlHelperFactory.GetUrlHelper(helper.ViewContext);
            string url = urlHelper.Action("Details", "Post", new { year = post.PostedOn.Year, month = post.PostedOn.Month, title = post.UrlSlug });
            TagBuilder a = new TagBuilder("a");
            a.Attributes.Add("href", url);
            TagBuilder h3 = new TagBuilder("h2");
            h3.AddCssClass("post-title text-black");
            h3.AddCssClass("text-decoration-underline");
            h3.InnerHtml.Append(post.Title);
            a.InnerHtml.AppendHtml(h3);
            return new HtmlContentBuilder().AppendHtml(a);
        }
    }

}
