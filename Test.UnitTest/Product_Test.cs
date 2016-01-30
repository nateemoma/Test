using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.BusinessLogic;
using Test.DataModel;

namespace Test.UnitTest
{
    [TestClass]
    public class Product_Test
    {
        Process process;

        public Product_Test()
        {
            process = new Process();
        }

        [TestMethod]
        public void InsertProduct_Test()
        {
            Product product = new Product();
            product.ProductId = 123;
            product.ProductName = "IPhone5 S";
            product.Price = 5000;
            product.Info = "";
            product.Live = true;
            product.Status = 1;
            product.Visible = true;
            product.Modified = DateTime.Now;

            process.InsertProduct(product);
        }

        [TestMethod]
        public void GetProducts_Test()
        {
            var items = process.GetProducts();
            Assert.IsNotNull(items);
        }
    }
}
