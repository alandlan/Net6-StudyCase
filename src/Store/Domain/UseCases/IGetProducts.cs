using Domain;

namespace Net6StudyCase.Store.Domain.UseCases
{
    public interface IGetProducts
    {
        Task<List<Produto>> GetAll();
    }
}
