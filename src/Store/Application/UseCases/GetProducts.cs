using Domain;
using Net6StudyCase.SharedKernel.Caching;
using Net6StudyCase.SharedKernel.Helper;
using Net6StudyCase.Store.Domain.UseCases;
using Net6StudyCase.Store.Infra.Database.Context;

namespace Net6StudyCase.Store.Application.UseCases
{
    public class GetProducts : IGetProducts
    {
        private readonly ProdutoDbContext _produtoDbContext;
        private readonly ICachingService _cachingService;

        public GetProducts(ProdutoDbContext produtoDbContext, ICachingService cachingService)
        {
            _produtoDbContext = produtoDbContext;
            _cachingService = cachingService;
        }
        public async Task<IEnumerable<Produto>> GetAll()
        {
            var key = RedisName.GetObjectKey<Produto>("all");

            var produtos = await _cachingService.GetListAsync<Produto>(key);

            if(produtos is null)
            {
                produtos = _produtoDbContext.Produtos.ToList();
                await _cachingService.SetAsync(key, produtos);
            } 

            return produtos.ToList();
        }

        public async Task<Produto?> GetById(int id)
        {
            var key = RedisName.GetObjectKey<Produto>(id.ToString());

            var produto = await _cachingService.GetAsync<Produto>(key);

            if(produto is null)
            {
                produto = _produtoDbContext.Produtos.FirstOrDefault(x => x.Id == id);
                await _cachingService.SetAsync(key, produto);
            }

            return produto;
        }

        public async Task<IEnumerable<Produto>> GetPagination(int page, int pageSize)
        {
            var key = RedisName.GetObjectKey<Produto>($"page:{page}:pageSize:{pageSize}");

            var produtos = await _cachingService.GetListAsync<Produto>(key);

            if(produtos is null)
            {
                produtos = _produtoDbContext.Produtos.Skip(page * pageSize).Take(pageSize).ToList();
                await _cachingService.SetAsync(key, produtos);
            }
            
            return produtos;
        }
    }
}
