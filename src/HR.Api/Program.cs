using FluentValidation;
using FluentValidation.AspNetCore;
using HR.Api.Extensions;
using HR.Business.Assembly;
using HR.Data.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

string connection = builder.Configuration.GetConnectionString("PostgreConn");
builder.Services.AddDbContext<HrDbContext>(options => options.UseNpgsql(connection));

builder.Services.ConfigureSwagger();
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.ConfigureAuthorization();
builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));

//builder.Services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
//builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.AddAutoMapper(typeof(AssemblyReference).Assembly);

builder.Services.ConfigureCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
