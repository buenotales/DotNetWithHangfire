namespace Hangfire.API.Jobs
{
    public class JobFireAndForget
    {
        public async Task MeuPrimeiroJob()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Meu primeiro Job");
            });
        }
    }
}
