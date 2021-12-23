using DCT.Common.Models;

namespace DCT.BLL.Interface
{
    public interface IDiscountOperation
    {
        decimal GetInvoiceAmount(DiscountModel discountModel);
    }
}
