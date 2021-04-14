using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable, IHandler<CreateBoletoSubscriptionCommand>, IHandler<CreatePayPalSubscriptionCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEmailService _emailService;
        public SubscriptionHandler(
            IStudentRepository studentRepository, 
            IEmailService emailService)
        {
            this._studentRepository = studentRepository;
            this._emailService = emailService;
        }
        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            command.Validate();
            if(command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel realizar sua assinatura");
            }

            if(_studentRepository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            if(_studentRepository.DocumentExists(command.EnderecoEmail))
                AddNotification("Document", "Este CPF já está em uso");
            
            var _name = new Name(command.FirstName, command.LastName);
            var _document = new Document(command.Document, Domain.Enum.EDocumentType.CPF);
            var _email= new Email(command.EnderecoEmail);    
            var _address = new Address(command.Rua, command.Bairro, command.Cidade, command.Estado, command.Pais, command.Complemento, command.Numero, command.CEP);
            var _student = new Student(_name, _document, _email);
            var _subscription = new Subscription(DateTime.Now.AddMonths(1));

            var paypalPayment = new BoletoPayment(
                command.BarCode, 
                command.BoletoNumber, 
                command.PaidDate, 
                command.ExpireDate, 
                command.Total , 
                command.TotalPaid, 
                command.Owner, 
                new Document(command.PayerDocument.Number, command.PayerDocumentType), 
                _address, 
                _email
            );

            _subscription.AddPayments(paypalPayment);
            _student.AddSubscription(_subscription);
            AddNotifications(_name, _document, _email, _address, _student, _subscription, paypalPayment);

            _studentRepository.CreateSubscription(_student);
            _emailService.Send(_student.Name.ToString(), _student.Email.EnderecoEmail, "Bem vindo", "Sua assinatura foi criada");
            AddNotifications(new Contract());
            return new CommandResult(true,"Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            /*command.Validate();
            if(command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel realizar sua assinatura");
            }*/

            if(_studentRepository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            if(_studentRepository.DocumentExists(command.EnderecoEmail))
                AddNotification("Document", "Este CPF já está em uso");
            
            var _name = new Name(command.FirstName, command.LastName);
            var _document = new Document(command.Document, Domain.Enum.EDocumentType.CPF);
            var _email= new Email(command.EnderecoEmail);    
            var _address = new Address(command.Rua, command.Bairro, command.Cidade, command.Estado, command.Pais, command.Complemento, command.Numero, command.CEP);
            var _student = new Student(_name, _document, _email);
            var _subscription = new Subscription(DateTime.Now.AddMonths(1));

            var paypalPayment = new PaypalPayment(
                command.TransactionCode, 
                command.PaidDate, 
                command.ExpireDate, 
                command.Total , 
                command.TotalPaid, 
                command.Owner, 
                new Document(command.PayerDocument.Number, command.PayerDocumentType), 
                _address, 
                _email
            );

            _subscription.AddPayments(paypalPayment);
            _student.AddSubscription(_subscription);
            AddNotifications(_name, _document, _email, _address, _student, _subscription, paypalPayment);

            if(Invalid)
                return new CommandResult(false, "Não foi possivel realizar sua assinatura");

            _studentRepository.CreateSubscription(_student);
            _emailService.Send(_student.Name.ToString(), _student.Email.EnderecoEmail, "Bem vindo", "Sua assinatura foi criada");
            AddNotifications(new Contract());
            return new CommandResult(true,"Assinatura realizada com sucesso");
        }
    }
}