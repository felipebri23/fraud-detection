
namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Order
    {
        private Order()
        {

        }

        public int OrderId { get; set; }

        public int DealId { get; set; }

        public string Email { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string CreditCard { get; set; }       

        public static Order Create(int orderId, int dealId, string email, string street, string city, string state, string zipCode, string creditCard)
        {
            var order = new Order
            {
                OrderId = orderId,
                DealId = dealId,
                Email = email,
                Street = street,
                City = city,
                State = state,
                ZipCode = zipCode,
                CreditCard = creditCard
            };
            order.Normalize();
            return order;
        }

        public bool IsFraudulent(IEnumerable<Order> previousOrders)
        {
            return previousOrders.Any(o => o.OrderId != OrderId
                                    && o.DealId == DealId
                                    && o.Email == Email
                                    && o.CreditCard != CreditCard)
                || previousOrders.Any(o => o.OrderId != OrderId
                                    && o.DealId == DealId
                                    && o.State == State
                                    && o.ZipCode == ZipCode
                                    && o.Street == Street
                                    && o.City == City
                                    && o.CreditCard == CreditCard);
        }

        private void Normalize()
        {
            NormalizeEmail();
            NormalizeStreet();
            NormalizeState();
        }

        private void NormalizeEmail()
        {
            var aux = Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            Email = string.Join("@", new string[] { aux[0], aux[1] });
        }

        private void NormalizeStreet()
        {
            Street = Street.Replace("st.", "street").Replace("rd.", "road");
        }

        private void NormalizeState()
        {
            State = State.Replace("il", "illinois").Replace("ca", "california").Replace("ny", "new york");
        }
    }
}
