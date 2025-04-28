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
    public class PresupuestoUniTest
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        public Mock<PresupuestoEncabezadoRepository> MockPresupuestoEncabezadoRepository { get; private set; }

        public PresupuestoUniTest()
        {
            MockPresupuestoEncabezadoRepository = new Mock<PresupuestoEncabezadoRepository>();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfileExtensions());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;

                var documentorepository = new DocumentoRepository();
                var equiposeguridad = new EquipoSeguridadRepository();
                var estadoProyecto = new EstadoProyectoRepository();
                var etaparepository = new EtapaRepository();
                var etapaPorProyecto = new EtapaPorProyectoRepository();
                var gestionAdicional = new GestionAdicionalRepository();
                var gestionRiesgo = new GestionRiesgoRepository();
                var imagePorControlCalidad = new ImagenPorControlCalidadRepository();
                var controlCalidad = new ControlDeCalidadRepository();
                var controlCalidadPorCalidad = new ControlDeCalidadPorActividadRepository();
                var notificacionRepository = new NotificacionRepository();
                var pagoRepository = new PagoRepository();
                var retraroRepository = new RetrasoRepository();
                var incidenteRepository = new IncidenteRepository();
                var notificacionAletarPorUsuario = new NotificacionAlertaPorUsuarioRepository();
                var actividadPorEtapa = new ActividadPorEtapaRepository();
                var archivoAjunto = new ArchivoAdjuntoRepository();
                var actividadRepository = new ActividadRepository();
                var alertaRepository = new AlertaRepository();
                /*Aqui iria el repository de encabezado presupuesot*/
                var presupuestoDetalleRepository = new PresupuestoDetalleRepository();
                var insumoPorActividadRepository = new InsumoPorActividadRepository();
                var rentaMaquinariaPorActividadRepository = new RentaMaquinariaPorActividadRepository();
                var presupuestoTasaCambioRepository = new PresupuestoPorTasaCambioRepository();
                var proyectoRepository = new ProyectoRepository();
                var insumoPorActividad = new InsumoPorActividadRepository();
                var rentaMaquiariaPorActividad = new RentaMaquinariaPorActividadRepository();
                var equipoSeguridadPorActividad = new EquipoSeguridadPorActividadRepository();
                var referenciasRepository = new ReferenciasRepository();

                _proyectoService = new ProyectoService(
                    documentorepository,
                    equiposeguridad,
                    estadoProyecto,
                    etaparepository,
                    incidenteRepository,
                    notificacionAletarPorUsuario,
                    etapaPorProyecto,
                    gestionAdicional,
                    gestionRiesgo,
                    imagePorControlCalidad,
                    controlCalidad,
                    controlCalidadPorCalidad,
                    notificacionRepository,
                    pagoRepository,
                    retraroRepository,
                    insumoPorActividadRepository,
                    rentaMaquiariaPorActividad,
                    actividadPorEtapa,
                    archivoAjunto,
                    actividadRepository,
                    alertaRepository,
                    MockPresupuestoEncabezadoRepository.Object,
                    presupuestoDetalleRepository,
                    presupuestoTasaCambioRepository,
                    proyectoRepository,
                    insumoPorActividad,
                    rentaMaquiariaPorActividad,
                    equipoSeguridadPorActividad,
                    referenciasRepository
                    );
            }

        }

        protected Mock<IMapper> map = new Mock<IMapper>();

        [TestMethod]
        public void presupuestoCreate()
        {
            MockPresupuestoEncabezadoRepository.Setup(pr => pr.Insert(It.IsAny<tbPresupuestosEncabezado>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _proyectoService.InsertarPresupuestoEncabezado(It.IsAny<tbPresupuestosEncabezado>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void PresupuestoUpdate()
        {
            MockPresupuestoEncabezadoRepository.Setup(pr => pr.Update(It.IsAny<tbPresupuestosEncabezado>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _proyectoService.ActualizarPresupuestosEncabezado(It.IsAny<tbPresupuestosEncabezado>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void PresupuestoList()
        {
            var modelo = new List<tbPresupuestosEncabezado>() {
                new tbPresupuestosEncabezado {pren_Id = 1, empl_Id = 50, pren_Estado = "Aceptado"},
                new tbPresupuestosEncabezado {pren_Id = 5, empl_Id = 14, pren_Estado = "Aceptado"},
                new tbPresupuestosEncabezado {pren_Id = 9, empl_Id = 74, pren_Estado = "Rechazado"},
            }.AsEnumerable();

            MockPresupuestoEncabezadoRepository.Setup(pr => pr.List())
                .Returns(modelo);

            var result = _proyectoService.ListarPresupuestosEncabezado();

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }

    }
}
