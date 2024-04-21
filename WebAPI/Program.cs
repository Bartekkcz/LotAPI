using Application.Dto;
using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Application.Validators;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation.AspNetCore;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(configuration =>
    {
        configuration.RegisterValidatorsFromAssemblyContaining<RegisterUserDtoValidator>(); 
    });
builder.Services.AddDbContext<PlanesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PlanesCS")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});

builder.Services.AddScoped<IPlaneRepository, PlaneRepository>();
builder.Services.AddScoped<IPlaneService, PlaneService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
//builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();

builder.Services.AddSingleton(AutoMapperConfig.Initialize());

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
