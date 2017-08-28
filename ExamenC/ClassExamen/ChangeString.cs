using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassExamen
{
    public class ChangeString
    {
        public static String build(String value)
        {
            char[] result = value.ToCharArray();
            Int32 ascii = 0;
            foreach (var item in result.Select((x, y) => new { Index = y, Value = x }))
            {
                ascii = (Int32)item.Value;
                if ((ascii >= 65 && ascii <= 90) || (ascii >= 97 && ascii <= 122) || (ascii == 209) || (ascii == 241))
                {
                    Int32 newAscii = 0;
                    newAscii = ascii + 1;

                    if (newAscii == 79) newAscii = 209;
                    if (newAscii == 111) newAscii = 241;
                    if (ascii == 209) newAscii = 79;
                    if (ascii == 241) newAscii = 111;

                    if (newAscii == 122)
                    {
                        newAscii = ascii;
                    }

                    result[item.Index] = (char)newAscii;
                }
            }
            String display = String.Join("", result.Select(x => String.Format("{0}", x)));
            return display;
        }
    }
}
