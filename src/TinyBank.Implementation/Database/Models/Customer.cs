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
        public string Nino { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CustomerCategory { get; set; }
    }
}
