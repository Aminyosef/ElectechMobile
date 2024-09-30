using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectechMobile.Model
{
    public class CustomerFlow
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string details { get; set; }
    }
}
