namespace Sitecore.Support.Mvc.Pipelines.Response.RenderPlaceholder
{
    using Sitecore.Diagnostics;
    using Sitecore.Diagnostics.PerformanceCounters;
    using Sitecore.Mvc.Pipelines.Response.RenderPlaceholder;
    using System;

    public class InitializePlaceholderStatistics : RenderPlaceholderProcessor
    {
        public override void Process(RenderPlaceholderArgs args)
        {
            args.CustomData.Add("timer", new HighResTimer(true));
            args.CustomData.Add("itemsRead", DataCounters.ItemsAccessed.Value);
        }
    }
}
