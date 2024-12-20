using System.Text.Json;
using BackendExamHub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet(
        "/my-office-acpd",
        ([FromServices] AppDbContext db) =>
        {
            return db.MyOfficeAcpds.AsNoTracking();
        }
    )
    .WithName("GetMyOfficeAcpd")
    .WithOpenApi();

app.MapPost(
        "/my-office-acpd",
        ([FromServices] AppDbContext db, [FromBody] MyOfficeAcpd acpd, ILogger<Program> logger) =>
        {
            var data = JsonSerializer.Serialize(acpd);
            _ = db
                .MyOfficeAcpds.FromSql($"execute dbo.My_Office_Acpd_Create @JsonData = '{data}'")
                .AsEnumerable();
        }
    )
    .WithName("CreateMyOfficeAcpd")
    .WithOpenApi();

app.Run();
