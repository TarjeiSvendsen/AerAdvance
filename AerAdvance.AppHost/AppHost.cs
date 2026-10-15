var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var aircraftApiService = builder.AddProject<Projects.AerAdvance_Aircraft_API>("aircraft-api")
    .WithHttpHealthCheck("/health");
var financeApiService = builder.AddProject<Projects.AerAdvance_Finance_API>("finance-api")
    .WithHttpHealthCheck("/health");


builder.AddProject<Projects.AerAdvance_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(aircraftApiService)
    .WaitFor(aircraftApiService)
    .WithReference(financeApiService)
    .WaitFor(financeApiService);

builder.Build().Run();