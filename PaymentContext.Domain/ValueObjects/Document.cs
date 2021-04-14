using PaymentContext.Domain.Enum;
using PaymentContext.Shared.ValueObject;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            this.Number = number;
            this.Type = type;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validate(), "Documento.Number", "Documento invalido")
            );
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

        public bool Validate(){
            if(Type == EDocumentType.CNPJ && Number.Length == 14)
                return  true;
            
            if(Type == EDocumentType.CPF && Number.Length == 11)
                return  true;

            return false;
        }
    }
}
