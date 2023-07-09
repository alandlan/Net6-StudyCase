using AutoMapper;
using Domain;
using SharedKernel.ViewModel;

namespace Application;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<CreateProdutoViewModel, Produto>();
    }    
}
