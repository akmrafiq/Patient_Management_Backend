using Autofac;
using Autofac.Extensions.DependencyInjection;
using Patient_Management_System.Core;
using Patient_Management_System.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionStringName = "DefaultConnection";
var connectionString = builder.Configuration.GetConnectionString(connectionStringName);
var migrationAssemblyName = typeof(Program).Assembly.FullName;
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new DataModule()));
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new CoreModule(connectionStringName, migrationAssemblyName!)));

// Add services to the container.

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
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
