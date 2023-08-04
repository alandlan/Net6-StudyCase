using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Net6StudyCase.Auth.Domain;
using Net6StudyCase.Auth.Domain.UseCases;
using SharedKernel.ViewModel;

namespace Net6StudyCase.Auth.Application.Authorization.UseCases
{
    public class CreateUser : ICreateUser
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;

        public CreateUser(IMapper mapper, UserManager<Usuario> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task Cadastrar(CreateUserViewModel dto)
        {
            try
            {
                Usuario usuario = _mapper.Map<Usuario>(dto);

                var result = await _userManager.CreateAsync(usuario, dto.Password);

                if(result.Succeeded && dto.IsAdmin)
                    await _userManager.AddClaimAsync(usuario, new Claim("UserType","Admin"));
            }
            catch (Exception)
            {
                throw new ApplicationException("Falha ao cadastrar usuário!");
            }
        }
    }
}
