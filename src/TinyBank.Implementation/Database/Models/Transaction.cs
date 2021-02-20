using System;
using TinyBank.Types.items;

namespace TinyBank.Implementation.Database.Models
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public Guid CustomerId { get; set; }
        public string Nino { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionCategory { get; set; }
    }
}
