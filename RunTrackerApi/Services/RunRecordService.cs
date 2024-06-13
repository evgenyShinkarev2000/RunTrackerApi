using RunTrackerApi.Data.Models;
using RunTrackerApi.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace RunTrackerApi.Services
{
    public interface IRunRecordService
    {
        Task<RunRecordCover> AddOrReplceRunCover(RunRecordCover runRecordCover, int userId, int key);

        Task<RunRecordCover?> GetBy(int userId, int key);
    }

    public class RunRecordService : IRunRecordService
    {
        private readonly IRunRecordCoverRepository runRecordCoverRepository;
        private readonly IRunRecordCoverMetaRepository runRecordCoverMetaRepository;

        public RunRecordService(IRunRecordCoverRepository runRecordCoverRepository, IRunRecordCoverMetaRepository runRecordCoverMetaRepository)
        {
            this.runRecordCoverRepository = runRecordCoverRepository;
            this.runRecordCoverMetaRepository = runRecordCoverMetaRepository;
        }

        public async Task<RunRecordCover> AddOrReplceRunCover(RunRecordCover runRecordCover, int userId, int key)
        {
            var oldRunRecordCoverMeta = await runRecordCoverMetaRepository.GetBy(userId, key);
            if (oldRunRecordCoverMeta != null)
            {
                runRecordCover.Id = oldRunRecordCoverMeta.RunRecordCover.Id;
                runRecordCoverRepository.Update(runRecordCover);
                await runRecordCoverRepository.SaveChangesAsync();

                return runRecordCover;
            }

            runRecordCoverMetaRepository.Add(new RunRecordCoverMeta()
            {
                Key = key,
                RunRecordCover = runRecordCover,
                UserId = userId,
            });
            await runRecordCoverMetaRepository.SaveChangesAsync();

            return runRecordCover;
        }

        public async Task<RunRecordCover?> GetBy(int userId, int key)
        {
            var runRecordCoverId = await runRecordCoverMetaRepository.GetRunRecordCoverId(userId, key);
            if (runRecordCoverId == 0)
            {
                return null;
            }

            return await runRecordCoverRepository.GetById(runRecordCoverId);
        }
    }
}
