using Net6StudyCase.SharedKernel.Enum;

namespace Net6StudyCase.Auth.Domain
{
    public interface IIdentityManager
    {
        Task Cadastrar(Usuario user, string password, UserTypeEnum userType);

        Task<string?> GenerateToken(Usuario usuario);
    }
}
