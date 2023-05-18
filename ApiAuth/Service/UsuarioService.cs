using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
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
    }
}