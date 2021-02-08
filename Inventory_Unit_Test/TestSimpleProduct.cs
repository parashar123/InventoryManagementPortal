using NUnit.Framework;
using System;
using System.Collections.Generic;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace InventoryUnit.Test
{
    [TestFixture]
    public class TestSimpleProduct
    {
        ISqliteDataAccess _database;

        #region ApiCollectionUnitTest

        [Test]
        public void Product_Load_ShouldLoadProduct()
        {
            //arrange

            //act

            //assert



            //Couldnt start on unit testing, time constraint!!
            var testProducts = Get();
            var controller = new ProductController();
            var result = controller.Get();
            Assert.That(testProducts, Is.All);// need to ork on it.
        }

        [Test]
        public void Product_AddNewProduct_ShouldAddNewProdcut()
        {
            //Couldnt start on unit testing, time constraint!!
            var testProducts = Get();
            var controller = new ProductController();
            var result = controller.Get();
            Assert.That(testProducts, Is.All);// need to ork on it.
        }

        [Test]
        public void Product_ChangeProduct_ShouldChangeGivenProdcut()
        {
            //Couldnt start on unit testing, time constraint!!
            var testProducts = Get();
            var controller = new ProductController();
            var result = controller.Get();
            Assert.That(testProducts, Is.All);// need to ork on it.
        }

        [Test]
        public void Prodcut_Delete_ShouldDeleteProduct()
        {
            //Couldnt start on unit testing, time constraint!!
            var testProducts = Get();
            var controller = new ProductController();
            var result = controller.Get();
            Assert.That(testProducts, Is.All);// need to ork on it.
        }

        [Test]
        public void Product_LoadName_ShouldLoadAllProductName()
        {
            //Couldnt start on unit testing, time constraint!!
            var testProducts = Get();
            var controller = new ProductController();
            var result = controller.Get();
            Assert.That(testProducts, Is.All);// need to ork on it.
        }

        [Test]
        public void Product_SavePhoto_ShouldSaveProdcutPhoto()
        {
            //Couldnt start on unit testing, time constraint!!
            var testProducts = Get();
            var controller = new ProductController();
            var result = controller.Get();
            Assert.That(testProducts, Is.All);// need to ork on it.
        }


        private List<Product> mainProduct()
        {
            var testProducts = new List<Product>();
            testProducts.Add(new Product { ProductName = "Abc", Description = "SampleSampleSampleSampleSampleSampleSample", DateOfAdding = "2021-02-07", Price = 0, PhotoFileName = "anonymous.png" });
            testProducts.Add(new Product { ProductName = "Abc", Description = "SampleSampleSampleSampleSampleSampleSample", DateOfAdding = "2021-02-07", Price = 0, PhotoFileName = "anonymous.png" });
            testProducts.Add(new Product { ProductName = "Abc", Description = "SampleSampleSampleSampleSampleSampleSample", DateOfAdding = "2021-02-07", Price = 0, PhotoFileName = "anonymous.png" });
            testProducts.Add(new Product { ProductName = "Abc", Description = "SampleSampleSampleSampleSampleSampleSample", DateOfAdding = "2021-02-07", Price = 0, PhotoFileName = "anonymous.png" });
            return testProducts;
        }

        #endregion

    }
}
