using AutoMapper;
using RunTrackerApi.Data.Models;
using RunTrackerApi.WebApi.Models;
using System;
using System.Diagnostics;

namespace RunTrackerApi.WebApi.Mappers.ToData
{
    public class WebApiToDataAutoMapperProfile : Profile
    {
        public WebApiToDataAutoMapperProfile()
        {
            CreateMap<int, TimeSpan>().ConvertUsing<TimeSpanConverter>();
            CreateMap<string, DateTime>().ConvertUsing<DateTimeConverter>();

            CreateMap<Models.RunRecordCover, Data.Models.RunRecordCover>();
        }
    }
}
