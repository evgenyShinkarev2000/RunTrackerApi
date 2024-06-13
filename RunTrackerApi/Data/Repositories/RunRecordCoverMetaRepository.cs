using Microsoft.EntityFrameworkCore;
using RunTrackerApi.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RunTrackerApi.Data.Repositories
{
    public interface IRunRecordCoverMetaRepository : ISaveChangesAsync
    {
        void Add(RunRecordCoverMeta runRecordCoverMeta);

        Task<bool> ContainsUserAndKey(int userId, int key);

        Task<int> GetRunRecordCoverId(int userId, int key);
        Task<RunRecordCoverMeta?> GetBy(int userId, int key);
    }

    public class RunRecordCoverMetaRepository : IRunRecordCoverMetaRepository
    {
        private readonly AppDbContext appDbContext;

        public RunRecordCoverMetaRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void Add(RunRecordCoverMeta runRecordCoverMeta)
        {
            appDbContext.RunRecordCoverMetas.Add(runRecordCoverMeta);
        }

        public async Task<bool> ContainsUserAndKey(int userId, int key)
        {
            return await appDbContext.RunRecordCoverMetas
                .Where(rrcm => rrcm.UserId == userId && rrcm.Key == key)
                .AnyAsync();
        }

        public async Task<RunRecordCoverMeta?> GetBy(int userId, int key)
        {
            return await appDbContext.RunRecordCoverMetas
                .AsNoTracking()
                .Include(rrcm => rrcm.RunRecordCover)
                .FirstOrDefaultAsync(rrcm => rrcm.UserId == userId && rrcm.Key == key);
        }

        public async Task<int> GetRunRecordCoverId(int userId, int key)
        {
            return await appDbContext.RunRecordCoverMetas
               .Where(rrcm => rrcm.UserId == userId && rrcm.Key == key)
               .Select(rrcm => rrcm.RunRecordCover.Id)
               .FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await appDbContext.SaveChangesAsync();
        }
    }
}
