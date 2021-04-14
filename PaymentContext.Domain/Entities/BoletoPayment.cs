using PaymentContext.Domain.ValueObjects;
using System;
namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(
            string barcode, 
            string boletonumber,
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
            this.BarCode = barcode;
            this.BoletoNumber = boletonumber;
        }
        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}