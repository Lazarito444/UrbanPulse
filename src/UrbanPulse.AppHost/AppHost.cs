var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.UrbanPulse_Api>("urbanpulse-api");

builder.Build().Run();
