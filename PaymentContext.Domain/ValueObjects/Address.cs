using PaymentContext.Shared.ValueObject;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string rua, string bairro, string cidade, string estado, string pais, string complemento, string numero, string cep)
        {
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            Complemento = complemento;
            Numero = numero;
            CEP = cep;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(this.Rua, 3, "Address.Rua", "A Rua deve conter ao menos 3 caracteres")
            );
        }

        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Pais { get; private set; }
        public string Complemento { get; private set; }
        public string Numero { get; private set; }
        public string CEP { get; private set; }
    }
}
