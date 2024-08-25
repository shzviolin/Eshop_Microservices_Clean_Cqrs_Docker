using IDP.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IDP.Application.Commands.User
{
    public class InsertUserCommand : IRequest<bool>
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public required string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [MaxLength(200)]
        public required string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "کد ملی")]
        [MaxLength(10)]
        public required string NationalCode { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
    }
}
