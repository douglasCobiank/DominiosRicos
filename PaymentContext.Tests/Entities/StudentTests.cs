using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using System;
namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Email _email;
        public StudentTests()
        {
            _name = new Name("Douglas", "Teixeira");
            _document = new Document("43313119883", Domain.Enum.EDocumentType.CPF);
            _email= new Email("douglas@teste.com");    
            _address = new Address("Rua Jaime Pinto Rosas", "Jd Carvalho", "Ponta Grossa", "PR", "Brasil", "", "56", "84015600");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
        }

        [TestMethod]
        public void ShouldReturnErroWhenActiveSubscription()
        {
            var paypalPayment = new PaypalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10 , 10, "Douglas Corp", _document, _address, _email);
            _subscription.AddPayments(paypalPayment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErroWhenHadSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var paypalPayment = new PaypalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10 , 10, "Douglas Corp", _document, _address, _email);
            _subscription.AddPayments(paypalPayment);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Valid);
        }
    }
}