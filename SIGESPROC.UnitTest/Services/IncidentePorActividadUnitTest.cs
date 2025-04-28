using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.API.Extensions;
using SIGESPROC.BusinessLogic;
using SIGESPROC.BusinessLogic.Services.ProyectoService;
using SIGESPROC.BusinessLogic.Services.ServiceProyecto;
using SIGESPROC.DataAccess;
using SIGESPROC.DataAccess.Repositories.RepositoryProyecto;
using SIGESPROC.Entities.Entities;
using System;

namespace SIGESPROC.UnitTest.Services
{
    [TestClass]
    public class IncidentePorActividadUnitTest
    {
        private readonly IncidentePorActividadService _incidentePorActividadService;
        private readonly IMapper _mapper;
        public Mock<IncidentePorActividadRepository> MockIncidentePorActividadRepository { get; private set; }


        // Mocks adicionales necesarios para BienRaizService
        private Mock<DocumentoRepository> MockDocumentoRepository;
        private Mock<EquipoSeguridadRepository> MockEquipoSeguridadRepository;
        private Mock<EstadoProyectoRepository> MockEstadoProyectoRepository;
        private Mock<EtapaRepository> MockEtapaRepository;
        private Mock<IncidenteRepository> MockIncidenteRepository;
        private Mock<NotificacionAlertaPorUsuarioRepository> MockNotificacionAlertaPorUsuarioRepository;
        private Mock<EtapaPorProyectoRepository> MockEtapaPorProyectoRepository;
        private Mock<GestionAdicionalRepository> MockGestionAdicionalRepository;
        private Mock<GestionRiesgoRepository> MockGestionRiesgoRepository;
        private Mock<ImagenPorControlCalidadRepository> MockImagenPorControlCalidadRepository;
        private Mock<ControlDeCalidadRepository> MockControlDeCalidadRepository;
        private Mock<ControlDeCalidadPorActividadRepository> MockControlDeCalidadPorActividadRepository;
        private Mock<NotificacionRepository> MockNotificacionRepository;
        private Mock<PagoRepository> MockPagoRepository;
        private Mock<RetrasoRepository> MockRetrasoRepository;
        private Mock<InsumoPorActividadRepository> MockInsumoPorActividadRepository;
        private Mock<RentaMaquinariaPorActividadRepository> MockRentaMaquinariaPorActividadRepository;
        private Mock<ActividadPorEtapaRepository> MockActividadPorEtapaRepository;
        private Mock<ArchivoAdjuntoRepository> MockArchivoAdjuntoRepository;
        private Mock<ActividadRepository> MockActividadRepository;
        private Mock<AlertaRepository> MockAlertaRepository;
        private Mock<PresupuestoEncabezadoRepository> MockPresupuestoEncabezadoRepository;
        private Mock<PresupuestoDetalleRepository> MockPresupuestoDetalleRepository;
        private Mock<PresupuestoPorTasaCambioRepository> MockPresupuestoPorTasaCambioRepository;
        private Mock<InsumoPorActividadRepository> MockinsumoPorActividadRepository;
        private Mock<RentaMaquinariaPorActividadRepository> MockrentaMaquinariaPorActividadRepository;
        private Mock<EquipoSeguridadPorActividadRepository> MockEquipoSeguridadPorActividadRepository;
        private Mock<ReferenciasRepository> MockReferenciasRepository;



