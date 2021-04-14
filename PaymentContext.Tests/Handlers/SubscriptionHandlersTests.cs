using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;
namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlersTests
    {
        
        [TestMethod]
        public void ShouldReturnErroWhenDocumentsExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand()
            {
                FirstName = "Douglas",
                LastName = "Teixeira Cobiank",
                Document = "99999999999",
                EnderecoEmail = "douglas@teste.com",
                BarCode = "123456789",
                BoletoNumber = "123456789",
                PaidDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddMonths(1),
                Total = 60,
                Owner = "Douglas",
                TotalPaid = 60
            };

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}