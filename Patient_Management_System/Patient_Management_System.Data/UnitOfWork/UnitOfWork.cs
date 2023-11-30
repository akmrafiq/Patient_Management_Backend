using Microsoft.EntityFrameworkCore;

namespace Patient_Management_System.Data.UnitOfWork;

public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext
{
    private readonly T _dbContext;

    public UnitOfWork(string connectionString, string migrationAssemblyName)
        => _dbContext = (T)Activator.CreateInstance(typeof(T), connectionString, migrationAssemblyName);

    public void Save() => _dbContext.SaveChanges();

    public void Dispose() => _dbContext.Dispose();
}