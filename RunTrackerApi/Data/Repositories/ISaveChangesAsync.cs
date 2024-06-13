using System.Threading.Tasks;

namespace RunTrackerApi.Data.Repositories
{
    public interface ISaveChangesAsync
    {
        Task SaveChangesAsync();
    }
}
