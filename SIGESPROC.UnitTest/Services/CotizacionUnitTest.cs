using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.API.Extensions;
using SIGESPROC.BusinessLogic;
using SIGESPROC.BusinessLogic.Services.ServiceInsumo;
using SIGESPROC.Common.Models.ModelsInsumo;
using SIGESPROC.DataAccess;
using SIGESPROC.DataAccess.Repositories.RepositoryInsumo;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SIGESPROC.UnitTest.Services
{
    [TestClass]
    public class CotizacionUnitTest
    {
        private readonly InsumoService _insumoService;
        private readonly IMapper _mapper;
        public Mock<CotizacionRepository> MockCotizacionRepository { get; private set; }
        public Mock<CotizacionDetalleRepository> MockCotizacionDetalleRepository { get; private set; }

        public CotizacionUnitTest()
        {
            MockCotizacionRepository = new Mock<CotizacionRepository>();
            MockCotizacionDetalleRepository = new Mock<CotizacionDetalleRepository>();
            var mockCotizacionPorDocumentoRepository = new Mock<CotizacionPorDocumentoRepository>();
            var mockCompraEncabezadoRepository = new Mock<CompraEncabezadoRepository>();

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
                MockCotizacionDetalleRepository.Object,
                MockCotizacionRepository.Object,
                mockInsumoPorMedidaRepository,
                mockInsumoPorProveedorRepository,
                mockInsumoRepository,
                mockMaterialRepository,
                mockProveedorRepository,
                mockBodegaRepository,
                mockBodegaPorInsumoRepository,
                mockCompraEncabezadoRepository.Object,
                mockMaquinariaRepository,
                mockMaquinariaPorProveedorRepository,
                mockSubCategoriaRepository,
                mockCompraDetalleRepository,
                mockCotizacionPorDocumentoRepository.Object
            );
        }

        protected Mock<IMapper> map = new Mock<IMapper>();

        [TestMethod]
        public void ListarCotizaciones()
        {
            var modelo = new List<tbCotizaciones>() {
                new tbCotizaciones {coti_Id = 1, usua_Creacion = 3},
                new tbCotizaciones {coti_Id = 2, usua_Creacion =3},
                new tbCotizaciones {coti_Id = 3, usua_Creacion = 3}
            }.AsEnumerable();

            MockCotizacionRepository.Setup(pl => pl.List())
                .Returns(modelo);


            var result = _insumoService.ListarCotizacion();
            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void ListarCotizacionesDetalle()
        {
            var modelo = new List<tbCotizaciones>() {
                new tbCotizaciones {code_Id = 1, usua_Creacion = 3},
                new tbCotizaciones {code_Id = 2, usua_Creacion =3},
                new tbCotizaciones {code_Id = 3, usua_Creacion = 3}
            }.AsEnumerable();

            MockCotizacionRepository.Setup(pl => pl.List())
                .Returns(modelo);


            var result = _insumoService.ListarCotizacionDetalles();
            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void CotizacionCrear()
        {
            try
            {
                MockCotizacionRepository.Setup(pl => pl.Insert(It.IsAny<tbCotizaciones>()))
                    .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

                var result = _insumoService.InsertarCotizacion(new tbCotizaciones());

                Assert.IsInstanceOfType<ServiceResult>(result);
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"El error: {ex.Message}");
            }
        }

        [TestMethod]
        public void CotizacionEditar()
        {
            try
            {
                MockCotizacionDetalleRepository.Setup(pl => pl.Update(It.IsAny<tbCotizacionesDetalle>()))
                    .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

                var result = _insumoService.ActualizarCotizacionDetalle(It.IsAny<tbCotizacionesDetalle>());

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
