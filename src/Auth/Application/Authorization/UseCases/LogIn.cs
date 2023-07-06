using Microsoft.AspNetCore.Identity;
using Net6StudyCase.Auth.Domain;
using Net6StudyCase.Auth.Domain.UseCases;
using Net6StudyCase.SharedKernel.ViewModel;

namespace Net6StudyCase.Auth.Application.Authorization.UseCases
{

    public class LogIn : ILogin
    {
        private SignInManager<Usuario> _signInManager;

        public LogIn(SignInManager<Usuario> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<SignInResult> Login(LoginUserViewModel dto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            return resultado;
        }
    }
}
