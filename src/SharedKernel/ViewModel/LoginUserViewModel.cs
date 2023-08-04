using System.ComponentModel.DataAnnotations;

namespace Net6StudyCase.SharedKernel.ViewModel
{
    public class LoginUserViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
