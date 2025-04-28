using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.API.Extensions;
using SIGESPROC.BusinessLogic;
using SIGESPROC.BusinessLogic.Services.ServicePlanilla;
using SIGESPROC.DataAccess;
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
    public class FrecuenciaUnitTest
    {
        private readonly FrecuenciaService _frecuenciaService;
        private readonly IMapper _mapper;

        public Mock<FrecuenciaRepository> MockFrecuenciaRepository { get; private set; }

        public FrecuenciaUnitTest()
        {
            MockFrecuenciaRepository = new Mock<FrecuenciaRepository>();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfileExtensions());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _frecuenciaService = new FrecuenciaService(
                MockFrecuenciaRepository.Object
                );
        }

        protected Mock<IMapper> map = new Mock<IMapper>();

        [TestMethod]
        public void FrecuenciaInsertar()
        {
            MockFrecuenciaRepository.Setup(pl => pl.Insert(It.IsAny<tbFrecuencias>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _frecuenciaService.InsertarFrecuencia(It.IsAny<tbFrecuencias>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void FrecuenciaActualizar()
        {
            MockFrecuenciaRepository.Setup(pl => pl.Update(It.IsAny<tbFrecuencias>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _frecuenciaService.ActualizarFrecuencia(It.IsAny<tbFrecuencias>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);

        }
    }
}
