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
    public class EstadoCivilUnitTest
    {
        private readonly GeneralService _generalService;

        public Mock<EstadoCivilRepository> MockEstadoCivilRepository { get; private set; }

        public EstadoCivilUnitTest()
        {
            MockEstadoCivilRepository = new Mock<EstadoCivilRepository>();

            _generalService = new GeneralService(
                new Mock<NivelRepository>().Object,
                new Mock<PaisRepository>().Object,
                new Mock<TasaCambioRepository>().Object,
                new Mock<TipoProyectoRepository>().Object,
                new Mock<EmpleadoRepository>().Object,
                new Mock<EstadoRepository>().Object,
                new Mock<MonedaRepository>().Object,
                MockEstadoCivilRepository.Object,
                new Mock<CargoRepository>().Object,
                new Mock<UnidadMedidaRepository>().Object,
                new Mock<CategoriaRepository>().Object,
                new Mock<CiudadRepository>().Object,
                new Mock<ClienteRepository>().Object,
                new Mock<ImpuestoRepository>().Object

            );
        }

        [TestMethod]
        public void EstadoCivilCreateTest()
        {
            MockEstadoCivilRepository.Setup(repo => repo.Insert(It.IsAny<tbEstadosCiviles>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Éxito" });

            var result = _generalService.InsertarEstadoCivil(It.IsAny<tbEstadosCiviles>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EstadoCivilUpdateTest()
        {
            MockEstadoCivilRepository.Setup(repo => repo.Update(It.IsAny<tbEstadosCiviles>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Actualización Exitosa" });

            var result = _generalService.ActualizarEstadoCivil(It.IsAny<tbEstadosCiviles>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }
    }
}
