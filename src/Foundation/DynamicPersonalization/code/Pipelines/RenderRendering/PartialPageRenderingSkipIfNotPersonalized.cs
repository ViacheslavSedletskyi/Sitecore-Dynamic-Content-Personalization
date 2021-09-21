using System.Web;
using Foundation.DynamicPersonalization.Extensions;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Common;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;

namespace Foundation.DynamicPersonalization.Pipelines.RenderRendering
{
    public class PartialPageRenderingSkipIfNotPersonalized : RenderRenderingProcessor
    {
        private const string CurrentRootRenderingId = "PartialPageRendering_CurrentRootRenderingId";

        public override void Process(RenderRenderingArgs args)
        {
            Assert.ArgumentNotNull(args, nameof(args));
            
            if (args.Rendered || args.Rendering == null || string.Equals(args.Rendering.RenderingType, "Layout") || HttpContext.Current.Items.Contains(CurrentRootRenderingId) || !HttpContext.Current.Request.IsPartialPageRendering())
            {
                return;
            }

            HttpContext.Current.Items[CurrentRootRenderingId] = args.Rendering.UniqueId;
            args.Disposables.Add(new GenericDisposable(() =>
            {
                if (HttpContext.Current.Items.Contains(CurrentRootRenderingId))
                {
                    HttpContext.Current.Items.Remove(CurrentRootRenderingId);
                }
            }));
        }
    }
}