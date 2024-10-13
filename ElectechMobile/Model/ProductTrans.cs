using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectechMobile.Model
{
   public class ProductTrans
    {
        public DateTime date { get; set; }
        public int product_TbleId { get; set; }
        public int qtyIn { get; set; }
        public int qtyOut { get; set; }
        public int runningBalance { get; set; }
        public int rsal_TblId { get; set; }
        public int sal_TblId { get; set; }
        public int buy_TblId { get; set; }
    }
}
