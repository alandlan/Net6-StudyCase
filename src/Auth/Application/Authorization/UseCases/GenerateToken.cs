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
        private ITokenService _tokenService;

        private readonly BaseResponseWithValue<string> _response;

        public GenerateToken(ITokenService tokenService, SignInManager<Usuario> signInManager)
        {
            _tokenService = tokenService;
            _signInManager = signInManager;
            _response = new BaseResponseWithValue<string>();
        }
        public BaseResponse RunAsync(LoginUserViewModel dto)
        {
            var usuario = _signInManager.UserManager.Users.FirstOrDefault(user => user.UserName == dto.Username.ToUpper());

            if (usuario == null)
                throw new Exception("Usuário não localizado!");

            var token = _tokenService.GenerateToken(usuario);

            return _response.AsSuccess(token);
        }
    }
}
