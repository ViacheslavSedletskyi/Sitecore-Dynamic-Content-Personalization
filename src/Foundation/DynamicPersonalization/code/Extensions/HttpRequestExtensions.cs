using System.Web;
using Sitecore.XA.Foundation.Multisite.Extensions;

namespace Foundation.DynamicPersonalization.Extensions
{
    public static class HttpRequestExtensions
    {
        /// <summary>
        /// Checks, if partial rendering enabled for current page.
        /// </summary>
        /// <param name="httpRequest">HttpRequest.</param>
        /// <returns>if partial rendering enabled for current page.</returns>
        public static bool IsPartialPageRenderingAllowed(this HttpRequest httpRequest)
        {
            // Ignore all requests, except site rendering.
            if (Sitecore.Context.Site == null ||
                !Sitecore.Context.Item.IsInSxaContext())
            {
                return false;
            }

            // Ignore all requests, except preview and normal modes.
            if (!Sitecore.Context.PageMode.IsNormal && !Sitecore.Context.PageMode.IsPreview)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks, if page is rendering in partial mode.
        /// </summary>
        /// <param name="httpRequest">HttpRequest.</param>
        /// <returns>if page is rendering in partial mode.</returns>
        public static bool IsPartialPageRendering(this HttpRequest httpRequest)
        {
            if (!httpRequest.IsPartialPageRenderingAllowed())
            {
                return false;
            }

            return string.Equals(httpRequest.QueryString[Constants.IsPartialPageRenderingQueryParameter], "1");
        }
    }
}