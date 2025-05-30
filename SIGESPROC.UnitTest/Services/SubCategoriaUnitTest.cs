﻿using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.API.Extensions;
using SIGESPROC.BusinessLogic;
using SIGESPROC.BusinessLogic.Services.ServiceInsumo;
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
    public class SubCategoriaUnitTest
    {
        private readonly InsumoService _insumoService;

        private readonly IMapper _mapper;
        private readonly Mock<SubCategoriaRepository> _maquinariaPorProveedorRepositoryMock;
        public Mock<SubCategoriaRepository> MockPlanillaRepositiry { get; private set; }

        public SubCategoriaUnitTest()
        {
            _maquinariaPorProveedorRepositoryMock = new Mock<SubCategoriaRepository>();
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfileExtensions());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            var maquinariaRepository = new MaquinariaRepository();
            var cotizacionDetalleRepository = new CotizacionDetalleRepository();
            var cotizacionRepository = new CotizacionRepository();
            var insumoPorMedidaRepository = new InsumoPorMedidaRepository();
            var insumoPorProveedorRepository = new InsumoPorProveedorRepository();
            var insumoRepository = new InsumoRepository();
            var materialRepository = new MaterialRepository();
            var proveedorRepository = new ProveedorRepository();
            var bodegaRepository = new BodegaRepository();
            var bodegaPorInsumoRepository = new BodegaPorInsumoRepository();
            var compraEncabezadoRepository = new CompraEncabezadoRepository();
            var maquinariaPorProveedorRepository = new MaquinariaPorProveedorRepository();
            var subCategoriaRepository = new SubCategoriaRepository();
            var compraDetalleRepository = new CompraDetalleRepository();
            var cotizacionPorDocumentoRepository = new CotizacionPorDocumentoRepository();


            _insumoService = new InsumoService(

                cotizacionDetalleRepository,
                cotizacionRepository,
                insumoPorMedidaRepository,
                insumoPorProveedorRepository,
                insumoRepository,
                materialRepository,
                proveedorRepository,
                bodegaRepository,
                bodegaPorInsumoRepository,
                compraEncabezadoRepository,
                maquinariaRepository,
                maquinariaPorProveedorRepository,
                subCategoriaRepository,
                compraDetalleRepository,
                cotizacionPorDocumentoRepository

                );
        }


        protected Mock<IMapper> map = new Mock<IMapper>();

        [TestMethod]
        public void MaterialCreate()
        {
            var data = new tbSubcategorias();
            var result = _insumoService.InsertarSubcategorias(data);

            Assert.IsInstanceOfType(result, typeof(ServiceResult));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MaterialUpdate()
        {
            var data = new tbSubcategorias();
            var result = _insumoService.ActualizarSubcategorias(data);

            Assert.IsInstanceOfType(result, typeof(ServiceResult));

            Assert.IsNotNull(result);
        }


    }
}
