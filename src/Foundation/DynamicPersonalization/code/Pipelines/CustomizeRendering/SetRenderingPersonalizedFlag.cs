using Sitecore.Mvc.Analytics.Pipelines.Response.CustomizeRendering;

namespace Foundation.DynamicPersonalization.Pipelines.CustomizeRendering
{
    public class SetRenderingPersonalizedFlag : CustomizeRenderingProcessor
    {
        public override void Process(CustomizeRenderingArgs args)
        {
            if (args.Rendering.RenderingItem != null && args.IsCustomized)
            {
                args.Rendering[Constants.RenderingPersonalizedProperty] = "1";
            }
        }
    }
}