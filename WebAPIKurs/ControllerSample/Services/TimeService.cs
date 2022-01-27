namespace ControllerSample.Services
{
    public class TimeService : ITimeService
    {
        public async Task<string> GetCurrentTime()
        {
            //Methode 
            await Task.Run(PseudoMethode);

            return DateTime.Now.ToString();
        }

        private void PseudoMethode()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(" Method 1");
                // Do something
                Task.Delay(100).Wait();
            }
        }
    }
}
