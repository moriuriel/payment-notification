using PaymentNotification.Worker;
using PaymentNotification.Worker.Adapters;
using PaymentProcessor.Worker.Application;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddAdapters(builder.Configuration);
builder.Services.AddApplicationDependency();
builder.Services.AddFactories();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
