using RunTrackerApi.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace RunTrackerApi.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<RunRecordCover> RunRecordCovers { get; set; }
        public DbSet<RunRecordCoverMeta> RunRecordCoverMetas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
