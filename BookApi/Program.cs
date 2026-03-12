using BookApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapBookEndpoints();

app.Run();