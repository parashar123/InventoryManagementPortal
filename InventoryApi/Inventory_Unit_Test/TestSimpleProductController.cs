using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace Inventory_Unit_Test
{
    [TestClass]
    public class TestSimpleProductController
    {
        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            //Couldnt start on unit testing, time constraint!!
            var testProducts = Get();
            var controller = new ProductController();
            var result = controller.Get();
            Assert.AreEqual(testProducts, result.RequestMessage);// need to ork on it.
        }

        private List<Product> Get()
        {
            var testProducts = new List<Product>();
            testProducts.Add(new Product { ProductName = "Abc", Description = "SampleSampleSampleSampleSampleSampleSample", DateOfAdding = "2021-02-07", Price = 0, PhotoFileName = "anonymous.png" });
            testProducts.Add(new Product {  ProductName = "Abc", Description = "SampleSampleSampleSampleSampleSampleSample", DateOfAdding = "2021-02-07", Price = 0, PhotoFileName = "anonymous.png" });
            testProducts.Add(new Product {  ProductName = "Abc", Description = "SampleSampleSampleSampleSampleSampleSample", DateOfAdding = "2021-02-07", Price = 0, PhotoFileName = "anonymous.png" });
            testProducts.Add(new Product {  ProductName = "Abc", Description = "SampleSampleSampleSampleSampleSampleSample", DateOfAdding = "2021-02-07", Price = 0, PhotoFileName = "anonymous.png" });
            return testProducts;
        }

    } 
}
