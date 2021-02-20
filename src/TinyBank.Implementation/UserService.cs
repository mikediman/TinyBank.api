using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using TinyBank.Implementation.Database;
using TinyBank.Implementation.Database.Models;
using TinyBank.Interfaces;
using TinyBank.Types.items;
using TinyBank.Types.Requests;
using TinyBank.Types.Responses;

namespace TinyBank.Implementation
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> logger;
        private readonly TinyBankDbContext dbContext;

        public UserService(ILogger<UserService> _logger, TinyBankDbContext _dbContext)
        {
            logger = _logger;
            dbContext = _dbContext;
        }

        #region Registration User Service

        public async Task<RegisterUserResponse> RegistrationUserAsync(RegisterUserRequest request)
        {
            RegisterUserResponse response = new RegisterUserResponse();
            Customer customer = new Customer();
            Transaction transaction = new Transaction();
            try
            {
                ValidateUserDetails(request);
                await CheckIfUserExists(request);
                AddCustomerInDb(customer, request);
                AddTransactionInDb(customer, transaction);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                logger.LogError(exception.Message);
                throw new Exception(exception.Message);
            }
            response.IsRegistered = true;
            return response;
        }

        private void ValidateUserDetails(RegisterUserRequest request)
        {
            if (String.IsNullOrWhiteSpace(request.UserName)) throw new Exception("Please enter a Username.");
            if (String.IsNullOrWhiteSpace(request.Nino) || request.Nino.Length != 9) throw new Exception("Please enter a valid National Insurance Number.");
            if (String.IsNullOrWhiteSpace(request.Email) || request.Nino.Length > 50) throw new Exception("Please enter an email address.");
        }

        private async Task CheckIfUserExists(RegisterUserRequest request)
        {
            var customer = await dbContext.Set<Customer>().Where(c => c.Nino == request.Nino).SingleOrDefaultAsync();            
            if (customer != null) throw new Exception("The user has already registered.");
        }

        private async void AddCustomerInDb(Customer customer, RegisterUserRequest request)
        {
            customer = CreateCustomer(customer, request);
            customer.CustomerCategory = TransactionCategory.GetValueByKey(GetCustomerCategory(request));
            await dbContext.AddAsync(customer);
        }

        private Customer CreateCustomer(Customer customer, RegisterUserRequest request)
        {   
            customer.CustomerId = Guid.NewGuid();
            customer.UserName = request.UserName;
            customer.Nino = request.Nino;
            customer.Email = CheckIfEmailIsValid(request.Email);
            customer.TransactionDate = DateTime.Now;
            return customer;
        }

        private string CheckIfEmailIsValid(string mail)
        {
            var emailAddress = new System.Net.Mail.MailAddress(mail);
            if (String.IsNullOrWhiteSpace(emailAddress.Address)) throw new Exception("Please enter a valid email address."); 
            return mail;
        }

        private string GetCustomerCategory(RegisterUserRequest request)
        {
            string category = String.Empty;
            if(request.CustomerCategory == (int)Categories.Personal) return category = TransactionCategory.GetKeyByEnum((int)Categories.Personal);
            if(request.CustomerCategory == (int)Categories.Merchant) return category = TransactionCategory.GetKeyByEnum((int)Categories.Merchant);
            else throw new Exception("Not valid customer category.");
        }

        private async void AddTransactionInDb(Customer customer, Transaction transaction)
        {
            transaction.TransactionId = Guid.NewGuid();
            transaction.CustomerId = customer.CustomerId;
            transaction.Nino = customer.Nino;
            transaction.TransactionDate = customer.TransactionDate;
            transaction.TransactionCategory = GetTransactionValue();
            await dbContext.AddAsync(transaction);            
        }

        private string GetTransactionValue()
        {
            string category = TransactionCategory.GetValueByKey(TransactionCategory.GetKeyByEnum((int)Categories.RegisterUser));
            return category;
        }

        #endregion
    }
}
