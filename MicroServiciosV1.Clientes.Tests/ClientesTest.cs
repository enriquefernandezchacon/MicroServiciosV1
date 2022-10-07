using MicroServiciosV1.Clientes.Controllers;
using MicroServiciosV1.Clientes.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MicroServiciosV1.Clientes.Tests
{
    [TestClass]
    public class ClientesTest
    {
        [TestMethod]
        public void GetAsyncReturnsOk()
        {
            var clientesRepository = new ClientesRepository();
            var clientesController = new ClientesController(clientesRepository);

            var result = clientesController.GetAsync("1").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAsyncReturnsNotFound()
        {
            var clientesRepository = new ClientesRepository();
            var clientesController = new ClientesController(clientesRepository);

            var result = clientesController.GetAsync("99").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
