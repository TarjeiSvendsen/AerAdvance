var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddGarnet("garnet")
    .WithDataVolume();


var s3 = builder.AddSeaweedFS("s3")
    .WithDataVolume()
    .WithS3();

var messaging = builder.AddKafka("messaging")
    .WithDataVolume();


var aircraftApiDb = builder.AddMongoDB("aircraftDb")
    .WithDataVolume();

var aircraftApiService = builder.AddProject<Projects.AerAdvance_Aircraft_API>("aircraft-api")
        .WaitFor(aircraftApiDb)
        .WithReference(aircraftApiDb);

var financeApiDb = builder.AddPostgres("financeDb")
    .WithDataVolume();

var financeApiService = builder.AddProject<Projects.AerAdvance_Finance_API>("finance-api")
    .WaitFor(financeApiDb)
    .WithReference(financeApiDb);


builder.Build().Run();