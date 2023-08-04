using Net6StudyCase.Auth.Domain;

namespace Net6StudyCase.Auth.Infra.Identity
{
    public interface ITokenService
    {
        Task<string> GenerateToken(Usuario usuario);
    }
}