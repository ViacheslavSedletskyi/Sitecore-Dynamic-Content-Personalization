using System.IO;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Analytics.Presentation;
using Sitecore.Mvc.Presentation;

namespace Foundation.DynamicPersonalization.Renderers
{
    public class PartialPageRenderingEmptyRenderer : EmptyRenderer
    {
        public PartialPageRenderingEmptyRenderer(Rendering rendering)
        {
            this.Rendering = rendering;
        }

        protected Rendering Rendering { get; }

        public override void Render(TextWriter writer)
        {
            Assert.IsNotNull(writer, nameof(writer));
            writer.Write($"<div class=\"component component-hidden\" data-rid=\"{this.Rendering.UniqueId:N}\"></div>");
        }
    }
}