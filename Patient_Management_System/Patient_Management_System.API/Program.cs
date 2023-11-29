using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
