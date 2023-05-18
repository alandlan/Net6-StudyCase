using ApiAuth.Service;
using AutoMapper;
using Library.Dtos;
using Library.Models;
using Microsoft.AspNetCore.Identity;
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