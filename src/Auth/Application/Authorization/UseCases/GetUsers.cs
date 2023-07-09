using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Net6StudyCase.Auth.Domain;
using Net6StudyCase.Auth.Domain.UseCases;
using SharedKernel.Responses;
using SharedKernel.ViewModel;

namespace Application.Authorization.UseCases
{
    public class GetUsers : IGetUsers<BaseResponseWithValue<ICollection<GetAllUsersViewModel>>>
    {
        private readonly IMapper _mapper;
        private UserManager<Usuario> _userManager;

        private readonly BaseResponseWithValue<ICollection<GetAllUsersViewModel>> _response;

        public GetUsers(UserManager<Usuario> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _response = new();
        }

        public async Task<BaseResponseWithValue<ICollection<GetAllUsersViewModel>>> RunAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            return _response.AsSuccess(_mapper.Map<ICollection<GetAllUsersViewModel>>(users));
        }
    }
}