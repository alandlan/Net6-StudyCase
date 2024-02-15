using Domain;

namespace Net6StudyCase.Store.Domain.UseCases
{
    public interface IGetProducts
    {
        Task<IEnumerable<Produto>> GetAll();
        Task<Produto?> GetById(int id);
        Task<IEnumerable<Produto>> GetPagination(int page, int pageSize);
    }
}
