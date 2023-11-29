using Patient_Management_System.Core.Entities;
using Patient_Management_System.Core.Repositories.PatientRepo;

namespace Patient_Management_System.Core.Services;

public class PatientService: IPatientService
{
    private readonly IPatientRepository _repository;

    public PatientService(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<IList<Patient>> Get()
    {
        return await _repository.GetAllAsync();
    }
}