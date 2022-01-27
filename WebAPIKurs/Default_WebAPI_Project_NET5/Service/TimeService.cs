using System;

namespace Default_WebAPI_Project_NET5.Services
{
    public class TimeService : ITimeService
    {
        public string GetCurrentTime()
        {
            return DateTime.Now.ToString();
        }
    }
}
