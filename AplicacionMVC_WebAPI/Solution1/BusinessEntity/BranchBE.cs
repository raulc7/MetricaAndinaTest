using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntity
{
    public class BranchBE
    {
        [Display(Name = "Codigo")]
        public Int32 Id { get; set; }
        public Int32 BankId { get; set; }
        [Display(Name = "Nombre")]
        public String Name { get; set; }
        [Display(Name = "Direccion")]
        public String Address { get; set; }
        [Display(Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
        [Display(Name = "Banco")]
        public String BankName { get; set; }
    }
}
