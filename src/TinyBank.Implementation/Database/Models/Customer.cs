using System;
using System.Collections.Generic;
using TinyBank.Types.items;

namespace TinyBank.Implementation.Database.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Transaction> Transactions { get; set; }
        public CustomerCategory CustomerCategory { get; set; }
    }
}
