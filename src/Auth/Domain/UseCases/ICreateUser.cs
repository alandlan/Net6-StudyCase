using SharedKernel.Responses;
using SharedKernel.ViewModel;

namespace Net6StudyCase.Auth.Domain.UseCases
{
    public interface ICreateUser
    {
        Task<BaseResponse> Cadastrar(CreateUserViewModel dto);
    }
}
