using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.API.Extensions;
using SIGESPROC.BusinessLogic;
using SIGESPROC.BusinessLogic.Services.ProcesosVentaService;
using SIGESPROC.BusinessLogic.Services.ServiceBienRaiz;
using SIGESPROC.DataAccess;
using SIGESPROC.DataAccess.Repositories.RepositoryBienRaiz;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.UnitTest.Services
{
    [TestClass]
    public class ProcesoVentaUnitTest
    {
        private readonly ProcesoVentaService _procesoVentaService;
        private readonly IMapper _mapper;
        private Mock<ProcesoVentaRepository> MockProcesoVentaRepository { get; set; }

        public ProcesoVentaUnitTest()
        {
            MockProcesoVentaRepository = new Mock<ProcesoVentaRepository>();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfileExtensions());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }


            var procesoVentaRepository = new ProcesoVentaRepository();
            var procesoVentaImagenesRepository = new ProcesoVentaImagenesRepository();


            _procesoVentaService = new ProcesoVentaService(MockProcesoVentaRepository.Object, procesoVentaImagenesRepository);
        }
        protected Mock<IMapper> map = new Mock<IMapper>();


        [TestMethod]
        public void ProcesoVentaCrear()
        {
            try
            {
                MockProcesoVentaRepository.Setup(pl => pl.Insert(It.IsAny<tbProcesosVentas>()))
                    .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

                var result = _procesoVentaService.InsertarProcesoVenta(new tbProcesosVentas());

                Assert.IsInstanceOfType<ServiceResult>(result);
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"El error: {ex.Message}");
            }
        }

        [TestMethod]
        public void ProcesoVentaEditar()
        {
            try
            {
                MockProcesoVentaRepository.Setup(pl => pl.Update(It.IsAny<tbProcesosVentas>()))
                    .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

                var result = _procesoVentaService.ActualizarProcesoVenta(It.IsAny<tbProcesosVentas>());

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
