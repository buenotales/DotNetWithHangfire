using Hangfire;
using Hangfire.API.Jobs;
using Hangfire.MemoryStorage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHangfire(op =>
{
    op.UseMemoryStorage();
});

var changeOrderStatusYamiServerOptions = new BackgroundJobServerOptions
{
    WorkerCount = 1,
    ServerName = "changeOrderStatusYamiServer",
    Queues = new[] { "change-order-status-yami-queue" }
};

var sendOrderYamiServerOptions = new BackgroundJobServerOptions
{
    WorkerCount = 1,
    ServerName = "sendOrderYamiServer",
    Queues = new[] { "send-order-yami-queue" }
};

builder.Services.AddHangfireServer(op => new BackgroundJobServer(changeOrderStatusYamiServerOptions));
builder.Services.AddHangfireServer(op => new BackgroundJobServer(sendOrderYamiServerOptions));

var app = builder.Build();
app.UseHangfireDashboard();

RecurringJob.AddOrUpdate("send-order-yami", () => new JobRecurringJob().MeuPrimeiroJobRecurringJob(), Cron.Minutely, queue: "send-order-yami-queue");
RecurringJob.AddOrUpdate("change-order-status-yami", () => new JobRecurringJob().MeuPrimeiroJobRecurringJob(), Cron.Minutely, queue: "change-order-status-yami-queue");



//BackgroundJob.Schedule(() => new JobSchedulerJob().MeuPrimeiroJob(), TimeSpan.FromSeconds(5));
//BackgroundJob.Enqueue(() => new JobFireAndForget().MeuPrimeiroJob());
//string jobId = BackgroundJob.Enqueue(() => Console.WriteLine("Tarefa Pai"));
//BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine("Tarefa Filha"));

app.Run();
