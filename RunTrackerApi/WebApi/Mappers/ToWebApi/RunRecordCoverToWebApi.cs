using AutoMapper;
using RunTrackerApi.WebApi.Models;

namespace RunTrackerApi.WebApi.Mappers.ToWebApi
{
    public interface IRunRecordCoverToWebApi : IDataToWebApiMapper<Data.Models.RunRecordCover, RunRecordCover>;

    public class RunRecordCoverToWebApi : IRunRecordCoverToWebApi
    {
        private readonly IMapper mapper;

        public RunRecordCoverToWebApi(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public RunRecordCover Map(Data.Models.RunRecordCover model) => mapper.Map<RunRecordCover>(model);
    }
}
