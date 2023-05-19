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
    

    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDto usuarioDto)
    {
        await _service.Cadastrar(usuarioDto);

        return Ok("Usuário cadastrado");
    }

    [HttpPost("login")]

    public async Task<IActionResult> Login(LoginUsuarioDto dto)
    {
        var login = await _service.Login(dto);

        if(login == null || !login.Succeeded)
            return Unauthorized("Usuario ou senha inválida!");

        var token = _service.GenerateToken(dto);
        
        return Ok(token);
    }
}