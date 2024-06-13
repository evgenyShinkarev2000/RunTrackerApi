namespace RunTrackerApi.Interfaces
{
    public interface IMapper<TIn, TOut>
    {
        TOut Map(TIn model);
    }
}
