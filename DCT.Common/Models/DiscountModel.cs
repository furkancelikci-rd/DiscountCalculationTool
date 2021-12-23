using DCT.Common.Enums;
using System.Collections.Generic;

namespace DCT.Common.Models
{
    public class DiscountModel
    {
        public UserType UserType { get; set; }
        public bool IsGroceriesProduct { get; set; }
        public List<InvoiceModel> Products { get; set; }
    }
}
