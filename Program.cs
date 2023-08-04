using CZTrails.Data;
using CZTrails.Mappings;
using CZTrails.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CZTrailsDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CZTrailsConnectionString")));

builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>(); //zde menim pouzivane repo (SQLRegion, InMemory,..)
builder.Services.AddScoped<ITrailRepository, SQLTrailRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles)); //injects automapper, scans for profiles in the given file

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
