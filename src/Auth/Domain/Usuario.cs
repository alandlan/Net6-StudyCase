using Microsoft.AspNetCore.Identity;

namespace Net6StudyCase.Auth.Domain
{
    public class Usuario : IdentityUser
    {
        public DateTime DataNascimento { get; set; }
        public Usuario() : base() { }
    }
}