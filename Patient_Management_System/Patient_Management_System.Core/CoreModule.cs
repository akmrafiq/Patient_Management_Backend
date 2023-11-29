using Autofac;
using Patient_Management_System.Core.Contexts;
using Patient_Management_System.Core.Repositories.DoctorRepo;
using Patient_Management_System.Core.Repositories.PatientRepo;
using Patient_Management_System.Core.Services;
using Patient_Management_System.Core.UnitOfWork;

namespace Patient_Management_System.Core;

public class CoreModule : Module
{
    private readonly string _connectionString;
    private readonly string _migrationAssemblyName;

    public CoreModule( string connectionStringName, string migrationAssemblyName)
    {
        _connectionString = connectionStringName;
        _migrationAssemblyName = migrationAssemblyName;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<PatientDbContext>()
            .WithParameter("connectionString", _connectionString)
            .WithParameter("migrationAssemblyName", _migrationAssemblyName)
            .InstancePerLifetimeScope();

        builder.RegisterType<PatientDbContext>().As<PatientDbContext>()
            .WithParameter("connectionString", _connectionString)
            .WithParameter("migrationAssemblyName", _migrationAssemblyName)
            .InstancePerLifetimeScope();

        builder.RegisterType<PatientUnitOfWork>().As<IPatientUnitOfWork>()
            .WithParameter("connectionString", _connectionString)
            .WithParameter("migrationAssemblyName", _migrationAssemblyName)
            .InstancePerLifetimeScope();

        builder.RegisterType<PatientRepository>().As<IPatientRepository>()
            .InstancePerLifetimeScope();

        builder.RegisterType<PatientService>().As<IPatientService>()
            .InstancePerLifetimeScope();

        builder.RegisterType<DoctorRepository>().As<IDoctorRepository>()
            .InstancePerLifetimeScope();

        base.Load(builder);
    }
}