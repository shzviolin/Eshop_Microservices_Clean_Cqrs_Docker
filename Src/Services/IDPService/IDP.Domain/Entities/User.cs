using System.ComponentModel.DataAnnotations;

namespace IDP.Domain.Entities;

public class User : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string NationalCode { get; set; }
    public DateTime? BirthDate { get; set; }
    public Gender Gender { get; set; }

}

public enum Gender : byte
{
    [Display(Name = "مرد")]
    Male,
    [Display(Name = "زن")]
    Female,
    [Display(Name = "سایر")]
    Other,
}
