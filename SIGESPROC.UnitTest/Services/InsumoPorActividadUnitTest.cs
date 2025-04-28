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

namespace SIGESPROC.UnitTest.Services
{
    [TestClass]
    public class InsumoPorActividadUnitTest
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;
        public Mock<ProyectoRepository> MockProyectoRepository { get; private set; }


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



        public InsumoPorActividadUnitTest()
        {
            MockProyectoRepository = new Mock<ProyectoRepository>();

            // Crear los mocks necesarios
            MockDocumentoRepository = new Mock<DocumentoRepository>();
            MockEquipoSeguridadRepository = new Mock<EquipoSeguridadRepository>();
            MockEstadoProyectoRepository = new Mock<EstadoProyectoRepository>();
            MockEtapaRepository = new Mock<EtapaRepository>();
            MockIncidenteRepository = new Mock<IncidenteRepository>();
            MockNotificacionAlertaPorUsuarioRepository = new Mock<NotificacionAlertaPorUsuarioRepository>();
            MockEtapaPorProyectoRepository = new Mock<EtapaPorProyectoRepository>();
            MockGestionAdicionalRepository = new Mock<GestionAdicionalRepository>();
            MockGestionRiesgoRepository = new Mock<GestionRiesgoRepository>();
            MockImagenPorControlCalidadRepository = new Mock<ImagenPorControlCalidadRepository>();
            MockControlDeCalidadRepository = new Mock<ControlDeCalidadRepository>();
            MockControlDeCalidadPorActividadRepository = new Mock<ControlDeCalidadPorActividadRepository>();
            MockNotificacionRepository = new Mock<NotificacionRepository>();
            MockPagoRepository = new Mock<PagoRepository>();
            MockRetrasoRepository = new Mock<RetrasoRepository>();
            MockInsumoPorActividadRepository = new Mock<InsumoPorActividadRepository>();
            MockRentaMaquinariaPorActividadRepository = new Mock<RentaMaquinariaPorActividadRepository>();
            MockActividadPorEtapaRepository = new Mock<ActividadPorEtapaRepository>();
            MockArchivoAdjuntoRepository = new Mock<ArchivoAdjuntoRepository>();
            MockActividadRepository = new Mock<ActividadRepository>();
            MockAlertaRepository = new Mock<AlertaRepository>();
            MockPresupuestoEncabezadoRepository = new Mock<PresupuestoEncabezadoRepository>();
            MockPresupuestoDetalleRepository = new Mock<PresupuestoDetalleRepository>();
            MockPresupuestoPorTasaCambioRepository = new Mock<PresupuestoPorTasaCambioRepository>();
            MockinsumoPorActividadRepository = new Mock<InsumoPorActividadRepository>();
            MockrentaMaquinariaPorActividadRepository = new Mock<RentaMaquinariaPorActividadRepository>();
            MockEquipoSeguridadPorActividadRepository = new Mock<EquipoSeguridadPorActividadRepository>();
            MockReferenciasRepository = new Mock<ReferenciasRepository>();


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



            _proyectoService = new ProyectoService(
                MockDocumentoRepository.Object,
                MockEquipoSeguridadRepository.Object,
                MockEstadoProyectoRepository.Object,
                MockEtapaRepository.Object,
                MockIncidenteRepository.Object,
                MockNotificacionAlertaPorUsuarioRepository.Object,
                MockEtapaPorProyectoRepository.Object,
                MockGestionAdicionalRepository.Object,
                MockGestionRiesgoRepository.Object,
                MockImagenPorControlCalidadRepository.Object,
                MockControlDeCalidadRepository.Object,
                MockControlDeCalidadPorActividadRepository.Object,
                MockNotificacionRepository.Object,
                MockPagoRepository.Object,
                MockRetrasoRepository.Object,
                MockInsumoPorActividadRepository.Object,
                MockRentaMaquinariaPorActividadRepository.Object,
                MockActividadPorEtapaRepository.Object,
                MockArchivoAdjuntoRepository.Object,
                MockActividadRepository.Object,
                MockAlertaRepository.Object,
                MockPresupuestoEncabezadoRepository.Object,
                MockPresupuestoDetalleRepository.Object,
                MockPresupuestoPorTasaCambioRepository.Object,
                MockProyectoRepository.Object,
                MockinsumoPorActividadRepository.Object,
                MockrentaMaquinariaPorActividadRepository.Object,
                MockEquipoSeguridadPorActividadRepository.Object,
                MockReferenciasRepository.Object
                );
        }
        //protected Mock<IMapper> map = new Mock<IMapper>();


        [TestMethod]
        public void InsumoPorActividadCreate()
        {
            var modelo = new tbInsumosPorActividades()
            {
                inpa_Id = 1941,
                acet_Id = 675,
                inpa_stock = 9,
                inpa_PrecioCompra = 74,
                inpa_Desperdicio = 0,
                inpa_Rendimiento = 0,
                inpa_FormulaRendimiento = "N/A",
                inpa_StockFormula = "N/A",
                inpa_PrecioCompraFormula = "N/A",
                inpa_ActividadLlenado = 0,
                inpa_EsCompra = true,
                inpa_Fecha = DateTime.Now,
                inpp_Id = 194,
                usua_Creacion = 13,
                inpa_FechaCreacion = DateTime.Now,
                usua_Modificacion = 13,
                inpa_FechaModificacion = DateTime.Now,
                inpa_Estado = true,
                row = 0,
                insu_Descripcion = "string",
                unme_Nombre = "string",
                unme_Nomenclatura = "string",
                bopi_Stock = 0,
                mate_Descripcion = "string",
                prov_Descripcion = "string",
                suca_Descripcion = "string",
                cate_Descripcion = "string",
                inpp_Observacion = "string",
                inpp_Preciocompra = 0
            };

            MockInsumoPorActividadRepository.Setup(pr => pr.Insert(It.IsAny<tbInsumosPorActividades>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _proyectoService.InsertarInsumoPorActividad(modelo);

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void InsumoPorActividadUpdate()
        {
            var modelo = new tbInsumosPorActividades()
            {
                inpa_Id = 1941,
                acet_Id = 675,
                inpa_stock = 9,
                inpa_PrecioCompra = 74,
                inpa_Desperdicio = 0,
                inpa_Rendimiento = 0,
                inpa_FormulaRendimiento = "N/A",
                inpa_StockFormula = "N/A",
                inpa_PrecioCompraFormula = "N/A",
                inpa_ActividadLlenado = 0,
                inpa_EsCompra = true,
                inpa_Fecha = DateTime.Now,
                inpp_Id = 194,
                usua_Creacion = 13,
                inpa_FechaCreacion = DateTime.Now,
                usua_Modificacion = 13,
                inpa_FechaModificacion = DateTime.Now,
                inpa_Estado = true,
                row = 0,
                insu_Descripcion = "string",
                unme_Nombre = "string",
                unme_Nomenclatura = "string",
                bopi_Stock = 0,
                mate_Descripcion = "string",
                prov_Descripcion = "string",
                suca_Descripcion = "string",
                cate_Descripcion = "string",
                inpp_Observacion = "string",
                inpp_Preciocompra = 0
            };
            MockInsumoPorActividadRepository.Setup(pr => pr.Update(It.IsAny<tbInsumosPorActividades>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _proyectoService.ActualizarInsumoPorActividad(modelo);

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }
    }
}
