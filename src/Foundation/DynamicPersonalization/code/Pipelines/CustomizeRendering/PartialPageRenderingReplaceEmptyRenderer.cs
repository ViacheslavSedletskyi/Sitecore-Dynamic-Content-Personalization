using System.Web;
using Foundation.DynamicPersonalization.Extensions;
using Foundation.DynamicPersonalization.Renderers;
using Sitecore.Mvc.Analytics.Pipelines.Response.CustomizeRendering;
using Sitecore.Mvc.Analytics.Presentation;

namespace Foundation.DynamicPersonalization.Pipelines.CustomizeRendering
{
    public class PartialPageRenderingReplaceEmptyRenderer : CustomizeRenderingProcessor
    {
        public override void Process(CustomizeRenderingArgs args)
        {
            if (args.IsCustomized && args.Renderer is EmptyRenderer && HttpContext.Current.Request.IsPartialPageRenderingAllowed())
            {
                args.Renderer = new PartialPageRenderingEmptyRenderer(args.Rendering);
            }
        }
    }
}