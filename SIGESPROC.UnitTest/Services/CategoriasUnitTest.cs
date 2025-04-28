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
    public class CategoriaUnitTest
    {
        private readonly GeneralService _generalService;

        public Mock<CategoriaRepository> MockCategoriaRepository { get; private set; }

        public CategoriaUnitTest()
        {
            MockCategoriaRepository = new Mock<CategoriaRepository>();

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
                MockCategoriaRepository.Object,
                new Mock<CiudadRepository>().Object,
                new Mock<ClienteRepository>().Object,
                new Mock<ImpuestoRepository>().Object

            );
        }

        [TestMethod]
        public void CategoriaCreateTest()
        {
            MockCategoriaRepository.Setup(repo => repo.Insert(It.IsAny<tbCategorias>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Éxito" });

            var result = _generalService.InsertarCategoria(It.IsAny<tbCategorias>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CategoriaUpdateTest()
        {
            MockCategoriaRepository.Setup(repo => repo.Update(It.IsAny<tbCategorias>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Actualización Exitosa" });

            var result = _generalService.ActualizarCategoria(It.IsAny<tbCategorias>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }
    }
}
