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
    public class DocumentoUnitTest
    {
        private readonly ProyectoService _proyectoService;
        public Mock<DocumentoRepository> MockDocumentoRepository { get; private set; }
        public DocumentoUnitTest()
        {
            MockDocumentoRepository = new Mock<DocumentoRepository>();

            _proyectoService = new ProyectoService(
                MockDocumentoRepository.Object,
                new Mock<EquipoSeguridadRepository>().Object,
                new Mock<EstadoProyectoRepository>().Object,
                new Mock<EtapaRepository>().Object,
                new Mock<IncidenteRepository>().Object,
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
        public void DocumentoCreateTest()
        {
            MockDocumentoRepository.Setup(repo => repo.Insert(It.IsAny<tbDocumentos>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Éxito" });

            var result = _proyectoService.InsertarDocumento(It.IsAny<tbDocumentos>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DocumentoUpdateTest()
        {
            MockDocumentoRepository.Setup(repo => repo.Update(It.IsAny<tbDocumentos>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Actualización Exitosa" });

            var result = _proyectoService.ActualizarDocumento(It.IsAny<tbDocumentos>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }

    }
}
