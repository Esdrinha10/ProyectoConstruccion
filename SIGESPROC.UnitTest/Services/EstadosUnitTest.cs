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
    public class EstadosUnitTest
    {
        private readonly GeneralService _generalService;

        public Mock<EstadoRepository> MockEstadoRepository { get; private set; }

        public EstadosUnitTest()
        {
            MockEstadoRepository = new Mock<EstadoRepository>();

            _generalService = new GeneralService(
                new Mock<NivelRepository>().Object,
                new Mock<PaisRepository>().Object,
                new Mock<TasaCambioRepository>().Object,
                new Mock<TipoProyectoRepository>().Object,
                new Mock<EmpleadoRepository>().Object,
                MockEstadoRepository.Object,
                new Mock<MonedaRepository>().Object,
                new Mock<EstadoCivilRepository>().Object,
                new Mock<CargoRepository>().Object,
                new Mock<UnidadMedidaRepository>().Object,
                new Mock<CategoriaRepository>().Object,
                new Mock<CiudadRepository>().Object,
                new Mock<ClienteRepository>().Object,
                new Mock<ImpuestoRepository>().Object

            );
        }

        [TestMethod]
        public void EstadoCreateTest()
        {
            MockEstadoRepository.Setup(repo => repo.Insert(It.IsAny<tbEstados>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Éxito" });

            var result = _generalService.InsertarEstado(It.IsAny<tbEstados>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EstadoUpdateTest()
        {
            MockEstadoRepository.Setup(repo => repo.Update(It.IsAny<tbEstados>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Actualización Exitosa" });

            var result = _generalService.ActualizarEstado(It.IsAny<tbEstados>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }
    }
}
