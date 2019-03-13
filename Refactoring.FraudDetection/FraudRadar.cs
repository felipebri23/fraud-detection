// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FraudRadar
    {
        public IEnumerable<Tuple<bool, int>> Check(IEnumerable<Order> orders)
        {
            var fraudResults = new List<Tuple<bool, int>>();

            foreach (var order in orders.Reverse())
            {
                var previousOrders = orders.Where(o => o.OrderId < order.OrderId);
                if (order.IsFraudulent(previousOrders))
                {
                    fraudResults.Add(new Tuple<bool, int>(true, order.OrderId));
                }
            }

            return fraudResults;
        }
    }
}