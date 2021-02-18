using System;
using TinyBank.Types.items;

namespace TinyBank.Implementation.Database.Models
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public Guid CustomerId { get; set; }
        public TransactionCategory TransactionCategory { get; set; }
    }
}
