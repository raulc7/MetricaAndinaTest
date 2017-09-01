using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntity
{
    public class PaymentStateBE
    {
        [Display(Name = "Codigo")]
        public Int32 Id { get; set; }
        [Display(Name = "Estado")]
        public String Name { get; set; }
    }
}
