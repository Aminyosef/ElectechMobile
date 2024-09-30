using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elc2025API.Models
{
    public class Engineer
    {
        [DisplayName("اسم مهندس المبيعات")]
        public int Id { get; set; }
        [DisplayName("اسم مهندس المبيعات")]
        public string EngName { get; set; }
        [DisplayName("رقم المحمول")]
        [DataType(DataType.PhoneNumber)]
        public string Mobil { get; set; }
        [DisplayName("رقم التليفون")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [DisplayName("الصورة")]
        public string EngPhoto { get; set; }
        [DisplayName("مناطق التسويق")]
        public string EngArea { get; set; }
        public string UserID { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}