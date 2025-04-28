using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.BusinessLogic;
using SIGESPROC.BusinessLogic.Services.ImagenPorIncidenteService;
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
    public class ImagenporIncidenteUnitTest
    {
        private readonly ImagenPorIncidenteService _imagenPorIncidenteService;

        public Mock<ImagenPorIncidenteRepository> MockImagenPorIncidenteRepository { get; private set; }

        public ImagenporIncidenteUnitTest()
        {
            MockImagenPorIncidenteRepository = new Mock<ImagenPorIncidenteRepository>();

            _imagenPorIncidenteService = new ImagenPorIncidenteService(

                MockImagenPorIncidenteRepository.Object
             
            );
        }

        [TestMethod]
        public void ImagenPorIncidenteCreateTest()
        {
            MockImagenPorIncidenteRepository.Setup(repo => repo.Insert(It.IsAny<tbImagenesPorIncidencias>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Éxito" });

            var result = _imagenPorIncidenteService.InsertarImagenPorIncidente(It.IsAny<tbImagenesPorIncidencias>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ImagenPorIncidenteUpdateTest()
        {
            MockImagenPorIncidenteRepository.Setup(repo => repo.Update(It.IsAny<tbImagenesPorIncidencias>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Actualización Exitosa" });

            var result = _imagenPorIncidenteService.ActualizarImagenPorIncidente(It.IsAny<tbImagenesPorIncidencias>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }
    }
}
