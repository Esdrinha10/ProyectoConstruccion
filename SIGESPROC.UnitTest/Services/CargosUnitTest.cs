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
    public class CargoUnitTest
    {
        private readonly GeneralService _generalService;

        public Mock<CargoRepository> MockCargoRepository { get; private set; }

        public CargoUnitTest()
        {
            MockCargoRepository = new Mock<CargoRepository>();

            _generalService = new GeneralService(
                new Mock<NivelRepository>().Object,
                new Mock<PaisRepository>().Object,
                new Mock<TasaCambioRepository>().Object,
                new Mock<TipoProyectoRepository>().Object,
                new Mock<EmpleadoRepository>().Object,
                new Mock<EstadoRepository>().Object,
                new Mock<MonedaRepository>().Object,
                new Mock<EstadoCivilRepository>().Object,
                MockCargoRepository.Object,
                new Mock<UnidadMedidaRepository>().Object,
                new Mock<CategoriaRepository>().Object,
                new Mock<CiudadRepository>().Object,
                new Mock<ClienteRepository>().Object,
                new Mock<ImpuestoRepository>().Object
               
            );
        }

        [TestMethod]
        public void CargoCreateTest()
        {
            MockCargoRepository.Setup(repo => repo.Insert(It.IsAny<tbCargos>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Éxito" });

            var result = _generalService.InsertarCargo(It.IsAny<tbCargos>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CargoUpdateTest()
        {
            MockCargoRepository.Setup(repo => repo.Update(It.IsAny<tbCargos>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Actualización Exitosa" });

            var result = _generalService.ActualizarCargo(It.IsAny<tbCargos>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }
    }
}
