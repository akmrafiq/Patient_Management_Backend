using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Patient_Management_System.Core.Entities;

namespace Patient_Management_System.API.Data;

public class ApplicationDbContext : IdentityDbContext<ExtendedIdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }
}