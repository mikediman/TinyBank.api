using System.Threading.Tasks;
using TinyBank.Types.Requests;
using TinyBank.Types.Responses;

namespace TinyBank.Interfaces
{
    public interface IUserService
    {
        public Task<RegisterUserResponse> RegistrationUserAsync(RegisterUserRequest request);
    }
}
