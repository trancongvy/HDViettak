using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadHDViettak
{
   public class Product
    {
       public int No { get; set; }
       public string ProdCode { get; set; }
       public string ProdName { get; set; }
       public string ProdUnit { get; set; }
       public double ProdQuantity { get; set; }
       public double ProdPrice { get; set; }
       public double Amount { get; set; }
       public double ProdVat { get; set; }
       public double ProdVATAmount { get; set; }
       public double DiscountRate { get; set; }
       public double DiscountAmount { get; set; }
       public int Promotion { get; set; }
    }
}
