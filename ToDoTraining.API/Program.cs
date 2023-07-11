using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ToDoTraining.Application.Features;
using ToDoTraining.Domain.Entities;
using ToDoTraining.Domain.Interface;
using ToDoTraining.Infrastructure.RavenDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IRepository<ToDo>, TodoRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(CreateToDoCommandHandler).Assembly));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(GetAllToDoCommandHandler).Assembly));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(GetToDoByIdQueryHandler).Assembly));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(DeleteToDoCommandHandler).Assembly));
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

app.MapControllers();

app.Run();
