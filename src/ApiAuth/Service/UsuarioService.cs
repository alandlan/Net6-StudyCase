using AutoMapper;
using Library.Dtos;
using Library.Models;
using Microsoft.AspNetCore.Identity;

namespace ApiAuth.Service
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager,SignInManager<Usuario> signInManager,TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task Cadastrar(CreateUsuarioDto dto)
        {
            try{
                Usuario usuario = _mapper.Map<Usuario>(dto);

                await _userManager.CreateAsync(usuario,dto.Password);

        
            }catch(Exception){
                throw new ApplicationException("Falha ao cadastrar usuário!");
            }
        }

        public async Task<SignInResult> Login(LoginUsuarioDto dto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password,false,false);

            return resultado;            
        }

        public string GenerateToken(LoginUsuarioDto dto)
        {
            var usuario = _signInManager.UserManager.Users.FirstOrDefault(user => user.UserName == dto.Username.ToUpper());

            if(usuario == null)
                throw new Exception("Usuário não localizado!");

            var token = _tokenService.GenerateToken(usuario);

            return token;
        }
    }
}