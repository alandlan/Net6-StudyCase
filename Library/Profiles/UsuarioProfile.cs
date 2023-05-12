
using AutoMapper;
using Library.Dtos;
using Library.Models;

namespace Library.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile(){
        CreateMap<CreateUsuarioDto,Usuario>();
    }
}

