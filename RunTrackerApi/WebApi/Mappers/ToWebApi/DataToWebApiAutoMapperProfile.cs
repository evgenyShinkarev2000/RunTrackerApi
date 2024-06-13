using AutoMapper;
using RunTrackerApi.Data.Models;
using RunTrackerApi.WebApi.Models;
using System;

namespace RunTrackerApi.WebApi.Mappers.ToWebApi
{
    public class DataToWebApiAutoMapperProfile : Profile
    {
        public DataToWebApiAutoMapperProfile()
        {

            CreateMap<TimeSpan, int>().ConvertUsing<TimeSpanConverter>();
            CreateMap<DateTime, string>().ConvertUsing<DateTimeConverter>();

            CreateMap<Data.Models.RunRecordCover, Models.RunRecordCover>();
        }
    }
}
