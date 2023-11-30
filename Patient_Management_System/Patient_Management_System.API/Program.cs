using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Patient_Management_System.API.Data;
using Patient_Management_System.Core;
using Patient_Management_System.Core.Contexts;
using Patient_Management_System.Core.Entities;
using Patient_Management_System.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionStringName = "DefaultConnection";
var connectionString = builder.Configuration.GetConnectionString(connectionStringName);
var migrationAssemblyName = typeof(Program).Assembly.FullName;

//Autofac Configuration
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new DataModule()));
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new CoreModule(connectionString, migrationAssemblyName!)));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationAssemblyName)));
builder.Services.AddDbContext<PatientDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationAssemblyName)));

builder.Services.AddSingleton<UserManager<ExtendedIdentityUser>>();
builder.Services.AddSingleton<SignInManager<ExtendedIdentityUser>>();

builder.Services.AddIdentity<ExtendedIdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Patient Management System", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            }, new List<string>()
        }
    });
});


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        b =>
        {
            var whiteOrigin = builder.Configuration.GetSection("WhiteOrigin").Get<string[]>();
            b
                .WithOrigins(whiteOrigin)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();
