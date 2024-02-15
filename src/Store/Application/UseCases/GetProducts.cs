using Domain;
using Net6StudyCase.Store.Domain.UseCases;
using Net6StudyCase.Store.Infra.Database.Context;

namespace Net6StudyCase.Store.Application.UseCases
{
    public class GetProducts : IGetProducts
    {
        private readonly ProdutoDbContext _produtoDbContext;

        public GetProducts(ProdutoDbContext produtoDbContext)
        {
            _produtoDbContext = produtoDbContext;
        }
        public Task<List<Produto>> GetAll()
        {
            return Task.FromResult(_produtoDbContext.Produtos.ToList());
        }

        public Task<Produto?> GetById(int id)
        {
            return Task.FromResult(_produtoDbContext.Produtos.FirstOrDefault(x => x.Id == id));
        }

        public Task<List<Produto>> GetPagination(int page, int pageSize)
        {
            return Task.FromResult(_produtoDbContext.Produtos.Skip(page * pageSize).Take(pageSize).ToList());
        }
    }
}
