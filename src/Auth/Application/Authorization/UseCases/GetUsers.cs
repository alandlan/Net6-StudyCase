using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Net6StudyCase.Auth.Domain;
using Net6StudyCase.Auth.Domain.UseCases;
using SharedKernel.ViewModel;

namespace Application.Authorization.UseCases
{
    public class GetUsers : IGetUsers
    {
        private readonly IMapper _mapper;
        private UserManager<Usuario> _userManager;

        public GetUsers(UserManager<Usuario> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ICollection<GetAllUsersViewModel>> RunAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            return _mapper.Map<ICollection<GetAllUsersViewModel>>(users);
        }
    }
}