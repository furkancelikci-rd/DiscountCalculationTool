using DCT.BLL.Interface;
using DCT.Common.Enums;
using DCT.Common.Models;
using System;

namespace DCT.BLL.Service
{
    public class DiscountOperation : IDiscountOperation
    {
        public decimal GetInvoiceAmount(DiscountModel discountModel)
        {
            decimal totalAmount = 0;
            discountModel.Products.ForEach(x =>
            {
                totalAmount += x.Amount * x.Count;
            });

            return CalculateNetAmount(discountModel.UserType, discountModel.IsGroceriesProduct, totalAmount);
        }


        #region private methods
        private decimal CalculateNetAmount(UserType userType, bool isGroceriesProduct, decimal totalAmount)
        {
            var netAmount = userType switch
            {
                UserType.StoreEmployee when !isGroceriesProduct => totalAmount - (totalAmount * 30 / 100),
                UserType.StoreAffiliate when !isGroceriesProduct => totalAmount - (totalAmount * 10 / 100),
                UserType.CustomerOverForTwoYears when !isGroceriesProduct => totalAmount - (totalAmount * 5 / 100),
                _ => totalAmount - (Math.Floor(totalAmount / 100) * 5),
            };
            return netAmount;
        }

        #endregion


    }
}
