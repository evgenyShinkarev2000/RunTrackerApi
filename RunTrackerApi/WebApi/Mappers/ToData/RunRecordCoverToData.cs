using AutoMapper;
using RunTrackerApi.WebApi.Models;

namespace RunTrackerApi.WebApi.Mappers.ToData
{
    public interface IRunRecordCoverToData : IWebApiToDataMapper<RunRecordCover, Data.Models.RunRecordCover>;

    public class RunRecordCoverToData : IRunRecordCoverToData
    {
        private readonly IMapper mapper;

        public RunRecordCoverToData(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Data.Models.RunRecordCover Map(RunRecordCover model) => mapper.Map<Data.Models.RunRecordCover>(model);
    }


}
