using Microsoft.AspNetCore.Identity;

namespace Library.Models;


public class Usuario : IdentityUser
{
    public DateTime DataNascimento { get; set; }
    public Usuario() : base (){ }
}
    
