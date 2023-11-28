using Microsoft.EntityFrameworkCore;

namespace Patient_Management_System.Data.UnitOfWork;

public interface IUnitOfWork<T>: IDisposable where T : DbContext
{
    void Save();
}