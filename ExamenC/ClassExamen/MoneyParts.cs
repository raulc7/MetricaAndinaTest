using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassExamen
{
    public class MoneyParts
    {
        public static String build(String value)
        {
            var moneyArray = new[]
                {
                    0.05m, 0.1m, 0.2m, 0.5m, 1m, 2m, 5m, 10m,
                    20m, 50m, 100m, 200m
                };

            var amount = Convert.ToDecimal(value);

            var result = new List<decimal>();

            foreach (var money in moneyArray)
            {
                var total = amount;
                var flag = 0;

                while (total >= money)
                {
                    total -= money;
                    result.Add(money);
                    flag = 1;
                }

                if (total > 0)
                {
                    if (flag == 1)
                        result.Add(total);
                }
            }

            var display = String.Format("[{0}]", String.Join(", ", result));

            return display;
        }
    }
}
