using Net6StudyCase.SharedKernel.Enum;
using System.ComponentModel.DataAnnotations;

namespace SharedKernel.ViewModel
{
    public class CreateUserViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
        [Required]
        public UserTypeEnum UserType { get; set; }
    }
}
