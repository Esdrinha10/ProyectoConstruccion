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
    public class EmpleadoUnitTest
    {
        private readonly GeneralService _generalService;

        public Mock<EmpleadoRepository> MockEmpleadoRepository { get; private set; }

        public EmpleadoUnitTest()
        {
            MockEmpleadoRepository = new Mock<EmpleadoRepository>();

            _generalService = new GeneralService(
                new Mock<NivelRepository>().Object,
                new Mock<PaisRepository>().Object,
                new Mock<TasaCambioRepository>().Object,
                new Mock<TipoProyectoRepository>().Object,
                MockEmpleadoRepository.Object,
                new Mock<EstadoRepository>().Object,
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
        public void EmpleadoCreateTest()
        {
            MockEmpleadoRepository.Setup(repo => repo.Insert(It.IsAny<tbEmpleados>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Éxito" });

            var result = _generalService.InsertarEmpleado(It.IsAny<tbEmpleados>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EmpleadoUpdateTest()
        {
            MockEmpleadoRepository.Setup(repo => repo.Update(It.IsAny<tbEmpleados>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Actualización Exitosa" });

            var result = _generalService.ActualizarEmpleado(It.IsAny<tbEmpleados>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }
    }
}
