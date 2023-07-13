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
        private IIdentityManager _identityManager;

        public CreateUser(IMapper mapper,IIdentityManager identityManager)
        {
            _mapper = mapper;
            _identityManager = identityManager;
        }
        public async Task Cadastrar(CreateUserViewModel dto)
        {
            try
            {
                Usuario usuario = _mapper.Map<Usuario>(dto);

                await _identityManager.Cadastrar(usuario,dto.Password,dto.UserType);


            }
            catch (Exception)
            {
                throw new ApplicationException("Falha ao cadastrar usuário!");
            }
        }
    }
}
