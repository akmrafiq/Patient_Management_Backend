using Patient_Management_System.Core.Contexts;
using Patient_Management_System.Core.Entities;
using Patient_Management_System.Data.Repositories;

namespace Patient_Management_System.Core.Repositories.DoctorRepo;

public interface IDoctorRepository : IRepository<Doctor, int, PatientDbContext>
{

}