using System;

namespace RunTrackerApi.WebApi.Models
{
    public class RunRecordCover : IWebApiModel
    {
        public string Title { get; set; } = default!;

        /// <summary>
        /// meters
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// UTC only
        /// </summary>
        public string Start { get; set; } = default!;

        /// <summary>
        /// microseconds
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// meters per second
        /// </summary>
        public double? AverageSpeed { get; set; }

        /// <summary>
        /// beats per minute
        /// </summary>
        public double? AveragePulse { get; set; }

        /// <summary>
        /// External key
        /// </summary>
        public int Key { get; set; }
    }
}
