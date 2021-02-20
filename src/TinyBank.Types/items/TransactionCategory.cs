using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TinyBank.Types.items
{
    [DataContract]
    public class TransactionCategory
    {
        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "value")]
        public string Value { get; set; }        

        TransactionCategory() { }

        private TransactionCategory(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public static TransactionCategory RegisterUser { get { return new TransactionCategory("001", "Register User"); } }
        public static TransactionCategory CreateAccount { get { return new TransactionCategory("002", "Create Account"); } }
        public static TransactionCategory Payment { get { return new TransactionCategory("003", "Payment"); } }
        public static TransactionCategory ReceiveAmount { get { return new TransactionCategory("004", "Receive Amount"); } }
        public static TransactionCategory Merchant { get { return new TransactionCategory("005", "Merchant Customer"); } }
        public static TransactionCategory Personal { get { return new TransactionCategory("006", "Personal Customer"); } }
        public static TransactionCategory DebitAccount { get { return new TransactionCategory("007", "Debit Account"); } }
        public static TransactionCategory CreditAccount { get { return new TransactionCategory("008", "Credit Account"); } }

        public static Dictionary<int, string> dictionaryEnum { get; set; } = new Dictionary<int, string>
        {
            { (int)Categories.RegisterUser, RegisterUser.Key },
            { (int)Categories.CreateAccount, CreateAccount.Key },
            { (int)Categories.Payment, Payment.Key },
            { (int)Categories.Receive, ReceiveAmount.Key },
            { (int)Categories.Merchant, Merchant.Key },
            { (int)Categories.Personal, Personal.Key },
            { (int)Categories.DebitAccount, DebitAccount.Key },
            { (int)Categories.CreditAccount, CreditAccount.Key },
        };

        public static Dictionary<string, string> dictionary { get; set; } = new Dictionary<string, string>
        {
            { RegisterUser.Key, RegisterUser.Value },
            { CreateAccount.Key, CreateAccount.Value },
            { Payment.Key, Payment.Value },
            { ReceiveAmount.Key, ReceiveAmount.Value },
            { Merchant.Key, Merchant.Value },
            { Personal.Key, Personal.Value },
            { DebitAccount.Key, DebitAccount.Value },
            { CreditAccount.Key, CreditAccount.Value },
        };

        public static string GetKeyByEnum(int id)
        {
            string value = String.Empty;
            dictionaryEnum.TryGetValue(id, out value);
            return value;
        }

        public static string GetValueByKey(string key)
        {
            string value = String.Empty;
            if (!String.IsNullOrEmpty(key)) dictionary.TryGetValue(key, out value);
            return value;
        }
    }
}
