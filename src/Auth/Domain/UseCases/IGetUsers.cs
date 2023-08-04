using SharedKernel.ViewModel;

namespace Net6StudyCase.Auth.Domain.UseCases
{
    public interface IGetUsers<TResult>
    {
        Task<TResult> RunAsync();
    }
}
