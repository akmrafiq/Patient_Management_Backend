using System.ComponentModel.DataAnnotations;

namespace Patient_Management_System.Core.Entities;

public class Doctor:BaseEntity
{
    [Required(ErrorMessage = "Please Enter Customer Name")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Provide a Valid Email"), DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required(ErrorMessage = "Provide a valid Phone Number"), DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }
    [Required(ErrorMessage = "Provide a valid a Educational Status")]
    public string Degree { get; set; }
    [Required(ErrorMessage = "Provide a valid Age")]
    public int Age { get; set; }
}