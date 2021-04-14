using PaymentContext.Domain.ValueObjects;
using System;
namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(
            string cardHolderName, 
            string cardNumber, 
            string LastTransactionNumber, 
            DateTime paidDate, 
            DateTime expireDate, 
            decimal total, 
            decimal totalPaid, 
            string owner,
            Document document,
            Address address,
            Email email)
        :base( paidDate,  expireDate,  total,  totalPaid,  owner,  document,  address,  email)
        {
            this.CardHolderName = cardHolderName;
            this.CardNumber = cardNumber;
            this.LastTransactionNumber = LastTransactionNumber;
        }
        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }
}