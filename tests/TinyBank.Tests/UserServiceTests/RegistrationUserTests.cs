﻿using System.Linq;
using System.Threading.Tasks;
using Xunit;

using Microsoft.Extensions.DependencyInjection;
using TinyBank.Implementation.Database.Models;

using TinyBank.Interfaces;
using TinyBank.Implementation.Database;
using TinyBank.Types.Responses;
using TinyBank.Types.Requests;

namespace TinyBank.Tests.UserServiceTests
{
    public class UserTests : IClassFixture<TinyBankFixture>
    {
        private IUserService userService;
        private TinyBankDbContext dbContext;

        private UserTests(TinyBankFixture fixture)
        { 
            userService = fixture.Scope.ServiceProvider.GetRequiredService<IUserService>();
            dbContext = fixture.Scope.ServiceProvider.GetRequiredService<TinyBankDbContext>();
        }

        [Fact]
        public async Task RegistrationUserAsync_Success()
        {
            RegisterUserRequest request = new RegisterUserRequest();
            request.UserName = "mikediman";
            request.Email = "mike@email.com";
            request.Nino = "AB123456C";
            request.CustomerCategory = 6;
            var response = (await userService.RegistrationUserAsync(request));
            Assert.NotNull(response);
            var savedCustomer = dbContext.Set<Customer>().Where(c => c.Nino == request.Nino).SingleOrDefault();
            Assert.NotNull(savedCustomer);           
        }
    }
}