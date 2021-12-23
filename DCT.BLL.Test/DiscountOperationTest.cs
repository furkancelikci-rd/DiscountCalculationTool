using DCT.BLL.Service;
using DCT.Common.Enums;
using DCT.Common.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace DCT.BLL.Test
{

    [TestFixture]
    public class DiscountOperationTest
    {
        private DiscountOperation discountOperation;

        [SetUp]
        public void Setup()
        {
            discountOperation = new DiscountOperation();
        }

        [Test]
        [Category("By NormalUser")]
        public void GetInvoiceAmount_NormalUserType_ReturnNetAmount()
        {
            DiscountModel normalUserModel = new DiscountModel()
            {
                UserType = UserType.Normal,
                IsGroceriesProduct = false,
                Products = new List<InvoiceModel>()
                {
                    new InvoiceModel(){ Name = "Defter" , Count = 2, Amount = 50},
                    new InvoiceModel(){ Name = "Kalem" , Count = 4, Amount = 35},
                    new InvoiceModel(){ Name = "Silgi" , Count = 3, Amount = 15},
                }
            };

            //Amount: 285, Discount Amount: 10, Net Amount: 275

            var response = discountOperation.GetInvoiceAmount(normalUserModel);

            Assert.AreEqual(response, 275);
        }

        [Test]
        [Category("By StoreEmployee")]
        public void GetInvoiceAmount_StoreEmployeeUserType_ReturnNetAmount()
        {
            DiscountModel normalUserModel = new DiscountModel()
            {
                UserType = UserType.StoreEmployee,
                IsGroceriesProduct = false,
                Products = new List<InvoiceModel>()
                {
                    new InvoiceModel(){ Name = "Defter" , Count = 2, Amount = 50},
                    new InvoiceModel(){ Name = "Kalem" , Count = 4, Amount = 35},
                    new InvoiceModel(){ Name = "Silgi" , Count = 4, Amount = 15},
                }
            };

            //Amount: 300, Discount Amount: 90, Net Amount: 210

            var response = discountOperation.GetInvoiceAmount(normalUserModel);

            Assert.AreEqual(response, 210);
        }

        [Test]
        [Category("By StoreEmployee")]
        public void GetInvoiceAmount_StoreEmployeeUserType_ReturnNotPercentNetAmount()
        {
            DiscountModel normalUserModel = new DiscountModel()
            {
                UserType = UserType.StoreEmployee,
                IsGroceriesProduct = true,
                Products = new List<InvoiceModel>()
                {
                    new InvoiceModel(){ Name = "Defter" , Count = 2, Amount = 50},
                    new InvoiceModel(){ Name = "Kalem" , Count = 4, Amount = 35},
                    new InvoiceModel(){ Name = "Silgi" , Count = 4, Amount = 15},
                }
            };

            //Amount: 300, Discount Amount: 15, Net Amount: 285

            var response = discountOperation.GetInvoiceAmount(normalUserModel);

            Assert.AreEqual(response, 285);
        }

        [Test]
        [Category("By StoreAffiliate")]
        public void GetInvoiceAmount_StoreAffiliateUserType_ReturnNetAmount()
        {
            DiscountModel normalUserModel = new DiscountModel()
            {
                UserType = UserType.StoreAffiliate,
                IsGroceriesProduct = false,
                Products = new List<InvoiceModel>()
                {
                    new InvoiceModel(){ Name = "Defter" , Count = 2, Amount = 50},
                    new InvoiceModel(){ Name = "Kalem" , Count = 4, Amount = 35},
                    new InvoiceModel(){ Name = "Silgi" , Count = 4, Amount = 15},
                }
            };

            //Amount: 300, Discount Amount: 30, Net Amount: 270

            var response = discountOperation.GetInvoiceAmount(normalUserModel);

            Assert.AreEqual(response, 270);
        }

        [Test]
        [Category("By CustomerOverForTwoYears")]
        public void GetInvoiceAmount_CustomerOverForTwoYearsUserType_ReturnNetAmount()
        {
            DiscountModel normalUserModel = new DiscountModel()
            {
                UserType = UserType.CustomerOverForTwoYears,
                IsGroceriesProduct = false,
                Products = new List<InvoiceModel>()
                {
                    new InvoiceModel(){ Name = "Defter" , Count = 2, Amount = 50},
                    new InvoiceModel(){ Name = "Kalem" , Count = 4, Amount = 35},
                    new InvoiceModel(){ Name = "Silgi" , Count = 4, Amount = 15},
                }
            };

            //Amount: 300, Discount Amount: 15, Net Amount: 285

            var response = discountOperation.GetInvoiceAmount(normalUserModel);

            Assert.AreEqual(response, 285);
        }

        [Test]
        [Category("By CustomerOverForTwoYears")]
        public void GetInvoiceAmount_CustomerOverForTwoYearsUserType_ReturnIncorrectNetAmount()
        {
            DiscountModel normalUserModel = new DiscountModel()
            {
                UserType = UserType.Normal,
                IsGroceriesProduct = false,
                Products = new List<InvoiceModel>()
                {
                    new InvoiceModel(){ Name = "Defter" , Count = 2, Amount = 50},
                    new InvoiceModel(){ Name = "Kalem" , Count = 3, Amount = 35},
                    new InvoiceModel(){ Name = "Silgi" , Count = 4, Amount = 15},
                }
            };

            //Amount: 300, Discount Amount: 15, Net Amount: 285, Incorrect Amount: 255

            var response = discountOperation.GetInvoiceAmount(normalUserModel);

            Assert.AreEqual(response, 255);
        }

    }
}