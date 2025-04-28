using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.API.Extensions;
using SIGESPROC.BusinessLogic;
using SIGESPROC.BusinessLogic.Services.ProyectoService;
using SIGESPROC.BusinessLogic.Services.ServiceProyecto;
using SIGESPROC.Common.Models.ModelsProyecto;
using SIGESPROC.DataAccess;
using SIGESPROC.DataAccess.Repositories.RepositoryProyecto;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SIGESPROC.UnitTest.Services
{
    [TestClass]
    public class DiagramaGanttUnitTest
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;
        public Mock<ActividadPorEtapaRepository> MockActividadPorEtapaRepository { get; private set; }
        public Mock<EtapaPorProyectoRepository> MockEtapaPorProyectoRepository { get; private set; }

        public DiagramaGanttUnitTest()
        {
            MockActividadPorEtapaRepository = new Mock<ActividadPorEtapaRepository>();
            MockEtapaPorProyectoRepository = new Mock<EtapaPorProyectoRepository>();
            var mockEtapaPorProyectoRepositoryRepository = new Mock<EtapaPorProyectoRepository>();
            var mockActividadPorEtapaRepositoryRepository = new Mock<ActividadPorEtapaRepository>();

            // Configuración del mapper
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfileExtensions());
                });
                _mapper = mappingConfig.CreateMapper();
            }

            // Crear mocks para todos los repositorios necesarios
            var mockDocumentoRepository = new Mock<DocumentoRepository>().Object;
            var mockEquipoSeguridadRepository = new Mock<EquipoSeguridadRepository>().Object;
            var mockEstadoProyectoRepository = new Mock<EstadoProyectoRepository>().Object;
            var mockEtapaRepository = new Mock<EtapaRepository>().Object;
            var mockIncidenteRepository = new Mock<IncidenteRepository>().Object;
            var mockNotificacionAlertaPorUsuarioRepository = new Mock<NotificacionAlertaPorUsuarioRepository>().Object;
            var mockEtapaPorProyectoRepository = new Mock<EtapaPorProyectoRepository>().Object;
            var mockGestionAdicionalRepository = new Mock<GestionAdicionalRepository>().Object;
            var mockGestionRiesgoRepository = new Mock<GestionRiesgoRepository>().Object;
            var mockImagenPorControlCalidadRepository = new Mock<ImagenPorControlCalidadRepository>().Object;
            var mockControlDeCalidadRepository = new Mock<ControlDeCalidadRepository>().Object;
            var mockControlDeCalidadPorActividadRepository = new Mock<ControlDeCalidadPorActividadRepository>().Object;
            var mockNotificacionRepository = new Mock<NotificacionRepository>().Object;
            var mockPagoRepository = new Mock<PagoRepository>().Object;
            var mockRetrasoRepository = new Mock<RetrasoRepository>().Object;
            var mockInsumoPorActividadRepository = new Mock<InsumoPorActividadRepository>().Object;
            var mockRentaMaquinariaPorActividadRepository = new Mock<RentaMaquinariaPorActividadRepository>().Object;
            var mockActividadPorEtapaRepository = new Mock<ActividadPorEtapaRepository>().Object;
            var mockArchivoAdjuntoRepository = new Mock<ArchivoAdjuntoRepository>().Object;
            var mockActividadRepository = new Mock<ActividadRepository>().Object;
            var mockAlertaRepository = new Mock<AlertaRepository>().Object;
            var mockPresupuestoEncabezadoRepository = new Mock<PresupuestoEncabezadoRepository>().Object;
            var mockPresupuestoDetalleRepository = new Mock<PresupuestoDetalleRepository>().Object;
            var mockPresupuestoPorTasaCambioRepository = new Mock<PresupuestoPorTasaCambioRepository>().Object;
            var mockProyectoRepository = new Mock<ProyectoRepository>().Object;
            var mockEquipoSeguridadPorActividadRepository = new Mock<EquipoSeguridadPorActividadRepository>().Object;
            var mockReferenciasRepository = new Mock<ReferenciasRepository>().Object;

            // Instanciación del Proyectos
            _proyectoService = new ProyectoService(
               mockDocumentoRepository,
               mockEquipoSeguridadRepository,
               mockEstadoProyectoRepository,
               mockEtapaRepository,
               mockIncidenteRepository,
               mockNotificacionAlertaPorUsuarioRepository,
               MockEtapaPorProyectoRepository.Object,
               mockGestionAdicionalRepository,
               mockGestionRiesgoRepository,
               mockImagenPorControlCalidadRepository,
               mockControlDeCalidadRepository,
               mockControlDeCalidadPorActividadRepository,
               mockNotificacionRepository,
               mockPagoRepository,
               mockRetrasoRepository, 
               mockInsumoPorActividadRepository,
               mockRentaMaquinariaPorActividadRepository,
               MockActividadPorEtapaRepository.Object,
               mockArchivoAdjuntoRepository,
               mockActividadRepository ,
               mockAlertaRepository,
               mockPresupuestoEncabezadoRepository,
               mockPresupuestoDetalleRepository,
               mockPresupuestoPorTasaCambioRepository,
               mockProyectoRepository,
               mockInsumoPorActividadRepository,
               mockRentaMaquinariaPorActividadRepository,
               mockEquipoSeguridadPorActividadRepository,
               mockReferenciasRepository
            );
        }

        protected Mock<IMapper> map = new Mock<IMapper>();

        [TestMethod]
        public void EtapasPorProyectoListar()
        {
            var modelo = new List<tbEtapasPorProyectos>() {
                new tbEtapasPorProyectos {etpr_Id = 1, usua_Creacion = 3},
                new tbEtapasPorProyectos {etpr_Id = 1, usua_Creacion = 3},
                new tbEtapasPorProyectos {etpr_Id = 1, usua_Creacion = 3},
            }.AsEnumerable();

            MockEtapaPorProyectoRepository.Setup(pl => pl.Listar(3))
                .Returns(modelo);

            var result = _proyectoService.ListarEtapasPorProyectos(3);

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ActividadesPorEtapaListar()
        {
            var modelo = new List<tbActividadesPorEtapas>() {
                new tbActividadesPorEtapas {etap_Id = 1, usua_Creacion = 3},
                new tbActividadesPorEtapas {etap_Id = 1, usua_Creacion = 3},
                new tbActividadesPorEtapas {etap_Id = 1, usua_Creacion = 3},
            }.AsEnumerable();

            MockActividadPorEtapaRepository.Setup(pl => pl.List(3))
                .Returns(modelo);

            var result = _proyectoService.ListarActividadesPorEtapa(3);

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }

    }
}
