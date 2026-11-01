var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var aircraftApiService = builder.AddProject<Projects.AerAdvance_Aircraft_API>("aircraft-api");

var financeApiService = builder.AddProject<Projects.AerAdvance_Finance_API>("finance-api");


builder.Build().Run();