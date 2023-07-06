using Microsoft.AspNetCore.Identity;
using Net6StudyCase.SharedKernel.ViewModel;

namespace Net6StudyCase.Auth.Domain.UseCases
{
    public interface ILogin
    {
        Task<SignInResult> Login(LoginUserViewModel dto);
    }
}
