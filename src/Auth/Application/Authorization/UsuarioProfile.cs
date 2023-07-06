

using AutoMapper;
using Net6StudyCase.Auth.Domain;
using SharedKernel.ViewModel;

namespace Application.Authorization;
public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUserViewModel, Usuario>();
    }
}