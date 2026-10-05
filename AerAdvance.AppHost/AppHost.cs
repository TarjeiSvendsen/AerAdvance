var builder = DistributedApplication.CreateBuilder(args);

var rabbitmq = builder.AddRabbitMQ("messaging");

var aircraftApiService = builder.AddProject<Projects.Aircraft_API>("aircraft-api")
    .WithHttpHealthCheck("/health")
    .WithReference(rabbitmq);

// builder.AddProject<Projects.AerAdvance_Web>("webfrontend")
//    .WithExternalHttpEndpoints()
//    .WithHttpHealthCheck("/health")
//    .WithReference(aircraftApiService)
//    .WaitFor(aircraftApiService);

builder.Build().Run();