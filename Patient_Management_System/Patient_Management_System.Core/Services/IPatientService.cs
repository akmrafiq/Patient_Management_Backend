using Patient_Management_System.Core.Entities;

namespace Patient_Management_System.Core.Services;

public interface IPatientService
{
    Task<IList<Patient>> Get();
}