using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.ML;
using MyFunctionApp;


var builder = FunctionsApplication.CreateBuilder(args);

// 1. Configure the Web Application (Isolated Worker)
builder.ConfigureFunctionsWebApplication();

// 2. Add Telemetry (The "Maintenance" part of your job)
builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

// 3. Dependency Injection for Scalability
builder.Services.AddHttpClient(); // Reuse connections for external API calls
builder.Services.AddPredictionEnginePool<SentimentModel.ModelInput, SentimentModel.ModelOutput>()
    .FromFile("SentimentModel.mlnet");

var host = builder.Build();
host.Run();


