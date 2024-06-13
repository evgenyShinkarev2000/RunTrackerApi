using AutoMapper;
using System;
using System.Globalization;

namespace RunTrackerApi.WebApi.Mappers
{
    public class DateTimeConverter : ITypeConverter<DateTime, string>, ITypeConverter<string, DateTime>
    {
        DateTime ITypeConverter<string, DateTime>.Convert(string source, DateTime destination, ResolutionContext context)
        {
            return DateTime.Parse(source.AsSpan(), CultureInfo.InvariantCulture).ToUniversalTime();
            
        }

        string ITypeConverter<DateTime, string>.Convert(DateTime source, string destination, ResolutionContext context)
        {
            return source.ToString("u", CultureInfo.InvariantCulture);
        }
    }
}
