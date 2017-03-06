namespace Sitecore.Support.Mvc.Pipelines.Response.RenderRendering
{
    using Sitecore.Data;
    using Sitecore.Diagnostics;
    using Sitecore.Diagnostics.PerformanceCounters;
    using Sitecore.Mvc.Pipelines.Response.RenderRendering;
    using Sitecore.Mvc.Presentation;
    using System;

    public class RecordStatistics : RenderRenderingProcessor
    {
        private string GetTraceName(Rendering rendering)
        {
            return string.Format("{0} ({1})", rendering.RenderingItem.DisplayName, rendering.RenderingItem.InnerItem.Paths.Path);
        }

        public override void Process(RenderRenderingArgs args)
        {
            try
            {
                if (args.Rendering.RenderingItem.InnerItem.TemplateID != ID.Parse("{B6F7EEB4-E8D7-476F-8936-5ACE6A76F20B}"))
                {
                    string traceName = this.GetTraceName(args.Rendering);
                    HighResTimer timer = args.CustomData["timer"] as HighResTimer;
                    long num = (long)args.CustomData["itemsRead"];
                    Statistics.AddRenderingData(traceName, timer.Elapsed(), DataCounters.ItemsAccessed.Value - num, args.UsedCache);
                }
            }
            catch (Exception exception)
            {
                Log.Warn("Failed to record rendering statistics", exception);
            }
        }
    }
}
