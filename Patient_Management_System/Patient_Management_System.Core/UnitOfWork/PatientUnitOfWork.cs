using Patient_Management_System.Core.Contexts;
using Patient_Management_System.Core.Repositories.DoctorRepo;
using Patient_Management_System.Core.Repositories.PatientRepo;
using Patient_Management_System.Data.UnitOfWork;

namespace Patient_Management_System.Core.UnitOfWork;

public class PatientUnitOfWork: UnitOfWork<PatientDbContext>, IPatientUnitOfWork
{
    private IDoctorRepository DoctorRepository { get; set; }
    private IPatientRepository PatientRepository { get; set; }
    public PatientUnitOfWork(string connectionString, string migrationAssemblyName,
        IDoctorRepository doctorRepository,
        IPatientRepository patientRepository
        ) : base(connectionString, migrationAssemblyName)
    {
        DoctorRepository= doctorRepository;
        PatientRepository= patientRepository;
    }
}