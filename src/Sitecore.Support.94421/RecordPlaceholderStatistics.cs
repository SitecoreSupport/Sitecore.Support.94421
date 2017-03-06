namespace Sitecore.Support.Mvc.Pipelines.Response.RenderPlaceholder
{
    using Sitecore.Diagnostics;
    using Sitecore.Diagnostics.PerformanceCounters;
    using Sitecore.Mvc.Pipelines.Response.RenderPlaceholder;
    using System;

    public class RecordPlaceholderStatistics : RenderPlaceholderProcessor
    {
        private string GetTraceName(string placeholderName)
        {
            return string.Format("Placeholder: {0}", placeholderName);
        }

        public override void Process(RenderPlaceholderArgs args)
        {
            try
            {
                string traceName = this.GetTraceName(args.PlaceholderName);
                HighResTimer timer = args.CustomData["timer"] as HighResTimer;
                long num = (long)args.CustomData["itemsRead"];
                Statistics.AddRenderingData(traceName, timer.Elapsed(), DataCounters.ItemsAccessed.Value - num, false);
            }
            catch (Exception exception)
            {
                Log.Warn("Failed to record placeholder statistics", exception);
            }
        }
    }
}
