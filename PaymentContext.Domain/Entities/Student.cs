using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscription;

        public Student(Name name, Document document, Email email) 
        {
            this.Name = name;
            this.Document = document;
            this.Email = email; 
            this._subscription = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }       
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return  _subscription.ToArray();} }

        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionActive = false;

            foreach(var sub in _subscription)
                if(sub.Active)
                    hasSubscriptionActive = true;

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Voce já tem uma assinatura ativa")
                .AreEquals(0, subscription.Payments.Count, "Student.Subscription.Payments", "Esta assinatura não possui pagamentos")
            );

            //Alternativo
            /*if(hasSubscriptionActive)
                AddNotification("Student.Subscriptions", "Voce já tem uma assinatura ativa");*/
        }
    }
}