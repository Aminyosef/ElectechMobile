using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Elc2025API.Models
{
    public class Custkind
    {
        [DisplayName("نوع العميل")]
        public int Id { get; set; }
        [DisplayName("نوع العميل")]
        public string Kind { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}