        public IncidentePorActividadUnitTest()
        {
            MockIncidentePorActividadRepository = new Mock<IncidentePorActividadRepository>();

            // Crear los mocks necesarios
            //MockDocumentoRepository = new Mock<DocumentoRepository>();
            //MockEquipoSeguridadRepository = new Mock<EquipoSeguridadRepository>();
            //MockEstadoProyectoRepository = new Mock<EstadoProyectoRepository>();
            //MockEtapaRepository = new Mock<EtapaRepository>();
            //MockIncidenteRepository = new Mock<IncidenteRepository>();
            //MockNotificacionAlertaPorUsuarioRepository = new Mock<NotificacionAlertaPorUsuarioRepository>();
            //MockEtapaPorProyectoRepository = new Mock<EtapaPorProyectoRepository>();
            //MockGestionAdicionalRepository = new Mock<GestionAdicionalRepository>();
            //MockGestionRiesgoRepository = new Mock<GestionRiesgoRepository>();
            //MockImagenPorControlCalidadRepository = new Mock<ImagenPorControlCalidadRepository>();
            //MockControlDeCalidadRepository = new Mock<ControlDeCalidadRepository>();
            //MockControlDeCalidadPorActividadRepository = new Mock<ControlDeCalidadPorActividadRepository>();
            //MockNotificacionRepository = new Mock<NotificacionRepository>();
            //MockPagoRepository = new Mock<PagoRepository>();
            //MockRetrasoRepository = new Mock<RetrasoRepository>();
            //MockInsumoPorActividadRepository = new Mock<InsumoPorActividadRepository>();
            //MockRentaMaquinariaPorActividadRepository = new Mock<RentaMaquinariaPorActividadRepository>();
            //MockActividadPorEtapaRepository = new Mock<ActividadPorEtapaRepository>();
            //MockArchivoAdjuntoRepository = new Mock<ArchivoAdjuntoRepository>();
            //MockActividadRepository = new Mock<ActividadRepository>();
            //MockAlertaRepository = new Mock<AlertaRepository>();
            //MockPresupuestoEncabezadoRepository = new Mock<PresupuestoEncabezadoRepository>();
            //MockPresupuestoDetalleRepository = new Mock<PresupuestoDetalleRepository>();
            //MockPresupuestoPorTasaCambioRepository = new Mock<PresupuestoPorTasaCambioRepository>();
            //MockinsumoPorActividadRepository = new Mock<InsumoPorActividadRepository>();
            //MockrentaMaquinariaPorActividadRepository = new Mock<RentaMaquinariaPorActividadRepository>();
            //MockEquipoSeguridadPorActividadRepository = new Mock<EquipoSeguridadPorActividadRepository>();
            //MockReferenciasRepository = new Mock<ReferenciasRepository>();
            //MockIncidentePorActividadRepository = new Mock<IncidentePorActividadRepository>();


            // Configuración de AutoMapper
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfileExtensions());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }



            _incidentePorActividadService = new IncidentePorActividadService(
                    MockIncidentePorActividadRepository.Object
                );
        }
        //protected Mock<IMapper> map = new Mock<IMapper>();


        [TestMethod]
        public void IncidentePorActividadCreate()
        {
            var modelo = new tbIncidenciasPorActividades()
            {
                inac_Id = 0,
                acet_Id = 1,
                inci_Id = 1,
                usua_Creacion = 3,
                inac_FechaCreacion = DateTime.Now,
                usua_Modificacion = 3,
                inac_FechaModificacion = DateTime.Now,
                inac_Estado = true
            };

            MockIncidentePorActividadRepository.Setup(pr => pr.Insert(It.IsAny<tbIncidenciasPorActividades>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _incidentePorActividadService.InsertarIncidentePorActividad(modelo);

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void InsumoPorActividadUpdate()
        {
            var modelo = new tbIncidenciasPorActividades()
            {
                inac_Id = 3,
                acet_Id = 1,
                inci_Id = 1,
                usua_Creacion = 3,
                inac_FechaCreacion = DateTime.Now,
                usua_Modificacion = 3,
                inac_FechaModificacion = DateTime.Now,
                inac_Estado = true
            };
            MockIncidentePorActividadRepository.Setup(pr => pr.Update(It.IsAny<tbIncidenciasPorActividades>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _incidentePorActividadService.ActualizarIncidentePorActividad(modelo);

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }
    }
}
