using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enum;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _students;
        public StudentQueriesTests()
        {
            for(var i = 0; i<=10;i++){
                _students.Add(new Student(
                    new Name("Aluno", i.ToString()), 
                    new Document("1111111111" + i.ToString(), EDocumentType.CPF),
                    new Email($"teste{i.ToString()}@teste.com")
                    )
                );
            }
        }
        [TestMethod]
        public void ShouldReturnErroWhenDocumentsNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("12345678911");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null,  student);
        }
    }
}