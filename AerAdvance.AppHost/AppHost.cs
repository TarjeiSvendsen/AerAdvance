var builder = DistributedApplication.CreateBuilder(args);

var rabbitmq = builder.AddRabbitMQ("messaging");

var keycloak = builder.AddKeycloak("keycloak", 8069);

var redisCache = builder.AddRedis("cache");

var mongo = builder.AddMongoDB("mongo")
    .WithLifetime(ContainerLifetime.Persistent);
var mongodb = mongo.AddDatabase("mongodb");

var aircraftApiService = builder.AddProject<Projects.Aircraft_API>("aircraft-api")
    .WithReference(redisCache)
    .WaitFor(redisCache)
    .WithReference(mongodb)
    .WaitFor(mongodb)
    .WithReference(rabbitmq);

builder.AddProject<Projects.Frontend>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(keycloak)
    .WaitFor(keycloak)
    .WithReference(aircraftApiService)
    .WaitFor(aircraftApiService);

builder.Build().Run();