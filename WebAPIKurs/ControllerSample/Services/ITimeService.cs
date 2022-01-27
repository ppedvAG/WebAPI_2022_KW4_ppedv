namespace ControllerSample.Services
{
    public interface ITimeService
    {
        Task<string> GetCurrentTime();
    }
}
