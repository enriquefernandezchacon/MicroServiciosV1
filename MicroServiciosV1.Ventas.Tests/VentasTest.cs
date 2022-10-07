using MicroServiciosV1.Ventas.Controllers;
using MicroServiciosV1.Ventas.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MicroServiciosV1.Ventas.Tests
{
    [TestClass]
    public class VentasTest
    {
        [TestMethod]
        public void GetAsyncReturnsOk()
        {
            var ventasRepository = new VentasRepository();
            var ventasController = new VentasController(ventasRepository);

            var result = ventasController.GetAsync("1").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAsyncReturnsNotFound()
        {
            var ventasRepository = new VentasRepository();
            var ventasController = new VentasController(ventasRepository);

            var result = ventasController.GetAsync("99").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
