using PaymentContext.Shared.ValueObject;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(this.FirstName, 3, "Name.FirstName", "Nome deve conter ao menos 3 caracteres")
                .HasMinLen(this.LastName, 3, "Name.LastName", "Sobrenome deve conter ao menos 3 caracteres")
                .HasMaxLen(this.FirstName, 40, "Name.FirstName", "Nome deve conter no maximo 40 caracteres")
            );
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
