namespace Sitecore.Support.Mvc.Pipelines.Response.RenderRendering
{
    using Sitecore.Diagnostics;
    using Sitecore.Diagnostics.PerformanceCounters;
    using Sitecore.Mvc.Pipelines.Response.RenderRendering;
    using System;

    public class InitializeStatistics : RenderRenderingProcessor
    {
        public override void Process(RenderRenderingArgs args)
        {
            args.CustomData.Add("timer", new HighResTimer(true));
            args.CustomData.Add("itemsRead", DataCounters.ItemsAccessed.Value);
        }
    }
}
