using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntity
{
    public class CurrencyBE
    {
        [Display(Name = "Codigo")]
        public Int32 Id { get; set; }
        [Display(Name = "ISO")]
        public String Iso { get; set; }
        [Display(Name = "Simbolo")]
        public String Symbol { get; set; }
        [Display(Name = "Moneda")]
        public String Name { get; set; }
    }
}
