using Net6StudyCase.SharedKernel.ViewModel;

namespace Net6StudyCase.Auth.Domain.UseCases
{
    public interface IGenerateToken
    {
        string RunAsync(LoginUserViewModel dto);
    }
}
