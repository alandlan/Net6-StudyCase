using SharedKernel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6StudyCase.Auth.Domain.UseCases
{
    public interface ICreateUser
    {
        Task Cadastrar(CreateUserViewModel dto);
    }
}
