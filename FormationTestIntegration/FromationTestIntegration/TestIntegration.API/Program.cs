using TestIntegration.Data.Abstractions;
using TestIntegration.Data.Implementations;
using TestIntegration.Service.Abstractions;
using TestIntegration.Service.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Injection Dépendance
builder.Services.AddTransient<IPersonneRepository, PersonneRepository>();
builder.Services.AddTransient<IPersonneIdentityFormater, PersonneIdentityFormater>();
builder.Services.AddTransient<ITextOutput, TextOutput>();
builder.Services.AddTransient<IPeopleService, PeopleService>();


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
