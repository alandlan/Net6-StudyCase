using Microsoft.AspNetCore.Authorization;
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
    public IGetUsers _getUsers {get;set;}
    public ILogin _login { get;set;}
    public IGenerateToken _generateToken { get;set;}
    public UsuarioController(ICreateUser createUser, ILogin login, IGenerateToken generateToken, IGetUsers getUsers)
    {
        _createUser = createUser;
        _login = login;
        _generateToken = generateToken;
        _getUsers = getUsers;
    }


    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastrarUsuario(CreateUserViewModel usuarioDto)
    {
        await _createUser.Cadastrar(usuarioDto);

        return Ok("Usuário cadastrado");
    }

    [AllowAnonymous]
    [HttpPost("login")]

    public async Task<IActionResult> Login(LoginUserViewModel dto)
    {
        var login = await _login.Login(dto);

        if(login == null || !login.Succeeded)
            return Unauthorized("Usuario ou senha inválida!");

        var token = _generateToken.RunAsync(dto);
        
        return Ok(token);
    }

    
    [HttpGet("")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _getUsers.RunAsync();

        return Ok(users);
    }
}