using Patient_Management_System.Core.Contexts;
using Patient_Management_System.Core.Repositories.DoctorRepo;
using Patient_Management_System.Core.Repositories.PatientRepo;
using Patient_Management_System.Data.UnitOfWork;

namespace Patient_Management_System.Core.UnitOfWork;

public interface IPatientUnitOfWork:IUnitOfWork<PatientDbContext>
{
    public IDoctorRepository DoctorRepository { get; set; }
    public IPatientRepository PatientRepository { get; set; }
}