
namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class OrderObjectMother
    {        
        public static IEnumerable<Order> CreateFromFile(string filePath)
        {
            var orders = new List<Order>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var items = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                var order = Order.Create(
                    orderId: int.Parse(items[0]),
                    dealId: int.Parse(items[1]),
                    email: items[2].ToLower(),
                    street: items[3].ToLower(),
                    city: items[4].ToLower(),
                    state: items[5].ToLower(),
                    zipCode: items[6],
                    creditCard: items[7]
                );

                orders.Add(order);
            }

            return orders;
        }
    }
}
