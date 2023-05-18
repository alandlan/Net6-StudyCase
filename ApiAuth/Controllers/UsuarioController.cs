using ApiAuth.Service;
using Library.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    public UsuarioService _service {get;set;}
    public UsuarioController(UsuarioService service)
    {
        _service = service;
    }
    

    [HttpPost]
    public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDto usuarioDto)
    {
        await _service.Cadastrar(usuarioDto);

        return Ok("Usuário cadastrado");
    }
}