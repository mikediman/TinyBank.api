using System;
using System.Collections.Generic;
using TinyBank.Types.items;

namespace TinyBank.Implementation.Database.Models
{
    public class Account
    {
        public Guid AccountId { get; set; }
        public List<Transaction> Transactions { get; set; }
        public AccountCategory AccountCategory { get; set; }
       
    }
}
