using Microsoft.EntityFrameworkCore;
using RunTrackerApi.Data.Models;
using System.Threading.Tasks;

namespace RunTrackerApi.Data.Repositories
{
    public interface IRunRecordCoverRepository : ISaveChangesAsync
    {
        void Add(RunRecordCover runRecordCover);
        Task<RunRecordCover?> GetById(int id);
        void Update(RunRecordCover runRecordCover);
    }

    public class RunRecordCoverRepository : IRunRecordCoverRepository
    {
        private readonly AppDbContext appDbContext;

        public RunRecordCoverRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void Add(RunRecordCover runRecordCover)
        {
            appDbContext.RunRecordCovers.Add(runRecordCover);
        }

        public async Task<RunRecordCover?> GetById(int id)
        {
            return await appDbContext.RunRecordCovers
                .AsNoTracking()
                .FirstOrDefaultAsync(rrc => rrc.Id == id);
        }

        public void Update(RunRecordCover runRecordCover)
        {
            appDbContext.RunRecordCovers.Update(runRecordCover);
        }

        public async Task SaveChangesAsync()
        {
            await appDbContext.SaveChangesAsync();
        }
    }
}
