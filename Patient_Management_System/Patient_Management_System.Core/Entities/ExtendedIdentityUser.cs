using Microsoft.AspNetCore.Identity;

namespace Patient_Management_System.Core.Entities;

public class ExtendedIdentityUser : IdentityUser
{
    public string Name { get; set; }
}