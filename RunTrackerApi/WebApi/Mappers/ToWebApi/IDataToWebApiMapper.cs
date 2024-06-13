using RunTrackerApi.Data.Models;
using RunTrackerApi.Interfaces;
using RunTrackerApi.WebApi.Models;
using System.Reflection.Metadata.Ecma335;

namespace RunTrackerApi.WebApi.Mappers.ToWebApi
{
    public interface IDataToWebApiMapper<TIn, TOut> : IMapper<TIn, TOut> where TIn : IEntity where TOut : IWebApiModel;
}
