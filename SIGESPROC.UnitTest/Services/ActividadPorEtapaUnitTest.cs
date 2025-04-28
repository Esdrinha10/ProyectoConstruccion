using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.API.Extensions;
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
    public class ActividadPorEtapaUnitTest
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;
        public Mock<ActividadPorEtapaRepository> MockActividadPorEtapaRepository { get; private set; }

        public ActividadPorEtapaUnitTest()
        {
            MockActividadPorEtapaRepository = new Mock<ActividadPorEtapaRepository>();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfileExtensions());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _proyectoService = new ProyectoService(
                    new Mock<DocumentoRepository>().Object,
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
                    MockActividadPorEtapaRepository.Object,
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

        protected Mock<IMapper> map = new Mock<IMapper>();

        [TestMethod]
        public void ActividadPorEtapaCreate()
        {
            MockActividadPorEtapaRepository.Setup(repo => repo.Insert(It.IsAny<tbActividadesPorEtapas>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Éxito" });

            var result = _proyectoService.InsertarActividadPorEtapa(It.IsAny<tbActividadesPorEtapas>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ActividadPorEtapaActualizar()
        {
            MockActividadPorEtapaRepository.Setup(repo => repo.Update(It.IsAny<tbActividadesPorEtapas>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Éxito" });

            var result = _proyectoService.ActualizarActividadPorEtapa(It.IsAny<tbActividadesPorEtapas>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }
    }
}
