using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.API.Extensions;
using SIGESPROC.BusinessLogic;
using SIGESPROC.BusinessLogic.Services.ServicePlanilla;
using SIGESPROC.Common.Models.ModelsPlanilla;
using SIGESPROC.DataAccess.Repositories.RepositoryPlanilla;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.UnitTest.Services
{
    [TestClass]
    public class ViaticosUnitTest
    {
        private readonly ViaticoEncabezadoService _viaticoEncabezadoService;
        private readonly ViaticoDetalleService _viaticoDetalleService;
        private readonly IMapper _mapper;
        private readonly Mock<ViaticoEncabezadoRepository> _viaticoEncabezadoRepositoryMock;
        public Mock<ViaticoEncabezadoRepository> MockPlanillaRepositiry { get; private set; }

        public ViaticosUnitTest()
        {
            _viaticoEncabezadoRepositoryMock = new Mock<ViaticoEncabezadoRepository>();
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfileExtensions());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }


            var deduccionRepository = new ViaticoDetEncRepository();
            var viatdetrr = new ViaticoDetalleRepository();
            var categoriaViaticoRepository = new ViaticoEncabezadoRepository();


            _viaticoDetalleService = new ViaticoDetalleService(
                viatdetrr
                );
            _viaticoEncabezadoService = new ViaticoEncabezadoService(
                categoriaViaticoRepository,
               deduccionRepository

                );
        }
        protected Mock<IMapper> map = new Mock<IMapper>();


        [TestMethod]
        public void ViaticoEmcabezadoListar()
        {
            var modelo = new List<tbViaticosEncabezados>()
            {
                new tbViaticosEncabezados
                {
                    vien_Id = 1,
                    vien_Estado = false,
                    usua_Creacion = 3,
                    vien_MontoEstimado = 1000,
                    vien_FechaEmicion = DateTime.Now.AddDays(-10),
                    vien_TotalGastado = 500,
                    vien_TotalReconocido = 500,
                    Proy_Id = 101,
                    empl_Id = 2001
                },
                new tbViaticosEncabezados
                {
                    vien_Id = 2,
                    vien_Estado = true,
                    usua_Creacion = 4,
                    vien_MontoEstimado = 1500,
                    vien_FechaEmicion = DateTime.Now.AddDays(-20),
                    vien_TotalGastado = 1500,
                    vien_TotalReconocido = 1400,
                    Proy_Id = 102,
                    empl_Id = 2002
                },
                new tbViaticosEncabezados
                {
                    vien_Id = 3,
                    vien_Estado = false,
                    usua_Creacion = 7,
                    vien_MontoEstimado = 800,
                    vien_FechaEmicion = DateTime.Now.AddDays(-15),
                    vien_TotalGastado = 600,
                    vien_TotalReconocido = 600,
                    Proy_Id = 103,
                    empl_Id = 2003
                }
            }.AsEnumerable();

            _viaticoEncabezadoRepositoryMock.Setup(repo => repo.ListR(It.IsAny<int>()))
         .Returns(modelo);

            var result = _viaticoEncabezadoService.ListarViaticosEncabezados(3);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ServiceResult));
        }

        [TestMethod]
        public void ViaticoDetalleListar()
        {

            var result = _viaticoDetalleService.ListarViaticosDetalles();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ServiceResult));
        }

        [TestMethod]
        public void ViaticoEmcabezadoCreate()
        {
            var data = new tbViaticosEncabezados();
            var result = _viaticoEncabezadoService.InsertarViaticoEncabezado(data);

            Assert.IsInstanceOfType(result, typeof(ServiceResult));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ViaticoDetalleCreate()
        {
            var data = new tbViaticosDetalles();
            var result = _viaticoDetalleService.InsertarViaticoDetalle(data);

            Assert.IsInstanceOfType(result, typeof(ServiceResult));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ViaticoEmcabezadoUpdate()
        {
            //int id = 0;
            var data = new tbViaticosEncabezados();
            var result = _viaticoEncabezadoService.ActualizarViaticoEncabezado(data);

            Assert.IsInstanceOfType(result, typeof(ServiceResult));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ViaticoDetalleUpdate()
        {

            var data = new tbViaticosDetalles();
            var result = _viaticoDetalleService.ActualizarViaticoDetalle(data);

                       Assert.IsInstanceOfType(result, typeof(ServiceResult));

            Assert.IsNotNull(result);
        }
    }
}
