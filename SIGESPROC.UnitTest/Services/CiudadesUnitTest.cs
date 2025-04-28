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
    public class CiudadesUnitTest
    {
        private readonly GeneralService _generalService;

        public Mock<CiudadRepository> MockCiudadRepository { get; private set; }

        public CiudadesUnitTest()
        {
            MockCiudadRepository = new Mock<CiudadRepository>();

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
                MockCiudadRepository.Object,
                new Mock<ClienteRepository>().Object,
                new Mock<ImpuestoRepository>().Object

            );
        }

        [TestMethod]
        public void CiudadCreateTest()
        {
            MockCiudadRepository.Setup(repo => repo.Insert(It.IsAny<tbCiudades>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Éxito" });

            var result = _generalService.InsertarCiudades(It.IsAny<tbCiudades>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CiudadUpdateTest()
        {
            MockCiudadRepository.Setup(repo => repo.Update(It.IsAny<tbCiudades>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Actualización Exitosa" });

            var result = _generalService.ActualizarCiudades(It.IsAny<tbCiudades>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }
    }
}
