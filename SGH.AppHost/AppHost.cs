var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.SGH_Server>("sgh-server");

builder.Build().Run();
