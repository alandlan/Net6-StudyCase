using SharedKernel.ViewModel;

namespace Net6StudyCase.Store.Domain.UseCases
{
    public interface ICreateProduct
    {
        Task Create(CreateProdutoViewModel product);
    }
}
