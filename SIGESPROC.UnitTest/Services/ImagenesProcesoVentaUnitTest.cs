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
    public class ImagenesProcesoVentaUnitTest
    {
        private readonly ProcesoVentaService _procesoVentaService;
        private readonly IMapper _mapper;
        private Mock<ProcesoVentaImagenesRepository> MockImagenesProcesoVentaRepository { get; set; }

        public ImagenesProcesoVentaUnitTest()
        {
            MockImagenesProcesoVentaRepository = new Mock<ProcesoVentaImagenesRepository>();

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


            _procesoVentaService = new ProcesoVentaService(procesoVentaRepository, MockImagenesProcesoVentaRepository.Object);
        }
        protected Mock<IMapper> map = new Mock<IMapper>();


        [TestMethod]
        public void ImagenesProcesoVentaCrear()
        {
            try
            {
                // Configura el mock para que devuelva un resultado exitoso en la inserción
                MockImagenesProcesoVentaRepository.Setup(pl => pl.Insert(It.IsAny<tbImagenesPorProcesosVentas>()))
                    .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

                // Crea una lista con un solo objeto
                var listaImagenes = new List<tbImagenesPorProcesosVentas>
        {
            new tbImagenesPorProcesosVentas()
        };

                // Llama al método de servicio con la lista
                var result = _procesoVentaService.InsertarImagenesProcesoVenta(listaImagenes);

                // Aserciones
                Assert.IsInstanceOfType(result, typeof(ServiceResult));
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"El error: {ex.Message}");
            }
        }

        [TestMethod]
        public void ImagenesProcesoVentaEditar()
        {
            try
            {
                MockImagenesProcesoVentaRepository.Setup(pl => pl.Update(It.IsAny<tbImagenesPorProcesosVentas>()))
                    .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

                var result = _procesoVentaService.ActualizarImagenProcesoVenta(It.IsAny<tbImagenesPorProcesosVentas>());

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
