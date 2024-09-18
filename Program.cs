using Cine_API.Data;
using Cine_API.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("MovieTheater");
builder.Services.AddSqlite<MovieTheaterContext>(connString);

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapMoviesEndpoint();

app.MapDirectorsEndpoint();
app.MapShowsEndpoint();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
await app.MigrateDbAsync();
app.Run();

