using Net6StudyCase.SharedKernel.ViewModel;
using SharedKernel.Responses;

namespace Net6StudyCase.Auth.Domain.UseCases
{
    public interface IGenerateToken
    {
        Task<BaseResponse> RunAsync(LoginUserViewModel dto);
    }
}
