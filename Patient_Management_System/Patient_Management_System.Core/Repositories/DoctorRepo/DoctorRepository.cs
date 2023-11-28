using Patient_Management_System.Core.Contexts;
using Patient_Management_System.Core.Entities;
using Patient_Management_System.Data.Repositories;

namespace Patient_Management_System.Core.Repositories.DoctorRepo;

public class DoctorRepository : Repository<Doctor, int, PatientDbContext>, IDoctorRepository
{
    private PatientDbContext _patientDbContext;
    public DoctorRepository(PatientDbContext patientDbContext) : base(patientDbContext)
    {
        _patientDbContext= patientDbContext;
    }
}