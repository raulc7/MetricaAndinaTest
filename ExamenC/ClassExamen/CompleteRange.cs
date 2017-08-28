using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassExamen
{
    public class CompleteRange
    {
        public static List<int> build(List<int> value)
        {
            int max = value[0];
            int min = value[0];

            foreach (var val in value)
            {
                if (val > max)
                    max = val;

                if (val < min)
                    min = val;
                
                if (min > 1)
                    min = 1;
            }

            return Enumerable.Range(min, max).ToList();
        }
    }
}
