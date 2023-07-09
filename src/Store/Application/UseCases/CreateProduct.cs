using AutoMapper;
using Domain;
using Net6StudyCase.Store.Domain.UseCases;
using Net6StudyCase.Store.Infra.Database.Context;
using SharedKernel.ViewModel;

namespace Net6StudyCase.Store.Application.UseCases
{
    public class CreateProduct : ICreateProduct
    {
        private IMapper _mapper;
        private readonly ProdutoDbContext _produtoDbContext;
        public CreateProduct(IMapper mapper, ProdutoDbContext produtoDbContext)
        {
            _mapper = mapper;
            _produtoDbContext = produtoDbContext;
        }
        public async Task Create(CreateProdutoViewModel product)
        {
            Produto usuario = _mapper.Map<Produto>(product);

            await _produtoDbContext.AddAsync(usuario);

            await _produtoDbContext.SaveChangesAsync();
        }
    }
}
