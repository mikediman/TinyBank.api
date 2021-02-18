using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TinyBank.Interfaces;
using TinyBank.Types.Requests;
using TinyBank.Types.Responses;

namespace TinyBank.Implementation
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> logger;
        //private readonly TinyBankDbContext dbContext;

        public UserService(ILogger<UserService> _logger/*, TinyBankDbContext _dbContext*/)
        {
            logger = _logger;
            //dbContext = _dbContext;
        }

        public async Task<RegisterUserResponse> RegistrationUserAsync(RegisterUserRequest request)
        {
            RegisterUserResponse response = new RegisterUserResponse();
            
            return response;
        }
    }
}
