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
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.UnitTest.Services
{
    [TestClass]
    public class CompraUnitTest
    {
        private readonly InsumoService _insumoService;
        private readonly IMapper _mapper;
        public Mock<CompraEncabezadoRepository> MockCompraEncabezadoRepository { get; private set; }
        public Mock<CompraDetalleRepository> MockCompraDetalleRepository { get; private set; }

        public CompraUnitTest()
        {
            MockCompraEncabezadoRepository = new Mock<CompraEncabezadoRepository>();
            MockCompraDetalleRepository = new Mock<CompraDetalleRepository>();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfileExtensions());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            var CompraEncabezadoRepository = new CompraEncabezadoRepository();
            var CotizacionDetalleRepository = new CotizacionDetalleRepository();
            var CotizacionRepository = new CotizacionRepository();
            var InsumoPorMedidaRepository = new InsumoPorMedidaRepository();
            var InsumoPorProveedorRepository = new InsumoPorProveedorRepository();

            var InsumoRepository = new InsumoRepository();
            var MaterialRepository = new MaterialRepository();
            var ProveedorRepository = new ProveedorRepository();
            var BodegaRepository = new BodegaRepository();
            var BodegaPorInsumoRepository = new BodegaPorInsumoRepository();

            var MaquinariaRepository = new MaquinariaRepository();
            var MaquinariaPorProveedorRepository = new MaquinariaPorProveedorRepository();
            var SubCategoriaRepository = new SubCategoriaRepository();
            var CompraDetalleRepository = new CompraDetalleRepository();
            var CotizacionPorDocumentoRepository = new CotizacionPorDocumentoRepository();



            _insumoService = new InsumoService(
               CotizacionDetalleRepository,
               CotizacionRepository,
               InsumoPorMedidaRepository,
               InsumoPorProveedorRepository,

               InsumoRepository,
               MaterialRepository,
               ProveedorRepository,
               BodegaRepository,
               BodegaPorInsumoRepository,
               MockCompraEncabezadoRepository.Object,

               MaquinariaRepository,
               MaquinariaPorProveedorRepository,
               SubCategoriaRepository,
               MockCompraDetalleRepository.Object,
               CotizacionPorDocumentoRepository
                );

        }
        protected Mock<IMapper> map = new Mock<IMapper>();

        [TestMethod]
        public void CompraEncabezadoCreate()
        {

            MockCompraEncabezadoRepository.Setup(pl => pl.Insert(It.IsAny<tbComprasEncabezado>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _insumoService.InsertarCompraEncabezado(It.IsAny<tbComprasEncabezado>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CompraDetalleCreate()
        {

            MockCompraDetalleRepository.Setup(pl => pl.Insert(It.IsAny<tbComprasDetalle>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _insumoService.InsertarCompraDetalle(It.IsAny<tbComprasDetalle>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CompraDetalleUpdate()
        {

            MockCompraDetalleRepository.Setup(pl => pl.Update(It.IsAny<tbComprasDetalle>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _insumoService.ActualizarCompraDetalle(It.IsAny<tbComprasDetalle>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }


    }
}
