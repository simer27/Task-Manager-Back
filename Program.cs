using Microsoft.EntityFrameworkCore;
using Task_Manager_Back.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<Context>(options => options.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=postgres;User Id=postgres;Password=Si!131710"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(p => p
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
);

app.MapControllers();

app.Run();
