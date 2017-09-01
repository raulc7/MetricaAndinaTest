using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntity
{
    public class PaymentOrderBE
    {
        [Display(Name = "Codigo")]
        public Int32 Id { get; set; }
        public Int32 BranchId { get; set; }
        public Int32 CurrencyId { get; set; }
        public Int32 PaymentStateId { get; set; }
        [Display(Name = "Monto")]
        public Decimal Amount { get; set; }
        [Display(Name = "Fecha Pago")]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }
        [Display(Name = "Sucursal")]
        public String BranchName { get; set; }
        [Display(Name = "Moneda")]
        public String CurrencyName { get; set; }
        [Display(Name = "Simbolo")]
        public String CurrencySymbol { get; set; }
        [Display(Name = "ISO")]
        public String CurrencyIso { get; set; }
        [Display(Name = "Estado Pago")]
        public String PaymentStateName { get; set; }
    }
}
