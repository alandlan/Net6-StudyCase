using SharedKernel.ViewModel;

namespace Net6StudyCase.Auth.Domain.UseCases
{
    public interface IGetUsers
    {
        Task<ICollection<GetAllUsersViewModel>> RunAsync();
    }
}
