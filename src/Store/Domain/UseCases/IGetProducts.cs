using Domain;

namespace Net6StudyCase.Store.Domain.UseCases
{
    public interface IGetProducts
    {
        Task<List<Produto>> GetAll();
        Task<Produto?> GetById(int id);
        Task<List<Produto>> GetPagination(int page, int pageSize);
    }
}
