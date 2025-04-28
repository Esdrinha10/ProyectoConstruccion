using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.API.Extensions;
using SIGESPROC.BusinessLogic;
using SIGESPROC.BusinessLogic.Services.ServiceInsumo;
using SIGESPROC.DataAccess;
using SIGESPROC.DataAccess.Repositories.RepositoryInsumo;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.UnitTest.Services
{   [TestClass]
    class InsumoPorProveedorUnitTest
    {
        private readonly InsumoService _insumoService;
        private readonly IMapper _mapper;
        public Mock<InsumoPorProveedorRepository> MockInsumoPorProveedorRepository { get; private set; }

        public InsumoPorProveedorUnitTest()
        {
            MockInsumoPorProveedorRepository = new Mock<InsumoPorProveedorRepository>();

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
            var mockCotizacionRepository = new Mock<CotizacionRepository>().Object;
            var mockCotizacionDetalleRepository = new Mock<CotizacionDetalleRepository>().Object;
            var mockCotizacionPorDocumentoRepository = new Mock<CotizacionPorDocumentoRepository>().Object;
            var mockCompraEncabezadoRepository = new Mock<CompraEncabezadoRepository>().Object;
            var mockInsumoPorMedidaRepository = new Mock<InsumoPorMedidaRepository>().Object;
            var mockInsumoPorProveedorRepository = new Mock<InsumoPorProveedorRepository>().Object;
            var mockInsumoRepository = new Mock<InsumoRepository>().Object;
            var mockMaterialRepository = new Mock<MaterialRepository>().Object;
            var mockProveedorRepository = new Mock<ProveedorRepository>().Object;
            var mockBodegaRepository = new Mock<BodegaRepository>().Object;
            var mockBodegaPorInsumoRepository = new Mock<BodegaPorInsumoRepository>().Object;
            var mockMaquinariaRepository = new Mock<MaquinariaRepository>().Object;
            var mockMaquinariaPorProveedorRepository = new Mock<MaquinariaPorProveedorRepository>().Object;
            var mockSubCategoriaRepository = new Mock<SubCategoriaRepository>().Object;
            var mockCompraDetalleRepository = new Mock<CompraDetalleRepository>().Object;

            // Instanciación del InsumoService
            _insumoService = new InsumoService(
                mockCotizacionDetalleRepository,
                mockCotizacionRepository,
                mockInsumoPorMedidaRepository,
                mockInsumoPorProveedorRepository,
                mockInsumoRepository,
                mockMaterialRepository,
                mockProveedorRepository,
                mockBodegaRepository,
                mockBodegaPorInsumoRepository,
                mockCompraEncabezadoRepository,
                mockMaquinariaRepository,
                mockMaquinariaPorProveedorRepository,
                mockSubCategoriaRepository,
                mockCompraDetalleRepository,
                mockCotizacionPorDocumentoRepository
            );
        }

        protected Mock<IMapper> map = new Mock<IMapper>();

        [TestMethod]
        public void InsumoPorProveedorCrear()
        {
            try
            {
                MockInsumoPorProveedorRepository.Setup(pl => pl.Insert(It.IsAny<tbInsumosPorProveedores>()))
                    .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

                var result = _insumoService.InsertarInsumoPorProveedor(It.IsAny<tbInsumosPorProveedores>());

                Assert.IsInstanceOfType<ServiceResult>(result);
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"El error: {ex.Message}");
            }
        }

        [TestMethod]
        public void InsumoPorProveedorEditar()
        {
            try
            {
                MockInsumoPorProveedorRepository.Setup(pl => pl.Update(It.IsAny<tbInsumosPorProveedores>()))
                    .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

                var result = _insumoService.ActualizarInsumoPorProveedor(It.IsAny<tbInsumosPorProveedores>());

                Assert.IsInstanceOfType<ServiceResult>(result);
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }
    }
}
