using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.BusinessLogic;
using SIGESPROC.BusinessLogic.Services.GeneralService;
using SIGESPROC.DataAccess;
using SIGESPROC.DataAccess.Repositories.RepositoryGeneral;
using SIGESPROC.Entities.Entities;
using System.Collections.Generic;

namespace SIGESPROC.UnitTest.Services
{
    [TestClass]
    public class ClienteUnitTest
    {
        private readonly GeneralService _generalService;

        public Mock<ClienteRepository> MockClienteRepository { get; private set; }

        public ClienteUnitTest()
        {
            MockClienteRepository = new Mock<ClienteRepository>();

            _generalService = new GeneralService(
                new Mock<NivelRepository>().Object,
                new Mock<PaisRepository>().Object,
                new Mock<TasaCambioRepository>().Object,
                new Mock<TipoProyectoRepository>().Object,
                new Mock<EmpleadoRepository>().Object,
                new Mock<EstadoRepository>().Object,
                new Mock<MonedaRepository>().Object,
                new Mock<EstadoCivilRepository>().Object,
                new Mock<CargoRepository>().Object,
                new Mock<UnidadMedidaRepository>().Object,
                new Mock<CategoriaRepository>().Object,
                new Mock<CiudadRepository>().Object,
                MockClienteRepository.Object,
                new Mock<ImpuestoRepository>().Object

            );
        }

        [TestMethod]
        public void ClienteCreateTest()
        {
            MockClienteRepository.Setup(repo => repo.Insert(It.IsAny<tbClientes>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Éxito" });

            var result = _generalService.InsertarClientes(It.IsAny<tbClientes>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ClienteUpdateTest()
        {
            MockClienteRepository.Setup(repo => repo.Update(It.IsAny<tbClientes>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Actualización Exitosa" });

            var result = _generalService.ActualizarClientes(It.IsAny<tbClientes>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }
    }
}
