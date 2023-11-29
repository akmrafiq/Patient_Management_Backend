using Microsoft.EntityFrameworkCore;
using Patient_Management_System.Core.Entities;

namespace Patient_Management_System.Core.Contexts;

public  class PatientDbContext: DbContext, IPatientDbContext
{
    private string _connectionString;
    private string _migrationAssemblyName;

    public PatientDbContext(string connectionString, string migrationAssemblyName)
    {
        _connectionString = connectionString;
        _migrationAssemblyName = migrationAssemblyName;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
        if (!dbContextOptionsBuilder.IsConfigured)
        {
            dbContextOptionsBuilder.UseSqlServer(_connectionString, m => m.MigrationsAssembly(_migrationAssemblyName));
        }

        base.OnConfiguring(dbContextOptionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
}