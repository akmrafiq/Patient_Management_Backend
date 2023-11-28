using Patient_Management_System.Core.Contexts;
using Patient_Management_System.Core.Entities;
using Patient_Management_System.Data.Repositories;

namespace Patient_Management_System.Core.Repositories.PatientRepo;

public class PatientRepository : Repository<Patient, int, PatientDbContext>, IPatientRepository
{
    private PatientDbContext _patientDbContext;
    public PatientRepository(PatientDbContext patientDbContext) : base(patientDbContext)
    {
        _patientDbContext = patientDbContext;
    }
}