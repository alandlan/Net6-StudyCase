using Library.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    [HttpPost]
    public IActionResult CadastrarUsuario(CreateUsuarioDto usuario)
    {
        throw new NotImplementedException();
    }
}