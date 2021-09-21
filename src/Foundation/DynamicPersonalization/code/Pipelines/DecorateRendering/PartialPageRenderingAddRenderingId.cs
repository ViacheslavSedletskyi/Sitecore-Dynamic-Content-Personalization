using System.Web;
using Foundation.DynamicPersonalization.Extensions;
using Sitecore.XA.Foundation.MarkupDecorator.Pipelines.DecorateRendering;

namespace Foundation.DynamicPersonalization.Pipelines.DecorateRendering
{
    public class PartialPageRenderingAddRenderingId : RenderingDecorator
    {
        public override void Process(RenderingDecoratorArgs args)
        {
            if (args.Rendering.Properties[Constants.RenderingPersonalizedProperty] == "1" && HttpContext.Current.Request.IsPartialPageRenderingAllowed())
            {
                args.AddAttribute("data-rid", args.Rendering.UniqueId.Guid.ToString("N"));
            }
        }
    }
}