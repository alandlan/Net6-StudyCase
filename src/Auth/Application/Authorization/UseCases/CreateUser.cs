using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Net6StudyCase.Auth.Domain;
using Net6StudyCase.Auth.Domain.UseCases;
using SharedKernel.Responses;
using SharedKernel.ViewModel;

namespace Net6StudyCase.Auth.Application.Authorization.UseCases
{
    public class CreateUser : ICreateUser
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;

        private readonly BaseResponseWithValue<CreateUserViewModel> _response;

        public CreateUser(IMapper mapper, UserManager<Usuario> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _response = new BaseResponseWithValue<CreateUserViewModel>();
        }
        public async Task<BaseResponse> Cadastrar(CreateUserViewModel dto)
        {
            try
            {
                Usuario usuario = _mapper.Map<Usuario>(dto);

                var result = await _userManager.CreateAsync(usuario, dto.Password);

                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description).ToArray();
                    return _response.AsError(dto, ResponseMessage.CreateUserError,errors);
                }

                if(result.Succeeded && dto.IsAdmin)
                    await _userManager.AddClaimAsync(usuario, new Claim("UserType","Admin"));

                return _response.AsSuccess(dto);
            }
            catch (Exception)
            {
                throw new ApplicationException("Falha ao cadastrar usuário!");
            }
        }
    }
}
