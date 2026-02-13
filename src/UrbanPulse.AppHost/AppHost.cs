IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<PostgresServerResource> postgreServer = builder.AddPostgres("postgre-server")
    .WithPgAdmin();

IResourceBuilder<PostgresDatabaseResource> urbanPulseDb = postgreServer.AddDatabase("urbanpulse-db");

builder.AddProject<Projects.UrbanPulse_Api>("urbanpulse-api")
    .WithReference(urbanPulseDb)
    .WaitFor(urbanPulseDb);

builder.Build().Run();
