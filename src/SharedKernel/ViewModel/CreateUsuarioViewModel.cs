using System.ComponentModel.DataAnnotations;

namespace SharedKernel.ViewModel
{
    public class CreateUsuarioViewModel
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [Compare("Password")]
        public string? RePassword { get; set; }
    }
}
