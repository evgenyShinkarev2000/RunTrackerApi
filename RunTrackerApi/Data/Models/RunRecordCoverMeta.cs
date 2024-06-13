using Microsoft.EntityFrameworkCore;

namespace RunTrackerApi.Data.Models
{
    [PrimaryKey("Key", "UserId")]
    public class RunRecordCoverMeta: IEntity
    {
        public RunRecordCover RunRecordCover { get; set; } = default!;

        /// <summary>
        /// external id
        /// </summary>
        public int Key { get; set; }

        public int UserId { get; set; }
    }
}
