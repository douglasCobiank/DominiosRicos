using PaymentContext.Domain.ValueObjects;
using System;
namespace PaymentContext.Domain.Entities
{
    public class PaypalPayment : Payment
    {
        public PaypalPayment(
            string transactionCode, 
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
            this.TransactionCode = transactionCode;
        }
        public string TransactionCode { get; private set; }
    }
}