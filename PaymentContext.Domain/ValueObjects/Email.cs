using PaymentContext.Shared.ValueObject;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string enderecoEmail)
        {
            this.EnderecoEmail = enderecoEmail;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(this.EnderecoEmail, "Email.EnderecoEmail", "E-mail inválido")
            );
        }

        public string EnderecoEmail { get; private set; }
    }
}
