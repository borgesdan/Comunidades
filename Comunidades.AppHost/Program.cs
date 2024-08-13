var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Comunidades_ApiService>("apiservice");

builder.AddProject<Projects.Comunidades_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
