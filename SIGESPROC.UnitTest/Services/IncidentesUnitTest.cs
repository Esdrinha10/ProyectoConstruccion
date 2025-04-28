using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.BusinessLogic;
using SIGESPROC.BusinessLogic.Services.ServiceProyecto;
using SIGESPROC.DataAccess;
using SIGESPROC.DataAccess.Repositories.RepositoryProyecto;
using SIGESPROC.Entities.Entities;
using System.Collections.Generic;

namespace SIGESPROC.UnitTest.Services
{
    [TestClass]
    public class IncidenteUnitTest
    {
        private readonly ProyectoService _proyectoService;

        public Mock<IncidenteRepository> MockIncidenteRepository { get; private set; }

        public IncidenteUnitTest()
        {
            MockIncidenteRepository = new Mock<IncidenteRepository>();

            _proyectoService = new ProyectoService(
                new Mock<DocumentoRepository>().Object,
                new Mock<EquipoSeguridadRepository>().Object,
                new Mock<EstadoProyectoRepository>().Object,
                new Mock<EtapaRepository>().Object,
                MockIncidenteRepository.Object, 
                new Mock<NotificacionAlertaPorUsuarioRepository>().Object,
                new Mock<EtapaPorProyectoRepository>().Object,
                new Mock<GestionAdicionalRepository>().Object,
                new Mock<GestionRiesgoRepository>().Object,
                new Mock<ImagenPorControlCalidadRepository>().Object,
                new Mock<ControlDeCalidadRepository>().Object,
                new Mock<ControlDeCalidadPorActividadRepository>().Object,
                new Mock<NotificacionRepository>().Object,
                new Mock<PagoRepository>().Object,
                new Mock<RetrasoRepository>().Object,
                new Mock<InsumoPorActividadRepository>().Object,
                new Mock<RentaMaquinariaPorActividadRepository>().Object,
                new Mock<ActividadPorEtapaRepository>().Object,
                new Mock<ArchivoAdjuntoRepository>().Object,
                new Mock<ActividadRepository>().Object,
                new Mock<AlertaRepository>().Object,
                new Mock<PresupuestoEncabezadoRepository>().Object,
                new Mock<PresupuestoDetalleRepository>().Object,
                new Mock<PresupuestoPorTasaCambioRepository>().Object,
                new Mock<ProyectoRepository>().Object,
                new Mock<InsumoPorActividadRepository>().Object,
                new Mock<RentaMaquinariaPorActividadRepository>().Object,
                new Mock<EquipoSeguridadPorActividadRepository>().Object,
                new Mock<ReferenciasRepository>().Object
            );
        }

        [TestMethod]
        public void IncidenteCreateTest()
        {
            MockIncidenteRepository.Setup(repo => repo.Insert(It.IsAny<tbIncidentes>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Éxito" });

            var result = _proyectoService.InsertarIncidente(It.IsAny<tbIncidentes>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IncidenteUpdateTest()
        {
            MockIncidenteRepository.Setup(repo => repo.Update(It.IsAny<tbIncidentes>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Actualización Exitosa" });

            var result = _proyectoService.ActualizarIncidente(It.IsAny<tbIncidentes>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }
    }
}
