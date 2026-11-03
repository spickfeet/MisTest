using MisTest.Host.Api;
using MisTest.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var startup = new Startup(builder.Configuration, builder.Environment);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
await startup.ConfigureAsync(app);

app.Run();
