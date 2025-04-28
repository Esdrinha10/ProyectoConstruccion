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
    public class DeduccionUnitTest
    {
        private readonly DeduccionService _deduccionService;
        private readonly IMapper _mapper;

        public Mock<DeduccionRepository> MockDeduccionRepository { get; private set; }

        public DeduccionUnitTest()
        {
            MockDeduccionRepository = new Mock<DeduccionRepository>();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfileExtensions());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _deduccionService = new DeduccionService(
                MockDeduccionRepository.Object
                );
        }

        protected Mock<IMapper> map = new Mock<IMapper>();


        [TestMethod]
        public void DeduccionInsertar()
        {
            MockDeduccionRepository.Setup(pl => pl.Insert(It.IsAny<tbDeducciones>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _deduccionService.InsertarDeduccion(It.IsAny<tbDeducciones>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void DeduccionActualizar()
        {
            MockDeduccionRepository.Setup(pl => pl.Update(It.IsAny<tbDeducciones>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _deduccionService.ActualizarDeduccion(It.IsAny<tbDeducciones>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);

        }
    }
}
