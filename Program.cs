using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PlaceAPI.Data;
using PlaceAPI.Middlewares;
using PlaceAPI.Repository;
using PlaceAPI.Services;
using AutoMapper;
using PlaceAPI.Helper.Mapping;
using PlaceAPI.Helper.Mapping.Interfaces;
using FluentValidation;
using PlaceAPI.Helper.Validations;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<PatchMappingProfile>();
});

builder.Services.AddSingleton<IPatchMapper>(sp =>
{
    var patchConfig = new MapperConfiguration(cfg => cfg.AddProfile<PatchMappingProfile>());
    var mapper = patchConfig.CreateMapper();
    return new PatchMapper(mapper);
});

builder.Services.AddValidatorsFromAssemblyContaining<PlacesUpdateValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<PlacesAddValidator>();



builder.Services.AddTransient<ServiceManager>();
builder.Services.AddTransient<PlacesServices>();
builder.Services.AddScoped<PlacesRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

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
