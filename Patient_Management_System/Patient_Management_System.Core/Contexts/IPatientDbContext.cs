using Microsoft.EntityFrameworkCore;
using Patient_Management_System.Core.Entities;

namespace Patient_Management_System.Core.Contexts;

public interface IPatientDbContext
{
    DbSet<Patient> Patients { get; set; }
    DbSet<Doctor> Doctors { get; set; }
}