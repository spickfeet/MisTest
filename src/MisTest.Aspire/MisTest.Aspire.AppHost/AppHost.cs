var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithDataVolume("mistestdb-postgres-data");

var mistestDb = postgres.AddDatabase("mistestdb");

builder.AddProject<Projects.MisTest_Host_Api>("api")
    .WithReference(mistestDb)
    .WaitFor(postgres);

builder.Build().Run();
