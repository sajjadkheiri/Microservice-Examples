using DomainEvent.ApplicationService;
using DomainEvent.ApplicationService.Person;
using DomainEvent.Dal;
using DomainEvent.Framework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<DomainEventDbContext>(x =>
    x.UseSqlServer("Server=.;Initial catalog=DomainEventDb;User=sa;Password=S@jj@d0910;TrustServerCertificate=True"));

builder.Services.AddScoped<PersonService>();
builder.Services.AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();

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