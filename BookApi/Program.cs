using BookApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapBookEndpoints();

app.Run();