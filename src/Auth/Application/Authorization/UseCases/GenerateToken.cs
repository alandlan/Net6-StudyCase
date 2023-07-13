using Microsoft.AspNetCore.Identity;
using Net6StudyCase.Auth.Domain;
using Net6StudyCase.Auth.Domain.UseCases;
using Net6StudyCase.Auth.Infra.Identity;
using Net6StudyCase.SharedKernel.ViewModel;
using SharedKernel.Responses;

namespace Net6StudyCase.Auth.Application.Authorization.UseCases
{
    public class GenerateToken : IGenerateToken
    {
        private SignInManager<Usuario> _signInManager;
        private IIdentityManager _identityManager;

        private readonly BaseResponseWithValue<string> _response;

        public GenerateToken(IIdentityManager identityManager, SignInManager<Usuario> signInManager)
        {
            _identityManager = identityManager;
            _signInManager = signInManager;
            _response = new BaseResponseWithValue<string>();
        }
        public async Task<BaseResponse> RunAsync(LoginUserViewModel dto)
        {
            var usuario = _signInManager.UserManager.Users.FirstOrDefault(user => user.UserName == dto.Username.ToUpper());

            if (usuario == null)
                return _response.AsError("Usuário não encontrado!");

            var token = await _identityManager.GenerateToken(usuario);

            if(String.IsNullOrEmpty(token))
                return _response.AsError("Falha ao gerar token!");

            return _response.AsSuccess(token);
        }
    }
}
