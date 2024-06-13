using Microsoft.AspNetCore.Http;
using System.Data;
using System.Linq;

namespace RunTrackerApi.Services
{
    public interface ICurrentUserService
    {
        int Id { get; }
    }

    public class CurrentUserService : ICurrentUserService
    {
        public int Id { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {

            var claims = httpContextAccessor.HttpContext!.User.Claims;

            int.TryParse(claims.FirstOrDefault(c => c.Type == "Id")?.Value, out var Id);
            this.Id = Id;
        }
    }
}
