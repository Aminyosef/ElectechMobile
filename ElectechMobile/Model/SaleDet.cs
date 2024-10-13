using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectechMobile.Model
{
    public class SaleDet
    {
        public string code { get; set; }
        public int qtyOut { get; set; }
        public decimal price { get; set; }
        public decimal amount { get; set; }
        public string productName { get; set; }
    }
}
