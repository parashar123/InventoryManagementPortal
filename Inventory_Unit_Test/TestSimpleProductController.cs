using Autofac.Extras.Moq;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace InventoryUnit.Test
{
    [TestFixture]
    public class TestSimpleProduct
    {

        #region Setup for mocking

        [SetUp]
        public void Setup()
        {
            //Mocking is really really needed as we cann't simply keep on accessing database resorce and increase potential danger to the database.
            //Having another shadow database or replica could be one of the option, but not a good option.

            //using ( var mock = AutoMock.GetLoose())
            //{
            //    mock.Mock<ProductController>()
            //        .Setup(x => x.Get<Product>("select ProductId, ProductName, Description, Price, convert(varchar(10),DateOfAdding,120) as DateOfAdding, PhotoFileName from dbo.Product"))
            //        .Returns(mainProduct());
            //}

        }

        [TearDown]
        public void TearDown()
        {
            //Disposing off the unwanted product object before running the next unit test. Not required in our case.

            //_product.Dispose();
            //_product = null;

        }
        #endregion

        #region ApiCollectionUnitTest
        [Test]
        public void Product_Load_ShouldLoadProduct()
        {
            //arrange
            var result = mainProduct();
            Mock<ProductController> objProduct = new Mock<ProductController>();

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost:62766/api/Product");
            
            httpRequestMessage.Content = new StringContent("result");

            var httpRouteDataMock = new Mock<ProductController>();

            objProduct.Setup(x => x.Get()).Returns(httpRequestMessage.CreateResponse);

            Assert.AreEqual(result, httpRequestMessage);

        }

        [Test]
        public void Product_AddNewProduct_ShouldAddNewProdcut()
        {
            var controller = new ProductController();
            var actual = controller.Post( new Product { ProductName = "Abc", Description = "SampleSampleSampleSampleSampleSampleSample", DateOfAdding = "2021-02-07", Price = 0, PhotoFileName = "anonymous.png" });
            var expected = "Added Successfully!!";
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Product_ChangeProduct_ShouldChangeGivenProdcut()
        {
            var controller = new ProductController();
            var actual = controller.Put(new Product { ProductName = "Abc", Description = "Kamplekample", DateOfAdding = "2027-02-07", Price = 100, PhotoFileName = "anonymous.png" });
            var expected = "Updated Successfully!!";
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Prodcut_Delete_ShouldDeleteProduct()
        {
            var controller = new ProductController();
            var actual = controller.Delete(7);
            var expected = "Deleted Successfully!!";
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Product_LoadName_ShouldLoadAllProductName()
        {
            var result = mainProduct();
            Mock<ProductController> objProduct = new Mock<ProductController>();

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost:62766/api/Product/GetAllProductNames");

            httpRequestMessage.Content = new StringContent("result");

            var httpRouteDataMock = new Mock<ProductController>();

            objProduct.Setup(x => x.Get()).Returns(httpRequestMessage.CreateResponse);

            Assert.AreEqual(result, httpRequestMessage);
        }

        [Ignore("Not required as of now")]
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
