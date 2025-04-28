using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.API.Extensions;
using SIGESPROC.BusinessLogic.Services.ServiceBienRaiz;
using SIGESPROC.Entities.Entities;
using SIGESPROC.DataAccess.Repositories.RepositoryBienRaiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGESPROC.BusinessLogic;
using SIGESPROC.DataAccess;

namespace SIGESPROC.UnitTest.Services
{
    [TestClass]
    public class TerrenosUnitTest
    {
        private readonly BienRaizService _bienRaizService;
        private readonly IMapper _mapper;
        public Mock<TerrenoRepository> MockTerrenoRepository { get; private set; }

        // Mocks adicionales necesarios para BienRaizService
        private Mock<AgenteBienesRaicesRepository> MockAgenteBienesRaicesRepository;
        private Mock<BienRaizRepository> MockBienRaizRepository;
        private Mock<DocumentoBienRaizRepository> MockDocumentoBienRaizRepository;
        private Mock<EmpresaBienRaizRepository> MockEmpresaBienRaizRepository;
        private Mock<ProyectoConstruccionBienRaizRepository> MockProyectoConstruccionBienRaizRepository;
        private Mock<TipoDocumentoRepository> MockTipoDocumentoRepository;
        private Mock<MantenimientoRepository> MockMantenimientoRepository;

        public TerrenosUnitTest()
        {
            // Crear los mocks necesarios
            MockTerrenoRepository = new Mock<TerrenoRepository>();
            MockAgenteBienesRaicesRepository = new Mock<AgenteBienesRaicesRepository>();
            MockBienRaizRepository = new Mock<BienRaizRepository>();
            MockDocumentoBienRaizRepository = new Mock<DocumentoBienRaizRepository>();
            MockEmpresaBienRaizRepository = new Mock<EmpresaBienRaizRepository>();
            MockProyectoConstruccionBienRaizRepository = new Mock<ProyectoConstruccionBienRaizRepository>();
            MockTipoDocumentoRepository = new Mock<TipoDocumentoRepository>();
            MockMantenimientoRepository = new Mock<MantenimientoRepository>();

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

            // Inicialización de BienRaizService con todos los mocks
            _bienRaizService = new BienRaizService(
                MockAgenteBienesRaicesRepository.Object,
                MockBienRaizRepository.Object,
                MockDocumentoBienRaizRepository.Object,
                MockEmpresaBienRaizRepository.Object,
                MockProyectoConstruccionBienRaizRepository.Object,
                MockTerrenoRepository.Object,
                MockTipoDocumentoRepository.Object,
                MockMantenimientoRepository.Object
            );
        }

        [TestMethod]
        public void TerrenosCrear()
        {
            var modelo = new tbTerrenos()
            {
                terr_Descripcion = "Terreno Nuevo",
                terr_Area = "50m2",
                terr_Estado = false,
                terr_PecioCompra = "10000",
                terr_LinkUbicacion = "ubicacion",
                terr_Imagen = "imagen",
                terr_Longitud = "-87.76156002428569",
                terr_Latitud = "11.762257447621977",
                usua_Creacion = 3,
                terr_FechaCreacion = DateTime.Now
            };

            MockTerrenoRepository.Setup(tr => tr.Insert(It.IsAny<tbTerrenos>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _bienRaizService.InsertarTerreno(modelo);

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TerrenosEditar()
        {
            var modelo = new tbTerrenos()
            {
                terr_Id = 1,
                terr_Descripcion = "Terreno Editado",
                terr_Area = "45m2",
                terr_Estado = true,
                terr_PecioCompra = "15000",
                terr_LinkUbicacion = "ubicacion_actualizada",
                terr_Imagen = "imagen_actualizada",
                terr_Longitud = "-87.76156002428569",
                terr_Latitud = "11.762257447621977",
                usua_Modificacion = 4,
                terr_FechaModificacion = DateTime.Now
            };

            MockTerrenoRepository.Setup(tr => tr.Update(It.IsAny<tbTerrenos>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Actualización Exitosa" });

            var result = _bienRaizService.ActualizarTerreno(modelo);

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TerrenosListar()
        {
            var listaTerrenos = new List<tbTerrenos>()
            {
                new tbTerrenos { terr_Id = 1, terr_Descripcion = "Terreno 1", terr_Area = "34m2" },
                new tbTerrenos { terr_Id = 2, terr_Descripcion = "Terreno 2", terr_Area = "50m2" }
            }.AsEnumerable();

            MockTerrenoRepository.Setup(tr => tr.List())
                .Returns(listaTerrenos);

            var result = _bienRaizService.ListarTerrenos();

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }
    }
}
