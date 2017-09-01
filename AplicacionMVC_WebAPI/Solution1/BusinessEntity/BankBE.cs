using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntity
{
    public class BankBE
    {
        [Display(Name = "Codigo")]
        public Int32 Id { get; set; }
        [Display(Name = "Nombre")]
        public String Name { get; set; }
        [Display(Name = "Direccion")]
        public String Address { get; set; }
        [Display(Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
    }
}
