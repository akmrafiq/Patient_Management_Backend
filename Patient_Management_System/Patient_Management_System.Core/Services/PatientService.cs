using Patient_Management_System.Core.Entities;
using Patient_Management_System.Core.Repositories.PatientRepo;
using Patient_Management_System.Core.UnitOfWork;

namespace Patient_Management_System.Core.Services;

public class PatientService: IPatientService
{
    private readonly IPatientUnitOfWork _patientUnitOfWork;

    public PatientService(IPatientUnitOfWork patientUnitOfWork)
    {
        _patientUnitOfWork = patientUnitOfWork;
    }

    public async Task<bool> Create(Patient patient)
    {
        await _patientUnitOfWork.PatientRepository.AddAsync(patient);
        _patientUnitOfWork.Save();
        return true;
    }

    public async Task<IList<Patient>> Get()
    {
        return await _patientUnitOfWork.PatientRepository.GetAllAsync();
    }
}