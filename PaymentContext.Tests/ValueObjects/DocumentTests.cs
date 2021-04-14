using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        //red, green, refactor
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", Domain.Enum.EDocumentType.CNPJ);
            Assert.IsFalse(doc.Validate());
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var doc = new Document("19247490000153", Domain.Enum.EDocumentType.CNPJ);
            Assert.IsTrue(doc.Validate());
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", Domain.Enum.EDocumentType.CPF);
            Assert.IsFalse(doc.Validate());
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("43313119883")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var doc = new Document(cpf, Domain.Enum.EDocumentType.CPF);
            Assert.IsTrue(doc.Validate());
        }
    }
}
