using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadHDViettak
{
    public class Invoice
    {
        public DateTime ArisingDate { get; set; }
        public string CusCode { get; set; }
        public string CusName { get; set; }
        public string CusTaxCode { get; set; }
        public string CusAddress { get; set; }
        public string CusBankNo { get; set; }
        public string CusBankName { get; set; }
        public string CusPhone { get; set; }
        public string EmailDeliver { get; set; }
        public string Buyer { get; set; }
        public string SellBankNo { get; set; }
        public string InvNote { get; set; }
        public string PaymentMethod { get; set; }
        public string Currency { get; set; }
        public double ExRate { get; set; }
        public double Amount { get; set; }
        public double DiscountAmount { get; set; }
        public double VATRate { get; set; }
        public double VATAmount { get; set; }
        public double Total { get; set; }
        public string AmountInWords { get; set; }
        public Product[] Products { get; set; }
    }
}
