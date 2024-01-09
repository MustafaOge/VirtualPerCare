using ETicaretAPI.Infrastructure.Filters;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VirtualPetCare.Core;
using VirtualPetCare.Core.DTOs.User;
using VirtualPetCare.Core.Validations.User;
using VirtualPetCare.Repository.Context;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<UserCreateValidation>());


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IValidator<UserCreateDto>, UserCreateValidation>();

builder.Services.AddDbContext<PetCareDbContext>(options =>
                                                options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); 

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
