namespace Hangfire.API.Jobs
{
    public class JobRecurringJob
    {
        public async Task MeuPrimeiroJobRecurringJob()
        {
            await Task.Delay(69000);
            await Task.Run(() => Console.WriteLine("Meu primeiro Job Agendado" + DateTime.Now.ToString()));
        }
    }
}
