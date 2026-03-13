using BookApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors();

app.MapBookEndpoints();

app.Run();