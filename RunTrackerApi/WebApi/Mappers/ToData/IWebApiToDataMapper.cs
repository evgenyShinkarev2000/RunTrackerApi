using RunTrackerApi.Data.Models;
using RunTrackerApi.Interfaces;
using RunTrackerApi.WebApi.Models;

namespace RunTrackerApi.WebApi.Mappers.ToData
{
    public interface IWebApiToDataMapper<TIn, TOut> : IMapper<TIn, TOut> where TIn : IWebApiModel where TOut : IEntity;
}
