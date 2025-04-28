using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.BusinessLogic;
using SIGESPROC.BusinessLogic.Services.ServiceProyecto;
using SIGESPROC.DataAccess;
using SIGESPROC.DataAccess.Repositories.RepositoryProyecto;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.UnitTest.Services
{
    [TestClass]
    public  class EtapapoProyectoUnitTest
    {
        private readonly ProyectoService _proyectoService;
        public Mock<EtapaPorProyectoRepository> MockEtapaPorProyectoRepository { get; private set; }
        public EtapapoProyectoUnitTest()
        {
            MockEtapaPorProyectoRepository = new Mock<EtapaPorProyectoRepository>();

            _proyectoService = new ProyectoService(
                new Mock<DocumentoRepository>().Object,
                new Mock<EquipoSeguridadRepository>().Object,
                new Mock<EstadoProyectoRepository>().Object,
                new Mock<EtapaRepository>().Object,
                new Mock<IncidenteRepository>().Object,
                new Mock<NotificacionAlertaPorUsuarioRepository>().Object,
                MockEtapaPorProyectoRepository.Object,
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
        public void EtapaPorProyectoCreateTest()
        {
            MockEtapaPorProyectoRepository.Setup(repo => repo.Insert(It.IsAny<tbEtapasPorProyectos>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Éxito" });

            var result = _proyectoService.InsertarEtapaPorProyecto(It.IsAny<tbEtapasPorProyectos>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EtapaPorProyectoUpdateTest()
        {
            MockEtapaPorProyectoRepository.Setup(repo => repo.Update(It.IsAny<tbEtapasPorProyectos>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Actualización Exitosa" });

            var result = _proyectoService.ActualizarEtapaPorProyecto(It.IsAny<tbEtapasPorProyectos>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }
    }
}
