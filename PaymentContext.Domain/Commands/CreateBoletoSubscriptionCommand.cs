using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enum;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand: Notifiable, ICommand
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Document { get;  set; }
        public string EnderecoEmail { get;  set; }

        public string BarCode { get;  set; }
        public string BoletoNumber { get;  set; }
        public DateTime PaidDate { get;  set; }
        public DateTime ExpireDate { get;  set; }
        public decimal Total { get;  set; }
        public decimal TotalPaid { get;  set; }
        public string Owner { get;  set; }
        public Document PayerDocument { get;  set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string PayerEmail { get;  set; }

        public string Rua { get;  set; }
        public string Bairro { get;  set; }
        public string Cidade { get;  set; }
        public string Estado { get;  set; }
        public string Pais { get;  set; }
        public string Complemento { get;  set; }
        public string Numero { get;  set; }
        public string CEP { get;  set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(this.FirstName, 3, "Name.FirstName", "Nome deve conter ao menos 3 caracteres")
                .HasMinLen(this.LastName, 3, "Name.LastName", "Sobrenome deve conter ao menos 3 caracteres")
                .HasMaxLen(this.FirstName, 40, "Name.FirstName", "Nome deve conter no maximo 40 caracteres")
            );
        }
    }
}