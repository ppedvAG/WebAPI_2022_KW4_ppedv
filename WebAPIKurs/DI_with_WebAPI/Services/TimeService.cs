namespace DI_with_WebAPI.Services
{
    public class TimeService : ITimeService
    {
        public string GetCurrentTime()
        {
            return DateTime.Now.ToString();
        }
    }
}
