using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6StudyCase.SharedKernel.Enum
{
    public static class UserType
    {
        public const string Admin = "Admin";
        public const string User = "User";

        public static string GetUserType(UserTypeEnum userType)
        {
            if (userType.Equals(UserTypeEnum.Admin))
                return UserType.Admin;
            else
                return UserType.User;
        }
    }

    public enum UserTypeEnum
    {
        Admin = 1,
        User = 2
    }    
}
