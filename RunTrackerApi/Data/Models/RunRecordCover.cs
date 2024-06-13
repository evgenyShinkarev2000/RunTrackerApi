using System;

namespace RunTrackerApi.Data.Models
{
    public class RunRecordCover : Entity
    {
        public string Title { get; set; } = default!;

        /// <summary>
        /// meters
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// UTC only
        /// </summary>
        public DateTime Start { get; set; }

        public TimeSpan Duration { get; set; }

        /// <summary>
        /// meters per second
        /// </summary>
        public double? AverageSpeed { get; set; }

        /// <summary>
        /// beats per minute
        /// </summary>
        public double? AveragePulse { get; set; }
    }
}
