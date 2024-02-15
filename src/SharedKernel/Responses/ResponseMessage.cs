using System.ComponentModel;

namespace SharedKernel.Responses
{
    public enum ResponseMessage
    {
        [Description("An error ocurred, try again later")]
        GenericError = 0,
        [Description("Success")]
        Success = 1,
        [Description("Error to create user")]
        CreateUserError = 2,
    }
}