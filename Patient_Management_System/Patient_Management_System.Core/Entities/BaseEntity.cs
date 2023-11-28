using Patient_Management_System.Data;

namespace Patient_Management_System.Core.Entities;

public abstract class BaseEntity : IEntity<int>
{
    public int Id { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public int? LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
}