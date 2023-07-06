using Microsoft.AspNetCore.Identity;
using Net6StudyCase.Auth.Domain;
using Net6StudyCase.Auth.Domain.UseCases;
using Net6StudyCase.Auth.Infra.Identity;
using Net6StudyCase.SharedKernel.ViewModel;

namespace Net6StudyCase.Auth.Application.Authorization.UseCases
{
    public class GenerateToken : IGenerateToken
    {
        private SignInManager<Usuario> _signInManager;
        private ITokenService _tokenService;

        public GenerateToken(ITokenService tokenService, SignInManager<Usuario> signInManager)
        {
            _tokenService = tokenService;
            _signInManager = signInManager;
        }
        public string RunAsync(LoginUserViewModel dto)
        {
            var usuario = _signInManager.UserManager.Users.FirstOrDefault(user => user.UserName == dto.Username.ToUpper());

            if (usuario == null)
                throw new Exception("Usuário não localizado!");

            var token = _tokenService.GenerateToken(usuario);

            return token;
        }
    }
}
