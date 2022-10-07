using MicroServiciosV1.Productos.Controllers;
using MicroServiciosV1.Productos.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MicroServiciosV1.Productos.Tests
{
    [TestClass]
    public class ProductosTest
    {
        [TestMethod]
        public void GetAsyncReturnsOk()
        {
            var productosRepository = new ProductosRepository();
            var productosController = new ProductosController(productosRepository);

            var result = productosController.GetAsync("1").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAsyncReturnsNotFound()
        {
            var productosRepository = new ProductosRepository();
            var productosController = new ProductosController(productosRepository);

            var result = productosController.GetAsync("959").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
