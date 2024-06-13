using AutoMapper;
using AutoMapper.Execution;
using System;

namespace RunTrackerApi.WebApi.Mappers
{
    public class TimeSpanConverter : ITypeConverter<TimeSpan, int>, ITypeConverter<int, TimeSpan>
    {
        public TimeSpanConverter()
        {
        }

        TimeSpan ITypeConverter<int, TimeSpan>.Convert(int source, TimeSpan destination, ResolutionContext context)
        {
            return TimeSpan.FromMicroseconds(source);
        }

        int ITypeConverter<TimeSpan, int>.Convert(TimeSpan source, int destination, ResolutionContext context)
        {
            return (int)Math.Round(source.TotalMicroseconds);
        }
    }
}
