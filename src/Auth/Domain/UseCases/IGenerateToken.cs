using Net6StudyCase.SharedKernel.ViewModel;
using SharedKernel.Responses;

namespace Net6StudyCase.Auth.Domain.UseCases
{
    public interface IGenerateToken
    {
        BaseResponse RunAsync(LoginUserViewModel dto);
    }
}
