using DCT.BLL.Interface;
using DCT.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DCT.WebAPI.Controllers
{
    [ApiController]
    [Route("api/discount")]
    public class DiscountController : ControllerBase
    {

        readonly IDiscountOperation discountOperation;
        public DiscountController(IDiscountOperation discountOperation)
        {
            this.discountOperation = discountOperation;
        }

        [HttpPost]
        [Route("getInvoiceAmount")]
        public decimal GetInvoiceAmount(DiscountModel discountModel)
        {
            return discountOperation.GetInvoiceAmount(discountModel);
        }
    }
}
