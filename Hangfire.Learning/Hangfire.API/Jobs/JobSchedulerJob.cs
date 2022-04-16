namespace Hangfire.API.Jobs
{
    public class JobSchedulerJob
    {
        public async Task MeuPrimeiroJob()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Meu primeiro Job Scheduler");
            });
        }
    }
}
