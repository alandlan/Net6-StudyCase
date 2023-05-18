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

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager,SignInManager<Usuario> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
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

        public async Task Login(LoginUsuarioDto dto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password,false,false);

            if(!resultado.Succeeded){
                throw new ApplicationException("Usuário não autenticado!");
            }
        }
    }
}