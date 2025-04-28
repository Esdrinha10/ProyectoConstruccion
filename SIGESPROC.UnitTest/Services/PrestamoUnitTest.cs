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
    public class PrestamoUnitTest
    {
        private readonly PrestamoService _prestamoService;
        private readonly IMapper _mapper;

        public Mock<PrestamoRepository> MockPrestamoRepository { get; private set; }

        public PrestamoUnitTest()
        {
            MockPrestamoRepository = new Mock<PrestamoRepository>();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfileExtensions());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _prestamoService = new PrestamoService(
                MockPrestamoRepository.Object
                );
        }

        protected Mock<IMapper> map = new Mock<IMapper>();

        [TestMethod]
        public void PrestamoInsertar()
        {
            MockPrestamoRepository.Setup(pl => pl.Insert(It.IsAny<tbPrestamos>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _prestamoService.InsertarPrestamo(It.IsAny<tbPrestamos>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void PrestamoActualizar()
        {
            MockPrestamoRepository.Setup(pl => pl.Update(It.IsAny<tbPrestamos>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _prestamoService.ActualizarPrestamo(It.IsAny<tbPrestamos>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);

        }
    }
}
