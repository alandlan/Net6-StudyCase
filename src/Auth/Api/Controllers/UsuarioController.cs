using Microsoft.AspNetCore.Mvc;
using Net6StudyCase.Auth.Domain.UseCases;
using Net6StudyCase.SharedKernel.ViewModel;
using SharedKernel.ViewModel;

namespace ApiAuth.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    public ICreateUser _createUser {get;set;}
    public ILogin _login { get;set;}
    public IGenerateToken _generateToken { get;set;}
    public UsuarioController(ICreateUser createUser, ILogin login, IGenerateToken generateToken)
    {
        _createUser = createUser;
        _login = login;
        _generateToken = generateToken;
    }


    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastrarUsuario(CreateUserViewModel usuarioDto)
    {
        await _createUser.Cadastrar(usuarioDto);

        return Ok("Usuário cadastrado");
    }

    [HttpPost("login")]

    public async Task<IActionResult> Login(LoginUserViewModel dto)
    {
        var login = await _login.Login(dto);

        if(login == null || !login.Succeeded)
            return Unauthorized("Usuario ou senha inválida!");

        var token = _generateToken.RunAsync(dto);
        
        return Ok(token);
    }
}