using Microsoft.AspNetCore.Mvc;
using RunTrackerApi.Data.Repositories;
using RunTrackerApi.Services;
using RunTrackerApi.WebApi.Mappers.ToData;
using RunTrackerApi.WebApi.Mappers.ToWebApi;
using RunTrackerApi.WebApi.Models;
using System.Threading.Tasks;

namespace RunTrackerApi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RunCoverController : ControllerBase
    {
        private readonly IRunRecordService runRecordService;
        private readonly IRunRecordCoverToData runRecordCoverToData;
        private readonly IRunRecordCoverToWebApi runRecordCoverToWebApi;
        private readonly ICurrentUserService currentUserService;
        private readonly IRunRecordCoverRepository runRecordCoverRepository;

        public RunCoverController(IRunRecordService runRecordService,
            IRunRecordCoverToData runRecordCoverToData,
            IRunRecordCoverToWebApi runRecordCoverToWebApi,
            ICurrentUserService currentUserService,
            IRunRecordCoverRepository runRecordCoverRepository)
        {
            this.runRecordService = runRecordService;
            this.runRecordCoverToData = runRecordCoverToData;
            this.runRecordCoverToWebApi = runRecordCoverToWebApi;
            this.currentUserService = currentUserService;
            this.runRecordCoverRepository = runRecordCoverRepository;
        }

        [HttpGet("GetBy")]
        public async Task<ActionResult<RunRecordCover>> GetBy(int userId, int key)
        {
            var data = await runRecordService.GetBy(userId, key);
            if (data == null)
            {
                return NotFound();
            }

            return runRecordCoverToWebApi.Map(data);
        }

        [HttpGet("GetByKey")]
        public async Task<ActionResult<RunRecordCover>> GetByKey(int key)
        {
            var data = await runRecordService.GetBy(currentUserService.Id, key);
            if (data == null)
            {
                return NotFound();
            }

            return runRecordCoverToWebApi.Map(data);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<RunRecordCover>> GetById(int id)
        {
            var data = await runRecordCoverRepository.GetById(id);
            if (data == null)
            {
                return NotFound();
            }

            return runRecordCoverToWebApi.Map(data);
        }


        [HttpPost("Share")]
        public async Task<ActionResult<int>> AddOrReplace(RunRecordCover runRecordCover)
        {
            var data = runRecordCoverToData.Map(runRecordCover);

            data = await runRecordService.AddOrReplceRunCover(data, currentUserService.Id, runRecordCover.Key);

            return Ok(data.Id); 
        }
    }
}
